using LibraryFinalProject.IRepository;
using LibraryFinalProject.Models;
using LibraryFinalProject.Models.DbContext;
using LibraryFinalProject.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Principal;

namespace LibraryFinalProject
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<ApplicationDbContext>(OptionBuilder =>
            {
                OptionBuilder.UseSqlServer(builder.Configuration.GetConnectionString("cs"));
            });
            builder.Services.AddScoped<IBookRepo, BookRepo>();
            builder.Services.AddScoped<IMemberRepo, MemberRepo>();
            builder.Services.AddScoped<ILibrarianRepo, LibrarianRepo>();
            builder.Services.AddScoped<ICheckoutsRepo, CheckoutsRepo>();
            builder.Services.AddScoped<IReturnRepo, ReturnRepo>();
            builder.Services.AddScoped<IPenaltyRepo, PenaltyRepo>();
            builder.Services.AddScoped<IMemberRepo, MemberRepo>();

            builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
               .AddEntityFrameworkStores<ApplicationDbContext>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Book}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
