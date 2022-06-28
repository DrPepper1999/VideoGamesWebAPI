using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VideoGames.Domain;

namespace VideoGames.Persistence.EntityTypeConfigurations
{
    public class DeveloperStudioConfiguration : IEntityTypeConfiguration<DeveloperStudio>
    {
        public void Configure(EntityTypeBuilder<DeveloperStudio> builder)
        {
            builder.HasKey(developerStudio => developerStudio.Id);
            builder.HasIndex(developerStudio => developerStudio.Id).IsUnique();

            builder.Property(developerStudio => developerStudio.Name).IsRequired();
        }
    }
}
