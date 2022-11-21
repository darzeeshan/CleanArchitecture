using Cone.InventoryManagement.Web.Contracts.Infrastructure.Functions;
using Cone.InventoryManagement.Web.Contracts.Persistence;
using Microsoft.AspNetCore.WebUtilities;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net.Http.Headers;

namespace Cone.InventoryManagement.Web.Services.Base
{
    public class BaseHttpService
    {
        protected readonly ILocalStorageService _localStorage;
        protected IClient _client; //Note, it's not readonly

        public BaseHttpService(IClient client, ILocalStorageService localStorage)
        {
            _client = client;
            _localStorage = localStorage;
        }

        protected Response<Guid> ConvertApiExceptions<Guid>(ApiException ex)
        {
            //var data = (JObject)JsonConvert.DeserializeObject(ex.Response); This can be used to get data from a specific node in json
            //data["title"].Value<string>(),

            return new Response<Guid>()
            {
                StatusCode = ex.StatusCode,
                MessageCode = "10",
                Message = ReasonPhrases.GetReasonPhrase(ex.StatusCode),
                Success = false,
                ValidationError = ex.Response
            };
            //+ ", 2:" + ex.InnerException.ToString() + ", 3:" + ex.InnerException.Data.ToString()
            //if (ex.StatusCode == 400)
            //    return new Response<Guid>() { Message = Messages.Info(10), ValidationError = ex.Response, Success = false };
            //else
            //    return new Response<Guid>() { Message = Messages.Info(10), Success = false };
        }

        protected void AddBearerToken()
        {
            if (_localStorage.Exists("token"))
                _client.HttpClient.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Bearer", _localStorage.GetStorageValue<string>("token"));
        }
    }
}
