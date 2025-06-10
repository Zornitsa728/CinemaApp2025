using CinemaApp.Data;
using CinemaApp.Data.Models;
using CinemaApp.Web.ViewModels.Watchlist;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static CinemaApp.Common.ApplicationConstants;

namespace CinemaApp.Web.Controllers
{
    [Authorize]
    public class WatchlistController : BaseController
    {
        private readonly CinemaDbContext dbContext;
        private readonly UserManager<ApplicationUser> userManager;

        public WatchlistController(CinemaDbContext dbContext, UserManager<ApplicationUser> userManager)
        {
            this.dbContext = dbContext;
            this.userManager = userManager;
        }


        [HttpGet]
        public async Task<IActionResult> Index()
        {
            string userId = this.userManager.GetUserId(User)!; // Get the current user's ID

            IEnumerable<ApplicationUserWatchlistViewModel> watchlist = await this.dbContext
                .UsersMovies
                .Include(um => um.Movie)
                .Where(um => um.ApplicationUserId.ToString().ToLower() == userId.ToLower())
                .Select(um => new ApplicationUserWatchlistViewModel
                {
                    MovieId = um.MovieId.ToString(),
                    Title = um.Movie.Title,
                    Genre = um.Movie.Genre,
                    ReleaseDate = um.Movie.ReleaseDate.ToString(ReleaseDateFormat),
                    ImageUrl = um.Movie.ImageUrl
                })
                .ToListAsync();

            return View(watchlist);
        }

        [HttpPost]
        public async Task<IActionResult> AddToWatchlist(string movieId)
        {
            Guid userGuid = Guid.Parse(this.userManager.GetUserId(User)!); // Get the current user's ID
            Guid movieGuid = Guid.Empty;

            if (!IsGuidValid(movieId, ref movieGuid))
            {
                return RedirectToAction("Index", "Movie");
            }

            Movie? movie = await this.dbContext.Movies.FirstOrDefaultAsync(m => m.Id == movieGuid);

            if (movie == null)
            {
                return RedirectToAction("Index", "Movie");
            }

            var userMovie = await this.dbContext.UsersMovies
                .FirstOrDefaultAsync(um => um.ApplicationUserId == userGuid && um.MovieId == movieGuid);

            if (userMovie != null)
            {
                return BadRequest("Movie is already in your watchlist.");
            }

            ApplicationUserMovie newUserMovie = new ApplicationUserMovie
            {
                ApplicationUserId = userGuid,
                MovieId = movieGuid
            };

            await this.dbContext.UsersMovies.AddAsync(newUserMovie);
            await this.dbContext.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> RemoveFromWatchlist(string movieId)
        {
            Guid userGuid = Guid.Parse(userManager.GetUserId(User)!);

            Guid movieGuid = Guid.Empty;
            if (!IsGuidValid(movieId, ref movieGuid))
            {
                return RedirectToAction("Index", "Movie");
            }

            ApplicationUserMovie? userMovie = await this.dbContext.UsersMovies
                .FirstOrDefaultAsync(um => um.ApplicationUserId == userGuid && um.MovieId == movieGuid);

            if (userMovie != null)
            {
                this.dbContext.UsersMovies.Remove(userMovie);
                await this.dbContext.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
