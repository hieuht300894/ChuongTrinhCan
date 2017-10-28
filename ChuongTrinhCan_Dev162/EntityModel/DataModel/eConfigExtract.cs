namespace EntityModel.DataModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("eConfigExtract")]
    public partial class eConfigExtract
    {
        [Key]
        public int KeyID { get; set; }

        public int IDFactory { get; set; }

        public int IDTypeExtract { get; set; }

        public int IDProduct { get; set; }

        public int IDUnit { get; set; }

        public decimal Weight { get; set; }

        public bool IsEnable { get; set; }

        public virtual eFactory eFactory { get; set; }

        public virtual eTypeExtract eTypeExtract { get; set; }

        public virtual eUnit eUnit { get; set; }
    }
}
