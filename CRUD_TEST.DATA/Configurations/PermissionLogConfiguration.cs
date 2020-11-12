using CRUD_TEST.MODELS.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CRUD_TEST.DATA.Configurations
{
    public class PermissionLogConfiguration : IEntityTypeConfiguration<PermissionLog>
    {
        public void Configure(EntityTypeBuilder<PermissionLog> builder)
        {
            builder.Property(pl => pl.EmployeeLastName).IsRequired();
            builder.Property(pl => pl.EmployeeName).IsRequired();
            builder.Property(pl => pl.PermissionTypeId).IsRequired();
            builder.Property(pl => pl.Date).IsRequired();
        }
    }
}
