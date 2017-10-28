namespace EntityModel.DataModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("eWarehouseIn")]
    public partial class eWarehouseIn
    {
        [Key]
        public int KeyID { get; set; }

        public int IDCustomer { get; set; }

        public int IDProduct { get; set; }

        public decimal TotalNumber { get; set; }

        public decimal Remain { get; set; }

        public int IDTaskCate { get; set; }

        public virtual eCustomer eCustomer { get; set; }

        public virtual eProduct eProduct { get; set; }
    }
}
