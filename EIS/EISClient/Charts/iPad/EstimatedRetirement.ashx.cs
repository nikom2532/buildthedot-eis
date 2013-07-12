
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EISClient.Model;

namespace EISClient.Charts {
    /// <summary>
    /// Summary description for EstimatedRetirement
    /// </summary>
    public class EstimatedRetirement : IHttpHandler {

        public void ProcessRequest(HttpContext context) {
            string yearString = context.Request["year"];
            int year = -1;
            if (yearString != null && int.TryParse(yearString, out year)) {

                eisEntities ctx = new eisEntities();
                var types = from type in ctx.estimatedretirements
                            where type.Year == year
                            select type;
                var typeList = types.ToList();

                List<string> yValues = new List<string>();
                List<int> xValues = new List<int>();

                DateTime lastUpdated = DateTime.MinValue;
                foreach (var type in typeList) {
                    yValues.Add(type.retirementtype.TypeName);
                    xValues.Add(type.EstimatedValue);
                    if (type.LastUpdated > lastUpdated) {
                        lastUpdated = type.LastUpdated;
                    }
                }
                ColumnChart chart = new ColumnChart(yValues.ToArray());
                chart.SetLastUpdated(lastUpdated);
                chart.AddSeries("จำนวนคน", xValues.ToArray());
                chart.GetChartArea().Area3DStyle.Enable3D = true;
                chart.GetChartArea().Area3DStyle.PointDepth = 30;
                chart.GetChartArea().Area3DStyle.IsRightAngleAxes = true;
                chart.GetChartArea().Area3DStyle.Rotation = 20;
                chart.GetChartArea().Area3DStyle.Inclination = 20;
                chart.GetSeries("จำนวนคน")["DrawingStyle"] = "Cylinder";

                DateTime now = DateTime.Now;
                DateTime yearCutOff = new DateTime(now.Year, 9, 30, 23, 59, 59);
                int currentYear = now.Year;
                if (now > yearCutOff) {
                    currentYear += 1;
                }
                if (currentYear < 2500) {
                    currentYear += 543;
                }
                chart.AddLeftAnnotation("(1 ตุลาคม "+currentYear+")", 67, 10);

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
                return true;
            }
        }
    }
}