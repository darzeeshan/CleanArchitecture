using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cone.InventoryManagement.Domain.Entities
{
    public class tblMapClientConnection
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int intClientConnectionId { get; set; }

        public int intClientSetupId { get; set; }

        [Required]
        public byte bytConnectionType { get; set; } = 0;

        [StringLength(100), Column(TypeName = "VARCHAR")]
        public string txtKey { get; set; }

        [StringLength(20), Column(TypeName = "VARCHAR")]
        public string txtUsername { get; set; }

        [StringLength(20), Column(TypeName = "VARCHAR")]
        public string txtPassword { get; set; }

        [StringLength(5), Column(TypeName = "VARCHAR")]
        public string txtPort { get; set; }

        public DateTime dtDateTime { get; set; } = DateTime.Now;

        public DateTime dtLastUpdated { get; set; } = DateTime.Now;

        [ForeignKey("intClientSetupId")]
        public virtual tblMapClientSetup mapClientSetup { get; set; }
    }
}
