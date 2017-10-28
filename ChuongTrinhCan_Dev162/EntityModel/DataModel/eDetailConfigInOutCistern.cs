namespace EntityModel.DataModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("eDetailConfigInOutCistern")]
    public partial class eDetailConfigInOutCistern
    {
        [Key]
        public int KeyID { get; set; }

        public int IDWorker { get; set; }

        public int IDTask { get; set; }

        public int IDParent { get; set; }

        public int IDTaskCate { get; set; }

        public int IDAgency { get; set; }

        public bool IsVoBon { get; set; }

        public bool IsEnable { get; set; }

        public int IDConfigInOutCistern { get; set; }

        public virtual eConfigInOutCistern eConfigInOutCistern { get; set; }
    }
}
