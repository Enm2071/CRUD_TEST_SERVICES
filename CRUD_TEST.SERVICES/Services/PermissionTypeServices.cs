using System.Linq;
using CRUD_TEST.DATA.Context;
using CRUD_TEST.DATA.Infraestructure;
using CRUD_TEST.MODELS.Dtos;
using CRUD_TEST.MODELS.Models;
using Microsoft.EntityFrameworkCore;

namespace CRUD_TEST.SERVICES.Services
{
    public interface IPermissionTypeServices
    {
        void SavePermissionType();
        Response<PermissionTypeDto> SelectAll();
    }

    public class PermissionTypeServices : IPermissionTypeServices
    {
        private readonly ApplicationDbcontext _dbcontext;
        private readonly DbSet<PermissionType> _permissionTypes;

        public PermissionTypeServices(IDbFactory db)
        {
            _dbcontext = db.Init();
            _permissionTypes = db.Init().PermissionTypes;
        }

        public void SavePermissionType()
        {
            _dbcontext.SaveChanges();
        }

        public Response<PermissionTypeDto> SelectAll()
        {
            var response = new Response<PermissionTypeDto> { Action = "SelectAll" };
            try
            {
                var permissionTypes = _permissionTypes.Select(pt => new PermissionTypeDto
                { Description = pt.Description, Id = pt.Id });
                response.Body.AddRange(permissionTypes);
                response.Succeed = true;
                return response;
            }
            catch (System.Exception e)
            {
                response.Error = new Error
                {
                    Name = e.Source,
                    Detail = e.Message
                };
                return response;
            }
        }
    }
}
