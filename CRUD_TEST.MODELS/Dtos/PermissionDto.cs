using System.ComponentModel.DataAnnotations;

namespace CRUD_TEST.MODELS.Dtos
{
    public class PermissionDto
    {
        public int Id { get; set; }
        [Required]
        public string EmployeeName { get; set; }
        [Required]
        public string EmployeeLastName { get; set; }
        [Required]
        public PermissionTypeDto PermissionType { get; set; }
    }
}
