using AgentieImobiliarWeb.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace AgentieImobiliarWeb.Data
{
    public class EstateContext : IdentityDbContext<IdentityUser>
    {
        public EstateContext(DbContextOptions<EstateContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IdentityUserLogin<string>>()
                .HasKey(l => new { l.UserId });

            modelBuilder.Entity<IdentityUserToken<string>>()
                .HasKey(t => new { t.UserId });

            modelBuilder.Entity<IdentityUserRole<string>>()
                .HasKey(r => new { r.UserId });

            modelBuilder.Entity<Estate>()
                .HasOne(e => e.EstateType)
                .WithMany(t => t.Estates)
                .HasForeignKey(e => e.EstateTypeId);
            modelBuilder.Entity<Estate>()
                .HasOne(e => e.Status)
                .WithMany(t => t.Estates)
                .HasForeignKey(e => e.StatusId);
            /*modelBuilder.Entity<ListEstate>()
				.HasOne<Customer>(l => l.Customer)
				.WithMany(u => u.ListEstates)
				.HasForeignKey(e => e.CustomerId);
            modelBuilder.Entity<ListEstate>()
				.HasOne<Estate>(l => l.Estate)
				.WithMany(u => u.ListEstates)
				.HasForeignKey(e => e.EstateId);*/
            modelBuilder.Entity<Announcement>()
                .HasOne(a => a.EstateType)
                .WithMany(u => u.Announcements)
                .HasForeignKey(e => e.EstateTypeId);
            modelBuilder.Entity<Announcement>()
               .HasOne(a => a.Status)
               .WithMany(u => u.Announcements)
               .HasForeignKey(e => e.StatusId);
			/* modelBuilder.Entity<Announcement>()
                 .HasOne<Customer>(u => u.Customer)
                 .WithMany(u => u.Announcements)
                 .HasForeignKey(e => e.CustomerId);
             modelBuilder.Entity<RequestEstate>()
                 .HasOne<Customer>(l => l.Customer)
                 .WithMany(u => u.RequestEstates)
                 .HasForeignKey(e => e.CustomerId);*/
			modelBuilder.Entity<Visualization>()
                .HasOne(l => l.Estate)
                .WithMany(u => u.Visualizations)
                .HasForeignKey(e => e.EstateId);
           /* modelBuilder.Entity<Visualization>()
				.HasOne<Customer>(l => l.Customer)
				.WithMany(u => u.Visualizations)
				.HasForeignKey(e => e.CustomerId);*/
        }
        public DbSet<Announcement> Announcements { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Estate> Estates { get; set; }
        public DbSet<EstateType> EstateTypes { get; set; }
        //public DbSet<ListEstate> ListEstates { get; set; }
        public DbSet<RequestEstate> RequestEstates { get; set; }
        public DbSet<Status> Status { get; set; }
        //public DbSet<Customer> Customers { get; set; }
        public DbSet<Visualization> Visualizations { get; set; }

    }

}
