using Mango.Services.CouponAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace Mango.Services.CouponAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Coupon> Coupons { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure the Coupon entity
            modelBuilder.Entity<Coupon>().HasData(new Coupon
            {
                CouponId = 1,
                CouponCode = "MANGO10",
                DiscountAmount = 10.0,
                MinimumAmount = 50
            },
                new Coupon
                {
                    CouponId = 2,
                    CouponCode = "MANGO20",
                    DiscountAmount = 20.0,
                    MinimumAmount = 100
                }
            );
        }


    }
}
