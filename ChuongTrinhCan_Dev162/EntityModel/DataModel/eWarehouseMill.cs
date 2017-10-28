namespace EntityModel.DataModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("eWarehouseMill")]
    public partial class eWarehouseMill
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public eWarehouseMill()
        {
        }

        [Key]
        public int KeyID { get; set; }

        public int IDCustomer { get; set; }

        public decimal TotalNumber { get; set; }

        public int? IDProduct { get; set; }

        public decimal Gao { get; set; }

        public decimal Tam { get; set; }

        public decimal Cam { get; set; }

        public decimal PheBL { get; set; }

        public virtual eCustomer eCustomer { get; set; }

        public virtual eProduct eProduct { get; set; }
    }
}
