using ChuongTrinhCan.Module;
using EntityModel.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.Migrations;

namespace ChuongTrinhCan.BLL.CATE
{
    public class clsWarehouse
    {
        #region Constructor
        private static volatile clsWarehouse instance = null;
        private static readonly object mLock = new object();
        protected clsWarehouse() { }
        public static clsWarehouse Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (mLock)
                    {
                        if (instance == null)
                            instance = new clsWarehouse();
                    }
                }
                return instance;
            }
        }
        #endregion

        #region Functions
        zModel db, _accessModel;
        public IList<eWarehouse> getAllWarehouse()
        {
            db = new zModel();
            IEnumerable<eWarehouse> lstTemp = db.eWarehouses.Where(n => n.IDAgency == clsGeneral.curAgency.KeyID);

            IList<eWarehouse> lstResult = lstTemp.ToList<eWarehouse>();
            return lstResult;
        }

        public IList<eWarehouse> searchWarehouse(bool IsEnable)
        {
            db = new zModel();
            IEnumerable<eWarehouse> lstTemp = db.eWarehouses.Where(n => n.IsEnable == IsEnable && n.IDAgency == clsGeneral.curAgency.KeyID);

            IList<eWarehouse> lstResult = lstTemp.ToList<eWarehouse>();
            return lstResult;
        }

        public IList<eWarehouse> searchWarehouse(bool IsEnable, int KeyID)
        {
            db = new zModel();
            IEnumerable<eWarehouse> lstTemp = db.eWarehouses.Where(n => n.IsEnable == IsEnable && n.IDAgency == clsGeneral.curAgency.KeyID || n.KeyID == KeyID);

            IList<eWarehouse> lstResult = lstTemp.ToList<eWarehouse>();
            return lstResult;
        }

        public eWarehouse getEntry(int KeyID)
        {
            try
            {
                _accessModel = new zModel();
                return _accessModel.eWarehouses.Find(KeyID) ?? new eWarehouse() { IsEnable = true, IDAgency = clsGeneral.curAgency.KeyID };
            }
            catch { return new eWarehouse() { IsEnable = true, IDAgency = clsGeneral.curAgency.KeyID }; }
        }

        public bool accessEntry(eWarehouse _acEntry)
        {
            bool bRe = false;
            try
            {
                _accessModel = _accessModel ?? new zModel();
                _accessModel.eWarehouses.AddOrUpdate<eWarehouse>(_acEntry);
                _accessModel.SaveChanges();
                bRe = true;
            }
            catch { bRe = false; }
            return bRe;
        }

        public bool deleteEntry(int keyID)
        {
            try
            {
                _accessModel = new zModel();
                _accessModel.eWarehouses.Find(keyID).IsEnable = false;
                _accessModel.SaveChanges();
                return true;
            }
            catch { return false; }
        }
        #endregion
    }
}
