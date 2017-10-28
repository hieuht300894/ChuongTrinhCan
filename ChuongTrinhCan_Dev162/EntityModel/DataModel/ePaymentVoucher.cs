namespace EntityModel.DataModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ePaymentVoucher")]
    public partial class ePaymentVoucher
    {
        [Key]
        public int KeyID { get; set; }

        public string Receiver { get; set; }

        public string Description { get; set; }

        public string Document { get; set; }

        public decimal UNC { get; set; }

        public decimal MoneyNoVAT { get; set; }

        public int VAT { get; set; }

        public decimal MoneyVAT { get; set; }

        public bool IsEnable { get; set; }

        public int IDAgency { get; set; }

        public DateTime DateCreate { get; set; }

        public int CreateBy { get; set; }

        public int IDFactory { get; set; }

        public string FactoryName { get; set; }
    }
}
