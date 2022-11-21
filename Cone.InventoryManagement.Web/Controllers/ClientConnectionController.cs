using Cone.InventoryManagement.Web.Contracts.Infrastructure.Functions;
using Cone.InventoryManagement.Web.Contracts.Persistence.Clients;
using Cone.InventoryManagement.Web.Models.Clients;
using Cone.InventoryManagement.Web.Models.Misc;
using Microsoft.AspNetCore.Mvc;

namespace Cone.InventoryManagement.Web.Controllers
{
    public class ClientConnectionController : Controller
    {
        private readonly IClientConnectionService _defaultService;
        private readonly IClientSetupService _clientSetupService;

        public ClientConnectionController(IClientConnectionService defaultService, IClientSetupService clientSetupService)
        {
            _defaultService = defaultService;
            _clientSetupService = clientSetupService;
        }

        #region Delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int SetupId, int ConnectionId)
        {
            var result = await _defaultService.ClientConnectionDelete(ConnectionId);

            if (result.StatusCode == 200)
            {
                return RedirectToAction("Detail", "ClientSetup", new { Id = SetupId, Info = Convert.ToByte(result.MessageCode) });
            }
            else if (result.StatusCode == 100)
            {
                return RedirectToAction("Detail", "ClientSetup", new { Id = SetupId, Info = Convert.ToByte(result.MessageCode) });
            }
            else
            {
                return RedirectToAction("Detail", "ClientSetup", new { Id = SetupId, Info = Convert.ToByte(result.MessageCode) });
            }
        }
        #endregion

        #region Create
        [HttpGet]
        public async Task<ActionResult> Create(int Id)
        {
            if (UtilityHelper.CheckValidId(this, Id))
                return RedirectToAction("Error", "Dashboard");

            var result = await _clientSetupService.ClientSetupDetail(Id);

            if (UtilityHelper.CheckObject(this, result))
                return RedirectToAction("Error", "Dashboard");

            // To pass client id and name created a rouge view model
            // It's purpose is to send and receive data from view page
            RougeClientConnectionCreateVM model = new RougeClientConnectionCreateVM
            {
                SetupId = Id,
                ConnectionType = 1,
                ClientId = result.ClientId,
                ClientName = result.ClientName
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([FromForm] RougeClientConnectionCreateVM entity)
        {
            string Key = "";
            string Username = "";
            string Password = "";
            string Port = "";

            if (entity.ConnectionType == 1)
            {
                Key = entity.txtKey;
            }
            else if (entity.ConnectionType == 2)
            {
                Key = entity.txtJwtBaseUrl;
                Username = entity.txtJwtUser;
                Password = entity.txtJwtPassword;
            }
            else if (entity.ConnectionType == 3)
            {
                Key = entity.txtFtpUrl;
                Username = entity.txtFtpUser;
                Password = entity.txtFtpPassword;
                Port = entity.txtFtpPort;
            }

            BaseClientConnectionVM model = new BaseClientConnectionVM
            {
                SetupId = entity.SetupId,
                ConnectionType = entity.ConnectionType,
                Key = Key,
                Username = Username,
                Password = Password,
                Port = Port
            };

            var result = await _defaultService.ClientConnectionCreate(model);

            //200 status code represents sucess response from server.
            //So we have to check any erros returned in the result as well.
            if (result.StatusCode == 200 && result.Errors.Count == 0)
            {
                return RedirectToAction("Detail", "ClientSetup", new { Id = entity.SetupId, Info = Convert.ToByte(result.MessageCode) });
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

                TempData["Errors"] = Convert.ToByte(result.MessageCode) + "|0|" + result.StatusCode + "|" + result.Message + "||";

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

            var result = await _defaultService.ClientConnectionEdit(Id);

            if (UtilityHelper.CheckObject(this, result))
                return RedirectToAction("Error", "Dashboard");

            //Rouge model To transfer data to view
            RougeClientConnectionCreateVM entity = new RougeClientConnectionCreateVM();

            entity.ConnectionId = result.ConnectionId;
            entity.SetupId = result.SetupId;
            entity.ConnectionType = result.ConnectionType;

            if (entity.ConnectionType == 1)
            {
                entity.txtKey = result.Key;
            }
            else if (entity.ConnectionType == 2)
            {
                entity.txtJwtBaseUrl = result.Key;
                entity.txtJwtUser = result.Username;
                entity.txtJwtPassword = result.Password;
            }
            else if (entity.ConnectionType == 3)
            {
                entity.txtFtpUrl = result.Key;
                entity.txtFtpUser = result.Username;
                entity.txtFtpPassword = result.Password;
                entity.txtFtpPort = result.Port;
            }

            var resultsetup = await _clientSetupService.ClientSetupDetail(result.SetupId);

            if (UtilityHelper.CheckObject(this, resultsetup))
                return RedirectToAction("Error", "Dashboard");

            entity.ClientId = resultsetup.ClientId;
            entity.ClientName = resultsetup.ClientName;

            return View(entity);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([FromForm] RougeClientConnectionCreateVM entity)
        {
            string Key = "";
            string Username = "";
            string Password = "";
            string Port = "";

            if (entity.ConnectionType == 1)
            {
                Key = entity.txtKey;
            }
            else if (entity.ConnectionType == 2)
            {
                Key = entity.txtJwtBaseUrl;
                Username = entity.txtJwtUser;
                Password = entity.txtJwtPassword;
            }
            else if (entity.ConnectionType == 3)
            {
                Key = entity.txtFtpUrl;
                Username = entity.txtFtpUser;
                Password = entity.txtFtpPassword;
                Port = entity.txtFtpPort;
            }

            ClientConnectionEditVM model = new ClientConnectionEditVM
            {
                ConnectionId = entity.ConnectionId,
                SetupId = entity.SetupId,
                ConnectionType = entity.ConnectionType,
                Key = Key,
                Username = Username,
                Password = Password,
                Port = Port
            };

            var result = await _defaultService.ClientConnectionEdit(entity.ConnectionId, model);

            //200 status code represents sucess response from server.
            //So we have to check any erros returned in the result as well.
            if (result.StatusCode == 200 && result.Errors.Count == 0)
            {
                return RedirectToAction("Detail", "ClientSetup", new { Id = entity.SetupId, Info = Convert.ToByte(result.MessageCode) });
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

                TempData["Errors"] = Convert.ToByte(result.MessageCode) + "|0|" + result.StatusCode + "|" + result.Message + "||";

                return RedirectToAction("Error", "Dashboard");
            }
        }
        #endregion
    }
}
