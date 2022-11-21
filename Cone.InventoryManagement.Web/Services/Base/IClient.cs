namespace Cone.InventoryManagement.Web.Services.Base
{
    public partial interface IClient
    {
        public HttpClient HttpClient { get; }
    }
}