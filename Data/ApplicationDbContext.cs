using hotelcourseworkV2.Configuration;
using hotelcourseworkV2.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace hotelcourseworkV2.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            //Database.EnsureCreated();
        }

        public DbSet<Composition> compositions { get; set; }
        public DbSet<Dish> dishes { get; set; }
        public DbSet<Guest> guests { get; set; }
        public DbSet<Hotel> hotels { get; set; }
        public DbSet<HotelRoom> hotelRooms { get; set; }
        public DbSet<Ingredient> ingredients { get; set; }
        public DbSet<Menu> menus { get; set; }
        public DbSet<ReserveRoom> reserves { get; set; }
        public DbSet<ServicesReserve> servicesReserves { get; set; }
        public DbSet<TypeRoom> typeRooms { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfiguration(new TypeRoomConfiguration());
            builder.ApplyConfiguration(new ServicesConfiguration());
            builder.ApplyConfiguration(new RoleConfiguration());
            builder.Entity<IdentityUser>().ToTable("user");
            builder.Entity<IdentityRole>().ToTable("role");
            builder.Entity<IdentityUserRole<string>>().ToTable("user_role");
        }

        public DbSet<hotelcourseworkV2.Models.Services>? Services { get; set; }

    }
}