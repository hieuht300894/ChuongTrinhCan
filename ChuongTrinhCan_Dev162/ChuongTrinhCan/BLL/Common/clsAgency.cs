using EntityModel.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.Migrations;

namespace ChuongTrinhCan.BLL.Common
{
    public class clsAgency
    {
        #region Constructor
        private static volatile clsAgency instance = null;
        private static readonly object mLock = new object();
        protected clsAgency() { }
        public static clsAgency Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (mLock)
                    {
                        if (instance == null)
                            instance = new clsAgency();
                    }
                }
                return instance;
            }
        }
        #endregion

        zModel db, accessModel;
        public List<eAgency> GetAllAgency()
        {
            accessModel = new zModel();
            List<eAgency> lstResult = accessModel.eAgencies.ToList<eAgency>();
            lstResult.Insert(0, new eAgency() { KeyID = 0, Name = "Not Selected", IsEnable = true });
            return lstResult;
        }

        public eAgency GetAgency(int keyID)
        {
            db = new zModel();
            return db.eAgencies.Find(keyID) ?? new eAgency();
        }

        public bool accessEntry(eAgency aEntry)
        {
            try
            {
                accessModel = accessModel ?? new zModel();
                accessModel.eAgencies.AddOrUpdate(aEntry);
                accessModel.SaveChanges();
                return true;
            }
            catch { return false; }
        }
    }
}
