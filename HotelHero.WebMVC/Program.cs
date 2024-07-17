using HotelHero.WebMVC.Interface;
using HotelHero.WebMVC.Services;
namespace HotelHero.WebMVC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddTransient<ILogInService, LogInService>();
            builder.Services.AddSingleton<IHotelService, HotelService>();
            builder.Services.AddSingleton<IReservationService, ReservationService>();
            builder.Services.AddSingleton<ICustomerDataService, CustomerDataService>();
            builder.Services.AddSingleton<IFileOperationService, FileOperationService>();
            builder.Services.AddSingleton<IPaymentService, PaymentService>();

            // Add services to the container.
            builder.Services.AddControllersWithViews()
                .AddRazorRuntimeCompilation();

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

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Search}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
