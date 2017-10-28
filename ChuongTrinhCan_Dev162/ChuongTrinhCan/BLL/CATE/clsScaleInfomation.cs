using ChuongTrinhCan.Module;
using EntityModel.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity.Migrations;
using System.IO;
using System.Text;

namespace ChuongTrinhCan.BLL.CATE
{
    public class clsScaleInfomation
    {
        #region Constructor
        private static volatile clsScaleInfomation instance = null;
        private static readonly object mLock = new object();
        protected clsScaleInfomation() { }
        public static clsScaleInfomation Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (mLock)
                    {
                        if (instance == null)
                            instance = new clsScaleInfomation();
                    }
                }
                return instance;
            }
        }
        #endregion

        #region Functions
        zModel db, _accessModel;
        public int getID()
        {
            int res = 1;
            db = new zModel();
            IEnumerable<eScaleInfomation> lstTemp = db.eScaleInfomations.Where(x => x.IDAgency == clsGeneral.curAgency.KeyID);
            lstTemp = lstTemp.Where(x => x.CreatedDate.Date >= DateTime.Now.ServerNow().Date && x.CreatedDate.Date <= DateTime.Now.ServerNow().Date);
            if (lstTemp.Any())
                res = Convert.ToInt32(lstTemp.LastOrDefault().Code) + 1;
            return res;
        }

        public string[] getVehicle()
        {
            db = new zModel();
            IEnumerable<eScaleInfomation> lstTemp = db.eScaleInfomations.Where(x => x.IDAgency == clsGeneral.curAgency.KeyID);
            string[] arrResult = lstTemp.Select(x => x.VehicleNumber).Distinct().ToArray<string>();
            return arrResult ?? new string[] { };
        }

        //public IList<eScaleInfomation> getAll(DateTime fDate, DateTime tDate, bool IsEnable = true)
        //{
        //    db = new zModel();
        //    IEnumerable<eScaleInfomation> lstTemp = db.eScaleInfomations.Where(x => x.IDAgency == clsGeneral.curAgency.KeyID && x.IsEnable == IsEnable);
        //    lstTemp = lstTemp.Where(x => x.CreatedDate.Date >= fDate.Date && x.CreatedDate.Date <= tDate.Date);

        //    IEnumerable<eScaleInfomation> lstImport = lstTemp.Where(x => x.IsImport && !x.IsExport).OrderByDescending(x => x.KeyID).ThenBy(x => x.CustomerName);
        //    IEnumerable<eScaleInfomation> lstExport = lstTemp.Where(x => x.IsImport && x.IsExport).OrderByDescending(x => x.KeyID).ThenBy(x => x.CustomerName);
        //    List<eScaleInfomation> lstResult = new List<eScaleInfomation>();
        //    lstResult.AddRange(lstImport);
        //    lstResult.AddRange(lstExport);

        //    return lstResult;
        //}

        public IList<eScaleInfomation> getAll(DateTime fDate, DateTime tDate)
        {
            db = new zModel();
            IEnumerable<eScaleInfomation> lstTemp = db.eScaleInfomations.Where(x => x.IDAgency == clsGeneral.curAgency.KeyID && x.IsEnable);

            lstTemp = lstTemp.Where(delegate (eScaleInfomation e)
            {
                if (e.DateScale2.HasValue)
                    return e.DateScale2.Value.Date >= fDate.Date && e.DateScale2.Value.Date <= tDate.Date;
                else
                    return e.DateScale1.Date >= fDate.Date && e.DateScale1.Date <= tDate.Date;
            });

            IEnumerable<eScaleInfomation> lstImport = lstTemp.Where(x => !x.IsImport && !x.IsExport).OrderBy(x => x.CustomerName).ThenByDescending(x => x.DateScale1);
            IEnumerable<eScaleInfomation> lstExport = lstTemp.Where(x => ((x.IsImport && !x.IsExport) || (!x.IsImport && x.IsExport)) && x.DateScale2.HasValue).OrderBy(x => x.CustomerName).ThenByDescending(x => x.DateScale2);
            List<eScaleInfomation> lstResult = new List<eScaleInfomation>();

            lstResult.AddRange(lstImport);
            lstResult.AddRange(lstExport);

            return lstResult;
        }

        public IList<eScaleInfomation> getAll(DateTime fDate, DateTime tDate, bool IsFilter = false, bool? IsImport = null, bool? IsExport = null, string VehicleNumber = "", string CustomerName = "", string WarehouseName = "", string ProductName = "", bool findAll = true)
        {
            db = new zModel();
            IEnumerable<eScaleInfomation> lstTemp = db.eScaleInfomations.Where(x => x.IDAgency == clsGeneral.curAgency.KeyID && x.IsEnable);

            lstTemp = lstTemp.Where(delegate (eScaleInfomation e)
            {
                if (e.DateScale2.HasValue)
                    return e.DateScale2.Value.Date >= fDate.Date && e.DateScale2.Value.Date <= tDate.Date;
                else
                    return e.DateScale1.Date >= fDate.Date && e.DateScale1.Date <= tDate.Date;
            });

            if (IsImport.HasValue)
                lstTemp = lstTemp.Where(x => x.IsImport == IsImport);

            if (IsExport.HasValue)
                lstTemp = lstTemp.Where(x => x.IsExport == IsExport);

            if (!string.IsNullOrEmpty(VehicleNumber))
                lstTemp = lstTemp.Where(x => x.VehicleNumber.CompareText(VehicleNumber, findAll));

            if (!string.IsNullOrEmpty(CustomerName))
                lstTemp = lstTemp.Where(x => x.CustomerName.CompareText(CustomerName, findAll));

            if (!string.IsNullOrEmpty(WarehouseName))
                lstTemp = lstTemp.Where(x => x.WarehouseName.CompareText(WarehouseName, findAll));

            if (!string.IsNullOrEmpty(ProductName))
                lstTemp = lstTemp.Where(x => x.ProductName.CompareText(ProductName, findAll));

            IEnumerable<eScaleInfomation> lstImport = lstTemp.Where(x => !x.IsImport && !x.IsExport).OrderBy(x => x.CustomerName).ThenByDescending(x => x.DateScale1);
            IEnumerable<eScaleInfomation> lstExport = lstTemp.Where(x => ((x.IsImport && !x.IsExport) || (!x.IsImport && x.IsExport)) && x.DateScale2.HasValue).OrderBy(x => x.CustomerName).ThenByDescending(x => x.DateScale2);
            List<eScaleInfomation> lstResult = new List<eScaleInfomation>();

            lstResult.AddRange(lstImport);
            lstResult.AddRange(lstExport);

            return lstResult;
        }

        public eScaleInfomation getEntry(int KeyID)
        {
            try
            {
                _accessModel = new zModel();
                return _accessModel.eScaleInfomations.Find(KeyID) ?? new eScaleInfomation() { IsEnable = true, CreatedDate = DateTime.Now.ServerNow() };
            }
            catch { return new eScaleInfomation() { IsEnable = true, CreatedDate = DateTime.Now.ServerNow() }; }
        }

        public eScaleInfomation getItemNotFinish(string VehicleNumber)
        {
            db = new zModel();
            IEnumerable<eScaleInfomation> lstTemp = db.eScaleInfomations.Where(x => x.IsEnable && !x.DateScale2.HasValue && x.IDAgency == clsGeneral.curAgency.KeyID && x.VehicleNumber.Equals(VehicleNumber));
            lstTemp = lstTemp.Where(x => x.CreatedDate.Date >= DateTime.Now.ServerNow().Date && x.CreatedDate.Date <= DateTime.Now.ServerNow().Date);
            return lstTemp.FirstOrDefault() ?? new eScaleInfomation();
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

        public bool accessEntry(eScaleInfomation _acEntry, decimal EmptyWeight = 0)
        {
            DateTime time = DateTime.Now.ServerNow();
            try
            {
                _accessModel = _accessModel ?? new zModel();
                var item = _accessModel.eVehicleEmpties.FirstOrDefault(x => x.IDAgency == _acEntry.IDAgency && x.IsEnable && x.VehicleNumber.ToLower().Equals(_acEntry.VehicleNumber.ToLower()));

                if (_acEntry.DateScale2.HasValue && item != null && EmptyWeight > 0)
                {
                    item.EmptyWeight = EmptyWeight;
                    item.ModifiedDate = time;
                }
                _accessModel.eScaleInfomations.AddOrUpdate(_acEntry);
                _accessModel.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        private void createLogFile(string content)
        {
            try
            {
                if (!Directory.Exists(@"Logs"))
                    Directory.CreateDirectory("Logs");
                if (!File.Exists(@"Logs/log.txt"))
                    File.Create(@"Logs/log.txt").Close();

                File.AppendAllText(@"Logs/log.txt", content);
                //StreamWriter sw = new StreamWriter(@"Logs/log.txt");
                //sw.WriteLine("\n");
                //sw.WriteLine(content);
                //sw.Close();
            }
            catch (Exception ex) { }
        }
        #endregion
    }
}
