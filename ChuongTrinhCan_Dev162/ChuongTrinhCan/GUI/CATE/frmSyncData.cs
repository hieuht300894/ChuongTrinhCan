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
                        // Không làm gì
                    }
                    else if (cMaxID > sMaxID)
                    {
                        // Chuyển dữ liệu từ Client sang Server
                        List<eScaleInfomation> lstCustomer_Client = cDB.Database.SqlQuery<eScaleInfomation>($"select * from eScaleInfomation where KeyID>{(sMaxID.HasValue ? sMaxID.Value : 0)}", new SqlParameter[] { }).ToList();
                        sDB.Database.ExecuteSqlCommand("SET IDENTITY_INSERT eScaleInfomation ON ");
                        foreach (var item in lstCustomer_Client) { SaveInsert(sDB, "eScaleInfomation", ObjectToDictionary(item)); }
                        sDB.Database.ExecuteSqlCommand("SET IDENTITY_INSERT eScaleInfomation OFF ");
                    }
                    else
                    {
                        // Chuyển dữ liệu từ Server sang Client
                        List<eScaleInfomation> lstCustomer_Server = sDB.Database.SqlQuery<eScaleInfomation>($"select * from eScaleInfomation where KeyID>{(cMaxID.HasValue ? cMaxID.Value : 0)}", new SqlParameter[] { }).ToList();
                        cDB.Database.ExecuteSqlCommand("SET IDENTITY_INSERT eScaleInfomation ON ");
                        foreach (var item in lstCustomer_Server) { SaveInsert(cDB, "eScaleInfomation", ObjectToDictionary(item)); }
                        cDB.Database.ExecuteSqlCommand("SET IDENTITY_INSERT eScaleInfomation OFF ");
                    }
                }
                else if (cMaxID.HasValue && !sMaxID.HasValue)
                {
                    // Chuyển dữ liệu từ Client sang Server
                    List<eScaleInfomation> lstCustomer_Client = cDB.Database.SqlQuery<eScaleInfomation>($"select * from eScaleInfomation where KeyID>{(sMaxID.HasValue ? sMaxID.Value : 0)}", new SqlParameter[] { }).ToList();
                    sDB.Database.ExecuteSqlCommand("SET IDENTITY_INSERT eScaleInfomation ON ");
                    foreach (var item in lstCustomer_Client) { SaveInsert(sDB, "eScaleInfomation", ObjectToDictionary(item)); }
                    sDB.Database.ExecuteSqlCommand("SET IDENTITY_INSERT eScaleInfomation OFF ");
                }
                else if (!cMaxID.HasValue && sMaxID.HasValue)
                {
                    // Chuyển dữ liệu từ Server sang Client
                    List<eScaleInfomation> lstCustomer_Server = sDB.Database.SqlQuery<eScaleInfomation>($"select * from eScaleInfomation where KeyID>{(cMaxID.HasValue ? cMaxID.Value : 0)}", new SqlParameter[] { }).ToList();
                    cDB.Database.ExecuteSqlCommand("SET IDENTITY_INSERT eScaleInfomation ON ");
                    foreach (var item in lstCustomer_Server) { SaveInsert(cDB, "eScaleInfomation", ObjectToDictionary(item)); }
                    cDB.Database.ExecuteSqlCommand("SET IDENTITY_INSERT eScaleInfomation OFF ");
                }
                else
                {
                    // Không làm gì
                }

                cDB.Database.CurrentTransaction.Commit();
                sDB.Database.CurrentTransaction.Commit();
                clsGeneral.CloseWaitForm();
                clsGeneral.showMessage("Đồng bộ dữ liệu cân hoàn tất");
            }
            catch (Exception ex)
            {
                cDB.Database.CurrentTransaction.Rollback();
                sDB.Database.CurrentTransaction.Rollback();
                clsGeneral.CloseWaitForm();
                clsGeneral.showErrorException(ex, "Đồng bộ dữ liệu cân thất bại");
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
                        // Không làm gì
                    }
                    else if (cMaxID > sMaxID)
                    {
                        // Chuyển dữ liệu từ Client sang Server
                        List<eProduct> lstCustomer_Client = cDB.Database.SqlQuery<eProduct>($"select * from eProduct where KeyID>{(sMaxID.HasValue ? sMaxID.Value : 0)}", new SqlParameter[] { }).ToList();
                        sDB.Database.ExecuteSqlCommand("SET IDENTITY_INSERT eProductScale ON ");
                        foreach (var item in lstCustomer_Client) { SaveInsert(sDB, "eProductScale", ObjectToDictionary(item)); }
                        sDB.Database.ExecuteSqlCommand("SET IDENTITY_INSERT eProductScale OFF ");
                    }
                    else
                    {
                        // Chuyển dữ liệu từ Server sang Client
                        List<eProductScale> lstCustomer_Server = sDB.Database.SqlQuery<eProductScale>($"select * from eProductScale where KeyID>{(cMaxID.HasValue ? cMaxID.Value : 0)}", new SqlParameter[] { }).ToList();
                        cDB.Database.ExecuteSqlCommand("SET IDENTITY_INSERT eProduct ON ");
                        foreach (var item in lstCustomer_Server) { SaveInsert(cDB, "eProduct", ObjectToDictionary(item)); }
                        cDB.Database.ExecuteSqlCommand("SET IDENTITY_INSERT eProduct OFF ");
                    }
                }
                else if (cMaxID.HasValue && !sMaxID.HasValue)
                {
                    // Chuyển dữ liệu từ Client sang Server
                    List<eProduct> lstCustomer_Client = cDB.Database.SqlQuery<eProduct>($"select * from eProduct where KeyID>{(sMaxID.HasValue ? sMaxID.Value : 0)}", new SqlParameter[] { }).ToList();
                    sDB.Database.ExecuteSqlCommand("SET IDENTITY_INSERT eProductScale ON ");
                    foreach (var item in lstCustomer_Client) { SaveInsert(sDB, "eProductScale", ObjectToDictionary(item)); }
                    sDB.Database.ExecuteSqlCommand("SET IDENTITY_INSERT eProductScale OFF ");
                }
                else if (!cMaxID.HasValue && sMaxID.HasValue)
                {
                    // Chuyển dữ liệu từ Server sang Client
                    List<eProductScale> lstCustomer_Server = sDB.Database.SqlQuery<eProductScale>($"select * from eProductScale where KeyID>{(cMaxID.HasValue ? cMaxID.Value : 0)}", new SqlParameter[] { }).ToList();
                    cDB.Database.ExecuteSqlCommand("SET IDENTITY_INSERT eProduct ON ");
                    foreach (var item in lstCustomer_Server) { SaveInsert(cDB, "eProduct", ObjectToDictionary(item)); }
                    cDB.Database.ExecuteSqlCommand("SET IDENTITY_INSERT eProduct OFF ");
                }
                else
                {
                    // Không làm gì
                }

                cDB.Database.CurrentTransaction.Commit();
                sDB.Database.CurrentTransaction.Commit();
                clsGeneral.CloseWaitForm();
                clsGeneral.showMessage("Đồng bộ sản phẩm hoàn tất");
            }
            catch (Exception ex)
            {
                cDB.Database.CurrentTransaction.Rollback();
                sDB.Database.CurrentTransaction.Rollback();
                clsGeneral.CloseWaitForm();
                clsGeneral.showErrorException(ex, "Đồng bộ sản phẩm thất bại");
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
                        // Không làm gì
                    }
                    else if (cMaxID > sMaxID)
                    {
                        // Chuyển dữ liệu từ Client sang Server
                        List<eWarehouse> lstCustomer_Client = cDB.Database.SqlQuery<eWarehouse>($"select * from eWarehouse where KeyID>{(sMaxID.HasValue ? sMaxID.Value : 0)}", new SqlParameter[] { }).ToList();
                        sDB.Database.ExecuteSqlCommand("SET IDENTITY_INSERT eWarehouseScale ON ");
                        foreach (var item in lstCustomer_Client) { SaveInsert(sDB, "eWarehouseScale", ObjectToDictionary(item)); }
                        sDB.Database.ExecuteSqlCommand("SET IDENTITY_INSERT eWarehouseScale OFF ");
                    }
                    else
                    {
                        // Chuyển dữ liệu từ Server sang Client
                        List<eWarehouseScale> lstCustomer_Server = sDB.Database.SqlQuery<eWarehouseScale>($"select * from eWarehouseScale where KeyID>{(cMaxID.HasValue ? cMaxID.Value : 0)}", new SqlParameter[] { }).ToList();
                        cDB.Database.ExecuteSqlCommand("SET IDENTITY_INSERT eWarehouse ON ");
                        foreach (var item in lstCustomer_Server) { SaveInsert(cDB, "eWarehouse", ObjectToDictionary(item)); }
                        cDB.Database.ExecuteSqlCommand("SET IDENTITY_INSERT eWarehouse OFF ");
                    }
                }
                else if (cMaxID.HasValue && !sMaxID.HasValue)
                {
                    // Chuyển dữ liệu từ Client sang Server
                    List<eWarehouse> lstCustomer_Client = cDB.Database.SqlQuery<eWarehouse>($"select * from eWarehouse where KeyID>{(sMaxID.HasValue ? sMaxID.Value : 0)}", new SqlParameter[] { }).ToList();
                    sDB.Database.ExecuteSqlCommand("SET IDENTITY_INSERT eWarehouseScale ON ");
                    foreach (var item in lstCustomer_Client) { SaveInsert(sDB, "eWarehouseScale", ObjectToDictionary(item)); }
                    sDB.Database.ExecuteSqlCommand("SET IDENTITY_INSERT eWarehouseScale OFF ");
                }
                else if (!cMaxID.HasValue && sMaxID.HasValue)
                {
                    // Chuyển dữ liệu từ Server sang Client
                    List<eWarehouseScale> lstCustomer_Server = sDB.Database.SqlQuery<eWarehouseScale>($"select * from eWarehouseScale where KeyID>{(cMaxID.HasValue ? cMaxID.Value : 0)}", new SqlParameter[] { }).ToList();
                    cDB.Database.ExecuteSqlCommand("SET IDENTITY_INSERT eWarehouse ON ");
                    foreach (var item in lstCustomer_Server) { SaveInsert(cDB, "eWarehouse", ObjectToDictionary(item)); }
                    cDB.Database.ExecuteSqlCommand("SET IDENTITY_INSERT eWarehouse OFF ");
                }
                else
                {
                    // Không làm gì
                }

                cDB.Database.CurrentTransaction.Commit();
                sDB.Database.CurrentTransaction.Commit();
                clsGeneral.CloseWaitForm();
                clsGeneral.showMessage("Đồng bộ kho hoàn tất");
            }
            catch (Exception ex)
            {
                cDB.Database.CurrentTransaction.Rollback();
                sDB.Database.CurrentTransaction.Rollback();
                clsGeneral.CloseWaitForm();
                clsGeneral.showErrorException(ex, "Đồng bộ kho thất bại");
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
                        // Không làm gì
                    }
                    else if (cMaxID > sMaxID)
                    {
                        // Chuyển dữ liệu từ Client sang Server
                        List<eCustomer> lstCustomer_Client = cDB.Database.SqlQuery<eCustomer>($"select * from eCustomer where KeyID>{(sMaxID.HasValue ? sMaxID.Value : 0)}", new SqlParameter[] { }).ToList();
                        sDB.Database.ExecuteSqlCommand("SET IDENTITY_INSERT eCustomerScale ON ");
                        foreach (var item in lstCustomer_Client) { SaveInsert(sDB, "eCustomerScale", ObjectToDictionary(item)); }
                        sDB.Database.ExecuteSqlCommand("SET IDENTITY_INSERT eCustomerScale OFF ");
                    }
                    else
                    {
                        // Chuyển dữ liệu từ Server sang Client
                        List<eCustomerScale> lstCustomer_Server = sDB.Database.SqlQuery<eCustomerScale>($"select * from eCustomerScale where KeyID>{(cMaxID.HasValue ? cMaxID.Value : 0)}", new SqlParameter[] { }).ToList();
                        cDB.Database.ExecuteSqlCommand("SET IDENTITY_INSERT eCustomer ON ");
                        foreach (var item in lstCustomer_Server) { SaveInsert(cDB, "eCustomer", ObjectToDictionary(item)); }
                        cDB.Database.ExecuteSqlCommand("SET IDENTITY_INSERT eCustomer OFF ");
                    }
                }
                else if (cMaxID.HasValue && !sMaxID.HasValue)
                {
                    // Chuyển dữ liệu từ Client sang Server
                    List<eCustomer> lstCustomer_Client = cDB.Database.SqlQuery<eCustomer>($"select * from eCustomer where KeyID>{(sMaxID.HasValue ? sMaxID.Value : 0)}", new SqlParameter[] { }).ToList();
                    sDB.Database.ExecuteSqlCommand("SET IDENTITY_INSERT eCustomerScale ON ");
                    foreach (var item in lstCustomer_Client) { SaveInsert(sDB, "eCustomerScale", ObjectToDictionary(item)); }
                    sDB.Database.ExecuteSqlCommand("SET IDENTITY_INSERT eCustomerScale OFF ");
                }
                else if (!cMaxID.HasValue && sMaxID.HasValue)
                {
                    // Chuyển dữ liệu từ Server sang Client
                    List<eCustomerScale> lstCustomer_Server = sDB.Database.SqlQuery<eCustomerScale>($"select * from eCustomerScale where KeyID>{(cMaxID.HasValue ? cMaxID.Value : 0)}", new SqlParameter[] { }).ToList();
                    cDB.Database.ExecuteSqlCommand("SET IDENTITY_INSERT eCustomer ON ");
                    foreach (var item in lstCustomer_Server) { SaveInsert(cDB, "eCustomer", ObjectToDictionary(item)); }
                    cDB.Database.ExecuteSqlCommand("SET IDENTITY_INSERT eCustomer OFF ");
                }
                else
                {
                    // Không làm gì
                }

                cDB.Database.CurrentTransaction.Commit();
                sDB.Database.CurrentTransaction.Commit();
                clsGeneral.CloseWaitForm();
                clsGeneral.showMessage("Đồng bộ khách hàng hoàn tất");
            }
            catch (Exception ex)
            {
                cDB.Database.CurrentTransaction.Rollback();
                sDB.Database.CurrentTransaction.Rollback();
                clsGeneral.CloseWaitForm();
                clsGeneral.showErrorException(ex, "Đồng bộ khách hàng thát bại");
            }
        }


    }
}
