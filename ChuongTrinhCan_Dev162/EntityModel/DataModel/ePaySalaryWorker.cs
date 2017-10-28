namespace EntityModel.DataModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ePaySalaryWorker")]
    public partial class ePaySalaryWorker
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ePaySalaryWorker()
        {
        }

        [Key]
        public int KeyID { get; set; }

        public DateTime DateClosed { get; set; }

        public DateTime? DateFrom { get; set; }

        public DateTime DateTo { get; set; }

        public int IDWorker { get; set; }

        public string WorkerName { get; set; }

        public decimal Weight { get; set; }

        public decimal TotalPrice { get; set; }

        public decimal Paid { get; set; }

        public decimal OtherPaid { get; set; }

        public decimal Debit { get; set; }

        public decimal Pay { get; set; }

        public decimal OtherPay { get; set; }

        public int IDAgency { get; set; }

        public int IDFactory { get; set; }

        public string FactoryName { get; set; }

        public int IDTaskCate { get; set; }

        public string TaskCateName { get; set; }

        public string Note { get; set; }

        public bool IsCancel { get; set; }
    }
}
