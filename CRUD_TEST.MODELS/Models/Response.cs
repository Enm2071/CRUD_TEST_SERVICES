using System.Collections.Generic;

namespace CRUD_TEST.MODELS.Models
{
    public class Response<T>
    {
        public string Action { get; set; }
        public bool Succeed { get; set; }
        public List<T> Body { get; set; } = new List<T>();
        public Error Error { get; set; }
    }
}
