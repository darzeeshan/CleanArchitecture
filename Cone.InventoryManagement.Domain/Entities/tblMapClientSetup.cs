using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cone.InventoryManagement.Domain.Entities
{
    public class tblMapClientSetup
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int intClientSetupId { get; set; }

        [Required]
        public byte bytStatus { get; set; } = 0; //0-255 Inactive / Active / Deleted

        [Required, StringLength(100), Column(TypeName = "VARCHAR")]
        public string txtClientName { get; set; }

        [Required, StringLength(15), Column(TypeName = "VARCHAR")]
        public string txtClientId { get; set; }

        [Required, StringLength(30), Column(TypeName = "VARCHAR")]
        public string txtFolderLocation { get; set; }

        public DateTime dtDateTime { get; set; } = DateTime.Now;

        //Below creates additional column in linked tables.
        public virtual ICollection<tblMapClientFile> mapClientFiles { get; set; } 
        public virtual ICollection<tblMapClientConnection> mapClientConnections { get; set; }
    }
}
