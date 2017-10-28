namespace EntityModel.DataModel
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("ePort")]
    public partial class ePort
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ePort()
        {
        }

        [Key]
        public int KeyID { get; set; }

        public string Code { get; set; }

        public DateTime DateIn { get; set; }

        public int IDWorker { get; set; }

        public string WorkerName { get; set; }

        public int IDTask { get; set; }

        public string TaskName { get; set; }

        public int IDCustomer { get; set; }

        public string CustomerName { get; set; }

        public int IDKilnDry { get; set; }

        public string KilnName { get; set; }

        public string IDCisterns { get; set; }

        public string CisternsName { get; set; }

        public int IDProduct { get; set; }

        public string ProductName { get; set; }

        public int IDFactory { get; set; }

        public string FactoryName { get; set; }

        public decimal TotalKG { get; set; }

        public decimal Price { get; set; }

        public decimal TotalPrice { get; set; }

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
