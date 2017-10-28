using EntityModel.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChuongTrinhCan.Module;
using System.Data.Entity.Migrations;

namespace ChuongTrinhCan.BLL.CATE
{
    class clsVehicleEmpty
    {
        #region Constructor
        private static volatile clsVehicleEmpty instance = null;
        private static readonly object mLock = new object();
        protected clsVehicleEmpty() { }
        public static clsVehicleEmpty Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (mLock)
                    {
                        if (instance == null)
                            instance = new clsVehicleEmpty();
                    }
                }
                return instance;
            }
        }
        #endregion

        #region Functions
        zModel db, _accessModel;

        public IList<eVehicleEmpty> getAll()
        {
            db = new zModel();
            IEnumerable<eVehicleEmpty> lstTemp = db.eVehicleEmpties.Where(x => x.IsEnable && x.IDAgency == clsGeneral.curAgency.KeyID);
            return lstTemp.ToList();
        }

        public eVehicleEmpty getVehicleWeight(string number)
        {
            db = new zModel();
            IEnumerable<eVehicleEmpty> lstTemp = db.eVehicleEmpties.Where(x => x.IsEnable && x.IDAgency == clsGeneral.curAgency.KeyID && x.VehicleNumber.Equals(number));
            return lstTemp.FirstOrDefault();
        }

        public eVehicleEmpty getEntry(int KeyID)
        {
            try
            {
                db = new zModel();
                IEnumerable<eScaleInfomation> lstScaleInfo = db.eScaleInfomations.Where(x => x.IsEnable && ((!x.IsExport && x.IsImport) || (x.IsExport && !x.IsImport) || x.DateScale2.HasValue) && x.IDAgency == clsGeneral.curAgency.KeyID);
                IEnumerable<eScaleInfomation> lstOrder = lstScaleInfo.OrderByDescending(x => x.DateScale2.Value);
                var info = lstOrder.FirstOrDefault();
                eVehicleEmpty item = null;
                string number = "";
                decimal weight = 0;
                if (info != null && !db.eVehicleEmpties.Any(x => x.IsEnable && x.VehicleNumber.Equals(info.VehicleNumber)))
                {
                    number = info.VehicleNumber;
                    weight = info.Weight1 > info.Weight2 ? info.Weight2 : info.Weight1;
                    _accessModel = new zModel();
                    return new eVehicleEmpty() { IsEnable = true, VehicleNumber = number, EmptyWeight = weight, IDAgency = clsGeneral.curAgency.KeyID };
                }
                return item;
            }
            catch { return new eVehicleEmpty() { IsEnable = true, VehicleNumber = "", EmptyWeight = 0, IDAgency = clsGeneral.curAgency.KeyID }; }
        }

        public bool deleteEntry(int keyID)
        {
            try
            {
                _accessModel = new zModel();
                var item = _accessModel.eVehicleEmpties.Find(keyID);
                item.IsEnable = false;
                _accessModel.SaveChanges();
                return true;
            }
            catch { return false; }
        }

        public bool accessEntry(eVehicleEmpty _acEntry)
        {
            bool bRe = false;
            try
            {
                _accessModel = _accessModel ?? new zModel();
                _accessModel.eVehicleEmpties.RemoveRange(_accessModel.eVehicleEmpties.Where(x => !x.IsEnable && x.VehicleNumber.Equals(_acEntry.VehicleNumber)));
                _accessModel.eVehicleEmpties.AddOrUpdate<eVehicleEmpty>(_acEntry);
                _accessModel.SaveChanges();
                bRe = true;
            }
            catch { bRe = false; }
            return bRe;
        }
        #endregion
    }
}
