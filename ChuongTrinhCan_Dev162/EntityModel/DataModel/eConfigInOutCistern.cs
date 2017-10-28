namespace EntityModel.DataModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("eConfigInOutCistern")]
    public partial class eConfigInOutCistern
    {
        public eConfigInOutCistern()
        {
            eDetailConfigInOutCisterns = new HashSet<eDetailConfigInOutCistern>();
        }

        [Key]
        public int KeyID { get; set; }

        public int IDWorker { get; set; }

        public string WorkerName { get; set; }

        public int IDTaskVB { get; set; }

        public int IDTaskRB { get; set; }

        public int IDParentVB { get; set; }

        public int IDParentRB { get; set; }

        public string TaskNameVB { get; set; }

        public string TaskNameRB { get; set; }

        public int IDAgency { get; set; }

        public int IDFactory { get; set; }

        public bool IsEnable { get; set; }

        public int CreatedBy { get; set; }

        public DateTime CreatedDate { get; set; }

        public int? ModifiedBy { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public virtual ICollection<eDetailConfigInOutCistern> eDetailConfigInOutCisterns { get; set; }
    }
}
