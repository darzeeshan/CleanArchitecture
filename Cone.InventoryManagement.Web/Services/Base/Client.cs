using Cone.InventoryManagement.Web.Services.Base;
using System.Net.Http;

namespace Cone.InventoryManagement.Web.Services.Base
{
    public partial class Client : IClient
    {
        public HttpClient HttpClient
        {
            get 
            { 
                return _httpClient; 
            }
        }
    }
}