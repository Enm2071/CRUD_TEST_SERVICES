namespace CRUD_TEST.MODELS.Dtos
{
    public class PermissionDto
    {
        public int Id { get; set; }
        public string EmployeeName { get; set; }
        public string EmployeeLastName { get; set; }
        public PermissionTypeDto PermissionType { get; set; }
    }
}
