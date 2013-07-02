using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EISClient.Model;
using System.Windows.Forms.DataVisualization.Charting;
using System.Drawing;

namespace EISClient.Charts {
    /// <summary>
    /// Summary description for NumberOfEmployeeDetail
    /// </summary>
    public class NumberOfEmployeeDetail : IHttpHandler {

        public void ProcessRequest(HttpContext context) {

            string yearString = context.Request["year"];
            int year = -1;
            if (yearString != null && int.TryParse(yearString, out year)) {

                int firstYear = year - 4;

                eisEntities ctx = new eisEntities();
                var types = from type in ctx.numberofemployees
                            where type.Year == year
                            select type;

                var empTypes = from empType in ctx.employeetypes
                               select empType.TypeName;

                string[] xVals = empTypes.ToArray<string>();

                List<decimal> y1 = new List<decimal>();
                List<decimal> y2 = new List<decimal>();
                List<decimal> y3 = new List<decimal>();
                DateTime lastUpdated = DateTime.MinValue;
                foreach (var type in types) {
                    y1.Add(type.GovernmentOfficer);
                    y2.Add(type.PermanentContractor);
                    y3.Add(type.GeneralOfficer);
                    if (type.LastUpdated > lastUpdated) {
                        lastUpdated = type.LastUpdated;
                    }
                }

                ColumnChart chart = new ColumnChart(xVals, 1, 1, 75);
                chart.SetLastUpdated(lastUpdated);
                chart.SetSummary("*ไม่มีข้อมูลพนักงานราชการ", Color.Red);
                chart.AddLeftAnnotation("จำนวนคน", 1, 8);
                chart.SetAxisFont(new Font("Circular", 16, FontStyle.Bold));

                chart.AddSeries("ข้าราชการ", y1.ToArray());
                chart.AddSeries("ลูกจ้างประจำ", y2.ToArray());
                chart.AddSeries("พนักงานราชการ", y3.ToArray());

                for (int i = 0; i < 3; i++) {
                    chart.GetSeries(i).SmartLabelStyle.Enabled = false;
                    chart.GetSeries(i).LabelAngle = -90;
                }

                //chart.GetLegendBox().Docking = Docking.Bottom;
                chart.GetLegendBox().Position = new ElementPosition(0, 87, 100, 6);
                chart.GetLegendBox().Alignment = StringAlignment.Center;

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