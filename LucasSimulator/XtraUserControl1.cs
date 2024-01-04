using System;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Views.Grid;
using System.Collections.Generic;
using System.Globalization;
using System.ComponentModel;
using DevExpress.Utils;
using DevExpress.XtraCharts;
using DevExpress.XtraEditors;
using System.Linq;
using CenterSpace.NMath.Core;

namespace LucasSimulator
{
    public partial class XtraUserControl1 : DevExpress.XtraEditors.XtraUserControl
    {
        public XtraUserControl1()
        {
            InitializeComponent();
            xtraTabPage3.PageVisible = false;
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

        private Simulator simulator;

        private void calculationButton_Click(object sender, System.EventArgs e)
        {
            // TODO : check transitionMatrix on 1 in each row
            var transitionMatrix = new double[16, 16];
            gridView1.RefreshData();
            var tempMatrix = (List<Populaster>)gridControl1.DataSource;
            for (int i = 0; i < tempMatrix.Count; i++)
            {
                transitionMatrix[i, 0] = tempMatrix[i].one;
                transitionMatrix[i, 1] = tempMatrix[i].tw;
                transitionMatrix[i, 2] = tempMatrix[i].th;
                transitionMatrix[i, 3] = tempMatrix[i].f;
                transitionMatrix[i, 4] = tempMatrix[i].fv;
                transitionMatrix[i, 5] = tempMatrix[i].six;
                transitionMatrix[i, 6] = tempMatrix[i].sev;
                transitionMatrix[i, 7] = tempMatrix[i].eig;
                transitionMatrix[i, 8] = tempMatrix[i].nine;
                transitionMatrix[i, 9] = tempMatrix[i].ten;
                transitionMatrix[i, 10] = tempMatrix[i].elev;
                transitionMatrix[i, 11] = tempMatrix[i].twel;
                transitionMatrix[i, 12] = tempMatrix[i].thrt;
                transitionMatrix[i, 13] = tempMatrix[i].fort;
                transitionMatrix[i, 14] = tempMatrix[i].fivt;
                transitionMatrix[i, 15] = tempMatrix[i].sixt;
                double counter = 0.0;
                for (int j = 0; j < 16; j++)
                {
                    counter += transitionMatrix[i, j];
                }

                if (Math.Abs(1.0 - counter) > 1e-4)
                {
                    System.Windows.Forms.MessageBox.Show($"Transition matrix has wrong value at {i + 1} row");
                }
            }
            // Initialization
            simulator = new Simulator(
                double.Parse(lambdaOneTextEdit.Text, CultureInfo.InvariantCulture),
                double.Parse(lambdaTwoTextEdit.Text, CultureInfo.InvariantCulture),
                double.Parse(lambdaStarOneTextEdit.Text, CultureInfo.InvariantCulture),
                double.Parse(lambdaStarTwoTextEdit.Text, CultureInfo.InvariantCulture),
                double.Parse(gOneTextEdit.Text, CultureInfo.InvariantCulture),
                double.Parse(gTowTextEdit.Text, CultureInfo.InvariantCulture),
                double.Parse(gStarOneTextEdit.Text, CultureInfo.InvariantCulture),
                double.Parse(gStarTwoTextEdit.Text, CultureInfo.InvariantCulture),
                double.Parse(nominalExchangeTextEdit.Text, CultureInfo.InvariantCulture),
                double.Parse(forwardPremiumTextEdit.Text, CultureInfo.InvariantCulture),
                double.Parse(forwardPayoffTextEdit.Text, CultureInfo.InvariantCulture),
                double.Parse(riskPremiumTextEdit.Text, CultureInfo.InvariantCulture),
                double.Parse(betaTextEdit.Text, CultureInfo.InvariantCulture),
                double.Parse(thetaTextEdit.Text, CultureInfo.InvariantCulture),
                double.Parse(gammaTextEdit.Text, CultureInfo.InvariantCulture),
                transitionMatrix);
            // Simulation
            var simResult = simulator.Simulate(int.Parse(simNumTextEdit.Text, CultureInfo.InvariantCulture));
            gridControl2.DataSource = simResult;
            gridControl2.Refresh();
            gridControl2.RefreshDataSource();
            gridView2.PopulateColumns();
            gridView2.BestFitColumns();
            gridView2.RefreshData();
            // Fill plots
            FillPlots();
            // Calculate matricies
            CalculateMatricies();
            // Add statistiks
            AddStatistics();
            // Show result to user after simulation
            xtraTabPage3.PageVisible = true;
        }

        private void AddStatistics()
        {
            var stats = new List<StatisticResults>();
            stats.Add(StatisticResults.MarkResult());
            stats.Add(StatisticResults.RealResult());
            //
            var simResults = gridControl2.DataSource as List<SimulationStepResult>;
            var series0 = new List<double>();
            var series1 = new List<double>();
            var series2 = new List<double>();
            var series3 = new List<double>();
            for (int i=0;i<simResults.Count;i++)
            {
                series0.Add(simResults[i].St);
                series1.Add(simResults[i].StDevide);
                series2.Add(simResults[i].FtDevide);
                series3.Add(simResults[i].FtMinusStDevide);
            }
            stats.Add(new StatisticResults("My model",
                StatisticResults.CalculateSlope(series1),
                StatisticResults.CalculateVolatility(series1),
                StatisticResults.CalculateVolatility(series2),
                StatisticResults.CalculateVolatility(series3),
                StatisticResults.CalculateAutocorrelation(series1, 1),
                StatisticResults.CalculateAutocorrelation(series2, 1),
                StatisticResults.CalculateAutocorrelation(series3, 1)
            ));
            gridControl5.DataSource = stats;
            gridControl5.Refresh();
            gridControl5.RefreshDataSource();
            gridView5.PopulateColumns();
            gridView5.BestFitColumns();
            gridView5.RefreshData();

        }
        private void CalculateMatricies()
        {
            var matrixResult = simulator.CalculatePriceDividendMatricies();
            gridControl3.DataSource = matrixResult.Item1;
            gridControl3.Refresh();
            gridControl3.RefreshDataSource();
            gridView3.PopulateColumns();
            gridView3.BestFitColumns();
            gridView3.RefreshData();
            var column =
                gridView3.Columns[0];
            column.OptionsColumn.AllowEdit = false;
            column.OptionsColumn.AllowMove = false;
            column.OptionsColumn.AllowSort = DefaultBoolean.False;
            //
            gridControl4.DataSource = matrixResult.Item1;
            gridControl4.Refresh();
            gridControl4.RefreshDataSource();
            gridView4.PopulateColumns();
            gridView4.BestFitColumns();
            gridView4.RefreshData();
            column =
                gridView4.Columns[0];
            column.OptionsColumn.AllowEdit = false;
            column.OptionsColumn.AllowMove = false;
            column.OptionsColumn.AllowSort = DefaultBoolean.False;
        }
        private void FillPlots()
        {
            chartControl1.Series.Clear();
            var xValues = new List<double>();
            var y1Values = new List<double>();
            var y2Values = new List<double>();
            var y3Values = new List<double>();
            var y4Values = new List<double>();
            var data = gridControl2.DataSource as List<SimulationStepResult>;
            Series series1 = new Series("S_(t+1)/S_t", ViewType.Line);
            Series series2 = new Series("F_t/S_t", ViewType.Line);
            Series series3 = new Series("(F_t-S_(t+1))/S_t", ViewType.Line);
            Series series4 = new Series("E_t[(F_t-S_(t+1))/S_t]", ViewType.Line);
            for (int i = 0; i < 97; i++)
            {
                xValues.Add(73.0 + i * 0.25);
                y1Values.Add(data[i].StDevide);
                y2Values.Add(data[i].FtDevide);
                y3Values.Add(data[i].FtMinusStDevide);
                y4Values.Add(data[i].EtFtMinusStDevide);
                series1.Points.Add(new SeriesPoint(xValues[i], y1Values[i]));
                series2.Points.Add(new SeriesPoint(xValues[i], y2Values[i]));
                series3.Points.Add(new SeriesPoint(xValues[i], y3Values[i]));
                series4.Points.Add(new SeriesPoint(xValues[i], y4Values[i]));
            }
            chartControl1.Series.Add(series1);
            chartControl1.Series.Add(series2);
            // Cast the chart's diagram to the XYDiagram type, to access its axes.
            XYDiagram diagram = (XYDiagram)chartControl1.Diagram;

            // Enable the diagram's scrolling.
            diagram.EnableAxisXScrolling = true;
            diagram.EnableAxisYScrolling = true;

            // Define the whole range for the X-axis. 
            diagram.AxisX.WholeRange.Auto = false;
            diagram.AxisX.WholeRange.SetMinMaxValues(73, 97);

            // Disable the side margins 
            // (this has an effect only for certain view types).
            diagram.AxisX.VisualRange.AutoSideMargins = false;

            // Limit the visible range for the X-axis.
            //diagram.AxisX.VisualRange.Auto = false;
            diagram.AxisX.VisualRange.SetMinMaxValues(72, 98);

            // Define the whole range for the Y-axis. 
            diagram.AxisY.WholeRange.Auto = false;
            diagram.AxisY.WholeRange.SetMinMaxValues(0.97, 1.02);
            chartControl2.Series.Add(series3);
            chartControl2.Series.Add(series4);
        }
    }

    public class StatisticResults
    {
        [DisplayName("Model")]
        public string ModelName { get; set; }
        [DisplayName("Slope")]
        public double Slope { get; set; }
        [DisplayName("Volatility S_(t+1)/S_t")]
        public double stDevideVolatility { get; set; }
        [DisplayName("Volatility F_t/S_t")]
        public double ftDevideVolatility { get; set; }
        [DisplayName("Volatility (F_t-S_(t+1))/S_t")]
        public double ftMinusStDevideVolatility { get; set; }
        [DisplayName("Autocorrelation S_(t+1)/S_t")]
        public double stDevideAutocorrelation { get; set; }
        [DisplayName("Autocorrelation F_t/S_t")]
        public double ftDevideAutocorrelation { get; set; }
        [DisplayName("Autocorrelation (F_t-S_(t+1))/S_t")]
        public double ftMinusStDevideAutocorrelation { get; set; }

        public StatisticResults(string modelName, double slope,
            double stDevideVolatility, double ftDevideVolatility, double ftMinusStDevideVolatility,
            double stDevideAutocorrelation, double ftDevideAutocorrelation, double ftMinusStDevideAutocorrelation)
        {
            this.ModelName = modelName;
            this.Slope = slope;
            this.stDevideVolatility = stDevideVolatility;
            this.ftDevideVolatility = ftDevideVolatility;
            this.ftMinusStDevideVolatility = ftMinusStDevideVolatility;
            this.stDevideAutocorrelation = stDevideAutocorrelation;
            this.ftDevideAutocorrelation = ftDevideAutocorrelation;
            this.ftMinusStDevideAutocorrelation = ftMinusStDevideAutocorrelation;
        }
        public static StatisticResults MarkResult()
        {
            return new StatisticResults("Mark Result",
                -1.444,
                0.014,
                0.006,
                0.029,
                0.105,
                0.006,
                0.628);
        }

        public static StatisticResults RealResult()
        {
            return new StatisticResults("Data", 
                -0.293, 
                0.060, 
                0.080, 
                0.061, 
                0.007, 
                0.888, 
                0.026);
        }

        public static double CalculateSlope(List<double> dataX, List<double> dataY)
        {
            var x = new DoubleMatrix(new DoubleVector(dataX.ToArray()));
            var y = new DoubleVector(dataY.ToArray());
            var lst = new DoubleLeastSquares(x, y, true);
            return lst.X[1];
        }

        public static double CalculateSlope(List<double> data)
        {
            double n = data.Count;
            double sumXY = 0;
            double sumX = 0;
            double sumY = data.Sum();
            double sumX2 = 0;

            for (int i = 0; i < n; i++)
            {
                sumXY += i * data[i];
                sumX += i;
                sumX2 += i * i;
            }

            return (n * sumXY - sumX * sumY) / (n * sumX2 - Math.Pow(sumX, 2));
        }


        public static double CalculateVolatility(List<double> data)
        {
            var array = new DoubleVector(data.ToArray());
            return StatsFunctions.StandardDeviation(array);
        }

        public static double CalculateAutocorrelation(List<double> data, int lag)
        {
            int n = data.Count;

            if (lag >= n)
            {
                throw new ArgumentException("Заданный лаг больше размера данных.");
            }

            double mean = data.Average();
            double numerator = 0;
            double denominator = 0;

            for (int i = 0; i < n - lag; i++)
            {
                numerator += (data[i] - mean) * (data[i + lag] - mean);
                denominator += Math.Pow(data[i] - mean, 2);
            }

            return numerator / denominator;
        }
    }
    // TODO: Clean up this class and rename it
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
