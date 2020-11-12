using System.Collections.Generic;
using CRUD_TEST.MODELS.Dtos;

namespace CRUD_TEST.MODELS.Models
{
    public class Response
    {
        public string Action { get; set; }
        public bool Succeed { get; set; }
        public List<PermissionDto> Permission { get; set; } = new List<PermissionDto>();
        public Error Error { get; set; }
    }
}
