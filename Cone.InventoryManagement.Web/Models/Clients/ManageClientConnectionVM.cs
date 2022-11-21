namespace Cone.InventoryManagement.Web.Models.Clients
{
    //Create
    public class BaseClientConnectionVM
    {
        public int SetupId { get; set; }

        public byte ConnectionType { get; set; } = 0;

        public string Key { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public string Port { get; set; }
    }

    //For Detailed / List / Delete
    public class ClientConnectionDetailedVM : BaseClientConnectionVM
    {
        public int ConnectionId { get; set; }

        public DateTime DateTime { get; set; } = DateTime.Now;

        public DateTime LastUpdated { get; set; } = DateTime.Now;
    }

    public class ClientConnectionForSpecificSetupVM : BaseClientConnectionVM
    {
        public int ConnectionId { get; set; }

        public string ClientId { get; set; }

        public string ClientName { get; set; }

        public DateTime DateTime { get; set; }

        public DateTime LastUpdated { get; set; }
    }

    //Edit
    public class ClientConnectionEditVM : BaseClientConnectionVM
    {
        public int ConnectionId { get; set; }

        public DateTime LastUpdated { get; set; } = DateTime.Now;
    }

    //Rouge view model
    //Its purpose is to send and receive data from view
    public class RougeClientConnectionCreateVM
    {
        public int ConnectionId { get; set; }

        public int SetupId { get; set; }

        public byte ConnectionType { get; set; }

        public string ClientId { get; set; }

        public string ClientName { get; set; }

        public string txtKey { get; set; }

        public string txtJwtBaseUrl { get; set; }

        public string txtJwtUser { get; set; }

        public string txtJwtPassword { get; set; }

        public string txtFtpUrl { get; set; }

        public string txtFtpUser { get; set; }

        public string txtFtpPassword { get; set; }

        public string txtFtpPort { get; set; }
    }
}
