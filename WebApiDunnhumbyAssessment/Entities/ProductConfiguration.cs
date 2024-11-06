using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace WebApiDunnhumbyAssessment.Entities
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products");
            builder.HasKey(t => t.Id);

            builder.HasIndex(t => t.Category).HasDatabaseName("UX_Product_Category");
        }
    }
}
