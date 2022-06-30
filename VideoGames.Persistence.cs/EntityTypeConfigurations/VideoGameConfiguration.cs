using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VideoGames.Domain;

namespace VideoGames.Persistence.EntityTypeConfigurations
{
    public class VideoGameConfiguration : IEntityTypeConfiguration<VideoGame>
    {
        public void Configure(EntityTypeBuilder<VideoGame> builder)
        {
            builder.HasKey(videoGame => videoGame.Id);
            builder.HasIndex(videoGame => videoGame.Id).IsUnique();

            builder.Property(videoGame => videoGame.Name).IsRequired();

            builder.Property(videoGame => videoGame.ReleaseDate).IsRequired();

            builder.Property(videoGame => videoGame.Rating).IsRequired();
        }
    }
}
