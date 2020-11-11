using System;
using CRUD_TEST.DATA.Context;

namespace CRUD_TEST.DATA.Infraestructure
{
    public interface IDbFactory : IDisposable
    {
        ApplicationDbcontext Init();
    }
}
