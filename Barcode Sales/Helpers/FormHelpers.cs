using Barcode_Sales.Helpers.Messages;
using Barcode_Sales.Validations;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Localization;
using DevExpress.XtraGrid.Views.Grid;
using Microsoft.Reporting.Map.WebForms.BingMaps;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static DevExpress.Utils.Drawing.Helpers.NativeMethods;

namespace Barcode_Sales.Helpers
{
    public static class FormHelpers
    {
        public static void ControlLoad<T>(T data, Control control, string displayMember = "Name", string valueMember = "Id") where T : class
        {
            if (control is System.Windows.Forms.ComboBox)
            {
                var ctrl = control as System.Windows.Forms.ComboBox;
                ctrl.DisplayMember = displayMember;
                ctrl.ValueMember = valueMember;
                ctrl.DataSource = data;
            }
            else if (control is GridControl)
            {
                var grid = control as GridControl;
                grid.DataSource = data;
                var gridView = grid.MainView as DevExpress.XtraGrid.Views.Grid.GridView;
                GridPanelText(gridView);
                gridView.RefreshData();
                GridCustomRowNumber(gridView);
            }
            else if (control is LookUpEdit look)
            {
                look.Properties.Columns.Clear();
                look.Properties.DataSource = data;
                look.Properties.DisplayMember = displayMember;
                look.Properties.ValueMember = valueMember;
                look.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo(displayMember));

                int rowCount = 0;
                if (data is IList list)
                    rowCount = list.Count;
                else if (data is DataTable dt)
                    rowCount = dt.Rows.Count;
                else if (data is IEnumerable<object> enumerable)
                    rowCount = enumerable.Count();

                look.Properties.DropDownRows = rowCount > 7 ? 7 : rowCount;
            }
        }

        /// <summary>
        /// Gridin başlığındakı yazını və axtarış qutusunun içərisindəki yazını dəyiştirir
        /// </summary>
        public static void GridPanelText(GridView grid)
        {
            grid.GroupPanelText = "Qruplaşdırmaq üçün sütun başlıqlarını buraya sürükləyin";
            grid.OptionsFind.FindNullPrompt = "Axtarış edin..";
        }

        /// <summary>
        /// Gridin axtarış çubuğundakı düymənin adını dəyiştirir
        /// </summary>
        public class MyGridLocalizer : GridLocalizer
        {
            public override string GetLocalizedString(GridStringId id)
            {
                if (id == GridStringId.FindControlFindButton)
                    return "Axtar";
                return base.GetLocalizedString(id);
            }
        }

        public static string AppVersion()
        {
            return "Versiya: " + Application.ProductVersion;
        }

        public static void GridCustomRowNumber(GridView gridView, string columnName = "#")
        {
            gridView.CustomDrawCell += (sender, e) =>
            {
                if (e.Column.FieldName == columnName)
                {
                    if (e.RowHandle >= 0)
                    {
                        e.DisplayText = (e.RowHandle + 1).ToString();
                    }
                }
            };
            gridView.RefreshData();

            GridColumn column = gridView.Columns.ColumnByFieldName(columnName);
            if (column != null)
                column.BestFit();
        }

        /// <summary>
        /// Gridə göndərilən sütunun foreColor-unu qırmızı yaxud yaşıl edir. 
        /// </summary>
        /// <param name="column">Hansı sütundakı textin rəngini dəyişəcəyiksə onu seçirik</param>
        /// <param name="value1">Yaşıl rəngdə yazılmasını istədiyimiz dəyəri göndəririk string formatında</param>
        /// <param name="value2">Qırmızı rəngdə yazılmasını istədiyimiz dəyəri göndəririk string formatında</param>
        /// <param name="eventArgs">Gridin RowCellCtyle eventi göndərilir</param>
        public static void GridViewStatusDisplayColor(GridColumn column, string value1, string value2, RowCellStyleEventArgs eventArgs)
        {
            if (eventArgs.Column == column)
            {
                if (eventArgs.CellValue != null)
                {
                    eventArgs.Appearance.FontStyleDelta = FontStyle.Bold;
                    if (eventArgs.CellValue.ToString() == value1)
                    {
                        eventArgs.Appearance.ForeColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Success;
                    }
                    else if (eventArgs.CellValue.ToString() == value2)
                    {
                        eventArgs.Appearance.ForeColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Danger;
                    }
                }
            }
        }

        public static T OpenForm<T>(params object[] constructorArgs) where T : Form
        {
            T form = Application.OpenForms.OfType<T>().FirstOrDefault();

            if (form == null)
            {
                form = (T)Activator.CreateInstance(typeof(T), constructorArgs);
                form.Show();
            }
            else
            {
                form.WindowState = FormWindowState.Normal;
                form.StartPosition = FormStartPosition.CenterScreen;
                form.BringToFront();
            }

            return form;
        }

        public static bool CheckInternetConnection()
        {
            using (Ping ping = new Ping())
            {
                try
                {
                    return ping.Send("8.8.8.8").Status == IPStatus.Success;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }

        public static void HasPermission(Action action)
        {
            if (Cursor.Current != Cursors.No)
            {
                action?.Invoke();
            }
            else
            {
                CommonMessageBox.Message("İcazəniz yoxdur !", NextPOS.UserControls.fMessage.enmType.Warning);
            }
        }

        public static string ConvertToEAN13(Guid guid)
        {
            string guidString = guid.ToString("N");
            string barcodeContent = new String(guidString.Where(Char.IsDigit).ToArray());
            barcodeContent = barcodeContent.Substring(0, Math.Min(barcodeContent.Length, 9));

            int sum = barcodeContent.Select((c, index) => int.Parse(c.ToString()) * (index % 2 == 0 ? 1 : 3)).Sum();
            int checksum = (10 - (sum % 10)) % 10;

            barcodeContent += checksum.ToString();

            return $"994{barcodeContent}";
        }

        public static void PingHostAsync(string host)
        {
            //using (Ping ping = new Ping())
            //{
            //    try
            //    {
            //        Cursor.Current = Cursors.WaitCursor;

            //        PingReply reply = ping.Send(host);
            //        if (reply.Status == IPStatus.Success)
            //        {
            //            Alert($"{host} adresi ilə əlaqə mövcuddur", Enums.MessageType.Success);
            //        }
            //        else
            //        {
            //            Alert($"{host} adresi ilə əlaqə yoxdur", Enums.MessageType.Error);
            //        }
            //    }
            //    catch (Exception ex)
            //    {
            //        ReadyMessages.ERROR_DEFAULT_MESSAGE($"Error ping {host}: {ex.Message}");
            //    }
            //    finally { Cursor.Current = Cursors.Default; }
            //}
        }

        public static string ConvertClassToJson(object item)
        {
            string json = JsonConvert.SerializeObject(item, new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore
            });

            return json;
        }

        public static RestResponse PostRequestJson(string ipAddress, string json)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                if (string.IsNullOrWhiteSpace(ipAddress))
                {
                    XtraMessageBox.Show("Kassa ip adresi daxil edilməmiştir", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }
                using (RestClient client = new RestClient())
                {
                    RestRequest request = new RestRequest(ipAddress, Method.Post);
                    request.AddHeader("Content-Type", "application/json;charset=utf-8");
                    request.AddStringBody(json, DataFormat.Json);
                    RestResponse response = client.Execute(request);
                    return response;
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally { Cursor.Current = Cursors.Default; }
        }
    }
}