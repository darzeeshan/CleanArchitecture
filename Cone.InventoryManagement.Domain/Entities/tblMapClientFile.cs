using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cone.InventoryManagement.Domain.Entities
{
    public class tblMapClientFile
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int intClientFileId { get; set; }

        public int intClientSetupId { get; set; }

        [Required]
        public byte bytFileType { get; set; } = 0; // 1=XML, 2=Excel, 3=CSV

        [Required]
        public bool blnFileColumnRequired { get; set; } = false; //bit

        [Required]
        public bool blnReferenceNumber { get; set; } = false;

        [Required, StringLength(35), Column(TypeName = "VARCHAR")]
        public string txtFileColumn { get; set; }

        [Required, StringLength(35), Column(TypeName = "VARCHAR")]
        public string txtMapWithNode { get; set; }

        public DateTime dtDateTime { get; set; } = DateTime.Now;

        public DateTime dtLastUpdated { get; set; } = DateTime.Now;

        [ForeignKey("intClientSetupId")] //Placing ForeignKey attribute above virtual table mapping, does not ask to create system generated related colomn in linked tables
        public virtual tblMapClientSetup mapClientSetup { get; set; }
    }
}
