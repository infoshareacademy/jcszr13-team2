using AutoMapper;
using HotelHero.Database.Context;
using HotelHero.Database.Entities;
using HotelHero.Database.Repositiories.Hotels;
using HotelHero.Database.Repositiories.Reservations;
using HotelHero.WebMVC.Configuration;
using HotelHero.WebMVC.Interface;
using HotelHero.WebMVC.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
namespace HotelHero.WebMVC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<HotelHeroDbContext>(options => options.UseSqlServer("Server=localhost;Database=HotelHero;Trusted_Connection=True;TrustServerCertificate=True"));


            builder.Services.AddIdentity<HotelUserDTO, IdentityRole>().AddEntityFrameworkStores<HotelHeroDbContext>().AddDefaultTokenProviders();

            builder.Services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireDigit = true;
                options.Password.RequiredLength = 6;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = true;
                options.Password.RequireLowercase = false;
                options.SignIn.RequireConfirmedEmail = false;

                //options.SignIn.RequireConfirmedAccount = false;
            });

            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });

            IMapper mapper = mapperConfig.CreateMapper();

            mapper.ConfigurationProvider.AssertConfigurationIsValid();

            builder.Services.AddSingleton(mapper);


            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddTransient<ILogInService, LogInService>(); //Zmieniæ na transient
            builder.Services.AddTransient<IHotelService, HotelService>();
            builder.Services.AddTransient<IReservationService, ReservationService>();
            builder.Services.AddTransient<ICustomerDataService, CustomerDataService>();
            builder.Services.AddTransient<IFileOperationService, FileOperationService>();
            builder.Services.AddTransient<IPaymentService, PaymentService>();
            builder.Services.AddTransient<IAdminService, AdminService>();

            builder.Services.AddTransient<IHotelRepository, HotelRepository>();
            builder.Services.AddTransient<IReservationRepository, ReservationRepository>();

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
