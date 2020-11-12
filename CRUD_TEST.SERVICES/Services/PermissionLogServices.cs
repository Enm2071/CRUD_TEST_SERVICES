using System;
using System.Collections.Generic;
using System.Text;
using CRUD_TEST.DATA.Context;
using CRUD_TEST.DATA.Infraestructure;
using CRUD_TEST.MODELS.Dtos;
using CRUD_TEST.MODELS.Models;
using Microsoft.EntityFrameworkCore;

namespace CRUD_TEST.SERVICES.Services
{
    public interface IPermissionLogServices
    {
        void SavePermisionLog();
        Response Create(PermissionDto data,string action);
    }

    public class PermissionLogServices : IPermissionLogServices
    {
        private readonly ApplicationDbcontext _dbcontext;
        private readonly DbSet<PermissionLog> _permissionLogs;

        public PermissionLogServices(IDbFactory db)
        {
            _dbcontext = db.Init();
            _permissionLogs = db.Init().PermissionLogs;
        }

        public void SavePermisionLog()
        {
            _dbcontext.SaveChanges();
        }

        public Response Create(PermissionDto data,string action)
        {
            var response = new Response{Action = action};

            var permisionLog = new PermissionLog
            {
                Action = action,
                Date = DateTime.Now,
                EmployeeLastName = data.EmployeeLastName,
                EmployeeName = data.EmployeeName,
                PermissionTypeId = data.PermissionTypeId
            };

            try
            {
                _permissionLogs.Add(permisionLog);
                SavePermisionLog();
                response.Succeed = true;
                response.Permission.Add(data);
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
