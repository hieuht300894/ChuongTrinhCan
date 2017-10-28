namespace EntityModel.DataModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("eDetailConfigWorkerSeparate")]
    public partial class eDetailConfigWorkerSeparate
    {
        [Key]
        public int KeyID { get; set; }

        public int IDWorkerTach { get; set; }

        public int IDWorkerTinh { get; set; }

        public int IDTask { get; set; }

        public int IDParent { get; set; }

        //public int IDTaskCate { get; set; }

        public int IDConfigWorkerSeparate { get; set; }

        public bool IsEnable { get; set; }

        public virtual eConfigWorkerSeparateColor eConfigWorkerSeparate { get; set; }

        //public virtual eTask eTask { get; set; }
    }
}
