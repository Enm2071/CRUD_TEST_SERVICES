using System;
using System.Linq;
using CRUD_TEST.DATA.Context;
using CRUD_TEST.DATA.Infraestructure;
using CRUD_TEST.MODELS.Dtos;
using CRUD_TEST.MODELS.Models;
using Microsoft.EntityFrameworkCore;

namespace CRUD_TEST.SERVICES.Services
{
    public interface IPermissionServices
    {
        void SavePermission();
        Response<PermissionDto> Create(PermissionDto data);
        Response<PermissionDto> Delete(int id);
        Response<PermissionDto> Edit(PermissionDto data, int id);
        Response<PermissionDto> SelectAll();
        Response<PermissionDto> Select(int id);

    }

    public class PermissionServices : IPermissionServices
    {
        private readonly ApplicationDbcontext _dbcontext;
        private readonly DbSet<Permission> _permissions;
        private readonly IPermissionLogServices _permissionLogServices;

        public PermissionServices(IDbFactory db, IPermissionLogServices permissionLogServices)
        {
            _permissionLogServices = permissionLogServices;
            _dbcontext = db.Init();
            _permissions = db.Init().Permissions;
        }

        public void SavePermission()
        {
            _dbcontext.SaveChanges();
        }

        public Response<PermissionDto> Create(PermissionDto data)
        {
            var permission = new Permission
            {
                Date = DateTime.Now,
                EmployeeLastName = data.EmployeeLastName,
                EmployeeName = data.EmployeeName,
                PermissionTypeId = data.PermissionTypeId
            };
            var response = new Response<PermissionDto> { Action = "Create" };
            try
            {
                _permissions.Add(permission);
                SavePermission();
                response.Succeed = true;
                response.Body.Add(data);

                var responseLog = _permissionLogServices.Create(data, "Create");
                if (!responseLog.Succeed)
                {
                    response.Error = new Error
                    {
                        Name = "¡Permission Log Error!",
                        Detail = "We could not add log for this action"
                    };
                }
                return response;
            }
            catch (Exception e)
            {
                response.Error = new Error { Name = e.Source, Detail = e.Message };
                return response;
            }

        }

        public Response<PermissionDto> Delete(int id)
        {
            var permission = _permissions.SingleOrDefault(p => p.Id == id);
            var response = new Response<PermissionDto> { Action = "Delete" };

            if (permission == null)
            {
                response.Error = new Error
                {
                    Name = "NotFound",
                    Detail = "The permission your are trying to deleted can not be found"
                };
                return response;
            }

            try
            {
                _permissions.Remove(permission);
                SavePermission();
                response.Succeed = true;
                var data = new PermissionDto
                {
                    EmployeeLastName = permission.EmployeeLastName,
                    EmployeeName = permission.EmployeeName,
                    PermissionTypeId = permission.PermissionTypeId
                };
                response.Body.Add(data);

                var responseLog = _permissionLogServices.Create(data, "Delete");
                if (!responseLog.Succeed)
                {
                    response.Error = new Error
                    {
                        Name = "¡Permission Log Error!",
                        Detail = "We could not add log for this action"
                    };
                }

                return response;
            }
            catch (Exception e)
            {
                response.Error = new Error
                {
                    Name = e.Source,
                    Detail = e.Message
                };
                return response;
            }

        }

        public Response<PermissionDto> Edit(PermissionDto data, int id)
        {
            var permission = _permissions.SingleOrDefault(p => p.Id == id);
            var response = new Response<PermissionDto> { Action = "Edit" };

            if (permission == null)
            {
                response.Error = new Error
                {
                    Name = "NotFound",
                    Detail = "The permission your are trying to edit can not be found"
                };
                return response;
            }
            var permissionLogData = new PermissionDto
            {
                PermissionTypeId = permission.PermissionTypeId,
                EmployeeLastName = permission.EmployeeLastName,
                EmployeeName = permission.EmployeeName
            };

            permission.EmployeeLastName = data.EmployeeLastName;
            permission.EmployeeName = data.EmployeeName;
            permission.PermissionTypeId = data.PermissionTypeId;

            try
            {
                SavePermission();
                response.Succeed = true;
                response.Body.Add(data);
                var responseLog = _permissionLogServices.Create(permissionLogData, "Edit");
                if (!responseLog.Succeed)
                {
                    response.Error = new Error
                    {
                        Name = "¡Permission Log Error!",
                        Detail = "We could not add log for this action"
                    };
                }
                return response;
            }
            catch (Exception e)
            {
                response.Error = new Error
                {
                    Name = e.Source,
                    Detail = e.Message
                };
                return response;
            }

        }

        public Response<PermissionDto> SelectAll()
        {
            var response = new Response<PermissionDto> { Action = "SelectAll" };
            try
            {
                var permissions = _permissions.Select(p => new PermissionDto
                {
                    EmployeeLastName = p.EmployeeLastName,
                    EmployeeName = p.EmployeeName,
                    PermissionTypeId = p.PermissionTypeId,
                    Id = p.Id
                });
                response.Body.AddRange(permissions);
                response.Succeed = true;
                return response;
            }
            catch (Exception e)
            {
                response.Error = new Error
                {
                    Name = e.Source,
                    Detail = e.Message
                };
                return response;
            }
        }

        public Response<PermissionDto> Select(int id)
        {
            var response = new Response<PermissionDto> { Action = "Select" };
            try
            {

                var permission = _permissions.SingleOrDefault(p => p.Id == id);
                if (permission == null)
                {
                    response.Error = new Error
                    {
                        Name = "NotFound",
                        Detail = "The permission your are trying to select can not be found"
                    };
                    return response;
                }

                response.Succeed = true;
                var data = new PermissionDto
                {
                    EmployeeLastName = permission.EmployeeLastName,
                    EmployeeName = permission.EmployeeName,
                    PermissionTypeId = permission.PermissionTypeId,
                    Id = permission.Id
                };
                response.Body.Add(data);
                return response;
            }
            catch (Exception e)
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
