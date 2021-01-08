using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using BLL;
using Bll.Csv;
using Point = Data.Point;

namespace ElectricityModel
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private enum GraphType
        {
            UcForR1,
            UlForR1,
            UrForR1,
            UcForR3,
            UlForR3,
            UrForR3,
            UcForAll,
            UlForAll,
            UrForAll,
        }

        private GraphType _currentGraph;

        private void button1_Click(object sender, EventArgs e)
        {
            var openFileDialog1 = new OpenFileDialog {Filter = @"Csv File(*.csv)|*.csv|All files(*.*)|*.*"};

            if (openFileDialog1.ShowDialog() != DialogResult.OK) return;
            var fileName = openFileDialog1.FileName;
            var data = CsvReader.ReadCsv(fileName);
            DataController.AddFirstData(data);
            button1.Text = fileName;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var openFileDialog1 = new OpenFileDialog {Filter = @"Csv File(*.csv)|*.csv|All files(*.*)|*.*"};

            if (openFileDialog1.ShowDialog() != DialogResult.OK) return;
            var fileName = openFileDialog1.FileName;
            var data = CsvReader.ReadCsv(fileName);
            DataController.AddSecondData(data);
            button2.Text = fileName;
        }



        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            _currentGraph = GraphType.UcForR1;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            _currentGraph = GraphType.UlForR1;
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            _currentGraph = GraphType.UrForR1;
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            _currentGraph = GraphType.UcForR3;
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            _currentGraph = GraphType.UlForR3;
        }

        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {
            _currentGraph = GraphType.UrForR3;
        }

        private void radioButton7_CheckedChanged(object sender, EventArgs e)
        {
            _currentGraph = GraphType.UcForAll;
        }
        private async Task CreateOneLine(List<Point> points)
        {
            chart1.Series[0].Points.Clear();
            chart1.BorderWidth = 2;

            foreach (var result in points)
            {
                await Task.Delay(1);
                chart1.Series[0].Points.AddXY(result.X, result.Y);
            }
        }

        private async Task CreateTwoLines(List<Point> points1, List<Point> points2)
        {
            chart1.Series[0].Points.Clear();
            chart1.BorderWidth = 2;
            chart1.Series[1].Points.Clear();
            foreach (var result in points1)
            {
                await Task.Delay(1);
                chart1.Series[0].Points.AddXY(result.X, result.Y);
            }

            foreach (var result in points2)
            {
                await Task.Delay(1);
                chart1.Series[1].Points.AddXY(result.X, result.Y);
            }
        }

        private async void button3_Click(object sender, EventArgs e)
        {
            switch (_currentGraph)
            {
                case GraphType.UcForR1:
                    await CreateOneLine(DataHandler.UcGraphPoints(DataController.GetFirstData()));
                    break;
                case GraphType.UlForR1:
                    await CreateOneLine(DataHandler.UlGraphPoints(DataController.GetFirstData()));
                    break;
                case GraphType.UrForR1:
                    await CreateOneLine(DataHandler.UrGraphPoints(DataController.GetFirstData()));
                    break;
                case GraphType.UcForR3:
                    await CreateOneLine(DataHandler.UcGraphPoints(DataController.GetSecondData()));
                    break;
                case GraphType.UlForR3:
                    await CreateOneLine(DataHandler.UlGraphPoints(DataController.GetSecondData()));
                    break;
                case GraphType.UrForR3:
                    await CreateOneLine(DataHandler.UrGraphPoints(DataController.GetSecondData()));
                    break;
                case GraphType.UcForAll:
                    await CreateTwoLines(
                        DataHandler.UcGraphPoints(DataController.GetFirstData()),
                        DataHandler.UcGraphPoints(DataController.GetSecondData()));
                    break;
                case GraphType.UlForAll:
                    await CreateTwoLines(
                        DataHandler.UlGraphPoints(DataController.GetFirstData()),
                        DataHandler.UlGraphPoints(DataController.GetSecondData()));
                    break;
                case GraphType.UrForAll:
                    await CreateTwoLines(
                        DataHandler.UrGraphPoints(DataController.GetFirstData()),
                        DataHandler.UrGraphPoints(DataController.GetSecondData()));
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private void radioButton8_CheckedChanged(object sender, EventArgs e)
        {
            _currentGraph = GraphType.UlForAll;
        }

        private void radioButton9_CheckedChanged(object sender, EventArgs e)
        {
            _currentGraph = GraphType.UrForAll;
        }
        private void chart_GetToolTipText(object sender, ToolTipEventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(e.Text))
                return;

            Console.WriteLine(e.HitTestResult.ChartElementType);

            switch (e.HitTestResult.ChartElementType)
            {
                case ChartElementType.DataPoint:
                case ChartElementType.DataPointLabel:
                case ChartElementType.Gridlines:
                case ChartElementType.Axis:
                case ChartElementType.TickMarks:
                case ChartElementType.PlottingArea:
                    var area = chart1.ChartAreas[0];

                    var areaPosition = area.Position;

                    var areaRect = new RectangleF(areaPosition.X * chart1.Width / 100, areaPosition.Y * chart1.Height / 100,
                        areaPosition.Width * chart1.Width / 100, areaPosition.Height * chart1.Height / 100);

                    var innerPlot = area.InnerPlotPosition;

                    double x = area.AxisX.Minimum +
                               (area.AxisX.Maximum - area.AxisX.Minimum) * (e.X - areaRect.Left - innerPlot.X * areaRect.Width / 100) /
                               (innerPlot.Width * areaRect.Width / 100);
                    double y = area.AxisY.Maximum -
                               (area.AxisY.Maximum - area.AxisY.Minimum) * (e.Y - areaRect.Top - innerPlot.Y * areaRect.Height / 100) /
                               (innerPlot.Height * areaRect.Height / 100);

                    Console.WriteLine($@"{x:F2} {y:F2}");
                    e.Text = $"{x:F2} {y:F2}";
                    break;
            }
        }
    }
}
