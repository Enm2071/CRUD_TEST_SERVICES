using CRUD_TEST.MODELS.Dtos;
using CRUD_TEST.MODELS.Models;
using CRUD_TEST.SERVICES.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace CRUD_TEST.Controllers.API
{
    [Route("api/permission")]
    [EnableCors]
    [ApiController]
    public class PermissionController : ControllerBase
    {

        private readonly IPermissionServices _permissionServices;

        public PermissionController(IPermissionServices permissionServices)
        {
            _permissionServices = permissionServices;
        }


        [HttpGet("all")]
        public Response All()
        {
            var response = _permissionServices.SelectAll();
            return response;
        }

        [HttpPost("create")]
        public Response Create(PermissionDto data)
        {
            var response = _permissionServices.Create(data);
            return response;
        }

        [HttpPost("edit/{id}")]
        public Response Edit(PermissionDto data,int id)
        {
            var response = _permissionServices.Edit(data,id);
            return response;
        }

        [HttpPost("delete/{id}")]
        public Response Delete(int id)
        {
            var response = _permissionServices.Delete(id);
            return response;
        }
    }
}
