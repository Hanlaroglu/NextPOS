using DevExpress.XtraEditors;
using System.Collections.Generic;

namespace Barcode_Sales.UserControls
{
    public class controlCategoryButton : CheckButton
    {
        public controlCategoryButton()
        {
            Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            Appearance.TextOptions.Trimming = DevExpress.Utils.Trimming.Character;
        }

        public int Id { get; set; }
        public IEnumerable<Products> Products { get; set; }
    }
}
