namespace EntityModel.DataModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("eExportMill")]
    public partial class eExportMill
    {
        [Key]
        public int KeyID { get; set; }

        [StringLength(50)]
        public string Code { get; set; }

        public int IDCustomer { get; set; }

        [StringLength(100)]
        public string Buyer { get; set; }

        [StringLength(100)]
        public string VehicleNumber { get; set; }

        [StringLength(100)]
        public string Receiver { get; set; }

        public int IDProduct { get; set; }

        public string ProductName { get; set; }

        public decimal NumberPacketBuy { get; set; }

        public decimal NumberKGBuy { get; set; }

        public decimal TotalRemain { get; set; }

        public int IDTaskGroup { get; set; }

        public bool IsEnable { get; set; }

        public int CreatedBy { get; set; }

        public DateTime CreatedDate { get; set; }

        public int? ModifiedBy { get; set; }

        public DateTime? ModifiedDate { get; set; }

        [StringLength(255)]
        public string Note { get; set; }

        public int IDAgency { get; set; }

        public int IDFactory { get; set; }
    }
}
