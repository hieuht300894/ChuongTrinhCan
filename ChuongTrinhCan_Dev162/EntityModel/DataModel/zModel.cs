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

        public virtual DbSet<eAgency> eAgencies { get; set; }
        public virtual DbSet<eCustomer> eCustomers { get; set; }
        public virtual DbSet<eProduct> eProducts { get; set; }
        public virtual DbSet<eWarehouse> eWarehouses { get; set; }
        public virtual DbSet<eScaleInfomation> eScaleInfomations { get; set; }
        public virtual DbSet<eVehicleEmpty> eVehicleEmpties { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
         
        }
    }
}
