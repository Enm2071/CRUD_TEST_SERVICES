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


        [HttpGet("get/{id}")]
        public Response<PermissionDto> Select(int id)
        {
            var response = _permissionServices.Get(id);
            return response;
        }

        [HttpGet("get/all")]
        public Response<PermissionDto> All()
        {
            var response = _permissionServices.GetAll();
            return response;
        }

        [HttpPost("create")]
        public Response<PermissionDto> Create(PermissionDto data)
        {
            var response = _permissionServices.Create(data);
            return response;
        }

        [HttpPost("update/{id}")]
        public Response<PermissionDto> Update(PermissionDto data, int id)
        {
            var response = _permissionServices.Update(data, id);
            return response;
        }

        [HttpPost("delete/{id}")]
        public Response<PermissionDto> Delete(int id)
        {
            var response = _permissionServices.Delete(id);
            return response;
        }
    }
}
