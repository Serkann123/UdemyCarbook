using Microsoft.EntityFrameworkCore;
using UdemyCarbook.Domain.Entities;

namespace UdemyCarbook.Persistence.Context
{
    public class CarbookContext : DbContext
    {
        public CarbookContext(DbContextOptions<CarbookContext> options) : base(options)
        {

        }

        #region DbSets
        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<AppRole> AppRoles { get; set; }
        public DbSet<About> Abouts { get; set; }
        public DbSet<Banner> Banners { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<CarDescription> CarDescriptions { get; set; }
        public DbSet<CarFeature> CarFeatures { get; set; }
        public DbSet<CarPricing> CarPricings { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Feature> Features { get; set; }
        public DbSet<FooterAddress> FooterAddresses { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Piricing> Piricings { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<SocialMedia> SocialMedias { get; set; }
        public DbSet<Testimonial> Testimonials { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<TagCloud> TagClouds { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<RendACar> RendACars { get; set; }
        public DbSet<RendACarProcess> RendACarProcesses { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Review> Reviews { get; set; }
        #endregion
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Reservation>()
               .HasOne(x => x.PickUpLocation)
               .WithMany(x => x.PickUpReservations)
               .HasForeignKey(x => x.PickUpLocationId)
               .OnDelete(DeleteBehavior.ClientSetNull);

            modelBuilder.Entity<Reservation>()
                .HasOne(x => x.DropOffLocation)
                .WithMany(x => x.DropOffReservations)
                .HasForeignKey(x => x.DropOffLocationId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
}