using DevExpress.LookAndFeel;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Popup;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace ChuongTrinhCan.Module
{
    public class MyColor
    {
        public static Color GridDefaultRow { get { return Color.FromArgb(35, 100, 190); } }
        public static Color GridEditRow { get { return Color.FromArgb(0, 90, 20); } }
        public static Color GridForeHeader { get { return Color.FromArgb(0, 0, 10); } }
        public static Color GridForeRow { get { return Color.White; } }
        public static Color BackColorEditing { get { return Color.FromArgb(232, 202, 200); } }
        public static Color ForeColorEditing { get { return Color.FromArgb(0, 0, 70); } }
    }

    static class FormatControl
    {
        static readonly string[] ChuSo = { " không", " một", " hai", " ba", " bốn", " năm", " sáu", " bảy", " tám", " chín" };
        static readonly string[] Tien = { "", " nghìn", " triệu", " tỷ", " nghìn tỷ", " triệu tỷ" };

        #region Extension DataType
        public static string ToTitleCase(this string sSource)
        {
            while (sSource.Contains("  "))
                sSource = sSource.Replace("  ", " ");
            return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(sSource.ToLower());
        }

        public static string AutoSpace(this string sSource)
        {
            string stRe = "";
            if (!string.IsNullOrEmpty(sSource.Replace(" ", "").Trim()))
            {
                System.Text.RegularExpressions.Regex rgxUpperLeter = new System.Text.RegularExpressions.Regex("[A-Z]");
                Char[] arrS = sSource.Replace(" ", "").ToCharArray();
                Array.Reverse(arrS);
                foreach (char arC in arrS)
                {
                    if (rgxUpperLeter.IsMatch(arC.ToString())) //Is UpperCase
                    {
                        System.Text.RegularExpressions.Regex rgxCheck = new System.Text.RegularExpressions.Regex("[A-Z][a-z]");
                        if (!string.IsNullOrEmpty(stRe) && stRe.Length > 1)
                        {
                            if (rgxUpperLeter.IsMatch(stRe.Substring(0, 1)) && rgxCheck.IsMatch(stRe.Substring(0, 2)) && !stRe.Substring(0, 2).EndsWith(" "))
                                stRe = stRe.Insert(0, arC.ToString() + " ");
                            else
                                stRe = stRe.Insert(0, arC.ToString());
                        }
                        else
                            stRe = stRe.Insert(0, arC.ToString());
                    }
                    else
                    {
                        if (!string.IsNullOrEmpty(stRe) && rgxUpperLeter.IsMatch(stRe.Substring(0, 1)))
                            stRe = stRe.Insert(0, arC.ToString() + " ");
                        else
                            stRe = stRe.Insert(0, arC.ToString());
                    }
                }
            }
            if (!string.IsNullOrEmpty(stRe) && stRe.Contains(" "))
            {
                System.Text.RegularExpressions.Regex rgxSuffic = new System.Text.RegularExpressions.Regex("[A-Z]");
                if (!rgxSuffic.IsMatch(stRe.Substring(0, stRe.IndexOf(" "))))
                    stRe = stRe.Remove(0, stRe.IndexOf(" "));
            }

            return stRe.Trim();
        }

        public static string NoSign(this string sSource)
        {
            if (string.IsNullOrEmpty(sSource)) return string.Empty;
            System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex("\\p{IsCombiningDiacriticalMarks}+");
            string temp = sSource.Normalize(NormalizationForm.FormD);
            string nameNosign = regex.Replace(temp, String.Empty).Replace('\u0111', 'd').Replace('\u0110', 'D');
            return nameNosign;
        }

        public static string NoSpace(this string sSource)
        {
            return Regex.Replace(sSource, "\\s+", " ");
        }

        public static bool CompareText(this string sSource, string sDes, bool isContain = true)
        {
            if (isContain)
                return sSource.NoSign().NoSpace().ToLower().Contains(sDes.NoSign().NoSpace().ToLower());
            else
                return sSource.ToLower().Equals(sDes.ToLower());
        }

        // Hàm đọc số thành chữ
        // Hàm đọc số có 3 chữ số
        private static string DocSo3ChuSo(int baso)
        {
            int tram, chuc, donvi;
            string KetQua = "";
            tram = (int)(baso / 100);
            chuc = (int)((baso % 100) / 10);
            donvi = baso % 10;
            if ((tram == 0) && (chuc == 0) && (donvi == 0)) return "";
            if (tram != 0)
            {
                KetQua += ChuSo[tram] + " trăm";
                if ((chuc == 0) && (donvi != 0)) KetQua += " linh";
            }
            if ((chuc != 0) && (chuc != 1))
            {
                KetQua += ChuSo[chuc] + " mươi";
                if ((chuc == 0) && (donvi != 0)) KetQua = KetQua + " linh";
            }
            if (chuc == 1) KetQua += " mười";
            switch (donvi)
            {
                case 1:
                    if ((chuc != 0) && (chuc != 1))
                        KetQua += " mốt";
                    else
                        KetQua += ChuSo[donvi];
                    break;
                case 5:
                    if (chuc == 0)
                        KetQua += ChuSo[donvi];
                    else
                        KetQua += " lăm";
                    break;
                default:
                    if (donvi != 0)
                        KetQua += ChuSo[donvi];
                    break;
            }
            return KetQua;
        }
        public static string ToMoneyText(this decimal Money, string Tail = "đồng")
        {
            int lan, i;
            decimal so;
            string KetQua = "", tmp = "";
            int[] ViTri = new int[6];
            if (Money < 0) return "Số tiền âm!";
            if (Money == 0) return string.Format("Không {0}!", Tail.Trim());
            if (Money > 0)
                so = Money;
            else
                so = -Money;
            //Kiểm tra số quá lớn
            if (Money > 8999999999999999)
            {
                Money = 0;
                return "";
            }
            ViTri[5] = (int)(so / 1000000000000000);
            so = so - long.Parse(ViTri[5].ToString()) * 1000000000000000;
            ViTri[4] = (int)(so / 1000000000000);
            so = so - long.Parse(ViTri[4].ToString()) * +1000000000000;
            ViTri[3] = (int)(so / 1000000000);
            so = so - long.Parse(ViTri[3].ToString()) * 1000000000;
            ViTri[2] = (int)(so / 1000000);
            ViTri[1] = (int)((so % 1000000) / 1000);
            ViTri[0] = (int)(so % 1000);
            if (ViTri[5] > 0)
                lan = 5;
            else if (ViTri[4] > 0)
                lan = 4;
            else if (ViTri[3] > 0)
                lan = 3;
            else if (ViTri[2] > 0)
                lan = 2;
            else if (ViTri[1] > 0)
                lan = 1;
            else
                lan = 0;
            for (i = lan; i >= 0; i--)
            {
                tmp = DocSo3ChuSo(ViTri[i]);
                KetQua += tmp;
                if (ViTri[i] != 0) KetQua += Tien[i];
                if ((i > 0) && (!string.IsNullOrEmpty(tmp))) KetQua += ",";//&& (!string.IsNullOrEmpty(tmp))
            }
            if (KetQua.Substring(KetQua.Length - 1, 1) == ",") KetQua = KetQua.Substring(0, KetQua.Length - 1);
            KetQua = KetQua.Trim() + " " + Tail.Trim();
            return KetQua.Substring(0, 1).ToUpper() + KetQua.Substring(1);
        }
        public static string ToMoneyText(this double Money, string Tail = "đồng")
        {
            return Convert.ToDecimal(Money).ToMoneyText(Tail);
        }
        public static string ToMoneyText(this long Money, string Tail = "đồng")
        {
            return Convert.ToDecimal(Money).ToMoneyText(Tail);
        }
        public static string ToMoneyText(this float Money, string Tail = "đồng")
        {
            return Convert.ToDecimal(Money).ToMoneyText(Tail);
        }
        public static string ToMoneyText(this int Money, string Tail = "đồng")
        {
            return Convert.ToDecimal(Money).ToMoneyText(Tail);
        }

        public static int MaxIndex<T>(this IEnumerable<T> source)
        {
            try { return source.LastOrDefault().GetInt32ByName("KeyID"); }
            catch { return 0; }
        }
        #endregion

        #region GetValueObject
        public static string GetStringByName(this object oSource, string pName)
        {
            if (oSource == null) return string.Empty;
            var oRe = oSource.GetType().GetProperty(pName).GetValue(oSource, null);
            return oRe != null ? oRe.ToString() : string.Empty;
        }

        public static int GetInt32ByName(this object oSource, string pName)
        {
            if (oSource == null) return 0;
            var oRe = oSource.GetType().GetProperty(pName).GetValue(oSource, null);
            return oRe != null ? Convert.ToInt32(oRe) : 0;
        }

        public static decimal GetDecimalByName(this object oSource, string pName)
        {
            if (oSource == null) return 0;
            var oRe = oSource.GetType().GetProperty(pName).GetValue(oSource, null);
            return oRe != null ? Convert.ToDecimal(oRe) : 0;
        }
        #endregion

        #region Format GridControl
        public static void Format(this GridControl gctMain, bool allowNewRow = false, bool showIndicator = true, bool ColumnAuto = true, bool ShowLines = false)
        {
            if (gctMain != null)
            {
                try
                {
                    foreach (var cView in gctMain.ViewCollection)
                    {
                        if (cView is GridView)
                        {
                            GridView grvMain = (GridView)cView;
                            grvMain.Format(allowNewRow, showIndicator, ColumnAuto, ShowLines);
                            if (ColumnAuto)
                            {
                                grvMain.RowCountChanged -= grvMain_RowCountChanged;
                                grvMain.RowCountChanged += grvMain_RowCountChanged;
                            }
                        }
                    }
                }
                catch { }
            }
        }

        private static void grvMain_RowCountChanged(object sender, EventArgs e)
        {
            //GridView grvMain = sender as GridView;
            //if (grvMain != null && grvMain.Columns.Count > 0 && grvMain.Columns[0].AppearanceHeader.ForeColor != MyColor.GridForeHeader)
            //    grvMain.FormatColmnsGridView();
        }

        public static void Format(this GridView grvMain, bool allowNewRow, bool showIndicator, bool ColumnAuto, bool ShowLines = false)
        {
            grvMain.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            grvMain.OptionsView.ShowGroupPanel = false;
            grvMain.OptionsBehavior.Editable = true;
            grvMain.OptionsMenu.EnableColumnMenu = false;
            grvMain.OptionsCustomization.AllowFilter = true;
            grvMain.OptionsCustomization.AllowSort = false;

            grvMain.OptionsView.ShowIndicator = showIndicator;
            if (showIndicator)
            {
                grvMain.IndicatorWidth = 35;
                grvMain.CustomDrawRowIndicator -= CustomDrawRowIndicator;
                grvMain.CustomDrawRowIndicator += CustomDrawRowIndicator;
            }

            grvMain.OptionsSelection.EnableAppearanceFocusedCell = false;
            //grvMain.ColumnPanelRowHeight = 25;
            grvMain.OptionsView.RowAutoHeight = true;
            grvMain.Appearance.FocusedRow.BackColor = grvMain.Appearance.FocusedRow.BackColor2 = MyColor.GridDefaultRow;
            grvMain.Appearance.SelectedRow.BackColor = grvMain.Appearance.SelectedRow.BackColor2 = MyColor.GridDefaultRow;
            grvMain.Appearance.HideSelectionRow.BackColor = grvMain.Appearance.HideSelectionRow.BackColor2 = MyColor.GridDefaultRow;
            grvMain.Appearance.FocusedRow.ForeColor = grvMain.Appearance.HideSelectionRow.ForeColor = grvMain.Appearance.SelectedRow.ForeColor = MyColor.GridForeRow;
            grvMain.OptionsView.ColumnAutoWidth = ColumnAuto;
            grvMain.LeftCoord = 0;

            //Format header
            grvMain.OptionsView.AllowHtmlDrawHeaders = true;
            grvMain.Appearance.HeaderPanel.Font = Properties.Settings.Default.GeneralFont;
            grvMain.Appearance.HeaderPanel.TextOptions.HAlignment = HorzAlignment.Center;
            grvMain.Appearance.HeaderPanel.TextOptions.VAlignment = VertAlignment.Center;
            grvMain.Appearance.HeaderPanel.TextOptions.WordWrap = WordWrap.Wrap;

            if (allowNewRow)
            {
                grvMain.GridControl.EmbeddedNavigator.Buttons.Append.Visible = false;
                grvMain.GridControl.EmbeddedNavigator.Buttons.CancelEdit.Visible = false;
                grvMain.GridControl.EmbeddedNavigator.Buttons.Edit.Visible = false;
                grvMain.GridControl.EmbeddedNavigator.Buttons.EndEdit.Visible = false;
                grvMain.GridControl.EmbeddedNavigator.Buttons.First.Visible = false;
                grvMain.GridControl.EmbeddedNavigator.Buttons.Last.Visible = false;
                grvMain.GridControl.EmbeddedNavigator.Buttons.Next.Visible = false;
                grvMain.GridControl.EmbeddedNavigator.Buttons.NextPage.Visible = false;
                grvMain.GridControl.EmbeddedNavigator.Buttons.Prev.Visible = false;
                grvMain.GridControl.EmbeddedNavigator.Buttons.PrevPage.Visible = false;
                grvMain.GridControl.EmbeddedNavigator.Buttons.Remove.Hint = "Xóa";
                grvMain.GridControl.EmbeddedNavigator.TextStringFormat = "";
                grvMain.GridControl.UseEmbeddedNavigator = true;

                grvMain.OptionsView.NewItemRowPosition = NewItemRowPosition.Bottom;
                //grvMain.Appearance.FocusedRow.BackColor = grvMain.Appearance.FocusedRow.BackColor2 = MyColor.GridEditRow;
                grvMain.Appearance.HideSelectionRow.BackColor = grvMain.Appearance.HideSelectionRow.BackColor2 = MyColor.GridEditRow;
                grvMain.Appearance.FocusedRow.ForeColor = MyColor.GridForeRow;


                grvMain.OptionsSelection.EnableAppearanceFocusedCell = true;
                grvMain.FocusRectStyle = DrawFocusRectStyle.CellFocus;
                grvMain.Appearance.FocusedCell.BackColor = MyColor.BackColorEditing;
                grvMain.Appearance.FocusedCell.ForeColor = MyColor.ForeColorEditing;
                grvMain.Appearance.FocusedCell.Font = new Font(grvMain.Appearance.FocusedCell.Font, FontStyle.Bold);

                grvMain.ShowingEditor -= grvMain_ShowingEditor;
                grvMain.ShowingEditor += grvMain_ShowingEditor;

                grvMain.VisibleColumns.ToList().ForEach(col => col.RealColumnEdit.KeyDown -= realColumnEdit_KeyDown);
                grvMain.VisibleColumns.ToList().ForEach(col => col.RealColumnEdit.KeyDown += realColumnEdit_KeyDown);
            }
            else
            {
                grvMain.InvalidRowException -= grvMain_InvalidRowException;
                grvMain.InvalidRowException += grvMain_InvalidRowException;
            }
            if (ShowLines)
            {
                grvMain.OptionsView.ShowHorizontalLines = DefaultBoolean.True;
                grvMain.OptionsView.ShowVerticalLines = DefaultBoolean.True;
                grvMain.Appearance.HorzLine.BackColor = Color.Black;
                grvMain.Appearance.HorzLine.BackColor2 = Color.Black;
                grvMain.Appearance.HorzLine.Options.UseBackColor = true;
                grvMain.Appearance.VertLine.BackColor = Color.Black;
                grvMain.Appearance.VertLine.BackColor2 = Color.Black;
                grvMain.Appearance.VertLine.Options.UseBackColor = true;
            }
            else
            {
                grvMain.OptionsView.EnableAppearanceOddRow = true;

                grvMain.Appearance.OddRow.Font = Properties.Settings.Default.GeneralFont;
                grvMain.Appearance.OddRow.BackColor = Color.AliceBlue;
                grvMain.Appearance.OddRow.BackColor2 = Color.AliceBlue;
                grvMain.Appearance.OddRow.BorderColor = Color.AliceBlue;
                grvMain.Appearance.OddRow.ForeColor = Color.Black;
                grvMain.Appearance.OddRow.Options.UseBackColor = true;
                grvMain.Appearance.OddRow.Options.UseBorderColor = true;
                grvMain.Appearance.OddRow.Options.UseForeColor = true;

                grvMain.Appearance.EvenRow.Font = Properties.Settings.Default.GeneralFont;
                grvMain.Appearance.EvenRow.BackColor = Color.AliceBlue;
                grvMain.Appearance.EvenRow.BackColor2 = Color.AliceBlue;
                grvMain.Appearance.EvenRow.BorderColor = Color.AliceBlue;
                grvMain.Appearance.EvenRow.ForeColor = Color.Black;
                grvMain.Appearance.EvenRow.Options.UseBackColor = true;
                grvMain.Appearance.EvenRow.Options.UseBorderColor = true;
            }
            //grvMain.Translation();
            grvMain.FormatColmnsGridView();

            //New
            grvMain.OptionsView.ShowAutoFilterRow = true;

            //16/3/2017
            grvMain.NewItemRowText = string.Empty;
            grvMain.OptionsSelection.MultiSelect = true;
            grvMain.KeyDown -= grvMain_KeyDown;
            grvMain.KeyDown += grvMain_KeyDown;
            grvMain.RowCellStyle -= grvMain_RowCellStyle;
            grvMain.RowCellStyle += grvMain_RowCellStyle;
            grvMain.CalcRowHeight -= grvMain_CalcRowHeight;
            grvMain.CalcRowHeight += grvMain_CalcRowHeight;
            grvMain.DataSourceChanged -= grvMain_DataSourceChanged;
            grvMain.DataSourceChanged += grvMain_DataSourceChanged;
            grvMain.OptionsView.ShowFooter = true;
            grvMain.Appearance.FooterPanel.Font = Properties.Settings.Default.GeneralFont;
            grvMain.SumResult();
        }

        private static void grvMain_DataSourceChanged(object sender, EventArgs e)
        {
            GridView view = sender as GridView;
            view.BestFitColumns();
        }

        static void grvMain_CalcRowHeight(object sender, RowHeightEventArgs e)
        {
            GridView view = sender as GridView;
            e.RowHeight = view.Appearance.HeaderPanel.FontHeight;
        }

        static void grvMain_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {
            GridView view = sender as GridView;
            e.Appearance.Font = view.Appearance.HeaderPanel.Font;
            if (view.Columns.Any(x => x.FieldName.Equals("Status")) && !view.IsFilterRow(e.RowHandle) && e.RowHandle >= 0)
            {
                int id = Convert.ToInt32(view.GetRowCellValue(e.RowHandle, view.Columns["Status"]));
                DateTime dateCreated = Convert.ToDateTime(view.GetRowCellValue(e.RowHandle, view.Columns["CreatedDate"]));
                DateTime? dateModified = Convert.ToDateTime(view.GetRowCellValue(e.RowHandle, view.Columns["ModifiedDate"]));
                if (id > 0)
                {
                    e.Appearance.Options.UseBackColor = true;
                    if (id == 1 && dateCreated.Date == DateTime.Now.ServerNow().Date)
                    {
                        e.Appearance.BackColor = Properties.Settings.Default.Add;
                        e.Appearance.BackColor2 = Properties.Settings.Default.Add;
                    }
                    if (id == 2 && dateModified.HasValue && dateModified.Value.Date == DateTime.Now.ServerNow().Date)
                    {
                        e.Appearance.BackColor = Properties.Settings.Default.Edit;
                        e.Appearance.BackColor2 = Properties.Settings.Default.Edit;
                    }
                    if (id == 3 && dateModified.HasValue && dateModified.Value.Date == DateTime.Now.ServerNow().Date)
                    {
                        e.Appearance.BackColor = Properties.Settings.Default.Delete;
                        e.Appearance.BackColor2 = Properties.Settings.Default.Delete;
                    }
                }
            }

            //if (e.RowHandle == view.FocusedRowHandle)
            //{
            //    e.Appearance.Options.UseBackColor = true;
            //    e.Appearance.BackColor = MyColor.GridDefaultRow;
            //    e.Appearance.BackColor2 = MyColor.GridDefaultRow;
            //}
        }

        public static void SumResult(this GridView grvMain)
        {
            grvMain.BeginSummaryUpdate();
            try
            {
                foreach (GridColumn col in grvMain.VisibleColumns)
                {
                    if (col.ColumnEdit is DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit)
                    {
                        col.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                        col.SummaryItem.DisplayFormat = "{0:#,#}";
                    }
                }
            }
            catch { }
            finally { grvMain.EndSummaryUpdate(); }

        }

        private static void grvMain_KeyDown(object sender, KeyEventArgs e)
        {
            GridView view = sender as GridView;
            if (view != null && e.KeyCode == Keys.Delete)
            {
                if (view.IsFilterRow(view.FocusedRowHandle))
                    view.ActiveFilter.Clear();
                else
                    view.SetRowCellValue(view.FocusedRowHandle, view.FocusedColumn, 0);
            }
        }

        private static void realColumnEdit_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Tab || e.KeyCode == Keys.Delete)
            {
                BaseEdit editor = null;

                if (sender is LookUpEdit)
                    editor = (LookUpEdit)sender;
                if (sender is DateEdit)
                    editor = (DateEdit)sender;
                if (sender is SpinEdit)
                    editor = (SpinEdit)sender;

                if (editor == null)
                    return;

                GridControl grid = editor.Parent as GridControl;
                if (grid == null)
                    return;

                GridView view = grid.FocusedView as GridView;

                if (view != null && view.IsEditing)
                {
                    view.CloseEditor();
                    if (e.KeyCode == Keys.Delete && view.IsFilterRow(view.FocusedRowHandle))
                        view.ActiveFilter.Clear();
                }
            }
        }

        static void grvMain_ShowingEditor(object sender, CancelEventArgs e)
        {
            GridView grvMain = (GridView)sender;
            grvMain.OptionsSelection.EnableAppearanceFocusedCell = true;
            grvMain.OptionsSelection.EnableAppearanceFocusedRow = true;
            grvMain.OptionsSelection.EnableAppearanceHideSelection = true;
        }

        public static void FormatColmnsGridView(this GridView grvMain)
        {
            grvMain.BeginInit();
            foreach (GridColumn col in grvMain.Columns)
            {
                col.OptionsFilter.FilterPopupMode = FilterPopupMode.CheckedList;
                col.OptionsFilter.ShowEmptyDateFilter = true;
                col.OptionsFilter.ShowBlanksFilterItems = DefaultBoolean.True;
                col.OptionsFilter.AutoFilterCondition = AutoFilterCondition.Contains;//new

                col.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
                col.AppearanceHeader.TextOptions.VAlignment = VertAlignment.Center;
                col.AppearanceHeader.Font = Properties.Settings.Default.GeneralFont;

                col.AppearanceCell.TextOptions.HAlignment = HorzAlignment.Default;
                col.AppearanceCell.TextOptions.VAlignment = VertAlignment.Center;
                col.AppearanceCell.Font = Properties.Settings.Default.GeneralFont;

                if (col.ColumnEdit != null)
                {
                    if (col.ColumnEdit is RepositoryItemSpinEdit)
                    {
                        col.AppearanceCell.TextOptions.HAlignment = HorzAlignment.Far;
                        col.DisplayFormat.FormatType = FormatType.Numeric;
                    }
                    if (col.ColumnEdit is RepositoryItemDateEdit)
                    {
                        col.AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center;

                        RepositoryItemDateEdit rItem = col.ColumnEdit as RepositoryItemDateEdit;

                        col.DisplayFormat.FormatType = FormatType.DateTime;
                        rItem.EditFormat.FormatType = FormatType.DateTime;
                        rItem.DisplayFormat.FormatType = FormatType.DateTime;

                        col.DisplayFormat.FormatString = rItem.EditMask;
                        rItem.EditFormat.FormatString = rItem.EditMask;
                        rItem.DisplayFormat.FormatString = rItem.EditMask;

                        rItem.ShowClear = false;
                    }
                }
            }
            grvMain.OptionsNavigation.EnterMoveNextColumn = true;
            grvMain.EndInit();
        }

        private static void CustomDrawRowIndicator(object sender, RowIndicatorCustomDrawEventArgs e)
        {
            if (!string.IsNullOrEmpty(e.Info.DisplayText)) return;
            bool indicatorIcon = false;
            DevExpress.XtraGrid.Views.Grid.GridView view = (DevExpress.XtraGrid.Views.Grid.GridView)sender;
            e.Appearance.Font = Properties.Settings.Default.GeneralFont;

            if (e.Info.IsRowIndicator && e.RowHandle >= 0)
            {
                e.Appearance.TextOptions.HAlignment = HorzAlignment.Center;
                e.Appearance.TextOptions.VAlignment = VertAlignment.Center;
                Rectangle rec = new Rectangle();
                rec.X = e.Bounds.X;
                rec.Y = e.Bounds.Y;
                rec.Width = e.Bounds.Width;
                rec.Height = e.Appearance.FontHeight + 20;
                e.Appearance.DrawString(e.Cache, e.RowHandle.ToString(), rec);
                e.Info.DisplayText = (Convert.ToInt32(e.RowHandle + 1)).ToString();
                if (!indicatorIcon)
                    e.Info.ImageIndex = -1;
            }
            if (e.RowHandle == DevExpress.XtraGrid.GridControl.InvalidRowHandle)
            {
                e.Appearance.TextOptions.HAlignment = HorzAlignment.Center;
                e.Appearance.TextOptions.VAlignment = VertAlignment.Center;
                Rectangle rec = new Rectangle();
                rec.X = e.Bounds.X;
                rec.Y = e.Bounds.Y;
                rec.Width = e.Bounds.Width;
                rec.Height = e.Appearance.FontHeight + 20;
                e.Appearance.DrawString(e.Cache, e.RowHandle.ToString(), rec);
                e.Info.DisplayText = "";
            }
            e.Painter.DrawObject(e.Info);
            e.Handled = true;
        }

        private static void grvMain_InvalidRowException(object sender, DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = ExceptionMode.Ignore;
        }

        public static List<int> DeleteItem<T>(this GridView grvMain) where T : class
        {
            GridControl gctMain = grvMain.GridControl;

            List<int> lstID = new List<int>();

            int[] id = grvMain.GetSelectedRows();
            for (int i = grvMain.SelectedRowsCount - 1; i >= 0; i--)
            {
                T item = grvMain.GetRow(id[i]) as T;
                if (item != null && item.GetInt32ByName("KeyID") > 0)
                    lstID.Add(item.GetInt32ByName("KeyID"));
            }

            gctMain.BeginUpdate();
            if (gctMain.DataSource != null)
            {
                IList<T> lst = (gctMain.DataSource as IEnumerable<T>).ToList();
                for (int i = grvMain.SelectedRowsCount - 1; i >= 0; i--)
                {
                    lst.RemoveAt(id[i]);
                }
                gctMain.DataSource = lst;
            }
            gctMain.EndUpdate();
            return lstID;
        }
        #endregion

        #region Format SpinEdit
        public static void Format(this SpinEdit spnMain, int DecimalScale = 0, bool LeftAlight = true, bool NotNegative = true)
        {
            spnMain.Properties.Buttons.Clear();
            spnMain.Properties.Mask.UseMaskAsDisplayFormat = true;
            spnMain.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            spnMain.Properties.AppearanceReadOnly.TextOptions.HAlignment = spnMain.Properties.AppearanceFocused.TextOptions.HAlignment = spnMain.Properties.Appearance.TextOptions.HAlignment = LeftAlight ? HorzAlignment.Near : HorzAlignment.Far;
            spnMain.Properties.Mask.EditMask = spnMain.Properties.DisplayFormat.FormatString = spnMain.Properties.EditFormat.FormatString = "N" + DecimalScale.ToString();
            if (NotNegative)
            {
                spnMain.KeyPress += NotNegative_KeyPress;
                if (spnMain.Properties.MinValue == spnMain.Properties.MaxValue)
                {
                    spnMain.Properties.MaxValue = decimal.MaxValue;
                }
                if (spnMain.Properties.MinValue < 0)
                    spnMain.Properties.MinValue = 0;
            }
        }

        public static int ToInt(this SpinEdit spnMain)
        {
            try
            {
                return Convert.ToInt32(spnMain.EditValue);
            }
            catch { return 0; }
        }

        public static int ToInt16(this SpinEdit spnMain)
        {
            try
            {
                return Convert.ToInt16(spnMain.EditValue);
            }
            catch { return 0; }
        }

        public static decimal ToDecimal(this SpinEdit spnMain)
        {
            try
            {
                return Convert.ToDecimal(spnMain.EditValue);
            }
            catch { return 0; }
        }

        public static void NotNegative_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
                e.Handled = true;
        }

        #endregion

        #region Format RepositorySpinEdit
        public static void Format(this RepositoryItemSpinEdit rspnMain, int DecimalScale = 0, bool LeftAlight = true, bool NotNegative = true)
        {
            rspnMain.Buttons.Clear();
            rspnMain.Mask.UseMaskAsDisplayFormat = true;
            rspnMain.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            rspnMain.AppearanceReadOnly.TextOptions.HAlignment = rspnMain.AppearanceFocused.TextOptions.HAlignment = rspnMain.Appearance.TextOptions.HAlignment = LeftAlight ? HorzAlignment.Near : HorzAlignment.Far;
            rspnMain.Mask.EditMask = rspnMain.DisplayFormat.FormatString = rspnMain.EditFormat.FormatString = "N" + DecimalScale.ToString();
            if (NotNegative)
            {
                rspnMain.KeyPress += NotNegative_KeyPress;
                if (rspnMain.MinValue == rspnMain.MaxValue)
                {
                    rspnMain.MaxValue = decimal.MaxValue;
                }
                if (rspnMain.MinValue < 0)
                    rspnMain.MinValue = 0;
            }
        }
        #endregion

        #region Format LookUpEdit
        public static void Format(this LookUpEdit lokMain, bool showHeader = true)
        {
            lokMain.Properties.BestFitMode = BestFitMode.BestFitResizePopup;
            lokMain.Properties.ShowFooter = false;
            lokMain.Properties.NullText = String.Empty;
            lokMain.Properties.ShowHeader = showHeader;
            lokMain.Properties.TextEditStyle = TextEditStyles.Standard;

            lokMain.Properties.SearchMode = SearchMode.AutoFilter;
            lokMain.Properties.AllowNullInput = DefaultBoolean.True;
            lokMain.Properties.AutoSearchColumnIndex = 1;
            lokMain.Properties.AppearanceDropDownHeader.TextOptions.HAlignment = HorzAlignment.Center;
            //lokMain.FormatColumnLookUpEdit();

            lokMain.Properties.KeyDown += rlok_KeyDown;
        }

        private static void rlok_KeyDown(object sender, KeyEventArgs e)
        {
            if (sender is LookUpEdit)
            {
                LookUpEdit lok = sender as LookUpEdit;
                if (e.KeyCode == Keys.Delete)
                    lok.EditValue = null;
            }
        }

        public static void FormatColumnLookUpEdit(this LookUpEdit lokMain)
        {
            //if (string.IsNullOrEmpty(fName))
            //{
            //    try { fName = lokMain.FindForm().Name; }
            //    catch { }
            //}
            //if (string.IsNullOrEmpty(fName) || lokMain.Properties.Columns.Count == 0 || !lokMain.Properties.ShowHeader) return;

            //db = new zModel();
            //List<xDisplay> lstAdd = new List<xDisplay>();

            //bool addCol = false;
            //foreach (LookUpColumnInfo col in lokMain.Properties.Columns)
            //{
            //    addCol = false;
            //    xDisplay myDisplay = null;
            //    try
            //    {
            //        myDisplay = db.xDisplays.FirstOrDefault<xDisplay>(n => n.ParentName.Equals(fName) && n.Group.Equals(lokMain.Name) && n.ColumnName.Equals(col.FieldName));

            //        addCol = (myDisplay == null);
            //    }
            //    catch { addCol = true; }
            //    finally
            //    {
            //        if (addCol && lokMain.Properties.DataSource != null)
            //        {
            //            myDisplay = new xDisplay();
            //            myDisplay.ParentName = fName;
            //            myDisplay.Group = lokMain.Name;
            //            myDisplay.ColumnName = col.FieldName;
            //            myDisplay.FieldName = col.FieldName;
            //            myDisplay.Showing = col.Visible;

            //            string cType = "None";
            //            string cAlign = "Default";
            //            if (col.FormatType == FormatType.DateTime)
            //            {
            //                cType = "DateTime"; cAlign = "Center";
            //            }
            //            else if (col.FormatType == FormatType.Numeric)
            //            {
            //                cType = "Numeric"; cAlign = "Far";
            //            }
            //            else
            //            {
            //                cType = "Custom"; cAlign = "Near";
            //            }

            //            myDisplay.Type = cType;
            //            myDisplay.TextAlign = cAlign;
            //            myDisplay.EnableEdit = false;
            //            lstAdd.Add(myDisplay);
            //        }
            //        else if (myDisplay == null)
            //            myDisplay = db.xDisplays.FirstOrDefault<xDisplay>(hts => hts.ParentName.Equals(fName) && hts.Group.Equals(lokMain.Name) && hts.ColumnName.Equals(col.FieldName));

            //        if (myDisplay != null)
            //        {
            //            col.Visible = myDisplay.Showing;
            //            col.FieldName = myDisplay.FieldName;
            //            if (myDisplay.Type != null)
            //            {
            //                if (lokMain.Properties.DataSource != null)
            //                    lokMain.Properties.AppearanceDropDownHeader.ForeColor = MyColor.GridForeHeader;

            //                col.FormatType = (FormatType)Enum.Parse(typeof(FormatType), myDisplay.Type);
            //                col.Alignment = (HorzAlignment)Enum.Parse(typeof(HorzAlignment), myDisplay.TextAlign);

            //                if (myDisplay.Type.Equals("Numeric") && curDecimalFormat != null && string.IsNullOrEmpty(col.FormatString))
            //                    col.FormatString = curDecimalFormat;
            //                else if (myDisplay.Type.Equals("DateTime") && curDateFormat != null && string.IsNullOrEmpty(col.FormatString))
            //                    col.FormatString = curDateFormat;
            //            }
            //        }
            //    }
            //}

            //if (lstAdd != null && lstAdd.Count > 0)
            //{
            //    try
            //    {
            //        db = new zModel();
            //        db.xDisplays.AddRange(lstAdd);
            //        db.SaveChanges();
            //    }
            //    catch { }
            //}
        }

        public static int ToInt32(this LookUpEdit lokMain)
        {
            try
            {
                if (lokMain.ItemIndex < 0)
                    return 0;
                else
                    return Convert.ToInt32(lokMain.EditValue);
            }
            catch { return 0; }
        }

        public static decimal ToDecimal(this LookUpEdit lokMain)
        {
            try
            {
                if (lokMain.ItemIndex < 0)
                    return 0;
                else
                    return Convert.ToDecimal(lokMain.EditValue);
            }
            catch { return 0; }
        }
        #endregion

        #region Format RepositoryLookUpEdit
        public static void Format(this RepositoryItemLookUpEdit rlokMain, string fName = "", bool showHeader = false)
        {
            rlokMain.NullText = "";
            rlokMain.ShowFooter = false;
            rlokMain.AllowFocused = false;
            rlokMain.ShowHeader = showHeader;
            rlokMain.AppearanceDropDownHeader.TextOptions.HAlignment = HorzAlignment.Center;
            rlokMain.AppearanceDropDownHeader.Options.UseFont = true;
            rlokMain.TextEditStyle = TextEditStyles.Standard;
            rlokMain.BestFitMode = BestFitMode.BestFitResizePopup;
            rlokMain.FormatColumnRepositoryLookUpEdit();

            rlokMain.KeyDown -= rlokMain_KeyDown;
            rlokMain.KeyDown += rlokMain_KeyDown;
        }

        static void rlokMain_KeyDown(object sender, KeyEventArgs e)
        {
            LookUpEdit lok = sender as LookUpEdit;
            DevExpress.Utils.Win.IPopupControl popupEdit = sender as DevExpress.Utils.Win.IPopupControl;
            PopupLookUpEditForm popupWindow = popupEdit.PopupWindow as PopupLookUpEditForm;
            if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
            {
                int index = popupWindow.SelectedIndex;
                int count = 0;
                if (lok.Properties.DataSource != null)
                    count = (lok.Properties.DataSource as IList).Count;
                if (e.KeyCode == Keys.Down)
                {
                    if (popupWindow != null)
                    {
                        if (index != -1 && index < (count - 1))
                            index++;
                    }
                }
                if (e.KeyCode == Keys.Up)
                    index = index > 0 ? index - 1 : index;
                lok.ItemIndex = index;
            }

            if (e.KeyCode == Keys.Delete || string.IsNullOrEmpty(lok.Text.Trim()))
                lok.EditValue = null;
        }

        public static void FormatColumnRepositoryLookUpEdit(this RepositoryItemLookUpEdit rlokMain)
        {
            //db = new zModel();
            //List<xDisplay> lstAdd = new List<xDisplay>();

            //bool addCol = false;
            //foreach (LookUpColumnInfo col in rlokMain.Columns)
            //{
            //    addCol = false;
            //    xDisplay myDisplay = null;
            //    try
            //    {
            //        myDisplay = db.xDisplays.FirstOrDefault<xDisplay>(hts => hts.ParentName.Equals(fName) && hts.Group.Equals(rlokMain.Name) && hts.ColumnName.Equals(col.FieldName));

            //        if (myDisplay == null)
            //            addCol = true;
            //    }
            //    catch { addCol = true; }
            //    finally
            //    {
            //        if (addCol && rlokMain.DataSource != null)
            //        {
            //            myDisplay = new xDisplay();
            //            myDisplay.ParentName = fName;
            //            myDisplay.Group = rlokMain.Name;
            //            myDisplay.ColumnName = col.FieldName;
            //            myDisplay.FieldName = col.FieldName;
            //            myDisplay.Showing = col.Visible;

            //            string cType = "None";
            //            string cAlign = "Default";
            //            if (col.FormatType == FormatType.DateTime)
            //            {
            //                cType = "DateTime"; cAlign = "Center";
            //            }
            //            else if (col.FormatType == FormatType.Numeric)
            //            {
            //                cType = "Numeric"; cAlign = "Far";
            //            }
            //            else
            //            {
            //                cType = "Custom"; cAlign = "Near";
            //            }

            //            myDisplay.Type = cType;
            //            myDisplay.TextAlign = cAlign;
            //            myDisplay.EnableEdit = false;
            //            lstAdd.Add(myDisplay);
            //        }
            //        else if (myDisplay == null)
            //            myDisplay = db.xDisplays.FirstOrDefault<xDisplay>(hts => hts.ParentName.Equals(fName) && hts.Group.Equals(rlokMain.Name) && hts.ColumnName.Equals(col.FieldName));


            //        if (myDisplay != null)
            //        {
            //            col.Visible = myDisplay.Showing;
            //            col.FieldName = myDisplay.FieldName;
            //            if (myDisplay.Type != null)
            //            {
            //                if (rlokMain.DataSource != null)
            //                    rlokMain.AppearanceDropDownHeader.ForeColor = MyColor.GridForeHeader;

            //                col.FormatType = (FormatType)Enum.Parse(typeof(FormatType), myDisplay.Type);
            //                col.Alignment = (HorzAlignment)Enum.Parse(typeof(HorzAlignment), myDisplay.TextAlign);

            //                if (myDisplay.Type.Equals("Numeric") && curDecimalFormat != null && string.IsNullOrEmpty(col.FormatString))
            //                    col.FormatString = curDecimalFormat;
            //                else if (myDisplay.Type.Equals("DateTime") && curDateFormat != null && string.IsNullOrEmpty(col.FormatString))
            //                    col.FormatString = curDateFormat;
            //            }
            //        }
            //    }
            //}

            //if (lstAdd != null && lstAdd.Count() > 0)
            //{
            //    try
            //    {
            //        db = new zModel();
            //        db.xDisplays.AddRange(lstAdd);
            //        db.SaveChanges();
            //    }
            //    catch { }
            //}
        }
        #endregion

        #region FormatTextEdit
        public static void Format(this TextEdit txtMain)
        {
            //New
            txtMain.Properties.MaxLength = 255;
            if (txtMain.Name.Contains("Code"))
                txtMain.Properties.MaxLength = 50;
            if (txtMain.Name.Contains("Name"))
                txtMain.Properties.MaxLength = 100;
        }

        public static void NotUnicode(this TextEdit txtMain, bool NoSpace = false, bool? AutoUperCase = null)
        {
            if (AutoUperCase.HasValue)
                txtMain.Properties.CharacterCasing = AutoUperCase.Value ? CharacterCasing.Upper : CharacterCasing.Lower;
            txtMain.KeyUp -= NotUnicode_KeyUp;
            txtMain.KeyUp += NotUnicode_KeyUp;
            if (NoSpace)
            {
                txtMain.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
                txtMain.Properties.Mask.EditMask = "[a-zA-Z0-9\\-\\_]+";
            }
        }

        public static void NumberOnly(this TextEdit txtMain)
        {
            txtMain.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            txtMain.Properties.Mask.EditMask = "[0-9]+";
        }

        public static void PhoneOnly(this TextEdit txtMain)
        {
            txtMain.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            txtMain.Properties.Mask.EditMask = "[0-9|.]+";

        }

        static void NotUnicode_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                TextEdit txtMain = (TextEdit)sender;
                int cPosition = txtMain.Text.Length - txtMain.SelectionStart;
                txtMain.Text = txtMain.Text.NoSign();
                txtMain.SelectionStart = txtMain.Text.Length - cPosition;
            }
            catch { }
        }

        public static void IsPersonName(this TextEdit txtMain)
        {
            if (!string.IsNullOrEmpty(txtMain.Text))
            {
                int cPosition = txtMain.Text.Length - txtMain.SelectionStart;
                txtMain.Text = txtMain.Text.ToTitleCase();
                txtMain.SelectionStart = txtMain.Text.Length - cPosition;
            }
            txtMain.KeyUp += IsPersonName_KeyUp;
        }

        static void IsPersonName_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                TextEdit txtMain = (TextEdit)sender;
                int cPosition = txtMain.Text.Length - txtMain.SelectionStart;
                txtMain.Text = txtMain.Text.ToTitleCase();
                txtMain.SelectionStart = txtMain.Text.Length - cPosition;
            }
            catch { }
        }

        static void txtMain_TextChanged(object sender, EventArgs e)
        {
            try
            {
                TextEdit txtMain = (TextEdit)sender;
                int cPosition = txtMain.Text.Length - txtMain.SelectionStart;
                txtMain.Text = txtMain.Text.ToTitleCase();
                txtMain.SelectionStart = txtMain.Text.Length - cPosition;
            }
            catch { }
        }
        #endregion

        #region Format GridLookUpEdit
        public static void Format(this GridLookUpEdit glkMain, bool showHeader = true)
        {
            string fName = "";
            try { fName = glkMain.FindForm().Name; }
            catch { }

            glkMain.Properties.AutoComplete = false;
            glkMain.Properties.AllowNullInput = DefaultBoolean.True;
            glkMain.Properties.NullText = string.Empty;
            glkMain.Properties.ShowFooter = false;
            glkMain.Properties.PopupFormMinSize = new Size(glkMain.Width, 200);
            glkMain.Properties.PopupFormSize = new Size(glkMain.Width, 200);
            glkMain.Properties.PopupResizeMode = DevExpress.XtraEditors.Controls.ResizeMode.LiveResize;
            glkMain.Properties.View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFullFocus;
            glkMain.Properties.TextEditStyle = TextEditStyles.Standard;
            GridView grvMain = (GridView)glkMain.Properties.View;
            grvMain.Format(false, false, true);
            grvMain.OptionsView.ShowColumnHeaders = showHeader;
            if (showHeader && !string.IsNullOrEmpty(fName))
            {
                glkMain.Popup -= glkMain_Popup;
                glkMain.Popup += glkMain_Popup;
            }
            grvMain.OptionsView.ColumnAutoWidth = true;

        }

        static void glkMain_Popup(object sender, EventArgs e)
        {
            GridLookUpEdit glkMain = (GridLookUpEdit)sender;
            if (glkMain != null)
            {
                GridView grvMain = (GridView)glkMain.Properties.View;
                if (grvMain.Columns.Count > 0 && grvMain.Columns[0].AppearanceHeader.ForeColor != MyColor.GridForeHeader)
                {
                    try
                    {
                        //grvMain.FormatColmnsGridView(glkMain.FindForm().Name);
                    }
                    catch { }
                }
            }
        }

        public static int ToInt16(this GridLookUpEdit glkMain)
        {
            try
            {
                return Convert.ToInt16(glkMain.EditValue);
            }
            catch { return 0; }
        }

        public static int ToInt32(this GridLookUpEdit glkMain)
        {
            try
            {
                return Convert.ToInt32(glkMain.EditValue);
            }
            catch { return 0; }
        }

        public static decimal ToDecimal(this GridLookUpEdit glkMain)
        {
            try
            {
                return Convert.ToDecimal(glkMain.EditValue);
            }
            catch { return 0; }
        }

        #endregion
    }
}
