using CRUD_TEST.MODELS.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CRUD_TEST.DATA.Configurations
{
    public class PermissiontypeConfiguration : IEntityTypeConfiguration<PermissionType>
    {
        public void Configure(EntityTypeBuilder<PermissionType> builder)
        {
            builder.Property(tp => tp.Descripcion).IsRequired();
        }
    }
}
