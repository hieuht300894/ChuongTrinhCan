namespace EntityModel.DataModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("eDetailTaskGroup")]
    public partial class eDetailTaskGroup
    {
        [Key]
        public int KeyID { get; set; }

        public int IDTaskGroup { get; set; }

        public int IDTask { get; set; }

        public int IDParent { get; set; }

        public int IDTaskCate { get; set; }

        public bool IsEnable { get; set; }

        public int CreatedBy { get; set; }

        public DateTime CreatedDate { get; set; }

        public int? ModifiedBy { get; set; }

        public DateTime? ModifiedDate { get; set; }

        [StringLength(255)]
        public string Note { get; set; }

        public int IDAgency { get; set; }

        public virtual eTask eTask { get; set; }

        public virtual eTaskGroup eTaskGroup { get; set; }
    }
}
