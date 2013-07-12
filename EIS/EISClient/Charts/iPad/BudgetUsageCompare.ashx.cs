using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EISClient.Model;
using System.Windows.Forms.DataVisualization.Charting;
using System.Drawing;

namespace EISClient.Charts {
    /// <summary>
    /// Summary description for BudgetUsageCompare
    /// </summary>
    public class BudgetUsageCompare : IHttpHandler {

        public void ProcessRequest(HttpContext context) {
            string yearString = context.Request["year"];
            int year = -1;
            if (yearString != null && int.TryParse(yearString, out year)) {

                int firstYear = year - 4;
                List<string> xVal = new List<string>();
                for (int i = firstYear; i <= year; i++) {
                    int actualYear = ((i - 2500) % 100);
                    xVal.Add(actualYear.ToString());
                }

                eisEntities ctx = new eisEntities();
                var usages = from type in ctx.budgetusages
                             where type.Year >= firstYear && type.Year <= year
                             select type;
                var usageList = usages.ToList();

                var usageTypes = from type in ctx.budgettypes
                                 select type.TypeName;

                Dictionary<string, Dictionary<string, decimal>> dataTable = new Dictionary<string, Dictionary<string, decimal>>();
                Dictionary<string, Dictionary<string, decimal>> dataTable2 = new Dictionary<string, Dictionary<string, decimal>>();
                DateTime lastUpdated = DateTime.MinValue;
                decimal maximumValue = 0;
                foreach (var usage in usageList) {
                    string typeName = usage.budgettype1.TypeName;
                    string shortYear = ((usage.Year - 2500) % 100).ToString();
                    if (!dataTable.ContainsKey(typeName)) {
                        dataTable[typeName] = new Dictionary<string, decimal>();
                        dataTable2[typeName] = new Dictionary<string,decimal>();
                    }
                    dataTable[typeName][shortYear] = usage.Used;
                    dataTable2[typeName][shortYear] = usage.BudgetAmount - usage.Used;
                    maximumValue = Math.Max(maximumValue, usage.BudgetAmount);
                    if (usage.LastUpdated > lastUpdated) {
                        lastUpdated = usage.LastUpdated;
                    }
                }

                ColumnChart chart = new ColumnChart(xVal.ToArray(), usageTypes.Count());
                chart.SetLastUpdated(lastUpdated);
                chart.SetAxisFont(new Font("Circular", 16, FontStyle.Bold));
                //chart.GetLegendBox().Enabled = false;

                int runner = 0;
                foreach (var type in usageTypes) {
                    List<decimal> s1y = new List<decimal>();
                    List<decimal> s2y = new List<decimal>();
                    Dictionary<string, decimal> dataList = dataTable[type];
                    Dictionary<string, decimal> dataList2 = dataTable2[type];
                    foreach (string x in xVal) {
                        s1y.Add(dataList[x]);
                        s2y.Add(dataList2[x]);
                    }
                    chart.AddSeries(type + "1", "" + runner, SeriesChartType.StackedColumn, xVal.ToArray(), s1y.ToArray());
                    chart.AddSeries(type + "2", "" + runner, SeriesChartType.StackedColumn, xVal.ToArray(), s2y.ToArray());

                    chart.GetSeries(type + "1").IsValueShownAsLabel = false;
                    chart.GetSeries(type + "2").IsValueShownAsLabel = false;
                    chart.GetSeries(type + "1").IsVisibleInLegend = false;
                    chart.GetSeries(type + "2").IsVisibleInLegend = false;
                    chart.GetSeries(type + "1").Color = ColorPalette.GetColor(1);
                    chart.GetSeries(type + "2").Color = ColorPalette.GetColor(0);

                    chart.GetChartArea("" + runner).AxisY.Maximum = (double)maximumValue;
                    chart.GetChartArea("" + runner).AxisY.MajorTickMark.Enabled = false;
                    chart.GetChartArea("" + runner).AxisY.LabelStyle.Enabled = true;

                    chart.GetChartArea("" + runner).AxisX.CustomLabels.Add(0, 6, type, 1, LabelMarkStyle.LineSideMark);

                    runner++;
                }

                LegendItem customLegend1 = new LegendItem();
                customLegend1.Name = "งบประมาณ (ลบ.)";
                customLegend1.Color = ColorPalette.GetColor(0);
                customLegend1.MarkerStyle = MarkerStyle.Square;
                chart.GetLegendBox().CustomItems.Add(customLegend1);

                LegendItem customLegend2 = new LegendItem();
                customLegend2.Name = "เบิกจ่าย (ลบ.)";
                customLegend2.Color = ColorPalette.GetColor(1);
                customLegend2.MarkerStyle = MarkerStyle.Square;
                chart.GetLegendBox().CustomItems.Add(customLegend2);

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