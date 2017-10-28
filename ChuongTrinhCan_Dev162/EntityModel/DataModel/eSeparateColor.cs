namespace EntityModel.DataModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("eSeparateColor")]
    public partial class eSeparateColor
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public eSeparateColor()
        {
        }

        [Key]
        public int KeyID { get; set; }

        [Required]
        [StringLength(50)]
        public string Code { get; set; }

        public bool IsEnable { get; set; }

        public DateTime DateIn { get; set; }

        public int CreatedBy { get; set; }

        public DateTime CreatedDate { get; set; }

        public int? ModifiedBy { get; set; }

        public DateTime? ModifiedDate { get; set; }

        [StringLength(255)]
        public string Note { get; set; }

        public int IDAgency { get; set; }

        public int IDCustomer { get; set; }

        public int IDFactory { get; set; }

        public int IDProduct { get; set; }

        public int IDTask { get; set; }

        public string CustomerName { get; set; }

        public string FactoryName { get; set; }

        public string ProductName { get; set; }

        public string TaskName { get; set; }

        public decimal TotalNumber { get; set; }

        public int IDWorkerTM { get; set; }

        public int IDWorkerTTP { get; set; }

        public string IDAddTask { get; set; }

        public decimal GaoBao { get; set; }

        public decimal GaoKg { get; set; }

        public decimal TamBao { get; set; }

        public decimal TamKg { get; set; }

        public decimal PheBao { get; set; }

        public decimal PheKg { get; set; }

        public decimal PriceTM { get; set; }

        public decimal PriceTI { get; set; }

        public decimal Price { get; set; }

        public decimal TotalPrice { get; set; }
    }
}
