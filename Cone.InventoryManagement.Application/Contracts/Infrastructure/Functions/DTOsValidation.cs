using System.Text.RegularExpressions;

namespace Cone.InventoryManagement.Application.Contracts.Infrastructure.Functions
{
    public static class DTOsValidation
    {
        public static bool ValidStatus(byte Status)
        {
            if (Status >= 0 && Status <= 4) //NotEmpty will handle the 0 selection
                return true;
            else
                return false;
        }

        public static bool ValidConnection(byte Connection)
        {
            if (Connection >= 0 && Connection <= 3 )
                return true;
            else
                return false;
        }

        public static bool ValidNumeric(string Value)
        {
            int result;
            if (Int32.TryParse(Value, out result))
                return result >= 1;
            else
                return false;
        }

        public static bool RegexExp(string Value)
        {
            return Regex.IsMatch(Value, "^[1-9]*$"); 
        }
    }
}
