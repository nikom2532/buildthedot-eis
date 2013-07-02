using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EISClient.Model;

namespace EISClient.Charts {
    /// <summary>
    /// Summary description for FirstCarStatusByPeople
    /// </summary>
    public class FirstCarStatusByPeople : IHttpHandler {

        public void ProcessRequest(HttpContext context) {
            string yearString = context.Request["year"];
            int year = -1;
            if (yearString != null && int.TryParse(yearString, out year)) {

                eisEntities ctx = new eisEntities();
                var statuses = from type in ctx.firstcarstatus
                               where type.Year == year
                               select type;
                var statusList = statuses.ToList();

                List<string> xValues = new List<string>();
                List<decimal> yValues = new List<decimal>();

                DateTime lastUpdated = DateTime.MinValue;
                foreach (var status in statusList) {
                    xValues.Add(status.firstcarstatustype.StatusName + " (คน)");
                    yValues.Add(status.NumberOfPeople);
                    if (status.LastUpdated > lastUpdated) {
                        lastUpdated = status.LastUpdated;
                    }
                }
                PieChart chart = new PieChart(xValues.ToArray());
                chart.SetLastUpdated(lastUpdated);
                chart.AddSeries("จำนวนคน", yValues.ToArray());

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