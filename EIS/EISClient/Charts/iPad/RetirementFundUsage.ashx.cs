using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EISClient.Model;
using System.Windows.Forms.DataVisualization.Charting;

namespace EISClient.Charts {
    /// <summary>
    /// Summary description for RetirementFundUsage
    /// </summary>
    public class RetirementFundUsage : IHttpHandler {

        public void ProcessRequest(HttpContext context) {
            string yearString = context.Request["year"];
            int year = -1;
            if (yearString != null && int.TryParse(yearString, out year)) {

                eisEntities ctx = new eisEntities();
                var usages = from type in ctx.retirementfundusages
                             where type.Year == year
                             select type;
                var usageList = usages.ToList();

                List<string> xValues = new List<string>();
                List<decimal> yValues = new List<decimal>();

                DateTime lastUpdated = DateTime.MinValue;
                foreach (var usage in usageList) {
                    xValues.Add(usage.retirementfundtype.TypeName);
                    yValues.Add(usage.NumberOfUsage);
                    if (usage.LastUpdated > lastUpdated) {
                        lastUpdated = usage.LastUpdated;
                    }
                }
                ColumnChart chart = new ColumnChart(xValues.ToArray());
                chart.SetLastUpdated(lastUpdated);
                chart.AddSeries("หน่วย (ล้านบาท) (คน)", SeriesChartType.Bar, yValues.ToArray());

                Series series = chart.GetSeries("หน่วย (ล้านบาท) (คน)");
                int runner = 0;
                foreach (var usage in usageList) {
                    series.Points[runner].Label = "(#VALY{N0}) ("+usage.NumberOfPeople.ToString("N0")+")";
                    runner++;
                }

                Axis xAxis = chart.GetXAxis();
                xAxis.Interval = 1;

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