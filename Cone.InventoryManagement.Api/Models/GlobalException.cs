using Newtonsoft.Json;

namespace Cone.InventoryManagement.Api.Models
{
    public class GlobalException
    {
        public int StatusCode { get; set; }

        public string Message { get; set; }

        public override string ToString() => JsonConvert.SerializeObject(this);
    }
}
