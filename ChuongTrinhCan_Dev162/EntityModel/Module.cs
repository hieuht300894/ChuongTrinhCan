using EntityModel.DataModel;
using System;
using System.Data.Entity;
using System.Linq;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.IO;

namespace EntityModel
{
    public class Module
    {
        public static string dbConnectString_Client = "";
        public static string dbConnectString_Server = "";

        private static ePersonnel _curPer = null;

        public static ePersonnel CurPer
        {
            get { return _curPer; }
            set { _curPer = value; }
        }

        private class MyConfiguration : System.Data.Entity.Migrations.DbMigrationsConfiguration<aModel>
        {
            public MyConfiguration()
            {
                this.AutomaticMigrationDataLossAllowed = true;
                this.AutomaticMigrationsEnabled = true;
            }
        }

        //public static void AutoLog(List<DbEntityEntry> changeTrack)
        //{
        //    if (acLog && curPer != null)
        //    {
        //        List<xUserLog> AuditLogs = new List<xUserLog>();
        //        //var changeTrack = Context.ChangeTracker.Entries().Where(p => p.State == EntityState.Added || p.State == EntityState.Deleted || p.State == EntityState.Modified);
        //        foreach (var entry in changeTrack)
        //        {
        //            if (entry.Entity != null)
        //            {
        //                xUserLog nLog = null;
        //                string entityName = string.Empty;
        //                string state = string.Empty;
        //                switch (entry.State)
        //                {
        //                    case EntityState.Modified:
        //                        entityName = ObjectContext.GetObjectType(entry.Entity.GetType()).Name;
        //                        state = entry.State.ToString();
        //                        nLog = new xUserLog
        //                        {
        //                            IDPersonnel = curPer.KeyID,
        //                            AccessDate = DateTime.Now,
        //                            TableName = entityName,
        //                            State = state,
        //                            NewValue = "",
        //                        };
        //                        foreach (string prop in entry.OriginalValues.PropertyNames)
        //                        {
        //                            object currentValue = entry.CurrentValues[prop];
        //                            object originalValue = entry.OriginalValues[prop];
        //                            if (!currentValue.Equals(originalValue))
        //                            {
        //                                string nValue = Convert.ToString(currentValue).Trim();
        //                                string oValue = Convert.ToString(originalValue).Trim();
        //                                if (!string.IsNullOrEmpty((nValue + oValue)))
        //                                {
        //                                    nLog.NewValue += string.Format("{0}: [{1}] -> [{2}]\r\n", prop, oValue, nValue);
        //                                }
        //                            }
        //                        }
        //                        nLog.NewValue = nLog.NewValue.Trim();
        //                        if (!string.IsNullOrEmpty(nLog.NewValue))
        //                            AuditLogs.Add(nLog);
        //                        break;
        //                    case EntityState.Added:
        //                        entityName = ObjectContext.GetObjectType(entry.Entity.GetType()).Name;
        //                        state = entry.State.ToString();
        //                        nLog = new xUserLog
        //                        {
        //                            IDPersonnel = curPer.KeyID,
        //                            AccessDate = DateTime.Now,
        //                            TableName = entityName,
        //                            State = state,
        //                            NewValue = "",
        //                        };
        //                        foreach (string prop in entry.CurrentValues.PropertyNames)
        //                        {
        //                            string nValue = Convert.ToString(entry.CurrentValues[prop]).Trim();
        //                            if (!string.IsNullOrEmpty(nValue))
        //                                nLog.NewValue += string.Format("{0}: [{1}]\r\n", prop, nValue);

        //                        }
        //                        nLog.NewValue = nLog.NewValue.Trim();
        //                        if (!string.IsNullOrEmpty(nLog.NewValue))
        //                            AuditLogs.Add(nLog);
        //                        break;
        //                    case EntityState.Deleted:
        //                        entityName = ObjectContext.GetObjectType(entry.Entity.GetType()).Name;
        //                        state = entry.State.ToString();
        //                        nLog = new xUserLog
        //                        {
        //                            IDPersonnel = curPer.KeyID,
        //                            AccessDate = DateTime.Now,
        //                            TableName = entityName,
        //                            State = state,
        //                            NewValue = "",
        //                        };
        //                        foreach (string prop in entry.OriginalValues.PropertyNames)
        //                        {
        //                            string oValue = Convert.ToString(entry.OriginalValues[prop]).Trim();
        //                            if (!string.IsNullOrEmpty(oValue))
        //                                nLog.NewValue += string.Format("{0}: [{1}]\r\n", prop, oValue);

        //                        }
        //                        nLog.NewValue = nLog.NewValue.Trim();
        //                        if (!string.IsNullOrEmpty(nLog.NewValue))
        //                            AuditLogs.Add(nLog);
        //                        break;
        //                    default:
        //                        break;
        //                }
        //            }
        //        }
        //        if (AuditLogs != null && AuditLogs.Count > 0)
        //        {
        //            try
        //            {
        //                acLog = false;
        //                using (aModel db = new aModel())
        //                {
        //                    db.xUserLogs.AddRange(AuditLogs);
        //                    db.SaveChanges();
        //                }
        //            }
        //            catch { }
        //            finally { acLog = true; }
        //        }
        //    }
        //}

        public static void InitDefaultData()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<aModel, MyConfiguration>());

            using (aModel db = new aModel())
            {
                db.Database.Initialize(false);

                if (db.eAgencies.Count() <= 0)
                {
                    try
                    {
                        eAgency _eAgency = new eAgency();
                        _eAgency.Code = "AGE0001";
                        _eAgency.Name = "Tintansoft";
                        _eAgency.Address = "Go Vap Dictrict, Ho Chi Minh City";
                        _eAgency.Phone = "0123456789";
                        _eAgency.Email = "tintansoft@gmail.com";
                        _eAgency.Description = "";
                        _eAgency.IsEnable = true;
                        _eAgency.CreatedBy = 0;
                        _eAgency.CreatedDate = DateTime.Today;
                        _eAgency.ModifiedBy = 0;
                        _eAgency.ModifiedDate = DateTime.Today;
                        db.eAgencies.Add(_eAgency);

                        eFactory eFactory = new eFactory();
                        eFactory.Code = "FACTORY2";
                        eFactory.Name = "Máy 2";
                        eFactory.IsEnable = true;
                        eFactory.CreatedBy = 0;
                        eFactory.CreatedDate = DateTime.Today;
                        eFactory.IDAgency = 1;
                        db.eFactories.Add(eFactory);

                        eFactory eFactory1 = new eFactory();
                        eFactory1.Code = "FACTORY3";
                        eFactory1.Name = "Máy 3";
                        eFactory1.IsEnable = true;
                        eFactory1.CreatedBy = 0;
                        eFactory1.CreatedDate = DateTime.Today;
                        eFactory1.IDAgency = 1;
                        db.eFactories.Add(eFactory1);

                        eUnitCategory unitCate1 = new eUnitCategory();
                        unitCate1.Name = "Bao";
                        eUnit unit1 = new eUnit() { Code = "BAO50", Name = "Bao 50", Weight = 50, IsEnable = true };
                        eUnit unit2 = new eUnit() { Code = "BAO45", Name = "Bao 45", Weight = 45, IsEnable = true };
                        unitCate1.eUnits.Add(unit1);
                        unitCate1.eUnits.Add(unit2);
                        db.eUnitCategories.AddOrUpdate(unitCate1);

                        eUnitCategory unitCate2 = new eUnitCategory();
                        unitCate2.Name = "Túi";
                        unitCate2.eUnits.Add(new eUnit() { Code = "TUI500", Name = "Túi 500", Weight = 500, IsEnable = true });
                        db.eUnitCategories.AddOrUpdate(unitCate2);

                        List<eTypeExtract> lstTypeExtracts = new List<eTypeExtract>();
                        lstTypeExtracts.Add(new eTypeExtract() { Code = "CAM", Name = "Cám" });
                        lstTypeExtracts.Add(new eTypeExtract() { Code = "TO", Name = "To" });
                        lstTypeExtracts.Add(new eTypeExtract() { Code = "TUI", Name = "Túi" });
                        lstTypeExtracts.Add(new eTypeExtract() { Code = "NHAN", Name = "Nhận" });
                        lstTypeExtracts.Add(new eTypeExtract() { Code = "TRA", Name = "Trả" });
                        db.eTypeExtracts.AddRange(lstTypeExtracts);

                        db.SaveChanges();
                    }
                    catch { }
                }
            }
        }
    }
}
