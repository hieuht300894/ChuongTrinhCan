namespace EntityModel.DataModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("eTask")]
    public partial class eTask
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public eTask()
        {
            eDetailTaskGroups = new HashSet<eDetailTaskGroup>();
            eExtracts = new HashSet<eExtract>();
            eTaskPrices = new HashSet<eTaskPrice>();
            eDetailConfigWorkerDryBVs = new HashSet<eDetailConfigWorkerDry>();
            eDetailConfigWorkerDrySays = new HashSet<eDetailConfigWorkerDry>();
            eDetailConfigWorkerDryXucs = new HashSet<eDetailConfigWorkerDry>();
        }

        [Key]
        public int KeyID { get; set; }

        [Required]
        [StringLength(50)]
        public string Code { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        public decimal Price { get; set; }

        public bool IsEnable { get; set; }

        public int CreatedBy { get; set; }

        public DateTime CreatedDate { get; set; }

        public int? ModifiedBy { get; set; }

        public DateTime? ModifiedDate { get; set; }

        [StringLength(255)]
        public string Note { get; set; }

        public int IDAgency { get; set; }

        public string ListTask { get; set; }

        public string IDTaskCate { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<eDetailTaskGroup> eDetailTaskGroups { get; set; }


        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<eExtract> eExtracts { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<eTaskPrice> eTaskPrices { get; set; }


        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<eDetailConfigWorkerDry> eDetailConfigWorkerDrySays { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<eDetailConfigWorkerDry> eDetailConfigWorkerDryXucs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<eDetailConfigWorkerDry> eDetailConfigWorkerDryBVs { get; set; }
    }
}
