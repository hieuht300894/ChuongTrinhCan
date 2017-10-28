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

        public virtual DbSet<eAccount> eAccounts { get; set; }
        public virtual DbSet<eAgency> eAgencies { get; set; }
        public virtual DbSet<eBillOrderDry> eBillOrderDries { get; set; }
        public virtual DbSet<eConfigExtract> eConfigExtracts { get; set; }
        public virtual DbSet<eConfigWorkerDry> eConfigWorkerDries { get; set; }
        public virtual DbSet<eConfigWorkerExtract> eConfigWorkerExtracts { get; set; }
        public virtual DbSet<eConfigWorkerMill> eConfigWorkerMills { get; set; }
        public virtual DbSet<eConfigWorkerSeparateColor> eConfigWorkerSeparateColors { get; set; }
        public virtual DbSet<eConfigWorkerPortExtract> eConfigWorkerPortExtracts { get; set; }
        public virtual DbSet<eCustomer> eCustomers { get; set; }
        public virtual DbSet<eContraKiln> eContraKilns { get; set; }
        public virtual DbSet<ePayDebitCustomer> ePayDebitCustomers { get; set; }
        public virtual DbSet<eDetailTaskGroup> eDetailTaskGroups { get; set; }
        public virtual DbSet<eDetailConfigWorkerMill> eDetailConfigWorkerMills { get; set; }
        public virtual DbSet<eDetailConfigWorkerDry> eDetailConfigWorkerDries { get; set; }
        public virtual DbSet<eDetailConfigWorkerSeparate> eDetailConfigWorkerSeparates { get; set; }
        public virtual DbSet<eDetailConfigWorkerPortExtract> eDetailConfigWorkerPortExtracts { get; set; }
        public virtual DbSet<eDry> eDries { get; set; }
        public virtual DbSet<eExportExtract> eExportExtracts { get; set; }
        public virtual DbSet<eExportMill> eExportMills { get; set; }
        public virtual DbSet<eExtract> eExtracts { get; set; }
        public virtual DbSet<eFactory> eFactories { get; set; }
        public virtual DbSet<eKilnDry> eKilnDries { get; set; }
        public virtual DbSet<eMill> eMills { get; set; }
        public virtual DbSet<eOrder> eOrders { get; set; }
        public virtual DbSet<eOrderDry> eOrderDries { get; set; }
        public virtual DbSet<ePaymentVoucher> ePaymentVouchers { get; set; }
        public virtual DbSet<ePaySalaryWorker> ePaySalaryWorkers { get; set; }
        public virtual DbSet<ePersonnel> ePersonnels { get; set; }
        public virtual DbSet<eProduct> eProducts { get; set; }
        public virtual DbSet<eProvider> eProviders { get; set; }
        public virtual DbSet<eSalaryWorker> eSalaryWorkers { get; set; }
        public virtual DbSet<eSeparateColor> eSeparateColors { get; set; }
        public virtual DbSet<eTask> eTasks { get; set; }
        public virtual DbSet<eTaskGroup> eTaskGroups { get; set; }
        public virtual DbSet<eTaskPrice> eTaskPrice { get; set; }
        public virtual DbSet<eTypeExtract> eTypeExtracts { get; set; }
        public virtual DbSet<eUnit> eUnits { get; set; }
        public virtual DbSet<eUnitCategory> eUnitCategories { get; set; }
        public virtual DbSet<eWarehouseIn> eWarehouseIns { get; set; }
        public virtual DbSet<eWarehouseMill> eWarehouseMills { get; set; }
        public virtual DbSet<eWarehouseOut> eWarehouseOuts { get; set; }
        public virtual DbSet<xAppConfig> xAppConfigs { get; set; }
        public virtual DbSet<xDisplay> xDisplays { get; set; }
        public virtual DbSet<xFeature> xFeatures { get; set; }
        public virtual DbSet<xLayoutItemCaption> xLayoutItemCaptions { get; set; }
        public virtual DbSet<xMsgDictionary> xMsgDictionaries { get; set; }
        public virtual DbSet<xPermission> xPermissions { get; set; }
        public virtual DbSet<xUserFeature> xUserFeatures { get; set; }
        public virtual DbSet<xUserLog> xUserLogs { get; set; }
        public virtual DbSet<eScaleInfomation> eScaleInfomations { get; set; }
        public virtual DbSet<eWarehouse> eWarehouses { get; set; }
        public virtual DbSet<eVehicleEmpty> eVehicleEmpties { get; set; }
        public virtual DbSet<eCistern> eCisternes { get; set; }
        public virtual DbSet<eConfigInOutCistern> eConfigInOutCisterns { get; set; }
        public virtual DbSet<eDetailConfigInOutCistern> eDetailConfigInOutCisterns { get; set; }
        public virtual DbSet<eHistoryCistern> eHistoryCisterns { get; set; }
        public virtual DbSet<eDebitCustomer> eDebitCustomers { get; set; }
        public virtual DbSet<ePort> ePorts { get; set; }
        public virtual DbSet<eSoDuDauKy> eSoDuDauKy { get; set; }
        public virtual DbSet<eCustomerScale> eCustomerScale { get; set; }
        public virtual DbSet<eProductScale> eProductScale { get; set; }
        public virtual DbSet<eWarehouseScale> eWarehouseScale { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<eAccount>()
                .Property(e => e.UserName)
                .IsUnicode(false);

            modelBuilder.Entity<eAccount>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<eAgency>()
                .Property(e => e.Code)
                .IsUnicode(false);

            modelBuilder.Entity<eAgency>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<eCustomer>()
                .HasMany(e => e.eOrders)
                .WithRequired(e => e.eCustomer)
                .HasForeignKey(e => e.IDCustomer)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<eCustomer>()
                .HasMany(e => e.eWarehouseIns)
                .WithRequired(e => e.eCustomer)
                .HasForeignKey(e => e.IDCustomer)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<eCustomer>()
                .HasMany(e => e.eWarehouseMills)
                .WithRequired(e => e.eCustomer)
                .HasForeignKey(e => e.IDCustomer);

            modelBuilder.Entity<eCustomer>()
                .HasMany(e => e.eWarehouseOuts)
                .WithRequired(e => e.eCustomer)
                .HasForeignKey(e => e.IDCustomer)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ePayDebitCustomer>()
                .Property(e => e.Weight)
                .HasPrecision(18, 2);

            modelBuilder.Entity<ePayDebitCustomer>()
                .Property(e => e.TotalPrice)
                .HasPrecision(18, 2);

            modelBuilder.Entity<ePayDebitCustomer>()
                .Property(e => e.Paid)
                .HasPrecision(18, 2);

            modelBuilder.Entity<ePayDebitCustomer>()
                .Property(e => e.Debit)
                .HasPrecision(18, 2);

            modelBuilder.Entity<ePayDebitCustomer>()
                .Property(e => e.Pay)
                .HasPrecision(18, 2);

            modelBuilder.Entity<eFactory>()
                .HasMany(e => e.eConfigExtracts)
                .WithRequired(e => e.eFactory)
                .HasForeignKey(e => e.IDFactory)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<eFactory>()
                .HasMany(e => e.eExtracts)
                .WithRequired(e => e.eFactory)
                .HasForeignKey(e => e.IDFactory);

            modelBuilder.Entity<eKilnDry>()
                .Property(e => e.Capacity)
                .HasPrecision(18, 2);

            modelBuilder.Entity<eMill>()
                .Property(e => e.TotalNumber)
                .HasPrecision(18, 2);

            modelBuilder.Entity<eOrder>()
                .Property(e => e.NumberKGPort)
                .HasPrecision(18, 2);

            modelBuilder.Entity<eOrder>()
                .HasMany(e => e.eOrderDetails)
                .WithRequired(e => e.eOrder)
                .HasForeignKey(e => e.IDOrder)
                .WillCascadeOnDelete(false);


            modelBuilder.Entity<ePaySalaryWorker>()
                .Property(e => e.TotalPrice)
                .HasPrecision(18, 2);

            modelBuilder.Entity<ePaySalaryWorker>()
                .Property(e => e.Paid)
                .HasPrecision(18, 2);

            modelBuilder.Entity<ePaySalaryWorker>()
                .Property(e => e.Debit)
                .HasPrecision(18, 2);

            modelBuilder.Entity<ePaySalaryWorker>()
                .Property(e => e.Pay)
                .HasPrecision(18, 2);

            modelBuilder.Entity<ePersonnel>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<ePersonnel>()
                .Property(e => e.Phone)
                .IsUnicode(false);

            modelBuilder.Entity<ePersonnel>()
                .HasOptional(e => e.eAccount)
                .WithRequired(e => e.ePersonnel);

            modelBuilder.Entity<eProduct>()
                .HasMany(e => e.eOrderDetails)
                .WithRequired(e => e.eProduct)
                .HasForeignKey(e => e.IDProduct)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<eProduct>()
                .HasMany(e => e.eWarehouseIns)
                .WithRequired(e => e.eProduct)
                .HasForeignKey(e => e.IDProduct)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<eProduct>()
                .HasMany(e => e.eWarehouseMills)
                .WithOptional(e => e.eProduct)
                .HasForeignKey(e => e.IDProduct);

            modelBuilder.Entity<eProduct>()
                .HasMany(e => e.eWarehouseOuts)
                .WithRequired(e => e.eProduct)
                .HasForeignKey(e => e.IDProduct)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<eProvider>()
                .Property(e => e.Code)
                .IsUnicode(false);

            modelBuilder.Entity<eProvider>()
                .Property(e => e.Phone)
                .IsUnicode(false);

            modelBuilder.Entity<eProvider>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<eSalaryWorker>()
                .Property(e => e.Price)
                .HasPrecision(18, 2);

            modelBuilder.Entity<eSalaryWorker>()
                .Property(e => e.OtherPrice)
                .HasPrecision(18, 1);

            modelBuilder.Entity<eSalaryWorker>()
                .Property(e => e.TotalSalary)
                .HasPrecision(18, 2);

            modelBuilder.Entity<eSeparateColor>()
                .Property(e => e.TotalNumber)
                .HasPrecision(18, 2);

            modelBuilder.Entity<eTask>()
                .Property(e => e.Price)
                .HasPrecision(18, 2);

            modelBuilder.Entity<eTask>()
                .HasMany(e => e.eDetailTaskGroups)
                .WithRequired(e => e.eTask)
                .HasForeignKey(e => e.IDTask)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<eTask>()
               .HasMany(e => e.eExtracts)
               .WithRequired(e => e.eTask)
               .HasForeignKey(e => e.IDTask);

            modelBuilder.Entity<eTask>()
               .HasMany(e => e.eTaskPrices)
               .WithRequired(e => e.eTask)
               .HasForeignKey(e => e.IDTask);

            modelBuilder.Entity<eTaskGroup>()
                .HasMany(e => e.eConfigWorkerExtractsEp)
                .WithRequired(e => e.eTaskGroupEp)
                .HasForeignKey(e => e.IDTaskGroupEp)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<eTaskGroup>()
                .HasMany(e => e.eConfigWorkerExtractsPort)
                .WithOptional(e => e.eTaskGroupPort)
                .HasForeignKey(e => e.IDTaskGroupPort);

            modelBuilder.Entity<eTaskGroup>()
                .HasMany(e => e.eDetailTaskGroups)
                .WithRequired(e => e.eTaskGroup)
                .HasForeignKey(e => e.IDTaskGroup)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<eTaskPrice>()
                .Property(e => e.Price)
                .HasPrecision(18, 2);

            modelBuilder.Entity<eTypeExtract>()
                .Property(e => e.Price)
                .HasPrecision(18, 2);

            modelBuilder.Entity<eTypeExtract>()
                .HasMany(e => e.eConfigExtracts)
                .WithRequired(e => e.eTypeExtract)
                .HasForeignKey(e => e.IDTypeExtract)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<eTypeExtract>()
                 .HasMany(e => e.eExtracts)
                 .WithRequired(e => e.eTypeExtract)
                 .HasForeignKey(e => e.IDTypeExtract);

            modelBuilder.Entity<eUnit>()
                .Property(e => e.Weight)
                .HasPrecision(18, 2);

            modelBuilder.Entity<eUnit>()
                .HasMany(e => e.eConfigExtracts)
                .WithRequired(e => e.eUnit)
                .HasForeignKey(e => e.IDUnit)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<eUnitCategory>()
                .HasMany(e => e.eUnits)
                .WithRequired(e => e.eUnitCategory)
                .HasForeignKey(e => e.IDUnitCate)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<eWarehouseIn>()
                .Property(e => e.TotalNumber)
                .HasPrecision(18, 2);

            modelBuilder.Entity<eWarehouseOut>()
                .Property(e => e.TotalNumber)
                .HasPrecision(18, 2);

            modelBuilder.Entity<xAppConfig>()
                .Property(e => e.colBinary)
                .IsFixedLength();

            modelBuilder.Entity<xDisplay>()
                .Property(e => e.ParentName)
                .IsUnicode(false);

            modelBuilder.Entity<xDisplay>()
                .Property(e => e.Group)
                .IsUnicode(false);

            modelBuilder.Entity<xDisplay>()
                .Property(e => e.ColumnName)
                .IsUnicode(false);

            modelBuilder.Entity<xDisplay>()
                .Property(e => e.Type)
                .IsUnicode(false);

            modelBuilder.Entity<xDisplay>()
                .Property(e => e.TextAlign)
                .IsUnicode(false);

            modelBuilder.Entity<xFeature>()
                .Property(e => e.KeyID)
                .IsUnicode(false);

            modelBuilder.Entity<xFeature>()
                .Property(e => e.EN)
                .IsUnicode(false);

            modelBuilder.Entity<xFeature>()
                .HasMany(e => e.xUserFeatures)
                .WithOptional(e => e.xFeature)
                .HasForeignKey(e => e.IDFeature);

            modelBuilder.Entity<xLayoutItemCaption>()
                .Property(e => e.FormName)
                .IsUnicode(false);

            modelBuilder.Entity<xLayoutItemCaption>()
                .Property(e => e.LayoutControlName)
                .IsUnicode(false);

            modelBuilder.Entity<xLayoutItemCaption>()
                .Property(e => e.LayoutControlItem)
                .IsUnicode(false);

            modelBuilder.Entity<xLayoutItemCaption>()
                .Property(e => e.EN)
                .IsUnicode(false);

            modelBuilder.Entity<xLayoutItemCaption>()
                .Property(e => e.Visibility)
                .IsUnicode(false);

            modelBuilder.Entity<xLayoutItemCaption>()
                .Property(e => e.TextLocation)
                .IsUnicode(false);

            modelBuilder.Entity<xLayoutItemCaption>()
                .Property(e => e.ControlAlignment)
                .IsUnicode(false);

            modelBuilder.Entity<xMsgDictionary>()
                .Property(e => e.FormName)
                .IsUnicode(false);

            modelBuilder.Entity<xMsgDictionary>()
                .Property(e => e.MsgName)
                .IsUnicode(false);

            modelBuilder.Entity<xMsgDictionary>()
                .Property(e => e.EN)
                .IsUnicode(false);

            modelBuilder.Entity<xPermission>()
                .HasMany(e => e.eAccounts)
                .WithOptional(e => e.xPermission)
                .HasForeignKey(e => e.IDPermission);

            modelBuilder.Entity<xPermission>()
                .HasMany(e => e.xUserFeatures)
                .WithRequired(e => e.xPermission)
                .HasForeignKey(e => e.IDUserRole)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<xUserFeature>()
                .Property(e => e.IDFeature)
                .IsUnicode(false);


            modelBuilder.Entity<eTaskGroup>()
                .HasMany(e => e.eExtracts)
                .WithRequired(e => e.eTaskGroup)
                .HasForeignKey(e => e.IDWorker)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<eTypeExtract>()
                .HasMany(e => e.eExportExtracts)
                .WithRequired(e => e.eTypeExtract)
                .HasForeignKey(e => e.IDTypeExtract)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<eUnit>()
                .HasMany(e => e.eExportExtracts)
                .WithRequired(e => e.eUnit)
                .HasForeignKey(e => e.IDUnit)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<eConfigWorkerMill>()
                .HasMany(e => e.eDetailConfigWorkerMills)
                .WithRequired(e => e.eConfigWorkerMill)
                .HasForeignKey(e => e.IDConfigWorkerMill)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<eExportExtract>()
                .Property(e => e.NumberPacket)
                .HasPrecision(18, 0);

            //--------------------------------------------------------

            modelBuilder.Entity<eConfigWorkerDry>()
                .HasMany(e => e.eDetailConfigWorkerDries)
                .WithRequired(e => e.eConfigWorkerDry)
                .HasForeignKey(e => e.IDConfigWorkerDry)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<eTaskGroup>()
                .HasMany(e => e.eDetailConfigWorkerDryBVs)
                .WithOptional(e => e.eTaskGroupBV)
                .HasForeignKey(e => e.IDWorkerBV)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<eTaskGroup>()
                .HasMany(e => e.eDetailConfigWorkerDrySays)
                .WithOptional(e => e.eTaskGroupSay)
                .HasForeignKey(e => e.IDWorkerSay)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<eTaskGroup>()
                .HasMany(e => e.eDetailConfigWorkerDryXucs)
                .WithOptional(e => e.eTaskGroupXuc)
                .HasForeignKey(e => e.IDWorkerXuc)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<eTask>()
                .HasMany(e => e.eDetailConfigWorkerDryBVs)
                .WithOptional(e => e.eTaskBV)
                .HasForeignKey(e => e.IDTaskBV)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<eTask>()
                .HasMany(e => e.eDetailConfigWorkerDrySays)
                .WithOptional(e => e.eTaskSay)
                .HasForeignKey(e => e.IDTaskSay)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<eTask>()
                .HasMany(e => e.eDetailConfigWorkerDryXucs)
                .WithOptional(e => e.eTaskXuc)
                .HasForeignKey(e => e.IDTaskXuc)
                .WillCascadeOnDelete(false);

            //--------------------------------------------------
            modelBuilder.Entity<eConfigWorkerSeparateColor>()
                .HasMany(e => e.eDetailConfigWorkerSeparates)
                .WithRequired(e => e.eConfigWorkerSeparate)
                .HasForeignKey(e => e.IDConfigWorkerSeparate)
                .WillCascadeOnDelete(false);


            modelBuilder.Entity<eConfigWorkerPortExtract>()
                .HasMany(e => e.eDetailConfigWorkerPortExtracts)
                .WithRequired(e => e.eConfigWorkerPortExtract)
                .HasForeignKey(e => e.IDConfigWorkerPortExtract)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<eConfigInOutCistern>()
                .HasMany(e => e.eDetailConfigInOutCisterns)
                .WithRequired(e => e.eConfigInOutCistern)
                .HasForeignKey(e => e.IDConfigInOutCistern)
                .WillCascadeOnDelete(false);
        }
    }
}
