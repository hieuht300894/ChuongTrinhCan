using ChuongTrinhCan.Module;
using EntityModel.DataModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChuongTrinhCan.GUI.CATE
{
    public partial class frmSyncData : frmBase
    {
        public frmSyncData()
        {
            InitializeComponent();
        }

        private bool checkConnection()
        {
            string _sName, _sDatabase, _sUser, _sPass;
            bool _wAu;
            _wAu = Properties.Settings.Default.sWinAu_Server;
            _sName = clsGeneral.Decrypt(Properties.Settings.Default.sServerName_Server);
            _sDatabase = clsGeneral.Decrypt(Properties.Settings.Default.sDBName_Server);
            _sUser = clsGeneral.Decrypt(Properties.Settings.Default.sUserName_Server);
            _sPass = clsGeneral.Decrypt(Properties.Settings.Default.sPassword_Server);

            string _conString = "";
            if (!_wAu)
                _conString = "data source={0};initial catalog={1};Integrated Security={2};user id={3};password={4};MultipleActiveResultSets=True;App=EntityFramework";
            else
                _conString = "data source={0};initial catalog={1};Integrated Security={2};MultipleActiveResultSets=True;App=EntityFramework";
            EntityModel.Module.dbConnectString_Server = string.Format(_conString, _sName, _sDatabase, _wAu, _sUser, _sPass);

            SqlConnection conn = new SqlConnection(EntityModel.Module.dbConnectString_Server);
            try
            {
                conn.Open();
                conn.Close();
                return true;
            }
            catch
            {
                clsGeneral.showMessage("Không thể kết nối tới máy chủ");
                Close();
                return false;
            }
        }

        public void SaveInsert(DbContext db, string TableName, Dictionary<string, object> dParams)
        {
            string qFormat = $"INSERT INTO {{0}} ({{1}}) VALUES ({{2}})";
            List<SqlParameter> parameters = new List<SqlParameter>();
            string qFields = "";
            string qParams = "";

            int i = 0;
            int length = dParams.Count - 1;
            dParams.ToList().ForEach(x =>
            {
                qFields += $"{x.Key}{(i < length ? ", " : "")}";
                qParams += $"@{x.Key}{(i < length ? ", " : "")}";
                i++;
                parameters.Add(new SqlParameter() { ParameterName = $"@{x.Key}", Value = x.Value ?? DBNull.Value });
            });

            db.Database.ExecuteSqlCommand(string.Format(qFormat, TableName, qFields, qParams), parameters.ToArray());
        }

        public void SaveUpdate(DbContext db, string TableName, Dictionary<string, object> dParamKeys, Dictionary<string, object> dParamValues)
        {
            string qFormat = $"UPDATE {{0}} SET {{1}} WHERE {{2}}";
            List<SqlParameter> parameters = new List<SqlParameter>();
            string qConditions = "";
            string qAssigns = "";

            int i = 0;
            int length = dParamKeys.Count - 1;
            dParamKeys.ToList().ForEach(x =>
            {
                qConditions += $"{x.Key}=@{x.Key} {(i++ < length ? " AND " : "")}";
                parameters.Add(new SqlParameter() { ParameterName = "@" + x.Key, Value = x.Value ?? DBNull.Value });
            });

            i = 0;
            length = dParamValues.Count - 1;
            dParamValues.ToList().ForEach(x =>
            {
                qAssigns += $"{x.Key}=@{x.Key}{(i++ < length ? ", " : "")}";
                parameters.Add(new SqlParameter() { ParameterName = "@" + x.Key, Value = x.Value ?? DBNull.Value });
            });

            if (!string.IsNullOrEmpty(qAssigns))
                db.Database.ExecuteSqlCommand(string.Format(qFormat, TableName, qAssigns, qConditions), parameters.ToArray());
        }

        public Dictionary<string, object> ObjectToDictionary(object source)
        {
            Dictionary<string, object> dic = new Dictionary<string, object>();
            foreach (PropertyInfo pInfo in source.GetType().GetProperties())
            {
                var tempType = pInfo.PropertyType;
                var tempValue = pInfo.GetValue(source);
                if (tempValue != null)
                {
                    if (tempType.IsGenericType && (tempType.GetGenericTypeDefinition() == typeof(Nullable<>)))
                        dic.Add(pInfo.Name, Convert.ChangeType(tempValue, Nullable.GetUnderlyingType(tempType)));
                    else
                        dic.Add(pInfo.Name, Convert.ChangeType(tempValue, tempType));
                }
                else
                    dic.Add(pInfo.Name, tempValue);
            }
            return dic;
        }

        private void frmSyncData_Load(object sender, EventArgs e)
        {
            if (checkConnection())
            {
                btnSyncKH.Click += btnSyncKH_Click;
                btnSyncKHO.Click += btnSyncKHO_Click;
                btnSyncSP.Click += btnSyncSP_Click;
                btnSyncCAN.Click += btnSyncCAN_Click;
            }
        }

        private void btnSyncCAN_Click(object sender, EventArgs e)
        {
            clsGeneral.CallWaitForm(this);
            zModel cDB = new zModel();
            sModel sDB = new sModel();

            cDB.Database.BeginTransaction();
            sDB.Database.BeginTransaction();

            try
            {
                List<int?> cQuery = cDB.Database.SqlQuery<int?>("select max(KeyID) from eScaleInfomation", new SqlParameter[] { }).ToList();
                List<int?> sQuery = sDB.Database.SqlQuery<int?>("select max(KeyID) from eScaleInfomation", new SqlParameter[] { }).ToList();

                int? cMaxID = cQuery[0];
                int? sMaxID = sQuery[0];

                if (cMaxID.HasValue && sMaxID.HasValue)
                {
                    if (cMaxID == sMaxID)
                    {
                        #region  Cập nhật dữ liệu
                        List<eScaleInfomation> lstDataUpdate_Client = cDB.Database.SqlQuery<eScaleInfomation>($"select * from eScaleInfomation", new SqlParameter[] { }).ToList();
                        List<eScaleInfomation> lstDataUpdate_Server = sDB.Database.SqlQuery<eScaleInfomation>($"select * from eScaleInfomation", new SqlParameter[] { }).ToList();
                        foreach (var item_Client in lstDataUpdate_Client)
                        {
                            var item_Server = lstDataUpdate_Server.Find(x => x.KeyID == item_Client.KeyID);

                            Dictionary<string, object> dKeys = new Dictionary<string, object>();
                            dKeys.Add("KeyID", item_Client.KeyID);

                            Dictionary<string, object> dValues = new Dictionary<string, object>();
                            Dictionary<string, object> dValues_New = ObjectToDictionary(item_Client);
                            Dictionary<string, object> dValues_Old = ObjectToDictionary(item_Server);

                            foreach (var item_New in dValues_New)
                            {
                                object NewValue = dValues_New[item_New.Key];
                                object OldValue = dValues_Old[item_New.Key];

                                if (OldValue != null && NewValue != null && !OldValue.Equals(NewValue)) { dValues.Add(item_New.Key, NewValue); }
                                else if (OldValue != null && NewValue == null) { dValues.Add(item_New.Key, NewValue); }
                                else if (OldValue == null && NewValue != null) { dValues.Add(item_New.Key, NewValue); }
                                else { }
                            }

                            foreach (var key in dKeys)
                            {
                                dValues.Remove(key.Key);
                            }

                            SaveUpdate(sDB, "eScaleInfomation", dKeys, dValues);
                        }
                        #endregion
                    }
                    else if (cMaxID > sMaxID)
                    {
                        #region Chuyển dữ liệu từ Client sang Server
                        List<eScaleInfomation> lstData_Client = cDB.Database.SqlQuery<eScaleInfomation>($"select * from eScaleInfomation where KeyID>{(sMaxID.HasValue ? sMaxID.Value : 0)}", new SqlParameter[] { }).ToList();
                        sDB.Database.ExecuteSqlCommand("SET IDENTITY_INSERT eScaleInfomation ON ");
                        foreach (var item in lstData_Client) { SaveInsert(sDB, "eScaleInfomation", ObjectToDictionary(item)); }
                        sDB.Database.ExecuteSqlCommand("SET IDENTITY_INSERT eScaleInfomation OFF ");
                        #endregion

                        #region  Cập nhật dữ liệu
                        List<eScaleInfomation> lstDataUpdate_Client = cDB.Database.SqlQuery<eScaleInfomation>($"select * from eScaleInfomation where KeyID<={(sMaxID.HasValue ? sMaxID.Value : 0)}", new SqlParameter[] { }).ToList();
                        List<eScaleInfomation> lstDataUpdate_Server = sDB.Database.SqlQuery<eScaleInfomation>($"select * from eScaleInfomation where KeyID<={(sMaxID.HasValue ? sMaxID.Value : 0)}", new SqlParameter[] { }).ToList();
                        foreach (var item_Client in lstDataUpdate_Client)
                        {
                            var item_Server = lstDataUpdate_Server.Find(x => x.KeyID == item_Client.KeyID);

                            Dictionary<string, object> dKeys = new Dictionary<string, object>();
                            dKeys.Add("KeyID", item_Client.KeyID);

                            Dictionary<string, object> dValues = new Dictionary<string, object>();
                            Dictionary<string, object> dValues_New = ObjectToDictionary(item_Client);
                            Dictionary<string, object> dValues_Old = ObjectToDictionary(item_Server);

                            foreach (var item_New in dValues_New)
                            {
                                object NewValue = dValues_New[item_New.Key];
                                object OldValue = dValues_Old[item_New.Key];

                                if (OldValue != null && NewValue != null && !OldValue.Equals(NewValue)) { dValues.Add(item_New.Key, NewValue); }
                                else if (OldValue != null && NewValue == null) { dValues.Add(item_New.Key, NewValue); }
                                else if (OldValue == null && NewValue != null) { dValues.Add(item_New.Key, NewValue); }
                                else { }
                            }

                            foreach (var key in dKeys)
                            {
                                dValues.Remove(key.Key);
                            }

                            SaveUpdate(sDB, "eScaleInfomation", dKeys, dValues);
                        }
                        #endregion
                    }
                    else
                    {
                        #region Chuyển dữ liệu từ Server sang Client
                        List<eScaleInfomation> lstData_Server = sDB.Database.SqlQuery<eScaleInfomation>($"select * from eScaleInfomation where KeyID>{(cMaxID.HasValue ? cMaxID.Value : 0)}", new SqlParameter[] { }).ToList();
                        cDB.Database.ExecuteSqlCommand("SET IDENTITY_INSERT eScaleInfomation ON ");
                        foreach (var item in lstData_Server) { SaveInsert(cDB, "eScaleInfomation", ObjectToDictionary(item)); }
                        cDB.Database.ExecuteSqlCommand("SET IDENTITY_INSERT eScaleInfomation OFF ");
                        #endregion

                        #region  Cập nhật dữ liệu
                        List<eScaleInfomation> lstDataUpdate_Client = cDB.Database.SqlQuery<eScaleInfomation>($"select * from eScaleInfomation where KeyID<={(cMaxID.HasValue ? cMaxID.Value : 0)}", new SqlParameter[] { }).ToList();
                        List<eScaleInfomation> lstDataUpdate_Server = sDB.Database.SqlQuery<eScaleInfomation>($"select * from eScaleInfomation where KeyID<={(cMaxID.HasValue ? cMaxID.Value : 0)}", new SqlParameter[] { }).ToList();
                        foreach (var item_Client in lstDataUpdate_Client)
                        {
                            var item_Server = lstDataUpdate_Server.Find(x => x.KeyID == item_Client.KeyID);

                            Dictionary<string, object> dKeys = new Dictionary<string, object>();
                            dKeys.Add("KeyID", item_Client.KeyID);

                            Dictionary<string, object> dValues = new Dictionary<string, object>();
                            Dictionary<string, object> dValues_New = ObjectToDictionary(item_Client);
                            Dictionary<string, object> dValues_Old = ObjectToDictionary(item_Server);

                            foreach (var item_New in dValues_New)
                            {
                                object NewValue = dValues_New[item_New.Key];
                                object OldValue = dValues_Old[item_New.Key];

                                if (OldValue != null && NewValue != null && !OldValue.Equals(NewValue)) { dValues.Add(item_New.Key, NewValue); }
                                else if (OldValue != null && NewValue == null) { dValues.Add(item_New.Key, NewValue); }
                                else if (OldValue == null && NewValue != null) { dValues.Add(item_New.Key, NewValue); }
                                else { }
                            }

                            foreach (var key in dKeys)
                            {
                                dValues.Remove(key.Key);
                            }

                            SaveUpdate(sDB, "eScaleInfomation", dKeys, dValues);
                        }
                        #endregion
                    }
                }
                else if (cMaxID.HasValue && !sMaxID.HasValue)
                {
                    #region Chuyển dữ liệu từ Client sang Server
                    List<eScaleInfomation> lstData_Client = cDB.Database.SqlQuery<eScaleInfomation>($"select * from eScaleInfomation where KeyID>{(sMaxID.HasValue ? sMaxID.Value : 0)}", new SqlParameter[] { }).ToList();
                    sDB.Database.ExecuteSqlCommand("SET IDENTITY_INSERT eScaleInfomation ON ");
                    foreach (var item in lstData_Client) { SaveInsert(sDB, "eScaleInfomation", ObjectToDictionary(item)); }
                    sDB.Database.ExecuteSqlCommand("SET IDENTITY_INSERT eScaleInfomation OFF ");
                    #endregion
                }
                else if (!cMaxID.HasValue && sMaxID.HasValue)
                {
                    #region Chuyển dữ liệu từ Server sang Client
                    List<eScaleInfomation> lstData_Server = sDB.Database.SqlQuery<eScaleInfomation>($"select * from eScaleInfomation where KeyID>{(cMaxID.HasValue ? cMaxID.Value : 0)}", new SqlParameter[] { }).ToList();
                    cDB.Database.ExecuteSqlCommand("SET IDENTITY_INSERT eScaleInfomation ON ");
                    foreach (var item in lstData_Server) { SaveInsert(cDB, "eScaleInfomation", ObjectToDictionary(item)); }
                    cDB.Database.ExecuteSqlCommand("SET IDENTITY_INSERT eScaleInfomation OFF ");
                    #endregion
                }
                else
                {
                }

                cDB.Database.CurrentTransaction.Commit();
                sDB.Database.CurrentTransaction.Commit();
                clsGeneral.CloseWaitForm();
                clsGeneral.showMessage("Cập nhật dữ liệu cân hoàn tất");
            }
            catch (Exception ex)
            {
                cDB.Database.CurrentTransaction.Rollback();
                sDB.Database.CurrentTransaction.Rollback();
                clsGeneral.CloseWaitForm();
                clsGeneral.showErrorException(ex, "Cập nhật dữ liệu cân thất bại");
            }
        }

        private void btnSyncSP_Click(object sender, EventArgs e)
        {
            clsGeneral.CallWaitForm(this);
            zModel cDB = new zModel();
            sModel sDB = new sModel();

            cDB.Database.BeginTransaction();
            sDB.Database.BeginTransaction();

            try
            {
                List<int?> cQuery = cDB.Database.SqlQuery<int?>("select max(KeyID) from eProduct", new SqlParameter[] { }).ToList();
                List<int?> sQuery = sDB.Database.SqlQuery<int?>("select max(KeyID) from eProductScale", new SqlParameter[] { }).ToList();

                int? cMaxID = cQuery[0];
                int? sMaxID = sQuery[0];

                if (cMaxID.HasValue && sMaxID.HasValue)
                {
                    if (cMaxID == sMaxID)
                    {
                        #region  Cập nhật dữ liệu
                        List<eProduct> lstDataUpdate_Client = cDB.Database.SqlQuery<eProduct>($"select * from eProduct", new SqlParameter[] { }).ToList();
                        List<eProductScale> lstDataUpdate_Server = sDB.Database.SqlQuery<eProductScale>($"select * from eProductScale", new SqlParameter[] { }).ToList();
                        foreach (var item_Client in lstDataUpdate_Client)
                        {
                            var item_Server = lstDataUpdate_Server.Find(x => x.KeyID == item_Client.KeyID);

                            Dictionary<string, object> dKeys = new Dictionary<string, object>();
                            dKeys.Add("KeyID", item_Client.KeyID);

                            Dictionary<string, object> dValues = new Dictionary<string, object>();
                            Dictionary<string, object> dValues_New = ObjectToDictionary(item_Client);
                            Dictionary<string, object> dValues_Old = ObjectToDictionary(item_Server);

                            foreach (var item_New in dValues_New)
                            {
                                object NewValue = dValues_New[item_New.Key];
                                object OldValue = dValues_Old[item_New.Key];

                                if (OldValue != null && NewValue != null && !OldValue.Equals(NewValue)) { dValues.Add(item_New.Key, NewValue); }
                                else if (OldValue != null && NewValue == null) { dValues.Add(item_New.Key, NewValue); }
                                else if (OldValue == null && NewValue != null) { dValues.Add(item_New.Key, NewValue); }
                                else { }
                            }

                            foreach (var key in dKeys)
                            {
                                dValues.Remove(key.Key);
                            }

                            SaveUpdate(sDB, "eProductScale", dKeys, dValues);
                        }
                        #endregion
                    }
                    else if (cMaxID > sMaxID)
                    {
                        #region Chuyển dữ liệu từ Client sang Server
                        List<eProduct> lstData_Client = cDB.Database.SqlQuery<eProduct>($"select * from eProduct where KeyID>{(sMaxID.HasValue ? sMaxID.Value : 0)}", new SqlParameter[] { }).ToList();
                        sDB.Database.ExecuteSqlCommand("SET IDENTITY_INSERT eProductScale ON ");
                        foreach (var item in lstData_Client) { SaveInsert(sDB, "eProductScale", ObjectToDictionary(item)); }
                        sDB.Database.ExecuteSqlCommand("SET IDENTITY_INSERT eProductScale OFF ");
                        #endregion

                        #region  Cập nhật dữ liệu
                        List<eProduct> lstDataUpdate_Client = cDB.Database.SqlQuery<eProduct>($"select * from eProduct where KeyID<={(sMaxID.HasValue ? sMaxID.Value : 0)}", new SqlParameter[] { }).ToList();
                        List<eProductScale> lstDataUpdate_Server = sDB.Database.SqlQuery<eProductScale>($"select * from eProductScale where KeyID<={(sMaxID.HasValue ? sMaxID.Value : 0)}", new SqlParameter[] { }).ToList();
                        foreach (var item_Client in lstDataUpdate_Client)
                        {
                            var item_Server = lstDataUpdate_Server.Find(x => x.KeyID == item_Client.KeyID);

                            Dictionary<string, object> dKeys = new Dictionary<string, object>();
                            dKeys.Add("KeyID", item_Client.KeyID);

                            Dictionary<string, object> dValues = new Dictionary<string, object>();
                            Dictionary<string, object> dValues_New = ObjectToDictionary(item_Client);
                            Dictionary<string, object> dValues_Old = ObjectToDictionary(item_Server);

                            foreach (var item_New in dValues_New)
                            {
                                object NewValue = dValues_New[item_New.Key];
                                object OldValue = dValues_Old[item_New.Key];

                                if (OldValue != null && NewValue != null && !OldValue.Equals(NewValue)) { dValues.Add(item_New.Key, NewValue); }
                                else if (OldValue != null && NewValue == null) { dValues.Add(item_New.Key, NewValue); }
                                else if (OldValue == null && NewValue != null) { dValues.Add(item_New.Key, NewValue); }
                                else { }
                            }

                            foreach (var key in dKeys)
                            {
                                dValues.Remove(key.Key);
                            }

                            SaveUpdate(sDB, "eProductScale", dKeys, dValues);
                        }
                        #endregion
                    }
                    else
                    {
                        #region Chuyển dữ liệu từ Server sang Client
                        List<eProductScale> lstData_Server = sDB.Database.SqlQuery<eProductScale>($"select * from eProductScale where KeyID>{(cMaxID.HasValue ? cMaxID.Value : 0)}", new SqlParameter[] { }).ToList();
                        cDB.Database.ExecuteSqlCommand("SET IDENTITY_INSERT eProduct ON ");
                        foreach (var item in lstData_Server) { SaveInsert(cDB, "eProduct", ObjectToDictionary(item)); }
                        cDB.Database.ExecuteSqlCommand("SET IDENTITY_INSERT eProduct OFF ");
                        #endregion

                        #region  Cập nhật dữ liệu
                        List<eProduct> lstDataUpdate_Client = cDB.Database.SqlQuery<eProduct>($"select * from eProduct where KeyID<={(cMaxID.HasValue ? cMaxID.Value : 0)}", new SqlParameter[] { }).ToList();
                        List<eProduct> lstDataUpdate_Server = sDB.Database.SqlQuery<eProduct>($"select * from eProductScale where KeyID<={(cMaxID.HasValue ? cMaxID.Value : 0)}", new SqlParameter[] { }).ToList();
                        foreach (var item_Client in lstDataUpdate_Client)
                        {
                            var item_Server = lstDataUpdate_Server.Find(x => x.KeyID == item_Client.KeyID);

                            Dictionary<string, object> dKeys = new Dictionary<string, object>();
                            dKeys.Add("KeyID", item_Client.KeyID);

                            Dictionary<string, object> dValues = new Dictionary<string, object>();
                            Dictionary<string, object> dValues_New = ObjectToDictionary(item_Client);
                            Dictionary<string, object> dValues_Old = ObjectToDictionary(item_Server);

                            foreach (var item_New in dValues_New)
                            {
                                object NewValue = dValues_New[item_New.Key];
                                object OldValue = dValues_Old[item_New.Key];

                                if (OldValue != null && NewValue != null && !OldValue.Equals(NewValue)) { dValues.Add(item_New.Key, NewValue); }
                                else if (OldValue != null && NewValue == null) { dValues.Add(item_New.Key, NewValue); }
                                else if (OldValue == null && NewValue != null) { dValues.Add(item_New.Key, NewValue); }
                                else { }
                            }

                            foreach (var key in dKeys)
                            {
                                dValues.Remove(key.Key);
                            }

                            SaveUpdate(sDB, "eProductScale", dKeys, dValues);
                        }
                        #endregion
                    }
                }
                else if (cMaxID.HasValue && !sMaxID.HasValue)
                {
                    #region Chuyển dữ liệu từ Client sang Server
                    List<eProduct> lstData_Client = cDB.Database.SqlQuery<eProduct>($"select * from eProduct where KeyID>{(sMaxID.HasValue ? sMaxID.Value : 0)}", new SqlParameter[] { }).ToList();
                    sDB.Database.ExecuteSqlCommand("SET IDENTITY_INSERT eProductScale ON ");
                    foreach (var item in lstData_Client) { SaveInsert(sDB, "eProductScale", ObjectToDictionary(item)); }
                    sDB.Database.ExecuteSqlCommand("SET IDENTITY_INSERT eProductScale OFF ");
                    #endregion
                }
                else if (!cMaxID.HasValue && sMaxID.HasValue)
                {
                    #region Chuyển dữ liệu từ Server sang Client
                    List<eProductScale> lstData_Server = sDB.Database.SqlQuery<eProductScale>($"select * from eProductScale where KeyID>{(cMaxID.HasValue ? cMaxID.Value : 0)}", new SqlParameter[] { }).ToList();
                    cDB.Database.ExecuteSqlCommand("SET IDENTITY_INSERT eProduct ON ");
                    foreach (var item in lstData_Server) { SaveInsert(cDB, "eProduct", ObjectToDictionary(item)); }
                    cDB.Database.ExecuteSqlCommand("SET IDENTITY_INSERT eProduct OFF ");
                    #endregion
                }
                else
                {
                    //  Cập nhật dữ liệu
                }

                cDB.Database.CurrentTransaction.Commit();
                sDB.Database.CurrentTransaction.Commit();
                clsGeneral.CloseWaitForm();
                clsGeneral.showMessage("Cập nhật sản phẩm hoàn tất");
            }
            catch (Exception ex)
            {
                cDB.Database.CurrentTransaction.Rollback();
                sDB.Database.CurrentTransaction.Rollback();
                clsGeneral.CloseWaitForm();
                clsGeneral.showErrorException(ex, "Cập nhật sản phẩm thất bại");
            }
        }

        private void btnSyncKHO_Click(object sender, EventArgs e)
        {
            clsGeneral.CallWaitForm(this);
            zModel cDB = new zModel();
            sModel sDB = new sModel();

            cDB.Database.BeginTransaction();
            sDB.Database.BeginTransaction();

            try
            {
                List<int?> cQuery = cDB.Database.SqlQuery<int?>("select max(KeyID) from eWarehouse", new SqlParameter[] { }).ToList();
                List<int?> sQuery = sDB.Database.SqlQuery<int?>("select max(KeyID) from eWarehouseScale", new SqlParameter[] { }).ToList();

                int? cMaxID = cQuery[0];
                int? sMaxID = sQuery[0];

                if (cMaxID.HasValue && sMaxID.HasValue)
                {
                    if (cMaxID == sMaxID)
                    {
                        #region  Cập nhật dữ liệu
                        List<eWarehouse> lstDataUpdate_Client = cDB.Database.SqlQuery<eWarehouse>($"select * from eWarehouse", new SqlParameter[] { }).ToList();
                        List<eWarehouseScale> lstDataUpdate_Server = sDB.Database.SqlQuery<eWarehouseScale>($"select * from eWarehouseScale", new SqlParameter[] { }).ToList();
                        foreach (var item_Client in lstDataUpdate_Client)
                        {
                            var item_Server = lstDataUpdate_Server.Find(x => x.KeyID == item_Client.KeyID);

                            Dictionary<string, object> dKeys = new Dictionary<string, object>();
                            dKeys.Add("KeyID", item_Client.KeyID);

                            Dictionary<string, object> dValues = new Dictionary<string, object>();
                            Dictionary<string, object> dValues_New = ObjectToDictionary(item_Client);
                            Dictionary<string, object> dValues_Old = ObjectToDictionary(item_Server);

                            foreach (var item_New in dValues_New)
                            {
                                object NewValue = dValues_New[item_New.Key];
                                object OldValue = dValues_Old[item_New.Key];

                                if (OldValue != null && NewValue != null && !OldValue.Equals(NewValue)) { dValues.Add(item_New.Key, NewValue); }
                                else if (OldValue != null && NewValue == null) { dValues.Add(item_New.Key, NewValue); }
                                else if (OldValue == null && NewValue != null) { dValues.Add(item_New.Key, NewValue); }
                                else { }
                            }

                            foreach (var key in dKeys)
                            {
                                dValues.Remove(key.Key);
                            }

                            SaveUpdate(sDB, "eWarehouseScale", dKeys, dValues);
                        }
                        #endregion
                    }
                    else if (cMaxID > sMaxID)
                    {
                        #region Chuyển dữ liệu từ Client sang Server
                        List<eWarehouse> lstData_Client = cDB.Database.SqlQuery<eWarehouse>($"select * from eWarehouse where KeyID>{(sMaxID.HasValue ? sMaxID.Value : 0)}", new SqlParameter[] { }).ToList();
                        sDB.Database.ExecuteSqlCommand("SET IDENTITY_INSERT eWarehouseScale ON ");
                        foreach (var item in lstData_Client) { SaveInsert(sDB, "eWarehouseScale", ObjectToDictionary(item)); }
                        sDB.Database.ExecuteSqlCommand("SET IDENTITY_INSERT eWarehouseScale OFF ");
                        #endregion

                        #region  Cập nhật dữ liệu
                        List<eWarehouse> lstDataUpdate_Client = cDB.Database.SqlQuery<eWarehouse>($"select * from eWarehouse where KeyID<={(sMaxID.HasValue ? sMaxID.Value : 0)}", new SqlParameter[] { }).ToList();
                        List<eWarehouseScale> lstDataUpdate_Server = sDB.Database.SqlQuery<eWarehouseScale>($"select * from eWarehouseScale where KeyID<={(sMaxID.HasValue ? sMaxID.Value : 0)}", new SqlParameter[] { }).ToList();
                        foreach (var item_Client in lstDataUpdate_Client)
                        {
                            var item_Server = lstDataUpdate_Server.Find(x => x.KeyID == item_Client.KeyID);

                            Dictionary<string, object> dKeys = new Dictionary<string, object>();
                            dKeys.Add("KeyID", item_Client.KeyID);

                            Dictionary<string, object> dValues = new Dictionary<string, object>();
                            Dictionary<string, object> dValues_New = ObjectToDictionary(item_Client);
                            Dictionary<string, object> dValues_Old = ObjectToDictionary(item_Server);

                            foreach (var item_New in dValues_New)
                            {
                                object NewValue = dValues_New[item_New.Key];
                                object OldValue = dValues_Old[item_New.Key];

                                if (OldValue != null && NewValue != null && !OldValue.Equals(NewValue)) { dValues.Add(item_New.Key, NewValue); }
                                else if (OldValue != null && NewValue == null) { dValues.Add(item_New.Key, NewValue); }
                                else if (OldValue == null && NewValue != null) { dValues.Add(item_New.Key, NewValue); }
                                else { }
                            }

                            foreach (var key in dKeys)
                            {
                                dValues.Remove(key.Key);
                            }

                            SaveUpdate(sDB, "eWarehouseScale", dKeys, dValues);
                        }
                        #endregion
                    }
                    else
                    {
                        #region Chuyển dữ liệu từ Server sang Client
                        List<eWarehouseScale> lstData_Server = sDB.Database.SqlQuery<eWarehouseScale>($"select * from eWarehouseScale where KeyID>{(cMaxID.HasValue ? cMaxID.Value : 0)}", new SqlParameter[] { }).ToList();
                        cDB.Database.ExecuteSqlCommand("SET IDENTITY_INSERT eWarehouse ON ");
                        foreach (var item in lstData_Server) { SaveInsert(cDB, "eWarehouse", ObjectToDictionary(item)); }
                        cDB.Database.ExecuteSqlCommand("SET IDENTITY_INSERT eWarehouse OFF ");
                        #endregion

                        #region  Cập nhật dữ liệu
                        List<eWarehouse> lstDataUpdate_Client = cDB.Database.SqlQuery<eWarehouse>($"select * from eWarehouse where KeyID<={(cMaxID.HasValue ? cMaxID.Value : 0)}", new SqlParameter[] { }).ToList();
                        List<eWarehouseScale> lstDataUpdate_Server = sDB.Database.SqlQuery<eWarehouseScale>($"select * from eWarehouseScale where KeyID<={(cMaxID.HasValue ? cMaxID.Value : 0)}", new SqlParameter[] { }).ToList();
                        foreach (var item_Client in lstDataUpdate_Client)
                        {
                            var item_Server = lstDataUpdate_Server.Find(x => x.KeyID == item_Client.KeyID);

                            Dictionary<string, object> dKeys = new Dictionary<string, object>();
                            dKeys.Add("KeyID", item_Client.KeyID);

                            Dictionary<string, object> dValues = new Dictionary<string, object>();
                            Dictionary<string, object> dValues_New = ObjectToDictionary(item_Client);
                            Dictionary<string, object> dValues_Old = ObjectToDictionary(item_Server);

                            foreach (var item_New in dValues_New)
                            {
                                object NewValue = dValues_New[item_New.Key];
                                object OldValue = dValues_Old[item_New.Key];

                                if (OldValue != null && NewValue != null && !OldValue.Equals(NewValue)) { dValues.Add(item_New.Key, NewValue); }
                                else if (OldValue != null && NewValue == null) { dValues.Add(item_New.Key, NewValue); }
                                else if (OldValue == null && NewValue != null) { dValues.Add(item_New.Key, NewValue); }
                                else { }
                            }

                            foreach (var key in dKeys)
                            {
                                dValues.Remove(key.Key);
                            }

                            SaveUpdate(sDB, "eWarehouseScale", dKeys, dValues);
                        }
                        #endregion
                    }
                }
                else if (cMaxID.HasValue && !sMaxID.HasValue)
                {
                    #region Chuyển dữ liệu từ Client sang Server
                    List<eWarehouse> lstData_Client = cDB.Database.SqlQuery<eWarehouse>($"select * from eWarehouse where KeyID>{(sMaxID.HasValue ? sMaxID.Value : 0)}", new SqlParameter[] { }).ToList();
                    sDB.Database.ExecuteSqlCommand("SET IDENTITY_INSERT eWarehouseScale ON ");
                    foreach (var item in lstData_Client) { SaveInsert(sDB, "eWarehouseScale", ObjectToDictionary(item)); }
                    sDB.Database.ExecuteSqlCommand("SET IDENTITY_INSERT eWarehouseScale OFF ");
                    #endregion
                }
                else if (!cMaxID.HasValue && sMaxID.HasValue)
                {
                    #region Chuyển dữ liệu từ Server sang Client
                    List<eWarehouseScale> lstData_Server = sDB.Database.SqlQuery<eWarehouseScale>($"select * from eWarehouseScale where KeyID>{(cMaxID.HasValue ? cMaxID.Value : 0)}", new SqlParameter[] { }).ToList();
                    cDB.Database.ExecuteSqlCommand("SET IDENTITY_INSERT eWarehouse ON ");
                    foreach (var item in lstData_Server) { SaveInsert(cDB, "eWarehouse", ObjectToDictionary(item)); }
                    cDB.Database.ExecuteSqlCommand("SET IDENTITY_INSERT eWarehouse OFF ");
                    #endregion
                }
                else
                {
                    //  Cập nhật dữ liệu
                }

                cDB.Database.CurrentTransaction.Commit();
                sDB.Database.CurrentTransaction.Commit();
                clsGeneral.CloseWaitForm();
                clsGeneral.showMessage("Cập nhật kho hoàn tất");
            }
            catch (Exception ex)
            {
                cDB.Database.CurrentTransaction.Rollback();
                sDB.Database.CurrentTransaction.Rollback();
                clsGeneral.CloseWaitForm();
                clsGeneral.showErrorException(ex, "Cập nhật kho thất bại");
            }
        }

        private void btnSyncKH_Click(object sender, EventArgs e)
        {
            clsGeneral.CallWaitForm(this);
            zModel cDB = new zModel();
            sModel sDB = new sModel();

            cDB.Database.BeginTransaction();
            sDB.Database.BeginTransaction();

            try
            {
                List<int?> cQuery = cDB.Database.SqlQuery<int?>("select max(KeyID) from eCustomer", new SqlParameter[] { }).ToList();
                List<int?> sQuery = sDB.Database.SqlQuery<int?>("select max(KeyID) from eCustomerScale", new SqlParameter[] { }).ToList();

                int? cMaxID = cQuery[0];
                int? sMaxID = sQuery[0];

                if (cMaxID.HasValue && sMaxID.HasValue)
                {
                    if (cMaxID == sMaxID)
                    {
                        #region  Cập nhật dữ liệu
                        List<eCustomer> lstDataUpdate_Client = cDB.Database.SqlQuery<eCustomer>($"select * from eCustomer", new SqlParameter[] { }).ToList();
                        List<eCustomerScale> lstDataUpdate_Server = sDB.Database.SqlQuery<eCustomerScale>($"select * from eCustomerScale", new SqlParameter[] { }).ToList();
                        foreach (var item_Client in lstDataUpdate_Client)
                        {
                            var item_Server = lstDataUpdate_Server.Find(x => x.KeyID == item_Client.KeyID);

                            Dictionary<string, object> dKeys = new Dictionary<string, object>();
                            dKeys.Add("KeyID", item_Client.KeyID);

                            Dictionary<string, object> dValues = new Dictionary<string, object>();
                            Dictionary<string, object> dValues_New = ObjectToDictionary(item_Client);
                            Dictionary<string, object> dValues_Old = ObjectToDictionary(item_Server);

                            foreach (var item_New in dValues_New)
                            {
                                object NewValue = dValues_New[item_New.Key];
                                object OldValue = dValues_Old[item_New.Key];

                                if (OldValue != null && NewValue != null && !OldValue.Equals(NewValue)) { dValues.Add(item_New.Key, NewValue); }
                                else if (OldValue != null && NewValue == null) { dValues.Add(item_New.Key, NewValue); }
                                else if (OldValue == null && NewValue != null) { dValues.Add(item_New.Key, NewValue); }
                                else { }
                            }

                            foreach (var key in dKeys)
                            {
                                dValues.Remove(key.Key);
                            }

                            SaveUpdate(sDB, "eCustomerScale", dKeys, dValues);
                        }
                        #endregion
                    }
                    else if (cMaxID > sMaxID)
                    {
                        #region Chuyển dữ liệu từ Client sang Server
                        List<eCustomer> lstData_Client = cDB.Database.SqlQuery<eCustomer>($"select * from eCustomer where KeyID>{(sMaxID.HasValue ? sMaxID.Value : 0)}", new SqlParameter[] { }).ToList();
                        sDB.Database.ExecuteSqlCommand("SET IDENTITY_INSERT eCustomerScale ON ");
                        foreach (var item in lstData_Client) { SaveInsert(sDB, "eCustomerScale", ObjectToDictionary(item)); }
                        sDB.Database.ExecuteSqlCommand("SET IDENTITY_INSERT eCustomerScale OFF ");
                        #endregion

                        #region  Cập nhật dữ liệu
                        List<eCustomer> lstDataUpdate_Client = cDB.Database.SqlQuery<eCustomer>($"select * from eCustomer where KeyID<={(sMaxID.HasValue ? sMaxID.Value : 0)}", new SqlParameter[] { }).ToList();
                        List<eCustomerScale> lstDataUpdate_Server = sDB.Database.SqlQuery<eCustomerScale>($"select * from eCustomerScale where KeyID<={(sMaxID.HasValue ? sMaxID.Value : 0)}", new SqlParameter[] { }).ToList();
                        foreach (var item_Client in lstDataUpdate_Client)
                        {
                            var item_Server = lstDataUpdate_Server.Find(x => x.KeyID == item_Client.KeyID);

                            Dictionary<string, object> dKeys = new Dictionary<string, object>();
                            dKeys.Add("KeyID", item_Client.KeyID);

                            Dictionary<string, object> dValues = new Dictionary<string, object>();
                            Dictionary<string, object> dValues_New = ObjectToDictionary(item_Client);
                            Dictionary<string, object> dValues_Old = ObjectToDictionary(item_Server);

                            foreach (var item_New in dValues_New)
                            {
                                object NewValue = dValues_New[item_New.Key];
                                object OldValue = dValues_Old[item_New.Key];

                                if (OldValue != null && NewValue != null && !OldValue.Equals(NewValue)) { dValues.Add(item_New.Key, NewValue); }
                                else if (OldValue != null && NewValue == null) { dValues.Add(item_New.Key, NewValue); }
                                else if (OldValue == null && NewValue != null) { dValues.Add(item_New.Key, NewValue); }
                                else { }
                            }

                            foreach (var key in dKeys)
                            {
                                dValues.Remove(key.Key);
                            }

                            SaveUpdate(sDB, "eCustomerScale", dKeys, dValues);
                        }
                        #endregion
                    }
                    else
                    {
                        #region Chuyển dữ liệu từ Server sang Client
                        List<eCustomerScale> lstData_Server = sDB.Database.SqlQuery<eCustomerScale>($"select * from eCustomerScale where KeyID>{(cMaxID.HasValue ? cMaxID.Value : 0)}", new SqlParameter[] { }).ToList();
                        cDB.Database.ExecuteSqlCommand("SET IDENTITY_INSERT eCustomer ON ");
                        foreach (var item in lstData_Server) { SaveInsert(cDB, "eCustomer", ObjectToDictionary(item)); }
                        cDB.Database.ExecuteSqlCommand("SET IDENTITY_INSERT eCustomer OFF ");
                        #endregion

                        #region  Cập nhật dữ liệu
                        List<eCustomer> lstDataUpdate_Client = cDB.Database.SqlQuery<eCustomer>($"select * from eCustomer where KeyID<={(cMaxID.HasValue ? cMaxID.Value : 0)}", new SqlParameter[] { }).ToList();
                        List<eCustomerScale> lstDataUpdate_Server = sDB.Database.SqlQuery<eCustomerScale>($"select * from eCustomerScale where KeyID<={(cMaxID.HasValue ? cMaxID.Value : 0)}", new SqlParameter[] { }).ToList();
                        foreach (var item_Client in lstDataUpdate_Client)
                        {
                            var item_Server = lstDataUpdate_Server.Find(x => x.KeyID == item_Client.KeyID);

                            Dictionary<string, object> dKeys = new Dictionary<string, object>();
                            dKeys.Add("KeyID", item_Client.KeyID);

                            Dictionary<string, object> dValues = new Dictionary<string, object>();
                            Dictionary<string, object> dValues_New = ObjectToDictionary(item_Client);
                            Dictionary<string, object> dValues_Old = ObjectToDictionary(item_Server);

                            foreach (var item_New in dValues_New)
                            {
                                object NewValue = dValues_New[item_New.Key];
                                object OldValue = dValues_Old[item_New.Key];

                                if (OldValue != null && NewValue != null && !OldValue.Equals(NewValue)) { dValues.Add(item_New.Key, NewValue); }
                                else if (OldValue != null && NewValue == null) { dValues.Add(item_New.Key, NewValue); }
                                else if (OldValue == null && NewValue != null) { dValues.Add(item_New.Key, NewValue); }
                                else { }
                            }

                            foreach (var key in dKeys)
                            {
                                dValues.Remove(key.Key);
                            }

                            SaveUpdate(sDB, "eCustomerScale", dKeys, dValues);
                        }
                        #endregion
                    }
                }
                else if (cMaxID.HasValue && !sMaxID.HasValue)
                {
                    #region  Chuyển dữ liệu từ Client sang Server
                    List<eCustomer> lstData_Client = cDB.Database.SqlQuery<eCustomer>($"select * from eCustomer where KeyID>{(sMaxID.HasValue ? sMaxID.Value : 0)}", new SqlParameter[] { }).ToList();
                    sDB.Database.ExecuteSqlCommand("SET IDENTITY_INSERT eCustomerScale ON ");
                    foreach (var item in lstData_Client) { SaveInsert(sDB, "eCustomerScale", ObjectToDictionary(item)); }
                    sDB.Database.ExecuteSqlCommand("SET IDENTITY_INSERT eCustomerScale OFF ");
                    #endregion
                }
                else if (!cMaxID.HasValue && sMaxID.HasValue)
                {
                    #region Chuyển dữ liệu từ Server sang Client
                    List<eCustomerScale> lstData_Server = sDB.Database.SqlQuery<eCustomerScale>($"select * from eCustomerScale where KeyID>{(cMaxID.HasValue ? cMaxID.Value : 0)}", new SqlParameter[] { }).ToList();
                    cDB.Database.ExecuteSqlCommand("SET IDENTITY_INSERT eCustomer ON ");
                    foreach (var item in lstData_Server) { SaveInsert(cDB, "eCustomer", ObjectToDictionary(item)); }
                    cDB.Database.ExecuteSqlCommand("SET IDENTITY_INSERT eCustomer OFF ");
                    #endregion
                }
                else
                {
                    //  Cập nhật dữ liệu
                }

                cDB.Database.CurrentTransaction.Commit();
                sDB.Database.CurrentTransaction.Commit();
                clsGeneral.CloseWaitForm();
                clsGeneral.showMessage("Cập nhật khách hàng hoàn tất");
            }
            catch (Exception ex)
            {
                cDB.Database.CurrentTransaction.Rollback();
                sDB.Database.CurrentTransaction.Rollback();
                clsGeneral.CloseWaitForm();
                clsGeneral.showErrorException(ex, "Cập nhật khách hàng thất bại");
            }
        }
    }
}
