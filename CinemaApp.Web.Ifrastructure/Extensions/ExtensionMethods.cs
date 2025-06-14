﻿using CinemaApp.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CinemaApp.Web.Infrastructure.Extensions
{
    public static class ExtensionMethods
    {
        public static IApplicationBuilder ApplyMigrations(this IApplicationBuilder app)
        {
            using IServiceScope serviceScope = app.ApplicationServices.CreateScope();

            CinemaDbContext dbContext = serviceScope.ServiceProvider.GetService<CinemaDbContext>()!;
            dbContext.Database.Migrate();

            return app;
        }
    }
}
