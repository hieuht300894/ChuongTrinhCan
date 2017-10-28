namespace EntityModel.DataModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("eOrderDetail")]
    public partial class eOrderDetail
    {
        [Key]
        public int KeyID { get; set; }

        public int IDProduct { get; set; }

        public decimal NumberPacket { get; set; }

        public decimal KG { get; set; }

        public decimal Total { get; set; }

        public int IDAgency { get; set; }

        public int IDOrder { get; set; }

        public bool IsEnable { get; set; }

        public virtual eOrder eOrder { get; set; }

        public virtual eProduct eProduct { get; set; }
    }
}
