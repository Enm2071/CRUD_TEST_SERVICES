using CRUD_TEST.MODELS.Dtos;
using CRUD_TEST.MODELS.Models;
using CRUD_TEST.SERVICES.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace CRUD_TEST.Controllers.API
{
    [Route("api/permissionType")]
    [EnableCors]
    [ApiController]
    public class PermissionTypeController : ControllerBase
    {
        private readonly IPermissionTypeServices _permissionTypeServices;

        public PermissionTypeController(IPermissionTypeServices permissionTypeServices)
        {
            _permissionTypeServices = permissionTypeServices;
        }

        [HttpGet("get/all")]
        public Response<PermissionTypeDto> GetAll()
        {
            var response = _permissionTypeServices.GetAll();
            return response;
        }
    }
}
