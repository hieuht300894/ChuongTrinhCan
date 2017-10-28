namespace EntityModel.DataModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("eOrderRemain")]
    public partial class eOrderRemain
    {
        [Key]
        public int KeyID { get; set; }

        public decimal Order { get; set; }

        public decimal In { get; set; }

        public decimal Out { get; set; }

        public decimal Remain { get; set; }

        public decimal Remain_Pre { get; set; }

        [Column("_Date")]
        public DateTime C_Date { get; set; }
    }
}
