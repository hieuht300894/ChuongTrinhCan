namespace EntityModel.DataModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("eDetailConfigWorkerPortExtract")]
    public partial class eDetailConfigWorkerPortExtract
    {
        [Key]
        public int KeyID { get; set; }

        public int IDWorker { get; set; }

        public int IDTask { get; set; }

        public int IDParent { get; set; }

        public int IDTaskCate { get; set; }

        public int IDAgency { get; set; }

        public bool IsEnable { get; set; }

        public int IDConfigWorkerPortExtract { get; set; }

        public virtual eConfigWorkerPortExtract eConfigWorkerPortExtract { get; set; }

    }
}
