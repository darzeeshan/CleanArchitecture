namespace Cone.InventoryManagement.Web.Services.Base
{
    public class Response<T>
    {
        //BaseCommandReponse
        public int ReferenceId { get; set; } = 0;
        public int StatusCode { get; set; } = 0;
        public string MessageCode { get; set; }
        public List<string> Errors { get; set; }

        public string Message { get; set; }

        //
        public string ValidationError { get; set; }

        public bool Success { get; set; }

        public T Data { get; set; }
    }
}
