namespace EntityModel.DataModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("eExportExtract")]
    public partial class eExportExtract
    {
        public eExportExtract() { }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int KeyID { get; set; }

        public DateTime DateIn { get; set; }

        public string Code { get; set; }

        public int IDFactory { get; set; }

        public string FactoryName { get; set; }

        public int IDWorker { get; set; }

        public string WorkerName { get; set; }

        public int IDTask { get; set; }

        public string TaskName { get; set; }

        public decimal TaskPrice { get; set; }

        public int IDCustomer { get; set; }

        public string CustomerName { get; set; }

        public int IDTypeExtract { get; set; }

        public int IDProduct { get; set; }

        public string ProductName { get; set; }

        public int IDUnit { get; set; }

        public decimal UnitWeight { get; set; }

        public decimal NumberPacket { get; set; }

        public decimal TotalWeight { get; set; }

        public decimal TotalPriceWorker { get; set; }

        public decimal PriceSold { get; set; }

        public decimal TotalPriceCustomer { get; set; }

        public bool IsEnable { get; set; }

        public int IDAgency { get; set; }

        public int CreatedBy { get; set; }

        public DateTime CreatedDate { get; set; }

        public int? ModifiedBy { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public string Note { get; set; }

        public virtual eTypeExtract eTypeExtract { get; set; }

        public virtual eUnit eUnit { get; set; }
    }
}
