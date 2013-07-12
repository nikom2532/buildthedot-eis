using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EISClient.Model;

namespace EISClient.Charts {
    /// <summary>
    /// Summary description for BankLoanApproval
    /// </summary>
    public class BankLoanApproval : IHttpHandler {

        public void ProcessRequest(HttpContext context) {
            string yearString = context.Request["year"];
            int year = -1;
            if (yearString != null && int.TryParse(yearString, out year)) {

                eisEntities ctx = new eisEntities();
                var providings = from type in ctx.bankloanapprovals
                                 where type.Year == year
                                 select type;
                var providingList = providings.ToList();

                List<string> xValues = new List<string>();
                List<decimal> yValues = new List<decimal>();

                DateTime lastUpdated = DateTime.MinValue;
                decimal sum = 0;
                foreach (var providing in providingList) {
                    xValues.Add(providing.banktype.BankName);
                    yValues.Add(providing.Amount);
                    sum += providing.Amount;
                    if (providing.LastUpdated > lastUpdated) {
                        lastUpdated = providing.LastUpdated;
                    }
                }

                ColumnChart chart = new ColumnChart(xValues.ToArray());
                chart.AddSeries("จำนวนเงิน (ล้านบาท)", yValues.ToArray());
                chart.GetChartArea().Area3DStyle.Enable3D = true;
                chart.GetChartArea().Area3DStyle.PointDepth = 30;
                chart.GetChartArea().Area3DStyle.IsRightAngleAxes = true;
                chart.GetChartArea().Area3DStyle.Rotation = 20;
                chart.GetChartArea().Area3DStyle.Inclination = 20;
                chart.GetSeries("จำนวนเงิน (ล้านบาท)")["DrawingStyle"] = "Cylinder";

                chart.SetLastUpdated(lastUpdated);
                chart.SetSummary("รวม " + sum.ToString("#,##0") + " ล้านบาท");

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