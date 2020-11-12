using System;

namespace CRUD_TEST.MODELS.Models
{
    public class Permission
    {
        public int Id { get; set; }
        public string EmployeeName { get; set; }
        public string EmployeeLastName { get; set; }
        public DateTime Date { get; set; }
        public int PermissionTypeId { get; set; }
        public PermissionType PermissionType { get; set; }
    }
}
