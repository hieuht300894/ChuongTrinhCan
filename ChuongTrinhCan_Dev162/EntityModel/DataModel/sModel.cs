namespace EntityModel.DataModel
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class sModel : DbContext
    {
        public sModel()
            : base(Module.dbConnectString_Server)
        {
        }

        public sModel(string conn)
            : base(conn)
        {
        }

        public virtual DbSet<eCustomer> eCustomer { get; set; }
        public virtual DbSet<eProduct> eProduct { get; set; }
        public virtual DbSet<eWarehouse> eWarehouse { get; set; }
        public virtual DbSet<eCustomerScale> eCustomerScale { get; set; }
        public virtual DbSet<eProductScale> eProductScale { get; set; }
        public virtual DbSet<eWarehouseScale> eWarehouseScale { get; set; }
        public virtual DbSet<eScaleInfomation> eScaleInfomation { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
           
        }
    }
}
