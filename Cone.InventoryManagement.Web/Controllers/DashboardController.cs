using Cone.InventoryManagement.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace Cone.InventoryManagement.Web.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Error(ErrorViewModel error)
        {
            return View(error);
        }
    }
}
