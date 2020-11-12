using CRUD_TEST.MODELS.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CRUD_TEST.DATA.Configurations
{
    public class PermissionConfiguration : IEntityTypeConfiguration<Permission>
    {
        public void Configure(EntityTypeBuilder<Permission> builder)
        {
            builder.Property(p => p.EmployeeName).IsRequired();
            builder.Property(p => p.EmployeeLastName).IsRequired();
            builder.Property(p => p.Date).IsRequired();
        }
    }
}
