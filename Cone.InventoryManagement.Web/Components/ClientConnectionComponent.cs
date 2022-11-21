using Cone.InventoryManagement.Web.Contracts.Persistence.Clients;
using Cone.InventoryManagement.Web.Models.Clients;
using Microsoft.AspNetCore.Mvc;

namespace Cone.InventoryManagement.Web.Components
{
    public class ClientConnectionListingViewComponent : ViewComponent
    {
        private readonly IClientConnectionService _defaultService;

        public ClientConnectionListingViewComponent(IClientConnectionService defaultService)
        {
            _defaultService = defaultService;
        }

        public async Task<IViewComponentResult> InvokeAsync(int Id)
        {
            var result = await _defaultService.ClientConnectionForSpecificSetup(Id);

            return View(result);
        }
    }
}
