using EntityModel.DataModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.Migrations;
using System.Data.Entity.Infrastructure;
using System.ComponentModel;
using System.Threading;
using System.Reflection;
using ChuongTrinhCan.Module;
using System.Data.SqlClient;
using System.Data;

namespace ChuongTrinhCan.BLL.Common
{
    class clsFuction
    {
        #region Constructor
        private static volatile clsFuction instance = null;
        private static readonly object mLock = new object();
        protected clsFuction() { }
        public static clsFuction Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (mLock)
                    {
                        if (instance == null)
                            instance = new clsFuction();
                    }
                }
                return instance;
            }
        }
        #endregion

        #region Functions
        zModel db, _accessModel;
        public T getEntry<T>(int KeyID) where T : class, new()
        {
            try
            {
                _accessModel = new zModel();
                DbSet entity = _accessModel.Set<T>();
                if (entity == null)
                    return null;
                return (T)entity.Find(KeyID);
            }
            catch { return null; }
        }

        public IList<T> getListEntry<T>() where T : class, new()
        {
            try
            {
                _accessModel = new zModel();
                DbSet entity = _accessModel.Set<T>();
                if (entity == null)
                    return null;

                IEnumerable<T> lstTemp = entity.OfType<T>().AsEnumerable<T>();
                return lstTemp.Where(x => x.GetInt32ByName("IDAgency") == clsGeneral.curAgency.KeyID && Convert.ToBoolean(x.GetStringByName("IsEnable"))).ToList<T>();
            }
            catch { return new List<T>(); }
        }

        public int getMaxKeyID<T>() where T : class
        {
            try
            {
                db = new zModel();
                DbSet entity = db.Set<T>();
                if (entity == null)
                    return 0;

                IEnumerable<T> lstTemp = entity.OfType<T>().AsEnumerable<T>();
                lstTemp = lstTemp.Where(x => x.GetInt32ByName("IDAgency") == clsGeneral.curAgency.KeyID).ToList<T>();
                if (lstTemp.Any())
                    return lstTemp.MaxIndex<T>() + 1;
                else
                    return 0;
            }
            catch { return 0; }
        }

        public IList<T> searchListEntry<T>(bool IsEnable) where T : class, new()
        {
            try
            {
                _accessModel = new zModel();
                DbSet entity = _accessModel.Set<T>();
                if (entity == null)
                    return null;

                IEnumerable<T> lstTemp = entity.OfType<T>().AsEnumerable<T>();
                return lstTemp.Where(x => x.GetInt32ByName("IDAgency") == clsGeneral.curAgency.KeyID && Convert.ToBoolean(x.GetStringByName("IsEnable")) == IsEnable).ToList<T>();
            }
            catch { return new List<T>(); }
        }

        public bool deleteEntry<T>(List<T> lstEntry) where T : class, new()
        {
            try
            {
                _accessModel = new zModel();
                DbSet entity = _accessModel.Set<T>();
                if (entity == null)
                    return false;

                foreach (T item in lstEntry)
                {
                    T edt = (T)entity.Find(item.GetInt32ByName("KeyID"));
                    _accessModel.Entry(edt).CurrentValues.SetValues(item);
                }

                _accessModel.SaveChanges();
                return true;
            }
            catch { return false; }
        }

        public bool accessEntry<T>(T entry) where T : class, new()
        {
            try
            {
                _accessModel = new zModel();
                DbSet entity = _accessModel.Set<T>();
                if (entity == null)
                    return false;

                if (entry.GetInt32ByName("KeyID") > 0)
                {
                    T edtEntry = (T)entity.Find(entry.GetInt32ByName("KeyID"));
                    _accessModel.Entry(edtEntry).CurrentValues.SetValues(entry);
                }
                else
                    entity.Add(entry);

                _accessModel.SaveChanges();
                return true;
            }
            catch { return false; }
        }

        public bool accessEntry<T>(BindingList<T> lstEntry) where T : class, new()
        {
            try
            {
                _accessModel = new zModel();
                DbSet entity = _accessModel.Set<T>();
                if (entity == null)
                    return false;

                foreach (T entry in lstEntry)
                {
                    if (entry.GetInt32ByName("KeyID") > 0)
                    {
                        T edtEntry = (T)entity.Find(entry.GetInt32ByName("KeyID"));
                        _accessModel.Entry(edtEntry).CurrentValues.SetValues(entry);
                    }
                    else
                        entity.Add(entry);
                }

                _accessModel.SaveChanges();
                return true;
            }
            catch { return false; }
        }

        #endregion
    }


    public partial class DeleteEntry<T1, T2, T3>
        where T1 : class
        where T2 : class
        where T3 : class
    {
        System.Windows.Forms.Timer timer;
        public delegate void LoadStatus(bool _status);
        public delegate void LoadPecent(int _num);
        public LoadStatus ReloadStatus;
        public LoadPecent ReloadPercent;
        private readonly List<int> ListEntry;
        private BackgroundWorker bWorker;
        private bool status;
        private Dictionary<string, List<int>> ListEntity;
        private int lenght = 0;
        private int cur = 0;
        zModel db;
        public DeleteEntry(List<int> _ListEntry)
        {
            this.ListEntry = _ListEntry;
            _BackgroundWorker();
        }

        private void _BackgroundWorker()
        {
            bWorker = new BackgroundWorker();
            bWorker.WorkerReportsProgress = true;
            bWorker.WorkerSupportsCancellation = true;

            bWorker.DoWork += bWorker_DoWork;
            bWorker.ProgressChanged += bWorker_ProgressChanged;
            bWorker.RunWorkerCompleted += bWorker_RunWorkerCompleted;

            if (Thread.CurrentThread.Name == null)
                Thread.CurrentThread.Name = "Deleting" + typeof(T1).Name;
        }

        public DeleteEntry()
        {
            this.ListEntity = new Dictionary<string, List<int>>();
            _BackgroundWorker();
        }

        public void SetEntity(string Name, List<int> _lstEntry)
        {
            ListEntity.Add(Name, _lstEntry);
        }

        public void StartRun()
        {
            db = new zModel();
            timer = new System.Windows.Forms.Timer();
            timer.Tick += timer_Tick;
            timer.Interval = 1000;
            timer.Enabled = false;
            bWorker.RunWorkerAsync();
            timer.Enabled = true;
            timer.Start();
        }

        void timer_Tick(object sender, EventArgs e)
        {
            if (lenght > 0 && bWorker.IsBusy)
            {
                int curPercent = Convert.ToInt32(((cur * 1.0f) / lenght) * 100);
                bWorker.ReportProgress(curPercent, bWorker.IsBusy);
            }
        }

        ~DeleteEntry()
        {
            timer.Enabled = false;
            timer.Dispose();
            bWorker.Dispose();
        }

        void bWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            timer.Enabled = false;

            if (ReloadStatus != null)
                ReloadStatus(status);
            if (ReloadPercent != null)
                ReloadPercent(100);

            if (Thread.CurrentThread.Name == "ChuongTrinhCanDeleting")
                Thread.CurrentThread.Name = null;
        }

        void bWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (!(bool)e.UserState)
                timer.Enabled = false;

            if (ReloadPercent != null)
                ReloadPercent(e.ProgressPercentage);
        }

        void bWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            cur = 0;

            if (ListEntry != null)
                lenght = ListEntry.Count;
            if (ListEntity != null)
                ListEntity.ToList().ForEach(x => lenght += x.Value.Count);

            _accessEntry();
        }

        private bool _accessEntry()
        {
            if (ListEntry != null)
                status = _deleteEntryByID();
            if (ListEntity != null)
                status = _deleteEntryByT();
            return status;
        }

        private bool _deleteEntryByID()
        {
            try
            {
                foreach (int id in ListEntry)
                {
                    T1 edt = (T1)db.Set<T1>().Find(id);
                    DbEntityEntry entry = db.Entry<T1>(edt);
                    if (entry != null && entry.State == EntityState.Unchanged)
                    {
                        string propName = entry.CurrentValues.PropertyNames.FirstOrDefault(x => x.Equals("IsEnable") || x.Equals("IsEditable") || x.Equals("IsEnbale"));
                        if (!string.IsNullOrEmpty(propName))
                            entry.Property(propName).CurrentValue = false;
                    }
                    cur++;
                }
                db.SaveChangesAsync().Wait();
                return true;
            }
            catch { return false; }
        }

        private bool _deleteEntryByT()
        {
            try
            {
                foreach (var strVal in ListEntity)
                {
                    foreach (int id in strVal.Value)
                    {
                        DbEntityEntry entry = getDbEntityEntry(strVal.Key, id);
                        if (entry != null && entry.State == EntityState.Unchanged)
                        {
                            string propName = entry.CurrentValues.PropertyNames.FirstOrDefault(x => x.Equals("IsEnable") || x.Equals("IsEditable") || x.Equals("IsEnbale"));
                            if (!string.IsNullOrEmpty(propName))
                                entry.Property(propName).CurrentValue = false;
                        }
                        cur++;
                    }
                }
                db.SaveChangesAsync().Wait();
                return true;
            }
            catch { return false; }
        }

        private DbEntityEntry getDbEntityEntry(string TName, int id)
        {
            DbEntityEntry entry = null;
            if (TName.Equals(typeof(T1).Name))
            {
                T1 edt = (T1)db.Set<T1>().Find(id);
                entry = db.Entry<T1>(edt);
            }
            if (TName.Equals(typeof(T2).Name))
            {
                T2 edt = (T2)db.Set<T2>().Find(id);
                entry = db.Entry<T2>(edt);
            }
            if (TName.Equals(typeof(T3).Name))
            {
                T3 edt = (T3)db.Set<T3>().Find(id);
                entry = db.Entry<T3>(edt);
            }
            return entry;
        }
    }

    public partial class AsyncEntry<T>
        where T : class
    {
        System.Windows.Forms.Timer timer;
        public delegate void LoadStatus(bool _status);
        public delegate void LoadPecent(int _num);
        public LoadStatus ReloadStatus;
        public LoadPecent ReloadPercent;
        private readonly List<int> ListEntry;
        private BackgroundWorker bWorker;
        private bool status = false;
        private int lenght = 0;
        private int cur = 0;
        public AsyncEntry(List<int> _ListEntry)
        {
            this.ListEntry = _ListEntry;
            initBackgroundWorker();
        }

        private void initBackgroundWorker()
        {
            timer = new System.Windows.Forms.Timer();

            bWorker = new BackgroundWorker();
            bWorker.WorkerReportsProgress = true;
            bWorker.WorkerSupportsCancellation = true;

            bWorker.DoWork += bWorker_DoWork;
            bWorker.ProgressChanged += bWorker_ProgressChanged;
            bWorker.RunWorkerCompleted += bWorker_RunWorkerCompleted;

            if (Thread.CurrentThread.Name == null)
                Thread.CurrentThread.Name = "Deleting" + typeof(T).Name;
        }

        public void startRun()
        {
            timer.Tick += timer_Tick;
            timer.Interval = 1000;
            timer.Enabled = false;
            bWorker.RunWorkerAsync();
            timer.Enabled = true;
            timer.Start();
        }

        void timer_Tick(object sender, EventArgs e)
        {
            if (lenght > 0 && bWorker.IsBusy)
            {
                int curPercent = Convert.ToInt32(((cur * 1.0f) / lenght) * 100);
                bWorker.ReportProgress(curPercent, bWorker.IsBusy);
            }
        }

        ~AsyncEntry()
        {
            timer.Enabled = false;
            timer.Dispose();
            bWorker.Dispose();
        }

        void bWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            timer.Enabled = false;

            ReloadStatus?.Invoke(status);
            ReloadPercent?.Invoke(100);

            if (Thread.CurrentThread.Name == "ChuongTrinhCanDeleting")
                Thread.CurrentThread.Name = null;
        }

        void bWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (!(bool)e.UserState)
                timer.Enabled = false;

            ReloadPercent?.Invoke(e.ProgressPercentage);
        }

        void bWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            cur = 0;
            if (ListEntry != null)
                lenght = ListEntry.Count;
            accessEntry();
        }

        private bool accessEntry()
        {
            if (ListEntry != null)
                status = asyncEntryByID();
            return status;
        }

        private bool asyncEntryByID()
        {
            try
            {
                //foreach (int id in ListEntry)
                //{
                //    T edt = db.Set<T>().Find(id);
                //    DbEntityEntry entry = db.Entry(edt);
                //    if (entry != null && entry.State == EntityState.Unchanged)
                //    {
                //        string propName = entry.CurrentValues.PropertyNames.FirstOrDefault(x => x.Equals("IsEnable") || x.Equals("IsEditable") || x.Equals("IsEnbale"));
                //        if (!string.IsNullOrEmpty(propName))
                //            entry.Property(propName).CurrentValue = false;
                //    }
                //    cur++;
                //}
                //db.SaveChangesAsync().Wait();

                //zModel db = new zModel();
                //sModel _db = new sModel();

                //foreach (int id in ListEntry)
                //{
                //    T edt = db.Set<T>().Find(id);

                //    T sItem = _db.Set<T>().Find(id);
                    
                //    cur++;
                //}
                //db.SaveChangesAsync().Wait();
                return true;
            }
            catch { return false; }
        }

        public bool checkConnection()
        {
            bool chk = false;
            string _sName, _sDatabase, _sUser, _sPass;
            bool _wAu;

            _wAu = Properties.Settings.Default.ServerWinAu;
            _sName = clsGeneral.Decrypt(Properties.Settings.Default.ServerServerName);
            _sDatabase = clsGeneral.Decrypt(Properties.Settings.Default.ServerDBName);
            _sUser = clsGeneral.Decrypt(Properties.Settings.Default.ServerUsername);
            _sPass = clsGeneral.Decrypt(Properties.Settings.Default.ServerPassword);

            string _conString = "";
            if (!_wAu)
                _conString = "data source={0};initial catalog={1};Integrated Security={2};user id={3};password={4};MultipleActiveResultSets=True;App=EntityFramework";
            else
                _conString = "data source={0};initial catalog={1};Integrated Security={2};MultipleActiveResultSets=True;App=EntityFramework";
            _conString = string.Format(_conString, _sName, _sDatabase, _wAu, _sUser, _sPass);

            try
            {
                clsEntity.serverConnectionString = _conString;
                sModel sdb = new sModel();
                sdb.InitDefaultData();
                chk = true;
            }
            catch (Exception ex) { clsGeneral.showErrorException(ex, "Không thể kết nối tới server."); }
            return chk;
        }
    }
}
