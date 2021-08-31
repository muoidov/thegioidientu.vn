using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SolutionShop.Data.Entities;

namespace SolutionShop.Data.EF
{
    public class Commentconfiguration : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.ToTable("Comments");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Contents).IsRequired(true);
            builder.Property(x => x.Name).IsRequired(true);
        }
    }
}