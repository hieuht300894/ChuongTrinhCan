namespace EntityModel.DataModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("eConfigWorkerMill")]
    public partial class eConfigWorkerMill
    {
        public eConfigWorkerMill()
        {
            eDetailConfigWorkerMills = new HashSet<eDetailConfigWorkerMill>();
        }

        [Key]
        public int KeyID { get; set; }

        public int IDWorkerGang { get; set; }

        public string WorkerGang { get; set; }

        public int IDWorkerTinhChinh { get; set; }

        public string WorkerTinhChinh { get; set; }

        public int IDWorkerTinhPhu { get; set; }

        public string WorkerTinhPhu { get; set; }

        public int IDTask { get; set; }

        public int IDParent { get; set; }

        public string TaskName { get; set; }

        public int IDAgency { get; set; }

        public bool IsEnable { get; set; }

        public bool IsDefault { get; set; }

        public int IDFactory { get; set; }

        public int CreatedBy { get; set; }

        public DateTime CreatedDate { get; set; }

        public int? ModifiedBy { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public virtual ICollection<eDetailConfigWorkerMill> eDetailConfigWorkerMills { get; set; }
    }
}
