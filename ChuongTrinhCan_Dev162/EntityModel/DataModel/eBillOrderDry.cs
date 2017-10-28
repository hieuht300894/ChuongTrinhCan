namespace EntityModel.DataModel
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("eBillOrderDry")]
    public partial class eBillOrderDry
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public eBillOrderDry()
        {
        }

        [Key]
        public int KeyID { get; set; }

        public string Code { get; set; }

        public DateTime? CreatedDate { get; set; }

        public int? IDTaskGroup { get; set; }

        public int IDTask { get; set; }

        public int? IDCustomer { get; set; }

        public int? IDKilnDry { get; set; }

        public string IDCisterns { get; set; }

        public int? IDProduct { get; set; }

        public int IDFactory { get; set; }

        public decimal TotalKG { get; set; }

        public decimal PriceTask  { get; set; }

        public decimal PriceCustomer { get; set; }

        public decimal TotalPriceTask { get; set; }

        public decimal TotalPriceCustomer { get; set; }

        //Sấy
        public DateTime? DateIn { get; set; }

        public int IDWorkerSay { get; set; }

        public int IDTaskSay { get; set; }

        public decimal PriceSay { get; set; }

        public decimal TotalPriceSay { get; set; }

        //Xúc
        public DateTime? DateOut { get; set; }

        public int IDWorkerXuc { get; set; }

        public int IDTaskXuc { get; set; }

        public decimal PriceXuc { get; set; }

        public decimal TotalPriceXuc { get; set; }

        public bool IsEnable { get; set; }

        public int CreatedBy { get; set; }

        [StringLength(255)]
        public string Note { get; set; }

        public int IDAgency { get; set; }

        public DateTime? DateClosed { get; set; }
    }
}
