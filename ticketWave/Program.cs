using Microsoft.EntityFrameworkCore;
using ticketWave.Data;
using ticketWave.Data.Cart;
using ticketWave.Data.Services;

namespace ticketWave
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<AppDbContext>(option =>
            {
                option.UseSqlServer(builder.Configuration.GetConnectionString("ticketWave"));
            });

            // Services Configration
            builder.Services.AddScoped<IActorsService, ActorsService>();
            builder.Services.AddScoped<IProducersService, ProducersService>();
            builder.Services.AddScoped<ICinemasService, CinemasService>();
            builder.Services.AddScoped<IMoviesService, MoviesService>();
            builder.Services.AddScoped<IOrdersService, OrdersService>();

            builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            builder.Services.AddScoped(sc => ShoppingCart.GetShoppingCart(sc));
            builder.Services.AddSession();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseSession();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            //Seed database
            AppDbInitializer.Seed(app);

            app.Run();
        }
    }
}