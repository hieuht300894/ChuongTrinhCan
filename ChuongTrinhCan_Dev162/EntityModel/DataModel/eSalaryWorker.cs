namespace EntityModel.DataModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("eSalaryWorker")]
    public partial class eSalaryWorker
    {
        [Key]
        public int KeyID { get; set; }

        public int IDWorker { get; set; }

        public int IDTask { get; set; }

        public decimal Weight { get; set; }

        public decimal Price { get; set; }

        public decimal OtherPrice { get; set; }

        public decimal TotalSalary { get; set; }

        public DateTime? DateClosed { get; set; }

        public DateTime DateIn { get; set; }

        public int CreatedBy { get; set; }

        public DateTime CreatedDate { get; set; }

        public int? ModifiedBy { get; set; }

        public DateTime? ModifiedDate { get; set; }

        [StringLength(255)]
        public string Note { get; set; }

        public int IDAgency { get; set; }

        public int IDOrder { get; set; }

        public int IDDry { get; set; }

        public int IDMill { get; set; }

        public int IDSeparate { get; set; }

        public int IDExtract { get; set; }

        public int IDPort { get; set; }

        public bool IsEnable { get; set; }

        public int IDFactory { get; set; }

        public int STT { get; set; }

        public int IDTaskCate { get; set; }
    }
}
