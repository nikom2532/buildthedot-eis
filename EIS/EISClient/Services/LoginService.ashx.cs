using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EISClient.Model;
using System.Security.Cryptography;
using System.Text;

namespace EISClient.Services {
    /// <summary>
    /// Summary description for LoginService
    /// </summary>
    public class LoginService : IHttpHandler {

        public void ProcessRequest(HttpContext context) {
            string key = context.Request["key"];

            eisEntities ctx = new eisEntities();
            var users = from u in ctx.users
                        where u.SHA1 == key
                        select u;
            var userList = users.ToList();
            string response = "";
            if (userList.Count > 0) {
                var user = userList[0];
                string returnedKey = calculateSHA1(user.Password + user.SHA1);
                response = "{\"success\":true, \"key\":\"" + returnedKey + "\"}";
            } else {
                response = "{\"success\":false, \"message\":\"รหัสผ่านไม่ถูกต้อง กรุณาลองอีกครั้ง\"}";
            }

            context.Response.ContentType = "application/json";
            context.Response.Write(response);
        }

        private string calculateSHA1(string text) {
            byte[] buffer = Encoding.UTF8.GetBytes(text);
            SHA1CryptoServiceProvider cryptoTransformSHA1 = new SHA1CryptoServiceProvider();
            return BitConverter.ToString(cryptoTransformSHA1.ComputeHash(buffer)).Replace("-", "");
        }

        public bool IsReusable {
            get {
                return false;
            }
        }
    }
}