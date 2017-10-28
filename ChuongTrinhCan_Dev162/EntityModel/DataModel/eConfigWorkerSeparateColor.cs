namespace EntityModel.DataModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("eConfigWorkerSeparateColor")]
    public partial class eConfigWorkerSeparateColor
    {
        public eConfigWorkerSeparateColor()
        {
            eDetailConfigWorkerSeparates = new HashSet<eDetailConfigWorkerSeparate>();
        }

        [Key]
        public int KeyID { get; set; }

        //public int IDTaskGroupGH { get; set; }

        public int IDWorkerTach { get; set; }

        public string WorkerTach { get; set; }

        public int IDWorkerTinh { get; set; }

        public string WorkerTinh { get; set; }

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

        //public virtual eTaskGroup eTaskGroupGH { get; set; }

        //public virtual eTaskGroup eTaskGroupTach { get; set; }

        //public virtual eTaskGroup eTaskGroupTinh { get; set; }

        public virtual ICollection<eDetailConfigWorkerSeparate> eDetailConfigWorkerSeparates { get; set; }
    }
}
