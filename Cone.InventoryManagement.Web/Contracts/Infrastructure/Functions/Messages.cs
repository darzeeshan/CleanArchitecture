namespace Cone.InventoryManagement.Web.Contracts.Infrastructure.Functions
{
    public static class Messages
    {
        public static string Info(byte i = 0)
        {
            string[] message = new string[20];

            message[0] = "";

            //Datbase actions related
            message[1] = "Record has been successfully added.";
            message[2] = "Record has been successfully updated.";
            message[3] = "Record has been successfully deleted.";
            message[4] = "Record not found.";
            message[5] = "Status has been successfully changed.";
            message[6] = "Are you sure to delete this record? Click 'Yes' to delete this record permanently.";
            message[7] = "Note: This action may delete any other related records in sub-tables.";


            //Something went wrong
            message[10] = "System encountered an error while trying to process your requests.";
            message[11] = "System encountered an error while trying to process your requests. Please contact system administrator.";

            //Validation 
            message[15] = "Validation error(s) occured. Please fix and try again.";
            message[16] = "Client folder could not be created.";

            return message[i];
        }

        public static string Validation(byte i = 0)
        {
            string[] message = new string[20];

            message[0] = "";
            message[1] = "{0} is required.";
            message[2] = "Maximum {0} characters allowed in {1}.";            

            message[10] = "Invalid values passed for a write operation.";            

            return message[i];
        }


    }
}
