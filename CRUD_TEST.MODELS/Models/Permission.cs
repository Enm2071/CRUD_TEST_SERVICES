using System;

namespace CRUD_TEST.MODELS.Models
{
    public class Permission
    {
        public int Id { get; set; }
        public string NombreEmpleado { get; set; }
        public string ApellidoEmpleado { get; set; }
        public int TipoPermisoId { get; set; }
        public DateTime Fecha { get; set; }
        public PermissionType PermissionType { get; set; }
    }
}
