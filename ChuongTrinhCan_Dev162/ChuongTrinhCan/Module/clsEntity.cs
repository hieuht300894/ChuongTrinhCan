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
        public static aModel db;
        public static List<xAppConfig> AllConfig = null;
        public static List<xDisplay> AllDisplay = null;
        public static List<xLayoutItemCaption> AllLayoutItemCaption = null;
        public static List<xMsgDictionary> AllMessage = null;
        public static string serverConnectionString = "";
    }

    public static class exEntity
    {
        public static DateTime ServerNow(this DateTime Now)
        {
            DateTime dRe = DateTime.MinValue;
            using (aModel db = new aModel())
            {
                var dateQuery = db.Database.SqlQuery<DateTime>("SELECT GETDATE()");
                dRe = dateQuery.AsEnumerable().First();
            }
            return dRe;
        }
    }
}
