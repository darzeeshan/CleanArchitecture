namespace Cone.InventoryManagement.Application.DTOs.Clients
{
    //Create
    public class BaseClientSetupDto
    {
        public byte Status { get; set; } = 0; //0-255 Inactive / Active / Deleted

        public string ClientName { get; set; }

        public string ClientId { get; set; }

        public string FolderLocation { get; set; }
    }

    //For Detailed / List / Delete
    public class ClientSetupDetailedDto : BaseClientSetupDto
    {
        public int SetupId { get; set; }

        public DateTime DateTime { get; set; }
    }

    //Edit
    public class ClientSetupEditDto : BaseClientSetupDto
    {
        public int SetupId { get; set; }
    }

    //Change Status
    public class ClientSetupStatusChangeDto
    {
        public byte Status { get; set; } = 0;
    }
}
