namespace EntityModel.DataModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("eDetailConfigWorkerDry")]
    public partial class eDetailConfigWorkerDry
    {
        [Key]
        public int KeyID { get; set; }

        public int IDKilnDry { get; set; }

        public int? IDWorkerBV { get; set; }

        public int? IDWorkerSay { get; set; }

        public int? IDWorkerXuc { get; set; }

        public int? IDTaskBV { get; set; }

        public int? IDTaskSay { get; set; }

        public int? IDTaskXuc { get; set; }

        public int IDParent { get; set; }

        public int IDTaskCate { get; set; }

        public int IDAgency { get; set; }

        public bool IsVoLo { get; set; }

        public bool IsEnable { get; set; }

        public int IDConfigWorkerDry { get; set; }

        public virtual eConfigWorkerDry eConfigWorkerDry { get; set; }

        public virtual eTask eTaskSay { get; set; }

        public virtual eTask eTaskXuc { get; set; }

        public virtual eTask eTaskBV { get; set; }

        public virtual eTaskGroup eTaskGroupSay { get; set; }

        public virtual eTaskGroup eTaskGroupXuc { get; set; }

        public virtual eTaskGroup eTaskGroupBV { get; set; }
    }
}
