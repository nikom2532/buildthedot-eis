using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EISClient.Model;
using System.Windows.Forms.DataVisualization.Charting;

namespace EISClient.Charts {
    /// <summary>
    /// Summary description for EmployeeRelatedBudget
    /// </summary>
    public class EmployeeRelatedBudget : IHttpHandler {

        public void ProcessRequest(HttpContext context) {
            string yearString = context.Request["year"];
            int year = -1;
            if (yearString != null && int.TryParse(yearString, out year)) {

                eisEntities ctx = new eisEntities();
                var usages = from type in ctx.employeerelatedbudgetusages
                             where type.Year == year
                             select type;
                var usageList = usages.ToList();

                List<string> xValues = new List<string>();
                List<decimal> yValues = new List<decimal>();

                DateTime lastUpdated = DateTime.MinValue;
                decimal sum = 0;
                foreach (var usage in usageList) {
                    xValues.Add(usage.employeerelatedbudgettype.TypeName);
                    yValues.Add(usage.Amount);
                    sum += usage.Amount;
                    if (usage.LastUpdated > lastUpdated) {
                        lastUpdated = usage.LastUpdated;
                    }
                }
                PieChart chart = new PieChart(xValues.ToArray());
                chart.SetLastUpdated(lastUpdated);
                chart.SetSummary("รวม "+sum.ToString("#,##0")+" ล้านบาท");
                chart.AddSeries("เบิกจ่าย (ล้านบาท)", yValues.ToArray());

                Series series = chart.GetSeries("เบิกจ่าย (ล้านบาท)");
                series.Label = "#VALY{N0}";

                Legend legend = chart.GetLegendBox();
                legend.Position.Auto = false;
                legend.Position.X = 0;
                legend.Position.Y = 10;
                legend.Position.Width = 100;
                legend.Position.Height = 20;

                // Add Color column
                LegendCellColumn firstColumn = new LegendCellColumn();
                firstColumn.ColumnType = LegendCellColumnType.SeriesSymbol;
                firstColumn.HeaderText = "";
                legend.CellColumns.Add(firstColumn);

                // Add Legend Text column
                LegendCellColumn secondColumn = new LegendCellColumn();
                secondColumn.ColumnType = LegendCellColumnType.Text;
                secondColumn.HeaderText = "";
                secondColumn.Text = "#VALX (ลบ.)";
                legend.CellColumns.Add(secondColumn);

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