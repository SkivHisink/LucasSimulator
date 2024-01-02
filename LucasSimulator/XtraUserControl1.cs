using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Views.Grid;
using System.Collections.Generic;
using System.Globalization;
using System.ComponentModel;
using DevExpress.Utils;

namespace LucasSimulator
{
    public partial class XtraUserControl1 : DevExpress.XtraEditors.XtraUserControl
    {
        public XtraUserControl1()
        {
            InitializeComponent();
        }

        private void ComboBoxDouble_EditValueChanging(object sender, ChangingEventArgs e)
        {
            string newText = e.NewValue.ToString();
            var comboBox = sender as DevExpress.XtraEditors.TextEdit;
            if (!IsValidDouble(newText))
            {
                // Некорректное значение, устанавливаем красный цвет текста
                comboBox.Properties.Appearance.ForeColor = System.Drawing.Color.Red;
                calculationButton.Enabled = false;
            }
            else
            {
                // Корректное значение, устанавливаем цвет текста по умолчанию
                comboBox.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
                calculationButton.Enabled = true;
            }
        }

        private void ComboBoxInt_EditValueChanging(object sender, ChangingEventArgs e)
        {
            string newText = e.NewValue.ToString();
            var comboBox = sender as DevExpress.XtraEditors.TextEdit;
            if (!IsValidInt(newText))
            {
                // Некорректное значение, устанавливаем красный цвет текста
                comboBox.Properties.Appearance.ForeColor = System.Drawing.Color.Red;
                calculationButton.Enabled = false;
            }
            else
            {
                // Корректное значение, устанавливаем цвет текста по умолчанию
                comboBox.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
                calculationButton.Enabled = true;
            }
        }
        private bool IsValidDouble(string value)
        {
            return double.TryParse(value, NumberStyles.Any, CultureInfo.InvariantCulture, out _);
        }

        private bool IsValidInt(string value)
        {
            return double.TryParse(value, NumberStyles.Any, CultureInfo.InvariantCulture, out _);
        }
        
        private void onLoad(object sender, System.EventArgs e)
        {
            if (!this.DesignMode)
            {
                var matrix = new List<Populaster>
                {
                    new Populaster
                    (
                        1, 0.00, 0.00, 1.0 / 5, 0.00, 2.0 / 5, 0.00, 0.00, 0.00, 1.0 / 5, 0.00, 0.00, 0.00, 1.0 / 5,
                        0.00, 0.00, 0.00
                    ),
                    new Populaster
                    (
                        2, 1.0 / 5, 1.0 / 5, 1.0 / 5, 1.0 / 5, 0.00, 1.0 / 5, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00,
                        0.00, 0.00, 0.00
                    ),
                    new Populaster
                    (
                        3, 1.0 / 6, 1.0 / 6, 0.00, 1.0 / 6, 1.0 / 6, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00,
                        0.00, 1.0 / 6, 1.0 / 6
                    ),
                    new Populaster
                    (
                        4, 0.00, 0.00, 0.00, 0.00, 1.0 / 6, 0.00, 0.00, 0.00, 0.00, 1.0 / 6, 2.0 / 6, 1.0 / 6, 0.00,
                        0.00, 1.0 / 6, 0.00
                    ),
                    new Populaster
                    (
                        5, 1.0 / 13, 1.0 / 13, 1.0 / 13, 1.0 / 13, 2.0 / 13, 1.0 / 13, 1.0 / 13, 1.0 / 13, 2.0 / 13,
                        1.0 / 13, 1.0 / 13, 0.00, 0.00, 0.00, 0.00, 0.00
                    ),
                    new Populaster
                    (
                        6, 1.0 / 5, 0.00, 0.00, 0.00, 1.0 / 5, 0.00, 0.00, 0.00, 0.00, 0.00, 1.0 / 5, 0.00, 0.00,
                        1.0 / 5, 1.0 / 5, 0.00
                    ),
                    new Populaster
                    (
                        7, 0.00, 0.00, 0.00, 1.0 / 5, 2.0 / 5, 0.00, 0.00, 1.0 / 5, 0.00, 0.00, 0.00, 0.00, 1.0 / 5,
                        0.00, 0.00, 0.00
                    ),
                    new Populaster
                    (
                        8, 1.0 / 4, 0.00, 0.00, 0.00, 0.00, 1.0 / 2, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00,
                        0.00, 1.0 / 4
                    ),
                    new Populaster
                    (
                        9, 0.00, 1.0 / 7, 0.00, 0.00, 0.00, 0.00, 1.0 / 7, 0.00, 1.0 / 7, 1.0 / 7, 0.00, 0.00, 0.00,
                        1.0 / 7, 1.0 / 7, 1.0 / 7
                    ),
                    new Populaster
                    (
                        10, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 1.0 / 4, 0.00, 1.0 / 4, 0.00, 0.00, 1.0 / 4, 1.0 / 4,
                        0.00, 0.00, 0.00
                    ),
                    new Populaster
                    (
                        11, 0.00, 0.00, 1.0 / 5, 0.00, 1.0 / 5, 0.00, 0.00, 0.00, 1.0 / 5, 1.0 / 5, 0.00, 1.0 / 5, 0.00,
                        0.00, 0.00, 0.00
                    ),
                    new Populaster
                    (
                        12, 0.00, 1.0 / 4, 0.00, 1.0 / 4, 1.0 / 4, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00,
                        1.0 / 4, 0.00, 0.00
                    ),
                    new Populaster
                    (
                        13, 0.00, 0.00, 0.00, 0.00, 1.0 / 8, 0.00, 0.00, 1.0 / 8, 1.0 / 8, 0.00, 1.0 / 8, 1.0 / 8,
                        2.0 / 8, 0.00, 1.0 / 8, 0.00
                    ),
                    new Populaster
                    (
                        14, 0.00, 0.00, 1.0 / 5, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 1.0 / 5, 0.00,
                        2.0 / 5, 1.0 / 5
                    ),
                    new Populaster
                    (
                        15, 0.00, 0.00, 0.00, 0.00, 1.0 / 4, 0.00, 1.0 / 4, 1.0 / 8, 0.00, 0.00, 0.00, 0.00, 1.0 / 8,
                        1.0 / 8, 0.00, 1.0 / 8
                    ),
                    new Populaster
                    (
                        16, 0.00, 0.00, 0.00, 1.0 / 5, 0.00, 1.0 / 5, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 1.0 / 5,
                        1.0 / 5, 1.0 / 5, 0.00
                    )
                };

                gridControl1.DataSource = matrix;
                // Assuming you have a GridView named gridView1
                GridView gridView = gridView1;
                gridView.CustomColumnDisplayText += (sender, e) =>
                {
                    if (e.Column.VisibleIndex > 0) // Skip the first column
                    {
                        if (e.Value is double value)
                        {
                            e.DisplayText = value.ToString("N2");
                        }
                    }
                };
                gridControl1.Refresh();
                gridControl1.RefreshDataSource();
                gridView.PopulateColumns();
                gridView.BestFitColumns();
                gridView.RefreshData();
                var column =
                    gridView.Columns[0];
                column.OptionsColumn.AllowEdit = false;
                column.OptionsColumn.AllowMove = false;
                column.OptionsColumn.AllowSort = DefaultBoolean.False;
            }
        }
    }
    public class Populaster
    {
        [DisplayName(" ")]
        public int indx { get; set; }
        [DisplayName("1")]
        public double one { get; set; }
        [DisplayName("2")]
        public double tw { get; set; }
        [DisplayName("3")]
        public double th { get; set; }
        [DisplayName("4")]
        public double f { get; set; }
        [DisplayName("5")]
        public double fv { get; set; }
        [DisplayName("6")]
        public double six { get; set; }
        [DisplayName("7")]
        public double sev { get; set; }
        [DisplayName("8")]
        public double eig { get; set; }
        [DisplayName("9")]
        public double nine { get; set; }
        [DisplayName("10")]
        public double ten { get; set; }
        [DisplayName("11")]
        public double elev { get; set; }
        [DisplayName("12")]
        public double twel { get; set; }
        [DisplayName("13")]
        public double thrt { get; set; }
        [DisplayName("14")]
        public double fort { get; set; }
        [DisplayName("15")]
        public double fivt { get; set; }
        [DisplayName("16")]
        public double sixt { get; set; }
        public Populaster(int indx,
                       double one,
                       double tw,
                       double th,
                       double f,
                       double fv,
                       double six,
                       double sev,
                       double eig,
                       double nine,
                       double ten,
                       double elev,
                       double twel,
                       double thrt,
                       double fort,
                       double fivt,
                       double sixt
        )
        {
            this.indx = indx;
            this.one = one;
            this.tw = tw;
            this.th = th;
            this.f = f;
            this.fv = fv;
            this.six = six;
            this.sev = sev;
            this.eig = eig;
            this.nine = nine;
            this.ten = ten;
            this.elev = elev;
            this.twel = twel;
            this.thrt = thrt;
            this.fort = fort;
            this.fivt = fivt;
            this.sixt = sixt;
        }
    }
}
