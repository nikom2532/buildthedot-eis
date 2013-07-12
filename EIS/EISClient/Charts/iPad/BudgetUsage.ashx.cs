using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EISClient.Model;
using System.Windows.Forms.DataVisualization.Charting;

namespace EISClient.Charts {
    /// <summary>
    /// Summary description for BudgetUsage
    /// </summary>
    public class BudgetUsage : IHttpHandler {

        public void ProcessRequest(HttpContext context) {
            string yearString = context.Request["year"];
            int year = -1;
            if (yearString != null && int.TryParse(yearString, out year)) {

                eisEntities ctx = new eisEntities();
                var usages = from type in ctx.budgetusages
                            where type.Year == year
                            select type;
                var usageList = usages.ToList();

                List<string> xValues = new List<string>();
                List<decimal> yValues = new List<decimal>();
                List<decimal> yValues2 = new List<decimal>();

                DateTime lastUpdated = DateTime.MinValue;
                foreach (var usage in usageList) {
                    xValues.Add(usage.budgettype1.TypeName);
                    yValues.Add(usage.BudgetAmount - usage.Used);
                    yValues2.Add(usage.Used);
                    if (usage.LastUpdated > lastUpdated) {
                        lastUpdated = usage.LastUpdated;
                    }
                }
                ColumnChart chart = new ColumnChart(xValues.ToArray());
                chart.SetLastUpdated(lastUpdated);
                chart.AddSeries("งบประมาณ (ลบ.)", yValues.ToArray());
                chart.AddSeries("เบิกจ่าย (ลบ.)", yValues2.ToArray());

                chart.GetChartArea().Area3DStyle.Enable3D = true;
                chart.GetChartArea().Area3DStyle.PointDepth = 30;
                chart.GetChartArea().Area3DStyle.IsRightAngleAxes = true;
                chart.GetChartArea().Area3DStyle.Rotation = 20;
                chart.GetChartArea().Area3DStyle.Inclination = 20;

                chart.GetSeries("งบประมาณ (ลบ.)").ChartType = SeriesChartType.StackedColumn;
                chart.GetSeries("เบิกจ่าย (ลบ.)").ChartType = SeriesChartType.StackedColumn;
                chart.GetSeries("งบประมาณ (ลบ.)")["DrawingStyle"] = "Cylinder";
                chart.GetSeries("เบิกจ่าย (ลบ.)")["DrawingStyle"] = "Cylinder";
                chart.GetSeries("งบประมาณ (ลบ.)").Color = ColorPalette.GetColor(0);
                chart.GetSeries("เบิกจ่าย (ลบ.)").Color = ColorPalette.GetColor(1);

                Series series = chart.GetSeries("เบิกจ่าย (ลบ.)");
                int runner = 0;
                foreach (var usage in usageList) {
                    decimal percent = (usage.Used / usage.BudgetAmount) * 100m;
                    series.Points[runner].Label = "#VALY{N0}\n(" + percent.ToString("N2") + "%)";                    
                    runner++;
                }

                series = chart.GetSeries("งบประมาณ (ลบ.)");
                runner = 0;
                foreach (var usage in usageList) {
                    series.Points[runner].Label = usage.BudgetAmount.ToString("N0");
                    runner++;
                }

                byte[] dataArray = chart.Render();

                string filename = "image.png";
                context.Response.ContentType = "image/png";
                context.Response.AddHeader("Content-Disposition", "attachment; filename=\"" + filename + "\"");
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