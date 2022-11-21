using Cone.InventoryManagement.Web.Models.Misc;
using Microsoft.AspNetCore.Mvc;

namespace Cone.InventoryManagement.Web.Components
{
    public class AlertViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(Alert model)
        {
            return View(model);
        }
    }
}
