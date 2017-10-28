namespace EntityModel.DataModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("eUnit")]
    public partial class eUnit
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public eUnit()
        {
            eConfigExtracts = new HashSet<eConfigExtract>();
            eExportExtracts = new HashSet<eExportExtract>();
        }

        [Key]
        public int KeyID { get; set; }

        [Required]
        [StringLength(50)]
        public string Code { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        public decimal Weight { get; set; }

        public bool IsEnable { get; set; }

        [StringLength(255)]
        public string Note { get; set; }

        public int IDUnitCate { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<eConfigExtract> eConfigExtracts { get; set; }

        public virtual eUnitCategory eUnitCategory { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<eExportExtract> eExportExtracts { get; set; }
    }
}
