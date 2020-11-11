using CRUD_TEST.DATA.Context;
using CRUD_TEST.DATA.Infraestructure;
using CRUD_TEST.MODELS.Models;
using Microsoft.EntityFrameworkCore;

namespace CRUD_TEST.SERVICES.Services
{
    public interface IPermissionTypeServices
    {
        void SavePermissionType();
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
    }
}
