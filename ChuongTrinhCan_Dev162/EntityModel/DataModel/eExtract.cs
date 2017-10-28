namespace EntityModel.DataModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("eExtract")]
    public partial class eExtract
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public eExtract()
        {
        }

        [Key]
        public int KeyID { get; set; }

        public string Code { get; set; }

        public int IDWorker { get; set; }

        public int IDTask { get; set; }

        public int IDTypeExtract { get; set; }

        public int IDProduct { get; set; }

        public string ProductName { get; set; }

        public decimal OutputPacket { get; set; }

        public decimal ReceivePacket { get; set; }

        public decimal ReturnPacket { get; set; }

        public bool IsEnable { get; set; }

        public DateTime DateIn { get; set; }

        public int CreatedBy { get; set; }

        public DateTime CreatedDate { get; set; }

        public int? ModifiedBy { get; set; }

        public DateTime? ModifiedDate { get; set; }

        [StringLength(255)]
        public string Note { get; set; }

        public int IDAgency { get; set; }

        public int IDFactory { get; set; }

        public int IDUnit { get; set; }

        public decimal Weight { get; set; }

        public decimal Price { get; set; }

        public decimal TotalPrice { get; set; }

        public virtual eTask eTask { get; set; }

        public virtual eTypeExtract eTypeExtract { get; set; }

        public virtual eFactory eFactory { get; set; }

        public virtual eTaskGroup eTaskGroup { get; set; }
    }
}
