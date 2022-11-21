using Cone.InventoryManagement.Web.Contracts.Infrastructure.Functions;
using Cone.InventoryManagement.Web.Contracts.Persistence.Clients;
using Cone.InventoryManagement.Web.Models.Clients;
using Cone.InventoryManagement.Web.Models.Misc;
using Microsoft.AspNetCore.Mvc;

namespace Cone.InventoryManagement.Web.Controllers
{
    public class ClientSetupController : Controller
    {
        private readonly IClientSetupService _defaultService;
        private readonly IConfiguration _configuration;
        public ClientSetupController(IClientSetupService defaultService, IConfiguration configuration)
        {
            _defaultService = defaultService;
            _configuration = configuration;
        }

        #region Index/Status/Delete
        public async Task<ActionResult> Index(byte Info = 0)
        {
            var result = await _defaultService.GetClientSetup();

            return View(result);
        }

        public async Task<ActionResult> Status(int Id)
        {
           if(UtilityHelper.CheckValidId(this, Id))
                return RedirectToAction("Error", "Dashboard");

            var result = await _defaultService.ClientSetupChangeStatus(Id);

            if (result.StatusCode == 200)
            {
                return RedirectToAction("Index", new { Info = Convert.ToByte(result.MessageCode) });
            }
            else if (result.StatusCode == 100)
            {
                return RedirectToAction("Index", new { Info = Convert.ToByte(result.MessageCode) });
            }
            else
            {
                return RedirectToAction("Index", new { Info = Convert.ToByte(result.MessageCode) });
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int SetupId)
        {
            if (UtilityHelper.CheckValidId(this, SetupId))
                return RedirectToAction("Error", "Dashboard");

            var result = await _defaultService.ClientSetupDelete(SetupId);

            if (result.StatusCode == 200)
            {
                return RedirectToAction("Index", new { Info = Convert.ToByte(result.MessageCode) });
            }
            else if (result.StatusCode == 100)
            {
                return RedirectToAction("Index", new { Info = Convert.ToByte(result.MessageCode) });
            }
            else
            {
                return RedirectToAction("Index", new { Info = Convert.ToByte(result.MessageCode) });
            }
        }
        #endregion

        #region Create
        [HttpGet]
        public async Task<ActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([FromForm] BaseClientSetupVM entity)
        {
            var result = await _defaultService.ClientSetupCreate(entity);

            //200 status code represents sucess response from server.
            //So we have to check any erros returned in the result as well.
            if (result.StatusCode == 200 && result.Errors.Count == 0)
            {
                return RedirectToAction("Index", new { Info = Convert.ToByte(result.MessageCode) });
            }
            //For any validation errors from FluentValidation we set status code as 100.
            else if ((result.StatusCode == 200 || result.StatusCode == 100) && result.Errors.Count != 0)
            {
                Alert alert = new Alert
                {
                    MessageType = 3,
                    Info = Convert.ToByte(result.MessageCode),
                    Errors = result.Errors
                };

                ViewData["Alert"] = alert; //Storing alert model into viewdata

                return View(entity);
            }
            else
            {
                //ErrorViewModel error = new ErrorViewModel
                //{
                //    Code = result.StatusCode,
                //    Info = Convert.ToByte(result.MessageCode),
                //    Message = result.Message
                //};

                //ViewData value becomes null if redirection has occurred.
                //TempData is used to pass data between two consecutive requests.
                //TempData is not holding Model when redirected to error page, so we are defining pipe separated values

                TempData["Errors"] = Convert.ToByte(result.MessageCode) +"|0|"+ result.StatusCode + "|" + result.Message + "||";

                return RedirectToAction("Error", "Dashboard");
            }
        }
        #endregion

        #region Edit
        [HttpGet]
        public async Task<ActionResult> Edit(int Id)
        {
            if (UtilityHelper.CheckValidId(this, Id))
                return RedirectToAction("Error", "Dashboard");

            var result = await _defaultService.ClientSetupEdit(Id);

            if (UtilityHelper.CheckObject(this, result))
                return RedirectToAction("Error", "Dashboard");

            return View(result);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([FromForm] ClientSetupEditVM entity)
        {
            //See Add method for comments
            var result = await _defaultService.ClientSetupEdit(entity.SetupId, entity);

            if (result.StatusCode == 200 && result.Errors.Count == 0)
            {
                return RedirectToAction("Index", new { Info = Convert.ToByte(result.MessageCode) });
            }
            else if ((result.StatusCode == 200 || result.StatusCode == 100) && result.Errors.Count != 0)
            {
                Alert alert = new Alert
                {
                    MessageType = 3,
                    Info = Convert.ToByte(result.MessageCode),
                    Errors = result.Errors
                };

                ViewData["Alert"] = alert;

                return View(entity);
            }
            else
            {
                TempData["Errors"] = Convert.ToByte(result.MessageCode) + "|0|" + result.StatusCode + "|" + result.Message + "||";

                return RedirectToAction("Error", "Dashboard");
            }
        }
        #endregion

        #region Detail
        public async Task<ActionResult> Detail(int Id, byte Info = 0)
        {
            if (UtilityHelper.CheckValidId(this, Id))
                return RedirectToAction("Error", "Dashboard");

            var result = await _defaultService.ClientSetupDetail(Id);

            if (UtilityHelper.CheckObject(this, result))
                return RedirectToAction("Error", "Dashboard");

            return View(result);
        }
        #endregion
    }
}
