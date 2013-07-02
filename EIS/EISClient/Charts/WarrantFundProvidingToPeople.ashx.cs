using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EISClient.Model;
using System.Windows.Forms.DataVisualization.Charting;

namespace EISClient.Charts {
    /// <summary>
    /// Summary description for WarrantFundProvidingToPeople
    /// </summary>
    public class WarrantFundProvidingToPeople : IHttpHandler {

        public void ProcessRequest(HttpContext context) {
            string yearString = context.Request["year"];
            int year = -1;
            if (yearString != null && int.TryParse(yearString, out year)) {

                eisEntities ctx = new eisEntities();
                var providings = from type in ctx.warrantfundprovidings
                                 where type.Year == year
                                 select type;
                var providingList = providings.ToList();

                List<string> xValues = new List<string>();
                List<decimal> yValues = new List<decimal>();

                DateTime lastUpdated = DateTime.MinValue;
                decimal sum = 0;
                foreach (var providing in providingList) {
                    xValues.Add(providing.warrantfundprovider.ProviderName);
                    yValues.Add(providing.NumberOfPeople);
                    sum += providing.NumberOfPeople;
                    if (providing.LastUpdated > lastUpdated) {
                        lastUpdated = providing.LastUpdated;
                    }
                }
                ColumnChart chart = new ColumnChart(xValues.ToArray());
                chart.SetLastUpdated(lastUpdated);
                chart.SetSummary("รวม "+sum.ToString("#,##0")+" คน");
                chart.AddSeries("จำนวน (คน)", yValues.ToArray());
                chart.GetChartArea().Area3DStyle.Enable3D = true;
                chart.GetChartArea().Area3DStyle.PointDepth = 30;
                chart.GetChartArea().Area3DStyle.IsRightAngleAxes = true;
                chart.GetChartArea().Area3DStyle.Rotation = 20;
                chart.GetChartArea().Area3DStyle.Inclination = 20;
                chart.GetSeries("จำนวน (คน)")["DrawingStyle"] = "Cylinder";

                Series series = chart.GetSeries("จำนวน (คน)");
                series.Color = ColorPalette.GetColor(1);

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