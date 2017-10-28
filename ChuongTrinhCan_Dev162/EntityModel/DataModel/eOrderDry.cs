namespace EntityModel.DataModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("eOrderDry")]
    public partial class eOrderDry
    {
        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        //public eOrderDry()
        //{
        //}

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IDBillOrderDry { get; set; }

        public DateTime CreatedDate { get; set; }

        public string WorkerName { get; set; }

        public string TaskName { get; set; }

        public string CustomerName { get; set; }

        public string KilnDryName { get; set; }

        public string ProductName { get; set; }

        public decimal TotalKG { get; set; }

        public decimal PriceTask { get; set; }

        public decimal PriceCustomer { get; set; }

        public decimal TotalPriceTask { get; set; }

        public decimal TotalPriceCustomer { get; set; }

        public bool IsEnable { get; set; }

        public int CreatedBy { get; set; }

        [StringLength(255)]
        public string Note { get; set; }

        public int IDAgency { get; set; }

        public virtual eBillOrderDry eBillOrderDry { get; set; }
    }
}
