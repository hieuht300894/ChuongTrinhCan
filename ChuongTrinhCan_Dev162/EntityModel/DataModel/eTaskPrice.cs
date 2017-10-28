namespace EntityModel.DataModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("eTaskPrice")]
    public partial class eTaskPrice
    {
        [Key]
        public int KeyID { get; set; }

        public int IDTask { get; set; }

        public int IDTaskCategory { get; set; }

        public decimal Price { get; set; }

        public int IDAgency { get; set; }

        public bool IsEnable { get; set; }

        public virtual eTask eTask { get; set; }
    }
}
