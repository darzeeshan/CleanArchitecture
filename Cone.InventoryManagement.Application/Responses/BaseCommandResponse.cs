using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cone.InventoryManagement.Application.Responses
{
    public class BaseCommandResponse
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public int ReferenceId { get; set; } = 0;

        public int StatusCode { get; set; }

        internal short ReasonCode { get; set; } = 0; //internal variable, not accessible outside assembly / API project

        public string MessageCode
        {
            get {
                if (ReasonCode == 0)
                    return "";
                else
                    return ReasonCode.ToString("D4");
            }            
        }

        public string Message { get; set; }

        public List<string> Errors { get; set; }

        /*traceid = how to get trace id. this could be guid
         change all fields to small
        Replace Success with Status int data type to contain 200, 400, 404 etc statuses
        Add field referenceurl
        
        
        "type": "https://tools.ietf.org/html/rfc7231#section-6.5.1",
        "title": "One or more validation errors occurred.",
        "status": 400,
        "traceId": "|e74d6837-4bbade115ebb90e2.",
        "errors": {
            "FirstName": [
                "'First Name' must not be empty."

         
         */
    }
}
