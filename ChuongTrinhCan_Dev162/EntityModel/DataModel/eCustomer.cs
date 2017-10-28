namespace EntityModel.DataModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("eCustomer")]
    public partial class eCustomer
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public eCustomer()
        {
            eOrders = new HashSet<eOrder>();
            eWarehouseIns = new HashSet<eWarehouseIn>();
            eWarehouseMills = new HashSet<eWarehouseMill>();
            eWarehouseOuts = new HashSet<eWarehouseOut>();
        }

        [Key]
        public int KeyID { get; set; }

        [Required]
        [StringLength(50)]
        public string Code { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(100)]
        public string Address { get; set; }

        [StringLength(50)]
        public string Contact { get; set; }

        public bool IsScale { get; set; }

        public int Status { get; set; }

        public bool IsEnable { get; set; }

        public bool IsSend { get; set; }

        public int CreatedBy { get; set; }

        public DateTime CreatedDate { get; set; }

        public int? ModifiedBy { get; set; }

        public DateTime? ModifiedDate { get; set; }

        [StringLength(255)]
        public string Note { get; set; }

        public int IDAgency { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<eOrder> eOrders { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<eWarehouseIn> eWarehouseIns { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<eWarehouseMill> eWarehouseMills { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<eWarehouseOut> eWarehouseOuts { get; set; }

    }
}
