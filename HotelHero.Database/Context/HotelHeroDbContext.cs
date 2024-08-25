using HotelHero.Database.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelHero.Database.Context
{
    public class HotelHeroDbContext : IdentityDbContext<HotelUserDTO>
    {
        public HotelHeroDbContext(DbContextOptions<HotelHeroDbContext> options) : base(options)
        {
            
        }
        //public DbSet<AdditionalService> Services { get; set; }
        public DbSet<CustomerDataDTO> CustomerDatas { get; set; }
        //public DbSet<CustomerDataHotel> CustomerDataHotels { get; set; }
        public DbSet<HotelDTO> Hotels { get; set; }
        //public DbSet<HotelUser> HotelUsers { get; set; }
        //public DbSet<Payment> Payments { get; set; }
        //public DbSet<PaymentAdditionalService> PaymentAdditionalServices { get; set; }
        //public DbSet<Reservation> Reservations { get; set; }

    }
}
