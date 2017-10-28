namespace EntityModel.DataModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("eContraKiln")]
    public partial class eContraKiln
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]

        [Key]
        public int KeyID { get; set; }

        public int IDFactory { get; set; }

        public string FactoryName { get; set; }

        public int IDKiln { get; set; }

        public string KilnName { get; set; }

        public decimal OutputRemain { get; set; }

        public decimal Input { get; set; }

        public decimal Output { get; set; }

        public decimal Remain { get; set; }

        public decimal InputRemain { get; set; }

        public int IDAgency { get; set; }
    }
}
