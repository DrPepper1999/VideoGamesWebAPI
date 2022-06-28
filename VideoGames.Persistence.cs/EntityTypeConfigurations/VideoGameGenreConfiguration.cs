using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VideoGames.Domain;

namespace VideoGames.Persistence.EntityTypeConfigurations
{
    public class VideoGameGenreConfiguration : IEntityTypeConfiguration<VideoGameGenre>
    {
        public void Configure(EntityTypeBuilder<VideoGameGenre> builder)
        {
            builder.HasKey(videoGameGenre => videoGameGenre.Id);
            builder.HasIndex(videoGameGenre => videoGameGenre.Id).IsUnique();

            builder.Property(videoGameGenre => videoGameGenre.Name).IsRequired();
        }
    }
}
