using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.Migrations;
using EntityModel.DataModel;
using ChuongTrinhCan.Module;
using ChuongTrinhCan.BLL.Common;

namespace ChuongTrinhCan.BLL.CATE
{
    public class clsCustomer
    {
        #region Constructor
        private static volatile clsCustomer instance = null;
        private static readonly object mLock = new object();
        protected clsCustomer() { }
        public static clsCustomer Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (mLock)
                    {
                        if (instance == null)
                            instance = new clsCustomer();
                    }
                }
                return instance;
            }
        }
        #endregion

        #region Functions
        zModel db, _accessModel;

        public IList<eCustomer> getAllCustomer()
        {
            db = new zModel();
            IEnumerable<eCustomer> lstTemp = db.eCustomers.Where(n => n.IDAgency == clsGeneral.curAgency.KeyID);

            IList<eCustomer> lstResult = lstTemp.ToList<eCustomer>();
            return lstResult;
        }

        public IList<eCustomer> getAllCustomer(string msg, bool IsEnable)
        {
            db = new zModel();
            IEnumerable<eCustomer> lstTemp = db.eCustomers.Where(n => n.IDAgency == clsGeneral.curAgency.KeyID && n.IsEnable == IsEnable);

            IList<eCustomer> lstResult = lstTemp.ToList<eCustomer>();
            lstResult.Insert(0, new eCustomer() { Name = msg });
            return lstResult;
        }

        public IList<eCustomer> searchCustomer(bool IsEnable)
        {
            db = new zModel();
            IEnumerable<eCustomer> lstTemp = db.eCustomers.Where(n => n.IsEnable == IsEnable && n.IDAgency == clsGeneral.curAgency.KeyID );

            IList<eCustomer> lstResult = lstTemp.ToList<eCustomer>();
            return lstResult;
        }

        public IList<eCustomer> searchCustomer(bool IsEnable, int KeyID)
        {
            db = new zModel();
            IEnumerable<eCustomer> lstTemp = db.eCustomers.Where(n => n.IsEnable == IsEnable && n.IDAgency == clsGeneral.curAgency.KeyID || n.KeyID == KeyID);

            IList<eCustomer> lstResult = lstTemp.ToList<eCustomer>();
            return lstResult;
        }

        public IList<eCustomer> searchCustomer(eCustomer eFilter)
        {
            db = new zModel();
            IEnumerable<eCustomer> lstTemp = db.eCustomers.Where(n => n.IDAgency == clsGeneral.curAgency.KeyID && n.IsEnable == eFilter.IsEnable );

            if (!string.IsNullOrEmpty(eFilter.Code))
                lstTemp = lstTemp.Where(x => x.Code.ToLower().Contains(eFilter.Code.ToLower()));
            if (!string.IsNullOrEmpty(eFilter.Name))
                lstTemp = lstTemp.Where(x => x.Name.ToLower().Contains(eFilter.Name.ToLower()));
            if (!string.IsNullOrEmpty(eFilter.Contact))
                lstTemp = lstTemp.Where(x => x.Contact.ToLower().Contains(eFilter.Contact.ToLower()));

            IEnumerable<eCustomer> lstOrder = lstTemp.OrderByDescending(x => x.Status).ThenBy(x => x.Code);
            IList<eCustomer> lstResult = lstOrder.ToList<eCustomer>();
            return lstResult;
        }

        public eCustomer getCustomerByID(int KeyID)
        {
            db = new zModel();
            return db.eCustomers.Find(KeyID) ?? new eCustomer();
        }

        public eCustomer getEntry(int KeyID)
        {
            try
            {
                _accessModel = new zModel();
                return _accessModel.eCustomers.Find(KeyID) ?? new eCustomer() { IsEnable = true, IsScale = true, IDAgency = clsGeneral.curAgency.KeyID };
            }
            catch { return new eCustomer() { IsEnable = true, IsScale = true, IDAgency = clsGeneral.curAgency.KeyID }; }
        }

        public bool deleteEntry(int keyID)
        {
            try
            {
                _accessModel = new zModel();
                var item = _accessModel.eCustomers.Find(keyID);
                item.Status = 3;
                _accessModel.SaveChanges();
                return true;
            }
            catch { return false; }
        }

        public bool deleteEntry(List<int> ids)
        {
            try
            {
                _accessModel = new zModel();
                foreach (int id in ids)
                {
                    var item = _accessModel.eCustomers.Find(id);
                    item.IsEnable = false;
                }
                _accessModel.SaveChanges();
                return true;
            }
            catch { return false; }
        }

        public bool accessEntry(eCustomer _acEntry)
        {
            bool bRe = false;
            try
            {
                _accessModel = _accessModel ?? new zModel();
                _accessModel.eCustomers.AddOrUpdate<eCustomer>(_acEntry);
                _accessModel.SaveChanges();
                bRe = true;
            }
            catch { bRe = false; }
            return bRe;
        }

        public bool asyncData(List<int> lstID)
        {
            try
            {
                _accessModel = new zModel();
                foreach (int id in lstID)
                {
                    var item = _accessModel.eCustomers.Find(id);
                    if (item != null)
                    {
                        item.IsSend = true;
                        item.IsScale = false;
                    }
                }
                _accessModel.SaveChanges();

                //AsyncEntry<eCustomer> async = new AsyncEntry<eCustomer>(lstID);
                //async.checkConnection();
                //if (async.checkConnection())
                //    async.startRun();
                return true;
            }
            catch { return false; }
        }
        #endregion
    }
}
