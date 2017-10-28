namespace EntityModel.DataModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("eConfigWorkerDry")]
    public partial class eConfigWorkerDry
    {
        public eConfigWorkerDry()
        {
            eDetailConfigWorkerDries = new HashSet<eDetailConfigWorkerDry>();
        }

        [Key]
        public int KeyID { get; set; }

        public int IDTaskGroup { get; set; }

        public string WorkerName { get; set; }

        public string ListTask { get; set; }

        public int IDAgency { get; set; }

        public string ListKilnDry { get; set; }

        public string ListSay { get; set; }

        public string ListXuc { get; set; }

        public int IDTaskBVVL { get; set; }

        public int IDTaskBVRL { get; set; }

        public int IDParentBVVL { get; set; }

        public int IDParentBVRL { get; set; }

        public string TaskNameVL { get; set; }

        public string TaskNameRL { get; set; }

        public bool IsEnable { get; set; }

        public int CreatedBy { get; set; }

        public DateTime CreatedDate { get; set; }

        public int? ModifiedBy { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public virtual ICollection<eDetailConfigWorkerDry> eDetailConfigWorkerDries { get; set; }
    }
}
