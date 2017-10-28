using ChuongTrinhCan.Module;
using DevExpress.Spreadsheet;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraPrinting;
using DevExpress.XtraRichEdit;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChuongTrinhCan.GUI.REPORT
{
    public partial class frmReportExcel : frmBase
    {
        #region Variable
        private GridControl gctMain;
        private string title;
        private DateTime fDate;
        private DateTime tDate;
        string[] str = new string[] { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };
        List<GridColumn> lstColumns;
        #endregion

        #region Form
        public frmReportExcel()
        {
            InitializeComponent();
        }

        public frmReportExcel(GridControl _gctMain, string _title, DateTime _fDate, DateTime _tDate)
        {
            InitializeComponent();
            this.gctMain = _gctMain;
            this.title = _title;
            this.fDate = _fDate;
            this.tDate = _tDate;
        }

        private void frmReportExcel_Load(object sender, EventArgs e)
        {
            clsGeneral.CallWaitForm(this);
            loadData();
            customForm();
            clsGeneral.CloseWaitForm();
        }

        private void ReportExcel_Load(object sender, EventArgs e)
        {
            loadData();
            customForm();
        }
        #endregion

        #region Base Button
        protected override void btnExportExcel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();
            save.FileName = string.Empty;
            save.Filter = "Excel 97-2003(.xls)|*.xls|Excel 2007-2010(.xlsx)|*.xlsx";
            save.FilterIndex = 2;
            save.ShowDialog();
            string path = save.FileName;
            if (path != string.Empty)
                saveExcel(path);
        }

        protected override void btnPrintPreview_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            PrintingSystem printingSystem = new PrintingSystem();
            PrintableComponentLink link = new PrintableComponentLink();
            // Assign a workbook to be printed by the link.
            link.Component = sprsReport.Document;
            // Add the link to the printing system's collection of links.
            printingSystem.Links.Add(link);
            // Print the workbook to specified printer.
            link.Landscape = true;
            link.PaperKind = System.Drawing.Printing.PaperKind.A4;
            link.Margins = new System.Drawing.Printing.Margins(1, 1, 2, 2);
            link.PaperName = "_A4";
            try
            {
                if (sprsReport.IsPrintingAvailable)
                    link.Print(Properties.Settings.Default.PrinterName);
                else
                    sprsReport.ShowPrintDialog();
            }
            catch { sprsReport.ShowPrintDialog(); }
        }
        #endregion

        #region Method
        private bool showReport()
        {
            try
            {
                string path = Path.Combine(Environment.CurrentDirectory, @"Reports\Common\Report.xlsx");

                using (FileStream stream = new FileStream(path, FileMode.Open))
                {
                    sprsReport.LoadDocument(stream, DevExpress.Spreadsheet.DocumentFormat.OpenXml);
                }
                return true;
            }
            catch
            {
                clsGeneral.showMessage("Không thể xuất Excel!\nFile excel mẫu đã bị mất hoặc đang được mở.");
                return false;
            }
        }

        private void saveExcel(string path)
        {
            using (FileStream stream = new FileStream(path, FileMode.Create, FileAccess.ReadWrite))
            {
                sprsReport.SaveDocument(stream, DevExpress.Spreadsheet.DocumentFormat.OpenXml);
            }

            string[] lstpath = path.Split('\\');
            path = lstpath[0];
            for (int i = 1; i < lstpath.Count() - 1; i++)
            {
                path += string.Format(@"\{0}", lstpath[i]);
            }
            System.Diagnostics.Process.Start(path);
        }

        private void loadData()
        {
            loadFilter();
        }

        private void loadFilter()
        {
            if (showReport())
                AddRowExcel();
        }

        private void AddRowExcel()
        {
            if (gctMain == null)
                return;

            GridView view = gctMain.FocusedView as GridView;

            lstColumns = new List<GridColumn>();
            lstColumns.AddRange(view.VisibleColumns.Where(x => !x.FieldName.Equals("Code") && !x.FieldName.Equals("Price") && !x.FieldName.Equals("TotalPrice")));
            lstColumns.Insert(0, view.Columns.FirstOrDefault(x => x.FieldName.Equals("KeyID")));

            sprsReport.BeginUpdate();

            Worksheet sheet = sprsReport.Document.Worksheets[0];
            sheet.ActiveView.PaperKind = System.Drawing.Printing.PaperKind.A4;
            sheet.ActiveView.Orientation = PageOrientation.Landscape;

            int eRow = 0;
            int nCol = lstColumns.Count;
            int nRow = view.RowCount;

            sheet.Columns["A"][eRow++].SetValue(clsGeneral.curAgency.Name);
            sheet.Columns["A"][eRow++].SetValue("Địa chỉ: " + clsGeneral.curAgency.Address);
            sheet.Columns["A"][eRow++].SetValue("SĐT: " + clsGeneral.curAgency.Phone + "     Email: " + clsGeneral.curAgency.Email);

            //Tiêu đề
            eRow++;
            sheet.Range[str[0] + (eRow + 1) + ":" + str[nCol - 1] + (eRow + 1)].Merge();
            sheet.Columns[str[0]][eRow].SetValue(title.ToUpper());
            sheet.Columns[str[0]][eRow].Alignment.Horizontal = SpreadsheetHorizontalAlignment.Center;
            sheet.Columns[str[0]][eRow].Alignment.Vertical = SpreadsheetVerticalAlignment.Center;
            sheet.Columns[str[0]][eRow].Font.FontStyle = SpreadsheetFontStyle.Bold;
            sheet.Columns[str[0]][eRow].Font.Size = 20;

            //Ngày tìm kiếm
            eRow++;
            sheet.Range[str[0] + (eRow + 1) + ":" + str[nCol - 1] + (eRow + 1)].Merge();
            sheet.Columns[str[0]][eRow].SetValue("Từ " + fDate.ToString("dd/MM/yyyy") + " đến " + tDate.ToString("dd/MM/yyyy"));
            sheet.Columns[str[0]][eRow].Alignment.Horizontal = SpreadsheetHorizontalAlignment.Center;
            sheet.Columns[str[0]][eRow].Alignment.Vertical = SpreadsheetVerticalAlignment.Center;
            sheet.Columns[str[0]][eRow].Font.FontStyle = SpreadsheetFontStyle.Regular;
            sheet.Columns[str[0]][eRow].Font.Size = 11;

            eRow += 2;
            for (int iCol = 0; iCol < nCol; iCol++)
            {
                GridColumn col = lstColumns[iCol];
                sheet.Columns[str[iCol]][eRow].SetValue(col.Caption);
                sheet.Columns[str[iCol]][eRow].Borders.SetAllBorders(Color.Black, BorderLineStyle.Thin);
                sheet.Columns[str[iCol]][eRow].Font.FontStyle = SpreadsheetFontStyle.Bold;
                sheet.Columns[str[iCol]][eRow].Alignment.Horizontal = SpreadsheetHorizontalAlignment.Center;
                sheet.Columns[str[iCol]][eRow].Alignment.Vertical = SpreadsheetVerticalAlignment.Center;
                sheet.Columns[str[iCol]][eRow].Font.Size = 11;
            }

            eRow++;
            //Format cell
            //FormatMergeCell(view, sheet, eRow);

            // Dữ liệu
            int iRow = 0;
            while (iRow <= nRow)
            {
                for (int iCol = 0; iCol < nCol; iCol++)
                {
                    if (iRow < nRow)
                    {
                        sheet.Columns[str[iCol]][eRow].Borders.SetAllBorders(Color.Black, BorderLineStyle.Thin);
                        sheet.Columns[str[iCol]][eRow].Alignment.Horizontal = SpreadsheetHorizontalAlignment.Center;
                        sheet.Columns[str[iCol]][eRow].Alignment.Vertical = SpreadsheetVerticalAlignment.Center;
                        sheet.Columns[str[iCol]][eRow].Font.FontStyle = SpreadsheetFontStyle.Regular;
                        sheet.Columns[str[iCol]][eRow].Font.Size = 11;
                        GridColumn col = lstColumns[iCol];

                        if (col.ColumnEdit is RepositoryItemSpinEdit)
                        {
                            sheet.Columns[str[iCol]][eRow].Alignment.Horizontal = SpreadsheetHorizontalAlignment.Right;
                            sheet.Columns[str[iCol]][eRow].NumberFormat = "#,##0;#,##0";
                            sheet.Columns[str[iCol]][eRow].SetValue(view.GetRowCellValue(iRow, col));
                        }
                        else if (col.ColumnEdit is RepositoryItemDateEdit)
                        {
                            sheet.Columns[str[iCol]][eRow].Alignment.Horizontal = SpreadsheetHorizontalAlignment.Center;
                            sheet.Columns[str[iCol]][eRow].SetValue(string.Format("{0:dd/MM/yyyy}", view.GetRowCellValue(iRow, col)));
                        }
                        else if (iCol > 0)
                        {
                            sheet.Columns[str[iCol]][eRow].Alignment.Horizontal = SpreadsheetHorizontalAlignment.Left;
                            sheet.Columns[str[iCol]][eRow].SetValue(view.GetRowCellValue(iRow, col));
                        }
                        else
                        {
                            //Set STT
                            sheet.Columns[str[iCol]][eRow].Alignment.Horizontal = SpreadsheetHorizontalAlignment.Center;
                            sheet.Columns[str[iCol]][eRow].SetValue((iRow + 1).ToString());
                        }
                    }
                }

                if (iRow == view.RowCount)
                {
                    int _index = lstColumns.FindIndex(x => x.ColumnEdit is RepositoryItemSpinEdit);

                    for (int iCol = 0; iCol < nCol; iCol++)
                    {
                        GridColumn col = lstColumns[iCol];
                        sheet.Columns[str[iCol]][eRow].Borders.SetAllBorders(Color.Black, BorderLineStyle.Thin);
                        sheet.Columns[str[iCol]][eRow].Alignment.Vertical = SpreadsheetVerticalAlignment.Center;
                        if (col.ColumnEdit is RepositoryItemSpinEdit)
                        {
                            sheet.Columns[str[iCol]][eRow].Borders.SetAllBorders(Color.Black, BorderLineStyle.Thin);
                            sheet.Columns[str[iCol]][eRow].Alignment.Horizontal = SpreadsheetHorizontalAlignment.Right;
                            sheet.Columns[str[iCol]][eRow].NumberFormat = "#,##0;#,##0";
                            sheet.Columns[str[iCol]][eRow].SetValue(col.SummaryItem.SummaryValue);
                            sheet.Columns[str[iCol]][eRow].Font.FontStyle = SpreadsheetFontStyle.Bold;
                            sheet.Columns[str[iCol]][eRow].Font.Size = 11;
                        }
                    }

                    sheet.Range[str[0] + (eRow + 1) + ":" + str[_index > 0 ? (_index - 1) : 0] + (eRow + 1)].Merge();
                    sheet.Columns[str[0]][eRow].SetValue("Tổng");
                    sheet.Columns[str[0]][eRow].Alignment.Horizontal = SpreadsheetHorizontalAlignment.Center;
                    sheet.Columns[str[0]][eRow].Alignment.Vertical = SpreadsheetVerticalAlignment.Center;
                    sheet.Columns[str[0]][eRow].Font.FontStyle = SpreadsheetFontStyle.Bold;
                    sheet.Columns[str[0]][eRow].Font.Size = 11;
                }

                eRow++;
                iRow++;
            }

            eRow += 2;
            //Ngày, tháng , năm
            DateTime dt = DateTime.Now.ServerNow();
            sheet.Range[str[nCol - 1 - 2] + (eRow + 1) + ":" + str[nCol - 1] + (eRow + 1)].Merge();
            sheet.Columns[str[nCol - 1 - 2]][eRow].SetValue("Ngày " + dt.Day + " tháng " + dt.Month + " năm " + dt.Year);
            sheet.Columns[str[nCol - 1 - 2]][eRow].Alignment.Horizontal = SpreadsheetHorizontalAlignment.Center;
            sheet.Columns[str[nCol - 1 - 2]][eRow].Font.FontStyle = SpreadsheetFontStyle.Regular;
            sheet.Columns[str[nCol - 1 - 2]][eRow].Font.Size = 11;

            eRow++;
            //Người lập phiếu
            sheet.Range[str[nCol - 1 - 2] + (eRow + 1) + ":" + str[nCol - 1] + (eRow + 1)].Merge();
            sheet.Columns[str[nCol - 1 - 2]][eRow].SetValue("Người lập phiếu");
            sheet.Columns[str[nCol - 1 - 2]][eRow].Alignment.Horizontal = SpreadsheetHorizontalAlignment.Center;
            sheet.Columns[str[nCol - 1 - 2]][eRow].Font.FontStyle = SpreadsheetFontStyle.Regular;
            sheet.Columns[str[nCol - 1 - 2]][eRow].Font.Size = 11;

            sheet.GetDataRange().AutoFitColumns();
            sheet.GetDataRange().AutoFitRows();

            sprsReport.EndUpdate();
        }

        private void FormatMergeCell(GridView view, Worksheet sheet, int eRow)
        {
            GridViewInfo viewInfo = view.GetViewInfo() as GridViewInfo;

            foreach (GridColumn col in view.VisibleColumns)
            {
                int iStart = 0;
                int iEnd = 0;
                int count = view.RowCount - 1;
                for (int i = 0; i < count; i++)
                {
                    view.FocusedRowHandle = i;
                    bool isMerge = false;
                    if (col.FieldName.Equals("DateCreate") || col.FieldName.Equals("WorkerName") || col.FieldName.Equals("FactoryName") || col.FieldName.Equals("Number") ||
                        col.FieldName.Equals("Code") || col.FieldName.Equals("ProductName") || col.FieldName.Equals("CustomerName") || col.FieldName.Equals("DateClosed"))
                    {
                        //Sấy lúa
                        if (Convert.ToBoolean(view.GetRowCellValue(i, view.Columns["IsBillDry"])) && Convert.ToBoolean(view.GetRowCellValue(i + 1, view.Columns["IsBillDry"])) &&
                            Convert.ToInt32(view.GetRowCellValue(i, view.Columns["IDBillDry"])) == Convert.ToInt32(view.GetRowCellValue(i + 1, view.Columns["IDBillDry"])))
                            isMerge = true;

                        //Xay xát
                        if (Convert.ToBoolean(view.GetRowCellValue(i, view.Columns["IsMillDetail"])) && Convert.ToBoolean(view.GetRowCellValue(i + 1, view.Columns["IsMillDetail"])) &&
                            Convert.ToInt32(view.GetRowCellValue(i, view.Columns["IDMill"])) == Convert.ToInt32(view.GetRowCellValue(i + 1, view.Columns["IDMill"])))
                            isMerge = true;

                        //Tách màu
                        if (Convert.ToBoolean(view.GetRowCellValue(i, view.Columns["IsSeparateColor"])) && Convert.ToBoolean(view.GetRowCellValue(i + 1, view.Columns["IsSeparateColor"])) &&
                          Convert.ToInt32(view.GetRowCellValue(i, view.Columns["IDSeparateColor"])) == Convert.ToInt32(view.GetRowCellValue(i + 1, view.Columns["IDSeparateColor"])))
                            isMerge = true;

                        //Ép cám
                        if (Convert.ToBoolean(view.GetRowCellValue(i, view.Columns["IsExtract"])) && Convert.ToBoolean(view.GetRowCellValue(i + 1, view.Columns["IsExtract"])) &&
                           Convert.ToInt32(view.GetRowCellValue(i, view.Columns["IDExtract"])) == Convert.ToInt32(view.GetRowCellValue(i + 1, view.Columns["IDExtract"])))
                            isMerge = true;

                        //Xuất cám
                        if (Convert.ToBoolean(view.GetRowCellValue(i, view.Columns["IsExportExtract"])) && Convert.ToBoolean(view.GetRowCellValue(i + 1, view.Columns["IsExportExtract"])) &&
                           Convert.ToInt32(view.GetRowCellValue(i, view.Columns["IDExportExtract"])) == Convert.ToInt32(view.GetRowCellValue(i + 1, view.Columns["IDExportExtract"])))
                            isMerge = true;

                        var val1 = view.GetRowCellValue(i, col);
                        var val2 = view.GetRowCellValue(i + 1, col);

                        if (col.FieldName.Equals("FactoryName"))
                            isMerge &= (val1 == null && val2 == null) || (val1 != null && val2 != null && val1.Equals(val2));
                        if (col.FieldName.Equals("WorkerName"))
                            isMerge &= (val1 == null && val2 == null) || (val1 != null && val2 != null && val1.Equals(val2));

                        if (isMerge)
                            iEnd = i + 1;
                        else
                        {
                            sheet.Range[str[col.VisibleIndex] + (iStart + eRow + 1) + ":" + str[col.VisibleIndex] + (iEnd + eRow + 1)].Merge();
                            iStart = iEnd = i + 1;
                        }
                        if (i == count - 1)
                            sheet.Range[str[col.VisibleIndex] + (iStart + eRow + 1) + ":" + str[col.VisibleIndex] + (iEnd + eRow + 1)].Merge();
                    }
                }
            }
        }

        private void customForm()
        {
            btsIsEnable.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            btnAdd.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            btnEdit.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            btnDisable.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            btnRefresh.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            btnExportExcel.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            btnPrintPreview.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
        }
        #endregion
    }
}
