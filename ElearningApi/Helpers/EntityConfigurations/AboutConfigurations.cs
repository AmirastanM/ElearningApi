using ElearningApi.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace ElearningApi.Helpers.EntityConfigurations
{
    public class AboutConfiguration : IEntityTypeConfiguration<About>
    {


        public void Configure(EntityTypeBuilder<About> builder)
        {
            builder.Property(e => e.Title).IsRequired().HasMaxLength(100);
            builder.Property(e => e.Description).IsRequired().HasMaxLength(100);
            builder.Property(e => e.Image).IsRequired();
        }
    }
}
