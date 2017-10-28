namespace EntityModel.DataModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("eHistoryCistern")]
    public partial class eHistoryCistern
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]

        [Key]
        public int KeyID { get; set; }

        public DateTime DateCreated { get; set; }

        public int IDBillPort { get; set; }

        public int IDMill { get; set; }

        public int IDCustomer { get; set; }

        public string CustomerName { get; set; }

        public int IDProduct { get; set; }

        public string ProductName { get; set; }

        public decimal Weight { get; set; }

        public int IDTask { get; set; }

        public string TaskName { get; set; }

        public int IDCistern { get; set; }

        public string CisternName { get; set; }

        public bool IsVoBon { get; set; }

        public bool IsRaBon { get; set; }

        public bool IsEnable { get; set; }

        public int IDFactory { get; set; }

        public string FactoryName { get; set; }

        public int IDAgency { get; set; }

        public bool IsWarming { get; set; }

        public string IDRaBon { get; set; }
    }
}
