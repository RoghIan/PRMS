using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Config
{
    public class PublisherTitleConfiguration : IEntityTypeConfiguration<PublisherTitle>
    {
        public void Configure(EntityTypeBuilder<PublisherTitle> builder)
        {
            builder.HasKey(sc => new { sc.PublisherId, sc.TitleId });

            builder.HasOne(at => at.Title)
                .WithMany(at => at.PublisherTitles)
                .HasForeignKey(at => at.TitleId);

            builder
                .HasOne(p => p.Publisher)
                .WithMany(at => at.PublisherTitles)
                .HasForeignKey(at => at.PublisherId);
        }
    }
}
