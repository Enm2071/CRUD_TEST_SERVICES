using System.Collections.Generic;
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
        void CreateDefaultValues();
        Response<PermissionTypeDto> Create(PermissionTypeDto data);
        Response<PermissionTypeDto> GetAll();
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

        public void CreateDefaultValues()
        {
            if (_permissionTypes.Any()) return;
            var permissionDefaultTypes = new List<PermissionTypeDto>
            {
                new PermissionTypeDto
                {
                    Description = "Illness"
                },
                new PermissionTypeDto
                {
                    Description = "Diligence"
                },
                new PermissionTypeDto
                {
                    Description = "Birthday"
                }
            };
            foreach (var permission in permissionDefaultTypes)
            {
                Create(permission);
            }

        }

        public Response<PermissionTypeDto> Create(PermissionTypeDto data)
        {
            var response = new Response<PermissionTypeDto>{Action = "Create"};
            var newData = new PermissionType
            {
                Description = data.Description
            };
            try
            {
                _permissionTypes.Add(newData);
                SavePermissionType();
                response.Succeed = true;
                response.Body.Add(data);
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

        public Response<PermissionTypeDto> GetAll()
        {
            var response = new Response<PermissionTypeDto> { Action = "GetAll" };
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
