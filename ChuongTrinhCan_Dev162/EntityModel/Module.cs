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

        private class MyConfiguration : System.Data.Entity.Migrations.DbMigrationsConfiguration<zModel>
        {
            public MyConfiguration()
            {
                this.AutomaticMigrationDataLossAllowed = true;
                this.AutomaticMigrationsEnabled = true;
            }
        }

        public static void InitDefaultData()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<zModel, MyConfiguration>());

            using (zModel db = new zModel())
            {
                db.Database.Initialize(false);

                if (db.eAgency.Count() <= 0)
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
                        db.eAgency.Add(_eAgency);
                        db.SaveChanges();
                    }
                    catch { }
                }
            }
        }
    }
}
