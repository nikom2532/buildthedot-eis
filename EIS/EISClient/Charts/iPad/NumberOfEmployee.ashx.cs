using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EISClient.Model;
using System.Drawing;

namespace EISClient.Charts {
    /// <summary>
    /// Summary description for NumberOfEmployee1
    /// </summary>
    public class NumberOfEmployee : IHttpHandler {

        public void ProcessRequest(HttpContext context) {

            string yearString = context.Request["year"];
            int year = -1;
            if (yearString != null && int.TryParse(yearString, out year)) {

                eisEntities ctx = new eisEntities();
                var types = from type in ctx.numberofemployees
                            where type.Year == year
                            select type;
                int sum1 = 0;
                int sum2 = 0;
                int sum3 = 0;
                DateTime lastUpdated = DateTime.MinValue;
                foreach (var type in types) {
                    sum1 += type.GovernmentOfficer;
                    sum2 += type.PermanentContractor;
                    sum3 += type.GeneralOfficer;
                    if (type.LastUpdated > lastUpdated) {
                        lastUpdated = type.LastUpdated;
                    }
                }

                string[] xVal = { "ข้าราชการ", "ลูกจ้างประจำ", "พนักงานราชการ" };
                double[] yVal = { sum1, sum2, sum3 };
                ColumnChart chart = new ColumnChart(xVal);
                chart.AddSeries("จำนวนอัตรา", yVal);
                chart.GetChartArea().Area3DStyle.Enable3D = true;
                chart.GetChartArea().Area3DStyle.PointDepth = 30;
                chart.GetChartArea().Area3DStyle.IsRightAngleAxes = true;
                chart.GetChartArea().Area3DStyle.Rotation = 20;
                chart.GetChartArea().Area3DStyle.Inclination = 20;
                chart.GetSeries("จำนวนอัตรา")["DrawingStyle"] = "Cylinder";

                chart.SetLastUpdated(lastUpdated);
                chart.SetSummary("*ไม่มีข้อมูลพนักงานราชการ", Color.Red);

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