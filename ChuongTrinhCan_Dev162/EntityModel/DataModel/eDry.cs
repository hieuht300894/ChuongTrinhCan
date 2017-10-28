namespace EntityModel.DataModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("eDry")]
    public partial class eDry
    {
        public eDry() { }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int KeyID { get; set; }

        public string Code { get; set; }

        public DateTime DateIn { get; set; }

        public int IDCustomer { get; set; }

        public string CustomerName { get; set; }

        public int IDKilnDry { get; set; }

        public string KilnName { get; set; }

        public int IDProduct { get; set; }

        public string ProductName { get; set; }

        public int IDFactory { get; set; }

        public string FactoryName { get; set; }

        public decimal TotalKG { get; set; }

        public decimal PriceCustomer { get; set; }

        public decimal TotalPriceCustomer { get; set; }

        //Sấy

        public int IDWorkerSay { get; set; }

        public string WorkerSay { get; set; }

        public int IDTaskSay { get; set; }

        public string TaskSay { get; set; }

        public decimal PriceSay { get; set; }

        public decimal TotalPriceSay { get; set; }

        //Xúc

        public int IDWorkerXuc { get; set; }

        public string WorkerXuc { get; set; }

        public int IDTaskXuc { get; set; }

        public string TaskXuc { get; set; }

        public decimal PriceXuc { get; set; }

        public decimal TotalPriceXuc { get; set; }

        public bool IsEnable { get; set; }

        public int CreatedBy { get; set; }

        public DateTime CreatedDate { get; set; }

        public int? ModifiedBy { get; set; }

        public DateTime? ModifiedDate { get; set; }

        [StringLength(255)]
        public string Note { get; set; }

        public int IDAgency { get; set; }
    }
}
