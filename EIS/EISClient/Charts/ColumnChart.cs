using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;
using System.Windows.Forms.DataVisualization.Charting;
using System.Drawing;
using System.IO;
using System.Globalization;

namespace EISClient.Charts {

    public class ColumnChart {

        private static CultureInfo th = new CultureInfo("th");

        private Chart _chart = null;
        private Font _axisFont = new Font("Circular", 20, FontStyle.Bold);
        private IEnumerable _xValues = null;
        private int _seriesCount = 0;

        public ColumnChart(IEnumerable xValues) : this(xValues, 1, 1, 80) {
        }

        public ColumnChart(IEnumerable xValues, int numberOfAreas) : this(xValues, numberOfAreas, 1, 80) {
        }

        public ColumnChart(IEnumerable xValues, int numberOfAreas, int heightPropotion, int chartHeight) {

            _xValues = xValues;

            _chart = new Chart() {
                Size = new Size(640, 580 * heightPropotion),
                AntiAliasing = AntiAliasingStyles.All
            };
            _chart.Legends.Add(new Legend("Default"));
            _chart.Legends["Default"].LegendStyle = LegendStyle.Row;
            _chart.Legends["Default"].Docking = Docking.Top;
            _chart.Legends["Default"].Alignment = StringAlignment.Near;
            _chart.Legends["Default"].Enabled = true;
            _chart.Legends["Default"].Font = new Font("Circular", 18, FontStyle.Bold);

            float areaWidth = 100f / numberOfAreas;
            float xRunner = 0;

            for (int i = 0; i < numberOfAreas;i++ ) {
                var chartArea = new ChartArea("" + i) {
                    BackColor = Color.White,
                    BorderWidth = 0,
                    BorderDashStyle = ChartDashStyle.NotSet
                };

                chartArea.AxisY.LineWidth = 0;
                chartArea.AxisX.MajorGrid.Enabled = false;
                chartArea.AxisY.MajorTickMark.Enabled = false;
                chartArea.AxisY.MajorGrid.LineColor = Color.LightGray;
                chartArea.AxisY.LabelStyle.Format = "N0";
                chartArea.Position.Auto = false;
                chartArea.Position.X = xRunner;
                chartArea.Position.Y = 15;
                chartArea.Position.Width = areaWidth;
                chartArea.Position.Height = chartHeight;
                _chart.ChartAreas.Add(chartArea);

                chartArea.AxisX.LabelStyle.Font = _axisFont;
                chartArea.AxisY.LabelStyle.Font = _axisFont;

                xRunner += areaWidth;
            }

        }

        public void AddSeries(string name, IEnumerable yValues) {
            AddSeries(name, SeriesChartType.Column, yValues);
        }

        public void AddSeries(string name, SeriesChartType chartType, IEnumerable yValues) {
            this.AddSeries(name, "0", chartType, yValues);
        }

        public void AddSeries(string name, string chartArea, SeriesChartType chartType, IEnumerable yValues) {
            this.AddSeries(name, "0", chartType, _xValues, yValues);
        }

        public void AddSeries(string name, string chartArea, SeriesChartType chartType, IEnumerable xValues, IEnumerable yValues) {
            var seriesColumns = new Series(name);
            seriesColumns.ChartArea = chartArea;
            seriesColumns.IsValueShownAsLabel = true;
            seriesColumns.ChartType = chartType;
            seriesColumns.Font = _axisFont;
            seriesColumns.Color = ColorPalette.GetColor(_seriesCount);
            seriesColumns.LabelFormat = "N0";
            seriesColumns.SmartLabelStyle.AllowOutsidePlotArea = LabelOutsidePlotAreaStyle.Yes;
            _chart.Series.Add(seriesColumns);
            _chart.Series[name].Points.DataBindXY(xValues, yValues);
            _seriesCount++;
        }

        public Chart GetChart() {
            return _chart;
        }

        public Series GetSeries(string name) {
            return _chart.Series[name];
        }

        public Series GetSeries(int index) {
            return _chart.Series[index];
        }

        public ChartArea GetChartArea() {
            return _chart.ChartAreas[0];
        }

        public ChartArea GetChartArea(string name) {
            return _chart.ChartAreas[name];
        }

        public Legend GetLegendBox() {
            return _chart.Legends[0];
        }

        public Axis GetXAxis() {
            return _chart.ChartAreas["0"].AxisX;
        }

        public Axis GetYAxis() {
            return _chart.ChartAreas["0"].AxisY;
        }

        public byte[] Render() {
            MemoryStream memStream = new MemoryStream();
            _chart.SaveImage(memStream, ChartImageFormat.Png);
            byte[] dataArray = memStream.ToArray();
            return dataArray;
        }

        public void SetAxisFont(Font font) {
            this._axisFont = font;
            foreach (ChartArea area in _chart.ChartAreas) {
                area.AxisX.LabelStyle.Font = _axisFont;
                area.AxisY.LabelStyle.Font = _axisFont;
            }
        }

        public void SetLastUpdated(DateTime date) {
            string text = "Updated: " + date.ToString("d MMM yy", th);
            AddLeftAnnotation(text, 0, 93);
        }

        public void SetSummary(string text) {
            AddRightAnnotation(text, 93, Color.Black);
        }

        public void SetSummary(string text, Color color) {
            AddRightAnnotation(text, 93, color);
        }

        public void AddLeftAnnotation(string text, double x, double y) {
            TextAnnotation annotation = new TextAnnotation();
            annotation.Text = text;
            annotation.ForeColor = Color.Black;
            annotation.Font = _axisFont;
            annotation.X = x;
            annotation.Y = y;
            annotation.ClipToChartArea = "";
            _chart.Annotations.Add(annotation);
        }

        public void AddRightAnnotation(string text, double y) {
            AddRightAnnotation(text, y, Color.Black);
        }

        public void AddRightAnnotation(string text, double y, Color color) {
            TextAnnotation annotation = new TextAnnotation();
            annotation.Text = text;
            annotation.ForeColor = Color.Black;
            annotation.Font = _axisFont;
            annotation.X = 0;
            annotation.Y = y;
            annotation.Width = 100;
            annotation.Alignment = ContentAlignment.BottomRight;
            annotation.ClipToChartArea = "";
            annotation.ForeColor = color;
            _chart.Annotations.Add(annotation);
        }

    }
}