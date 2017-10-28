using EntityModel.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.Migrations;
using ChuongTrinhCan.Module;

namespace ChuongTrinhCan.BLL.CATE
{
    public class Product_Temp
    {
        public int KeyID { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public decimal Remain { get; set; }
    }
    public class clsProduct
    {
        #region Constructor
        private static volatile clsProduct instance = null;
        private static readonly object mLock = new object();
        protected clsProduct() { }
        public static clsProduct Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (mLock)
                    {
                        if (instance == null)
                            instance = new clsProduct();
                    }
                }
                return instance;
            }
        }
        #endregion

        #region Functions

        aModel db, _accessModel;
        public IList<eProduct> getAllProduct()
        {
            db = new aModel();
            IEnumerable<eProduct> lstTemp = db.eProducts.Where(n => n.IDAgency == clsGeneral.curAgency.KeyID && n.Status != 3);

            IEnumerable<eProduct> lstOrder = lstTemp.OrderByDescending(x => x.Status).ThenBy(x => x.Code);
            IList<eProduct> lstResult = lstOrder.ToList<eProduct>();
            return lstResult;
        }

        public IList<eProduct> searchProduct(bool IsEnable)
        {
            db = new aModel();
            IEnumerable<eProduct> lstTemp = db.eProducts.Where(n => n.IsEnable == IsEnable && n.IDAgency == clsGeneral.curAgency.KeyID && n.Status != 3);

            IEnumerable<eProduct> lstOrder = lstTemp.OrderByDescending(x => x.Status).ThenBy(x => x.Code);
            IList<eProduct> lstResult = lstOrder.ToList<eProduct>();
            return lstResult;
        }

        public IList<eProduct> searchProduct(bool IsEnable, int KeyID)
        {
            db = new aModel();
            IEnumerable<eProduct> lstTemp = db.eProducts.Where(n => n.IsEnable == IsEnable && n.IDAgency == clsGeneral.curAgency.KeyID && n.Status != 3 || n.KeyID == KeyID);

            IEnumerable<eProduct> lstOrder = lstTemp.OrderByDescending(x => x.Status).ThenBy(x => x.Code);
            IList<eProduct> lstResult = lstOrder.ToList<eProduct>();
            return lstResult;
        }

        public eProduct getProductByID(int KeyID)
        {
            db = new aModel();
            return db.eProducts.Find(KeyID) ?? new eProduct();
        }

        public bool deleteEntry(int KeyID)
        {
            bool bRe = false;
            try
            {
                _accessModel = new aModel();
                eProduct item = _accessModel.eProducts.Find(KeyID);
                item.Status = 3;
                _accessModel.SaveChanges();
                bRe = true;
            }
            catch { }
            return bRe;
        }

        public bool deleteEntry(List<int> ids)
        {
            bool bRe = false;
            try
            {
                _accessModel = new aModel();
                foreach (int id in ids)
                {
                    eProduct item = _accessModel.eProducts.Find(id);
                    item.Status = 3;
                }
                _accessModel.SaveChanges();
                bRe = true;
            }
            catch { }
            return bRe;
        }

        public bool checkExist(string Ma, int KeyID)
        {
            bool bRe = false;
            using (aModel db = new aModel())
            {
                if (KeyID > 0)
                    bRe = db.eProducts.Any(n => n.IDAgency == clsGeneral.curAgency.KeyID && n.KeyID != KeyID && n.Code.ToUpper().Equals(Ma.ToUpper()));
                else
                    bRe = db.eProducts.Any(n => n.IDAgency == clsGeneral.curAgency.KeyID && n.Code.ToUpper().Equals(Ma.ToUpper()));
            }
            return bRe;
        }

        public eProduct getEntry(int KeyID)
        {
            try
            {
                _accessModel = new aModel();
                return _accessModel.eProducts.Find(KeyID) ?? new eProduct() { IsEnable = true, IDAgency = clsGeneral.curAgency.KeyID };
            }
            catch { return new eProduct() { IsEnable = true, IDAgency = clsGeneral.curAgency.KeyID }; }
        }

        public bool accessEntry(eProduct _acEntry)
        {
            bool bRe = false;
            try
            {
                _accessModel = _accessModel ?? new aModel();
                _accessModel.eProducts.AddOrUpdate(_acEntry);
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
                _accessModel = new aModel();
                foreach (int id in lstID)
                {
                    var item = _accessModel.eProducts.Find(id);
                    if (item != null)
                    {
                        item.IsSend = true;
                    }
                }
                _accessModel.SaveChanges();
                return true;
            }
            catch { return false; }
        }
        #endregion
    }
}
