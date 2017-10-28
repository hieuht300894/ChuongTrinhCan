using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using EntityModel.DataModel;
using System.Data.Entity.Migrations;

namespace ChuongTrinhCan.Module
{
    public class clsEntity
    {
        public static zModel db;
    }

    public static class exEntity
    {
        public static DateTime ServerNow(this DateTime Now)
        {
            DateTime dRe = DateTime.MinValue;
            using (zModel db = new zModel())
            {
                var dateQuery = db.Database.SqlQuery<DateTime>("SELECT GETDATE()");
                dRe = dateQuery.AsEnumerable().First();
            }
            return dRe;
        }
    }
}
