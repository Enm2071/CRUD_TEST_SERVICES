using CRUD_TEST.DATA.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace CRUD_TEST.DATA.Infraestructure
{
    public class DbFactory : IDbFactory
    {
        private ApplicationDbcontext _dbcontext;
        private readonly DbContextOptions<ApplicationDbcontext> _options;

        public DbFactory(IConfiguration configuration)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbcontext>();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            var options = optionsBuilder.Options;
            _options = options;
        }

        public void Dispose()
        {
            _dbcontext?.Dispose();
        }

        public ApplicationDbcontext Init()
        {
            return _dbcontext ?? (_dbcontext = new ApplicationDbcontext(_options));
        }
    }
}
