
namespace CinemaApp.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    public class HomeController : Controller
    {
        public HomeController()
        {

        }

        public IActionResult Index()
        {
            // Two ways of transmitting data from Controller to View    
            // 1. Using ViewData/ViewBag
            // 2. Pass ViewModel to the View
            ViewData["Title"] = "Home Page";
            ViewData["Message"] = "Welcome to the Cinema Web App!";
            return View();
        }

    }
}
