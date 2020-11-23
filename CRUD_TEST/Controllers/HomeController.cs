using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CRUD_TEST.Models;
using CRUD_TEST.SERVICES.Services;

namespace CRUD_TEST.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPermissionTypeServices _permissionTypeServices;

        public HomeController(IPermissionTypeServices permissionTypeServices)
        {
            _permissionTypeServices = permissionTypeServices;
        }


        public IActionResult Index()
        {
            _permissionTypeServices.CreateDefaultValues();
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {

            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
