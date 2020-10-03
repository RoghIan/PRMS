using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Infrastructure.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<ActivityLog> ActivityLogs { get; set; }
        public DbSet<Title> Titles { get; set; }
        public DbSet<Report> Reports { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<PublisherTitle> PublisherTitles { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {

            base.OnModelCreating(builder);

            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            /*builder.Entity<PublisherTitle>()
                .HasKey(sc => new { sc.PublisherId, sc.TitleId });

            builder.Entity<PublisherTitle>()
                .HasOne(p => p.Publisher)
                .WithMany(at => at.PublisherTitles)
                .HasForeignKey(at => at.PublisherId);

            builder.Entity<PublisherTitle>()
                .HasOne(at => at.Title)
                .WithMany(at => at.PublisherTitles)
                .HasForeignKey(at => at.TitleId);*/

            /*            builder.Entity<Publisher>()
                            .HasOne(au => au.Status)
                            .WithMany(au => au.Publishers)
                            .HasForeignKey(au => au.StatusId);

                        builder.Entity<Publisher>()
                            .HasOne(p => p.Group)
                            .WithMany(au => au.Publishers)
                            .HasForeignKey(au => au.GroupId);*/

            /*            builder.Entity<Report>()
                            .HasOne(s => s.Publisher)
                            .WithMany(g => g.Reports)
                            .HasForeignKey(s => s.PublisherId);
            */
        }
    }
}
