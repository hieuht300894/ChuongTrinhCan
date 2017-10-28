namespace EntityModel.DataModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("eWarehouseOut")]
    public partial class eWarehouseOut
    {
        [Key]
        public int KeyID { get; set; }

        public int IDCustomer { get; set; }

        public int IDProduct { get; set; }

        public int? IDDry { get; set; }

        public int? IDSeparate { get; set; }

        public int? IDMill { get; set; }

        public decimal TotalNumber { get; set; }

        public virtual eCustomer eCustomer { get; set; }

        public virtual eDry eDry { get; set; }

        public virtual eMill eMill { get; set; }

        public virtual eProduct eProduct { get; set; }

        public virtual eSeparateColor eSeparateColor { get; set; }
    }
}
