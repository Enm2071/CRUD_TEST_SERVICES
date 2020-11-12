using System;

namespace CRUD_TEST.MODELS.Models
{
    public class PermissionLog
    {
        public int Id { get; set; }
        public string Action { get; set; }
        public string EmployeeName { get; set; }
        public string EmployeeLastName { get; set; }
        public DateTime Date { get; set; }
        public int PermissionTypeId { get; set; }
    }
}
