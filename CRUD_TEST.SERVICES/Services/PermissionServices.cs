using CRUD_TEST.DATA.Context;
using CRUD_TEST.DATA.Infraestructure;
using CRUD_TEST.MODELS.Models;
using Microsoft.EntityFrameworkCore;

namespace CRUD_TEST.SERVICES.Services
{
    public interface IPermissionServices
    {
        void SavePermission();
    }

    public class PermissionServices : IPermissionServices
    {
        private readonly ApplicationDbcontext _dbcontext;
        private readonly DbSet<Permission> _permissions;

        public PermissionServices(IDbFactory db)
        {
            _dbcontext = db.Init();
            _permissions = db.Init().Permissions;
        }

        public void SavePermission()
        {
            _dbcontext.SaveChanges();
        }
    }
}
