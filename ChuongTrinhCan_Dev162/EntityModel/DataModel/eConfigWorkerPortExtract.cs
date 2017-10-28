namespace EntityModel.DataModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("eConfigWorkerPortExtract")]
    public partial class eConfigWorkerPortExtract
    {
        public eConfigWorkerPortExtract()
        {
            eDetailConfigWorkerPortExtracts = new HashSet<eDetailConfigWorkerPortExtract>();
        }

        [Key]
        public int KeyID { get; set; }

        public int IDWorker{ get; set; }

        public string WorkerName { get; set; }

        public int IDAgency { get; set; }

        public int IDTask { get; set; }

        public int IDParent { get; set; }

        public string TaskName { get; set; }

        public bool IsEnable { get; set; }

        public int IDProduct { get; set; }

        public string ProductName { get; set; }

        public int IDFactory { get; set; }

        public int CreatedBy { get; set; }

        public DateTime CreatedDate { get; set; }

        public int? ModifiedBy { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public virtual ICollection<eDetailConfigWorkerPortExtract> eDetailConfigWorkerPortExtracts { get; set; }
    }
}
