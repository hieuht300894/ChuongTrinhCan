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

        public virtual DbSet<eCustomer> eCustomers { get; set; }
        public virtual DbSet<eProduct> eProducts { get; set; }
        public virtual DbSet<eWarehouse> eWarehouses { get; set; }
        public virtual DbSet<eCustomerScale> eCustomerScales { get; set; }
        public virtual DbSet<eProductScale> eProductScales { get; set; }
        public virtual DbSet<eWarehouseScale> eWarehouseScales { get; set; }
        public virtual DbSet<eScaleInfomation> eScaleInfomations { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
           
        }
    }
}
