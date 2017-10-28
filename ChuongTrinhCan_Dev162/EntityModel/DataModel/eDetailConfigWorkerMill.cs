namespace EntityModel.DataModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("eDetailConfigWorkerMill")]
    public partial class eDetailConfigWorkerMill
    {
        [Key]
        public int KeyID { get; set; }

        public int IDWorkerGang { get; set; }

        public int IDWorkerTinhChinh { get; set; }

        public int IDWorkerTinhPhu { get; set; }

        public int IDTask { get; set; }

        public int IDParent { get; set; }

        //public int IDTaskCate { get; set; }

        public int IDConfigWorkerMill { get; set; }

        public bool IsEnable { get; set; }

        public virtual eConfigWorkerMill eConfigWorkerMill { get; set; }

        //public virtual eTask eTask { get; set; }
    }
}
