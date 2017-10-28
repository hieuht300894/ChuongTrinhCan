namespace EntityModel.DataModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("eMill")]
    public partial class eMill
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public eMill()
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

        public int IDProduct { get; set; }

        public int IDFactory { get; set; }

        public int IDTask { get; set; }

        public string CustomerName { get; set; }

        public string FactoryName { get; set; }

        public string ProductName { get; set; }

        public string TaskName { get; set; }

        public string IDCisterns { get; set; }

        public decimal GaoBao { get; set; }

        public decimal GaoKg { get; set; }

        public decimal Tam1Bao { get; set; }

        public decimal Tam1Kg { get; set; }

        public decimal CamBao { get; set; }

        public decimal CamKg { get; set; }

        public decimal Tam2Kg { get; set; }

        public decimal BL { get; set; }

        public decimal Phe { get; set; }

        public decimal TotalNumber { get; set; }

        public decimal Price { get; set; }

        public decimal PriceG { get; set; }

        public decimal PriceTC { get; set; }

        public decimal PriceTP { get; set; }

        public int IDWorkerG { get; set; }

        public int IDWorkerTTP { get; set; }

        public int IDWorkerTTP2 { get; set; }

        public string IDAddTaskTC { get; set; }

        public string IDAddTaskTP { get; set; }

        public decimal TotalPrice { get; set; }
    }
}
