namespace Cone.InventoryManagement.Web.Models.Clients
{
    //Create
    public class BaseClientSetupVM
    {
        public byte Status { get; set; } = 0; //0-255 Inactive / Active / Deleted

        public string ClientName { get; set; }

        public string ClientId { get; set; }

        public string FolderLocation { get; set; }
    }

    //For Detailed / List / Delete
    public class ClientSetupDetailedVM : BaseClientSetupVM
    {
        public int SetupId { get; set; }

        public DateTime DateTime { get; set; }
    }

    //Edit
    public class ClientSetupEditVM : BaseClientSetupVM
    {
        public int SetupId { get; set; }
    }

    //Change Status
    public class ClientSetupStatusChangeVM
    {
        public byte Status { get; set; } = 0;
    }
}
