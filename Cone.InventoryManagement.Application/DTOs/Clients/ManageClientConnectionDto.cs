namespace Cone.InventoryManagement.Application.DTOs.Clients
{
    //Create
    public class BaseClientConnectionDto
    {
        public int SetupId { get; set; }

        public byte ConnectionType { get; set; } = 0;

        public string Key { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public string Port { get; set; }
    }

    //For Detailed / List / Delete
    public class ClientConnectionDetailedDto : BaseClientConnectionDto
    {
        public int ConnectionId { get; set; }

        //public int SetupId { get; set; } already in base class

        public DateTime DateTime { get; set; } = DateTime.Now;

        public DateTime LastUpdated { get; set; } = DateTime.Now;
    }

    public class ClientConnectionForSpecificSetupDto : BaseClientConnectionDto
    {
        public int ConnectionId { get; set; }

        public string ClientId { get; set; }

        public string ClientName { get; set; }

        public DateTime DateTime { get; set; }

        public DateTime LastUpdated { get; set; }
    }

    //Edit
    public class ClientConnectionEditDto : BaseClientConnectionDto
    {
        public int ConnectionId { get; set; }

        public DateTime LastUpdated { get; set; } = DateTime.Now;
    }
}
