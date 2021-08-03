using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Config
{
    // public class PublisherTitleConfiguration : IEntityTypeConfiguration<AppointedPublisher>
    // {
    //     public void Configure(EntityTypeBuilder<AppointedPublisher> builder)
    //     {
    //         builder.HasKey(sc => new { sc.PublisherId, TitleId = sc.AppointedId });
    //
    //         builder.HasOne(at => at.Title)
    //             .WithMany(at => at.AppointedPublishers)
    //             .HasForeignKey(at => at.AppointedId);
    //
    //         builder
    //             .HasOne(p => p.Publisher)
    //             .WithMany(at => at.PublisherTitles)
    //             .HasForeignKey(at => at.PublisherId);
    //     }
    // }
}
