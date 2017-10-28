namespace EntityModel.DataModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("eConfigWorkerExtract")]
    public partial class eConfigWorkerExtract
    {
        [Key]
        public int KeyID { get; set; }

        public int IDTaskGroupEp { get; set; }

        public int IDTaskEp { get; set; }

        public int IDTypeExtract { get; set; }

        public int IDProduct { get; set; }

        public int? IDTypeRecRet { get; set; }// Nhận hoặc trả

        public int? IDTaskGroupPort { get; set; }

        public int IDFactory { get; set; }

        public int IDAgency { get; set; }

        public string ListDay { get; set; }

        public bool IsEnable { get; set; }

        public int CreatedBy { get; set; }

        public DateTime CreatedDate { get; set; }

        public int? ModifiedBy { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public virtual eTaskGroup eTaskGroupEp { get; set; }

        public virtual eTaskGroup eTaskGroupPort { get; set; }
    }
}
