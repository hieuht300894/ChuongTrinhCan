using System.Data.Entity;

namespace ChuongTrinhCan.Module
{
    public partial class sModel : DbContext
    {
        public sModel() :
            base(EntityModel.Module.dbConnectString_Server)
        {
        }

        private class MyConfiguration : System.Data.Entity.Migrations.DbMigrationsConfiguration<sModel>
        {
            public MyConfiguration()
            {
                this.AutomaticMigrationDataLossAllowed = true;
                this.AutomaticMigrationsEnabled = true;
            }
        }

        public void InitDefaultData()
        {
            Database.SetInitializer<sModel>(new MigrateDatabaseToLatestVersion<sModel, MyConfiguration>());

            sModel db = new sModel();


        }
    }
}
