namespace EntityModel.DataModel
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class zModel : DbContext
    {
        public zModel()
            : base(Module.dbConnectString_Client)
        {
        }

        public zModel(string conn)
            : base(conn)
        {
        }

        public virtual DbSet<eAgency> eAgency { get; set; }
        public virtual DbSet<eCustomer> eCustomer { get; set; }
        public virtual DbSet<eProduct> eProduct { get; set; }
        public virtual DbSet<eWarehouse> eWarehouse { get; set; }
        public virtual DbSet<eScaleInfomation> eScaleInfomation { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
         
        }
    }
}
