using System.ComponentModel.DataAnnotations;

namespace CRUD_TEST.MODELS.Dtos
{
    public class PermissionTypeDto
    {
        public int Id { get; set; }
        [Required]
        public string Description { get; set; }
    }
}
