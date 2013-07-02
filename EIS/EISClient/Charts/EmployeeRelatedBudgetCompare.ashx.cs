using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EISClient.Model;
using System.Windows.Forms.DataVisualization.Charting;
using System.Drawing;

namespace EISClient.Charts {
    /// <summary>
    /// Summary description for EmployeeRelatedBudgetCompare
    /// </summary>
    public class EmployeeRelatedBudgetCompare : IHttpHandler {

        public void ProcessRequest(HttpContext context) {
            string yearString = context.Request["year"];
            int year = -1;
            if (yearString != null && int.TryParse(yearString, out year)) {

                int firstYear = year - 4;
                DateTime lastUpdated = DateTime.MinValue;
                List<string> yearList = new List<string>();
                for (int y = year; y >= firstYear; y--) {
                    yearList.Add(y.ToString());
                }

                eisEntities ctx = new eisEntities();
                var types = from type in ctx.employeerelatedbudgettypes
                            select type.TypeName;
                var typeList = types.ToList();

                ColumnChart chart = new ColumnChart(yearList.ToArray(), 1, 2, 80);
                foreach (var type in typeList) {
                    var usages = from usage in ctx.employeerelatedbudgetusages
                                 where usage.Year >= firstYear && usage.Year <= year
                                 orderby usage.Year descending
                                 select usage;
                    var usageList = usages.ToList();

                    var filteredUsages = from usage in usageList
                                            where usage.employeerelatedbudgettype.TypeName == type
                                            select usage;
                    var filteredUsageList = filteredUsages.ToList();

                    List<decimal> yValues = new List<decimal>();
                    foreach (var usage in filteredUsageList) {
                        yValues.Add(usage.Amount);
                        if (usage.LastUpdated > lastUpdated) {
                            lastUpdated = usage.LastUpdated;
                        }
                    }
                    chart.AddSeries(type, yValues.ToArray());
                    chart.GetSeries(type).ChartType = SeriesChartType.Bar;
                }
                chart.SetLastUpdated(lastUpdated);
                chart.AddLeftAnnotation("เงิน - ล้านบาท)", 4, 13);

                Legend legend = chart.GetLegendBox();
                legend.Position.Auto = false;
                legend.Position.X = 0;
                legend.Position.Y = 5;
                legend.Position.Width = 100;
                legend.Position.Height = 10;
                legend.Font = new Font("Circular", 18, FontStyle.Regular);
                
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