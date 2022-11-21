using Microsoft.AspNetCore.Mvc;

namespace Cone.InventoryManagement.Web.Contracts.Infrastructure.Functions
{
    #region Redirection
    //public class UtilityHelper
    //{
    //    //Redirection not working
    //    //public async Task IdCheckHelper(Controller controller, int Id)
    //    //{
    //    //    if (Id <= 0)
    //    //    {
    //    //        controller.TempData["Errors"] = "11|4||||";
    //    //        controller.HttpContext.Response.Redirect("/Dashboard/Error");
    //    //    }
    //    //}
    //}

    //if (UtilityHelper.CheckValidId(this, Id))
    //    return RedirectToAction("Error", "Dashboard");

    //if (UtilityHelper.CheckObject(this, result))
    //    return RedirectToAction("Error", "Dashboard");
    #endregion

    public static class UtilityHelper
    {
        public static bool CheckValidId(Controller controller, int Id)
        {
            if (Id <= 0)
            {
                controller.TempData["Errors"] = "11|4||||";
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool CheckObject(Controller controller, object obj)
        {
            if (obj == null)
            {
                controller.TempData["Errors"] = "11|4||||";
                return true;
            }
            else
            {
                return false;
            }
        }

        //*** Disabled following code. ***
        //*** It is now handled from within Application and Settings class library ***

        //The below code was written to check and create the clients related folders 
        //Folders were defined in appsettings.js
        //Since this is a static method and IConfiguration could not be directly accessed
        //so IConfiguration was injected from program.cs

        //private static IConfiguration _config;

        //Injecting IConfiguration from Program.cs to enable static class access
        //AppSettings.json
        //public static void AppSettingsConfigure(IConfiguration config)
        //{
        //    _config = config;
        //}

        //public static bool CreateStorageFolders(string ClientFolderName)
        //{
        //    //Note: GetChildren returns the result sorted on array key (node name) so main root folder has to be 
        //    //created separately.
        //    var mainFolder = _config.GetSection("FileStorageFolders:MainFolder:Root").Value;

        //    //Check main directory exists
        //    if (!Directory.Exists(mainFolder))
        //    {
        //        return false; //main folder defined in setting does not exist. Do not proceed.
        //    }
        //    else if (Directory.Exists(mainFolder + "" + ClientFolderName))
        //    {
        //        return false; //folder already exist. Do not proceed.
        //    }
        //    else
        //    {
        //        Directory.CreateDirectory(mainFolder + "" + ClientFolderName); //ok, now you can create the folder
        //    }

        //    if (!Directory.Exists(mainFolder + "" + ClientFolderName))
        //    {
        //        return false; //System did not created our given folder. Permission issue may exist. Do not proceed.
        //    }

        //    //Sub folders
        //    var subFolders = _config.GetSection("FileStorageFolders:SubFolders").GetChildren();

        //    foreach (var folder in subFolders)
        //    {
        //        Directory.CreateDirectory(mainFolder + "" + ClientFolderName +""+ folder.Value);
        //    }

        //    return true;
        //}
    }
}
