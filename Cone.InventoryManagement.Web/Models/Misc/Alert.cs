namespace Cone.InventoryManagement.Web.Models.Misc
{
    public class Alert
    {
        public byte MessageType { get; set; } = 3; //Yellow background + black text
        public byte Info { get; set; } = 0;

        public List<string> Errors { get; set; }
    }
}
