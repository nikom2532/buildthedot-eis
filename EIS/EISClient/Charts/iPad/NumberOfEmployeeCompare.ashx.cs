using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EISClient.Model;
using System.Drawing;
using System.Windows.Forms.DataVisualization.Charting;

namespace EISClient.Charts {
    /// <summary>
    /// Summary description for NumberOfEmployeeCompare
    /// </summary>
    public class NumberOfEmployeeCompare : IHttpHandler {

        public void ProcessRequest(HttpContext context) {
            string yearString = context.Request["year"];
            int year = -1;
            if (yearString != null && int.TryParse(yearString, out year)) {

                int firstYear = year - 4;

                eisEntities ctx = new eisEntities();
                var types = from type in ctx.numberofemployees
                            where type.Year >= firstYear && type.Year <= year
                            select type;

                var empTypes = from empType in ctx.employeetypes
                               select empType.TypeName;

                List<string> xVal = new List<string>();
                for (int i = firstYear; i <= year; i++) {
                    int actualYear = ((i - 2500) % 100);
                    xVal.Add(actualYear.ToString());
                }

                Dictionary<string, decimal> dataTable1 = new Dictionary<string, decimal>();
                Dictionary<string, decimal> dataTable2 = new Dictionary<string, decimal>();
                Dictionary<string, decimal> dataTable3 = new Dictionary<string, decimal>();
                DateTime lastUpdated = DateTime.MinValue;
                decimal maximumValue = 0;
                foreach (var type in types) {
                    string shortYear = ((type.Year - 2500) % 100).ToString();
                    if (!dataTable1.ContainsKey(shortYear)) {
                        dataTable1[shortYear] = 0;
                        dataTable2[shortYear] = 0;
                        dataTable3[shortYear] = 0;
                    }
                    dataTable1[shortYear] += type.GovernmentOfficer;
                    dataTable2[shortYear] += type.PermanentContractor;
                    dataTable3[shortYear] += type.GeneralOfficer;
                    if (type.LastUpdated > lastUpdated) {
                        lastUpdated = type.LastUpdated;
                    }
                    maximumValue = Math.Max(maximumValue, dataTable1[shortYear]);
                    maximumValue = Math.Max(maximumValue, dataTable2[shortYear]);
                    maximumValue = Math.Max(maximumValue, dataTable3[shortYear]);
                }

                //Series1
                List<string> s1x = new List<string>();
                List<decimal> s1y = new List<decimal>();
                for (int i = 0; i < 5; i++) {
                    s1x.Add(xVal[i]);
                    s1y.Add(dataTable1[xVal[i]]);
                }

                //Series2
                List<string> s2x = new List<string>();
                List<decimal> s2y = new List<decimal>();
                for (int i = 0; i < 5; i++) {
                    s2x.Add(xVal[i]);
                    s2y.Add(dataTable2[xVal[i]]);
                }

                //Series3
                List<string> s3x = new List<string>();
                List<decimal> s3y = new List<decimal>();
                for (int i = 0; i < 5; i++) {
                    s3x.Add(xVal[i]);
                    s3y.Add(dataTable3[xVal[i]]);
                }

                ColumnChart chart = new ColumnChart(xVal, 3, 1, 75);
                chart.SetLastUpdated(lastUpdated);
                chart.SetSummary("*ไม่มีข้อมูลพนักงานราชการ", Color.Red);
                chart.AddLeftAnnotation("จำนวนคน  ", 82, 15);
                chart.SetAxisFont(new Font("Circular", 16, FontStyle.Bold));

                chart.AddSeries("0", "0", SeriesChartType.Column, s1x.ToArray(), s1y.ToArray());
                chart.AddSeries("1", "1", SeriesChartType.Column, s2x.ToArray(), s2y.ToArray());
                chart.AddSeries("2", "2", SeriesChartType.Column, s3x.ToArray(), s3y.ToArray());

                chart.GetSeries("0").Color = ColorPalette.GetColor(0);
                chart.GetSeries("1").Color = ColorPalette.GetColor(0);
                chart.GetSeries("2").Color = ColorPalette.GetColor(0);
                chart.GetSeries("0").Points[4].Color = ColorPalette.GetColor(1);
                chart.GetSeries("1").Points[4].Color = ColorPalette.GetColor(1);
                chart.GetSeries("2").Points[4].Color = ColorPalette.GetColor(1);

                for (int i = 0; i < 3; i++) {
                    chart.GetSeries("" + i).SmartLabelStyle.Enabled = false;
                    chart.GetSeries("" + i).LabelAngle = -90;
                    chart.GetSeries("" + i).SmartLabelStyle.MaxMovingDistance = 100;
                    chart.GetSeries("" + i).SmartLabelStyle.MovingDirection = LabelAlignmentStyles.Top;
                    chart.GetSeries("" + i).SetCustomProperty("RenderType", "Cylinder");
                }

                chart.GetChartArea("0").AxisY.LabelStyle.Enabled = false;
                chart.GetChartArea("0").AxisY.MajorTickMark.Enabled = false;
                chart.GetChartArea("1").AxisY.LabelStyle.Enabled = false;
                chart.GetChartArea("1").AxisY.MajorTickMark.Enabled = false;
                chart.GetChartArea("2").AxisY.LabelStyle.Enabled = false;
                chart.GetChartArea("2").AxisY.MajorTickMark.Enabled = false;

                chart.GetChartArea("0").AxisY.Maximum = (double)maximumValue;
                chart.GetChartArea("1").AxisY.Maximum = (double)maximumValue;
                chart.GetChartArea("2").AxisY.Maximum = (double)maximumValue;

                chart.GetChartArea("0").AxisX.CustomLabels.Add(0, 6, "ข้าราชการ", 1, LabelMarkStyle.LineSideMark);
                chart.GetChartArea("1").AxisX.CustomLabels.Add(0, 6, "ลูกจ้างประจำ", 1, LabelMarkStyle.LineSideMark);
                chart.GetChartArea("2").AxisX.CustomLabels.Add(0, 6, "พนักงานราชการ", 1, LabelMarkStyle.LineSideMark);

                chart.GetLegendBox().Enabled = false;

                byte[] dataArray = chart.Render();

                context.Response.ContentType = "image/png";
                context.Response.OutputStream.Write(dataArray, 0, dataArray.Length);
            } else {
                context.Response.ContentType = "text/plain";
                context.Response.Write("Error: Year was not specified");
            }
        }

        public bool IsReusable {
            get {
                return false;
            }
        }
    }
}