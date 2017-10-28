using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityModel.DataModel
{
    [Table("eWarehouseScale")]
    public class eWarehouseScale
    {
        [Key]
        public int KeyID { get; set; }

        public string Code { get; set; }

        public string Name { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime? ModifiedDate { get; set; }

        [StringLength(255)]
        public string Note { get; set; }

        public bool IsEnable { get; set; }

        public int IDAgency { get; set; }
    }
}
