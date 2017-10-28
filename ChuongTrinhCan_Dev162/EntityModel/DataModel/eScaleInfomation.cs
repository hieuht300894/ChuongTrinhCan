namespace EntityModel.DataModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("eScaleInfomation")]
    public partial class eScaleInfomation
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public eScaleInfomation()
        {
        }

        [Key]
        public int KeyID { get; set; }

        public string Code { get; set; }

        public string VehicleNumber { get; set; }

        public int IDCustomer { get; set; }

        public string CustomerName { get; set; }

        public int IDProduct { get; set; }

        public string ProductName { get; set; }

        public int IDWarehouse { get; set; }

        public string WarehouseName { get; set; }

        public decimal Weight1 { get; set; }

        public decimal Weight2 { get; set; }

        public decimal WeightProduct { get; set; }

        public decimal Price { get; set; }

        public decimal TotalPrice { get; set; }

        public bool IsImport { get; set; }

        public bool IsExport { get; set; }

        public string ExportName { get; set; }

        public DateTime DateScale1 { get; set; }

        public DateTime? DateScale2 { get; set; }

        public DateTime CreatedDate { get; set; }

        [StringLength(255)]
        public string Note { get; set; }

        public bool IsEnable { get; set; }

        public int Status { get; set; }

        public bool IsSend { get; set; }

        public int IDAgency { get; set; }
    }
}

