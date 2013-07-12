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

    public class PieChart {

        private static CultureInfo th = new CultureInfo("th");

        private Chart _chart = null;
        private Font _axisFont = new Font("Circular", 20, FontStyle.Bold);
        private IEnumerable _xValues = null;
        private int _seriesCount = 0;

        public PieChart(IEnumerable xValues) {

            _xValues = xValues;

            _chart = new Chart() {
                Size = new Size(640, 580),
                AntiAliasing = AntiAliasingStyles.All,
            };
            _chart.Palette = ChartColorPalette.None;
            _chart.PaletteCustomColors = ColorPalette.GetPalette();
            _chart.Legends.Add(new Legend("Default"));
            _chart.Legends["Default"].MaximumAutoSize = 30;
            _chart.Legends["Default"].Docking = Docking.Top;
            _chart.Legends["Default"].Alignment = StringAlignment.Near;
            _chart.Legends["Default"].Enabled = true;
            _chart.Legends["Default"].Font = new Font("Circular", 20, FontStyle.Bold);

            var chartArea = new ChartArea("main") {
                BackColor = Color.White,
                BorderWidth = 1,
                BorderDashStyle = ChartDashStyle.NotSet
            };

            chartArea.AxisY.LineWidth = 0;
            chartArea.AxisX.MajorGrid.Enabled = false;
            chartArea.AxisY.MajorTickMark.Enabled = false;
            chartArea.AxisY.MajorGrid.LineColor = Color.LightGray;
            chartArea.AxisY.LabelStyle.Format = "N0";
            chartArea.Position.Auto = false;
            chartArea.Position.X = 0;
            chartArea.Position.Y = 20;
            chartArea.Position.Width = 100;
            chartArea.Position.Height = 80;
            _chart.ChartAreas.Add(chartArea);

            var axisFont = new Font("Circular", 15, FontStyle.Regular);
            chartArea.AxisX.LabelStyle.Font = axisFont;
            chartArea.AxisY.LabelStyle.Font = axisFont;

        }

        public void AddSeries(string name, IEnumerable yValues) {
            var seriesColumns = new Series(name);
            seriesColumns.IsValueShownAsLabel = true;
            seriesColumns.ChartType = SeriesChartType.Pie;
            seriesColumns.Font = _axisFont;
            seriesColumns.Color = ColorPalette.GetColor(_seriesCount);
            seriesColumns.LabelFormat = "N0";
            seriesColumns.SmartLabelStyle.Enabled = true;
            seriesColumns.SmartLabelStyle.AllowOutsidePlotArea = LabelOutsidePlotAreaStyle.Partial;
            seriesColumns.BorderWidth = 1;
            seriesColumns.BorderColor = Color.Black;
            seriesColumns["PieLabelStyle"] = "Outside";
            _chart.Series.Add(seriesColumns);
            _chart.Series[name].Points.DataBindXY(_xValues, yValues);
            _seriesCount++;
        }

        public Series GetSeries(string name) {
            return _chart.Series[name];
        }

        public Legend GetLegendBox() {
            return _chart.Legends[0];
        }

        public byte[] Render() {
            MemoryStream memStream = new MemoryStream();
            _chart.SaveImage(memStream, ChartImageFormat.Png);
            byte[] dataArray = memStream.ToArray();
            return dataArray;
        }

        public void SetLastUpdated(DateTime date) {
            TextAnnotation annotation = new TextAnnotation();
            annotation.Text = "Updated: " + date.ToString("d MMM yy", th);
            annotation.ForeColor = Color.Black;
            annotation.Font = _axisFont;
            annotation.X = 0;
            annotation.Y = 93;
            annotation.ClipToChartArea = "";
            _chart.Annotations.Add(annotation);
        }

        public void SetSummary(string text) {
            TextAnnotation annotation = new TextAnnotation();
            annotation.Text = text;
            annotation.ForeColor = Color.Black;
            annotation.Font = _axisFont;
            annotation.X = 0;
            annotation.Y = 93;
            annotation.Width = 100;
            annotation.Alignment = ContentAlignment.BottomRight;
            annotation.ClipToChartArea = "";
            _chart.Annotations.Add(annotation);
        }
    }
}