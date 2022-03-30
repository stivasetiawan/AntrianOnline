using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;

namespace AntrianOnline.AntrianOnline.Utills
{
    public static class clsFunction
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static long ConvertToTimeStamp(DateTime value)
        {
            var time = DateTime.SpecifyKind(new DateTime(0x7B2, 1, 1), DateTimeKind.Utc);
            var span = value.ToUniversalTime() - time;  // DirectCast((value.ToUniversalTime - time), TimeSpan)
            return Convert.ToInt64(Math.Floor(span.TotalSeconds));
        }

        public static string GenerateSignature(string sConsumerId, string sPassword, string sTimeStamp)
        {
            var encoding = new ASCIIEncoding();
            var bytes = encoding.GetBytes(sPassword);
            string s = sConsumerId + "&" + sTimeStamp;
            var buffer = encoding.GetBytes(s);
            using (var hmacsha = new HMACSHA256(bytes))
            {
                return Convert.ToBase64String(hmacsha.ComputeHash(buffer));
            }
        }

        public static DataTable ToDataTable<T>(List<T> items)
        {
            var table = new DataTable(typeof(T).Name);
            var properties = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (var info in properties)
                table.Columns.Add(info.Name);
            foreach (var local in items)
            {
                var values = new object[properties.Length];
                int i;
                var loopTo = properties.Length - 1;
                for (i = 0; i <= loopTo; i++)
                    values[i] = properties[i].GetValue(local, null);
                table.Rows.Add(values);
            }

            return table;
        }
    }
}