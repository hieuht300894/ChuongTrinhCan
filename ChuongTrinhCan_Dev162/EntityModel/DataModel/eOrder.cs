namespace EntityModel.DataModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("eOrder")]
    public partial class eOrder
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public eOrder()
        {
            eOrderDetails = new HashSet<eOrderDetail>();
        }

        [Key]
        public int KeyID { get; set; }

        [Required]
        [StringLength(50)]
        public string Code { get; set; }

        public string Document { get; set; }

        public int IDCustomer { get; set; }

        [StringLength(100)]
        public string VehicleNumber { get; set; }

        public decimal NumberKGPort { get; set; }

        public bool IsEnable { get; set; }

        public int CreatedBy { get; set; }

        public DateTime CreatedDate { get; set; }

        public int? ModifiedBy { get; set; }

        public DateTime? ModifiedDate { get; set; }

        [StringLength(255)]
        public string Note { get; set; }

        public int IDAgency { get; set; }

        public int? IDTaskGroup { get; set; }

        public int IDTaskCategory { get; set; }

        public virtual eCustomer eCustomer { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<eOrderDetail> eOrderDetails { get; set; }

    }
}
