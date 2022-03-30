using AntrianOnline.AntrianOnline.Models;
using AntrianOnline.AntrianOnline.Utills;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace AntrianOnline.AntrianOnline.DAL
{
    public class ReferensiDAL
    {
        public static clsDecrypt security = new clsDecrypt();

        public static refPoliAn wsRefPoliAn(string sURL, string sConsID, string sPass)
        {
            string sTimeStamp = clsFunction.ConvertToTimeStamp(DateTime.Now).ToString();
            string sSignature = clsFunction.GenerateSignature(sConsID, sPass, sTimeStamp);
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(sURL + "ref/poli");
            var cache = new CredentialCache();
            request.Method = "GET";
            request.KeepAlive = true;
            request.Credentials = cache;
            request.Headers.Add("X-cons-id", sConsID);
            request.Headers.Add("X-timestamp", sTimeStamp);
            request.Headers.Add("X-signature", sSignature);
            request.Headers.Add("user_key", clsDecrypt.sUserKeyAntrol);
            var key = sConsID + sPass + sTimeStamp;
            try
            {
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
                var enc = Encoding.GetEncoding(1252);
                var loResponseStream = new StreamReader(response.GetResponseStream(), enc);
                string stext = loResponseStream.ReadToEnd();
                var encrypt = JsonConvert.DeserializeObject<ResponseEncrypt>(stext);
                refPoliAn result = new refPoliAn();
                if (encrypt.MetaData.Code != "1")
                {
                    result.Metadata = encrypt.MetaData;
                    return result;
                }
                string LZDecrypted = security.Decrypt(key, encrypt.Response);
                string decrypt = LZString.DecompressFromEncodedURIComponent(LZDecrypted);
                var hasil = JsonConvert.DeserializeObject<List<ResponseAn>>(decrypt);

                result.Metadata = encrypt.MetaData;
                result.Response = hasil;
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + request.RequestUri.AbsoluteUri);
            }
        }

        public static refDokterAn wsRefDokterAn(string sURL, string sConsID, string sPass)
        {
            string sTimeStamp = clsFunction.ConvertToTimeStamp(DateTime.Now).ToString();
            string sSignature = clsFunction.GenerateSignature(sConsID, sPass, sTimeStamp);
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(sURL + "ref/dokter");
            var cache = new CredentialCache();
            request.Method = "GET";
            request.KeepAlive = true;
            request.Credentials = cache;
            request.Headers.Add("X-cons-id", sConsID);
            request.Headers.Add("X-timestamp", sTimeStamp);
            request.Headers.Add("X-signature", sSignature);
            request.Headers.Add("user_key", clsDecrypt.sUserKeyAntrol);
            var key = sConsID + sPass + sTimeStamp;
            try
            {
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
                var enc = Encoding.GetEncoding(1252);
                var loResponseStream = new StreamReader(response.GetResponseStream(), enc);
                string stext = loResponseStream.ReadToEnd();
                var encrypt = JsonConvert.DeserializeObject<ResponseEncrypt>(stext);
                refDokterAn result = new refDokterAn();
                if (encrypt.MetaData.Code != "1")
                {
                    result.Metadata = encrypt.MetaData;
                    return result;
                }
                string LZDecrypted = security.Decrypt(key, encrypt.Response);
                string decrypt = LZString.DecompressFromEncodedURIComponent(LZDecrypted);
                var hasil = JsonConvert.DeserializeObject<List<ResponseAnDokter>>(decrypt);

                result.Metadata = encrypt.MetaData;
                result.Response = hasil;
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + request.RequestUri.AbsoluteUri);
            }
        }

        public static refJwDokter wsRefJwDokterAn(string sPoliBpjs, string sTanggal, string sURL, string sConsID, string sPass)
        {
            string sTimeStamp = clsFunction.ConvertToTimeStamp(DateTime.Now).ToString();
            string sSignature = clsFunction.GenerateSignature(sConsID, sPass, sTimeStamp);
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(sURL + "jadwaldokter/kodepoli/"+sPoliBpjs+"/tanggal/"+sTanggal);
            var cache = new CredentialCache();
            request.Method = "GET";
            request.KeepAlive = true;
            request.Credentials = cache;
            request.Headers.Add("X-cons-id", sConsID);
            request.Headers.Add("X-timestamp", sTimeStamp);
            request.Headers.Add("X-signature", sSignature);
            request.Headers.Add("user_key", clsDecrypt.sUserKeyAntrol);
            var key = sConsID + sPass + sTimeStamp;
            try
            {
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
                var enc = Encoding.GetEncoding(1252);
                var loResponseStream = new StreamReader(response.GetResponseStream(), enc);
                string stext = loResponseStream.ReadToEnd();
                var encrypt = JsonConvert.DeserializeObject<ResponseEncrypt>(stext);
                refJwDokter result = new refJwDokter();
                if (encrypt.MetaData.Code != "200")
                {
                    result.Metadata = encrypt.MetaData;
                    return result;
                }
                string LZDecrypted = security.Decrypt(key, encrypt.Response);
                string decrypt = LZString.DecompressFromEncodedURIComponent(LZDecrypted);
                var hasil = JsonConvert.DeserializeObject<List<ResponseJwDokter>>(decrypt);

                result.Metadata = encrypt.MetaData;
                result.Response = hasil;
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + request.RequestUri.AbsoluteUri);
            }
        }

        public static GetListWaktuTask wsListWaktuTaskAn(string sKodeBooking, string sURL, string sConsID, string sPass)
        {
            string sReturn = "InValid";
            string sTimeStamp = clsFunction.ConvertToTimeStamp(DateTime.Now).ToString();
            string sSignature = clsFunction.GenerateSignature(sConsID, sPass, sTimeStamp);
            var request = WebRequest.Create(sURL + "antrean/getlisttask");
            var cache = new CredentialCache();
            string sPostData;
            var sReq = new StringBuilder();
            sReq.Append("{" + (char)34 + "kodebooking" + (char)34 + ":" + (char)34 + sKodeBooking + (char)34 + "}");
            sPostData = sReq.ToString();
            var byteArray = Encoding.UTF8.GetBytes(sPostData);        
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = byteArray.Length;
            request.Credentials = cache;
            request.Headers.Add("x-cons-id", sConsID);
            request.Headers.Add("x-timestamp", sTimeStamp);
            request.Headers.Add("x-signature", sSignature);
            request.Headers.Add("user_key", clsDecrypt.sUserKeyAntrol);
            var key = sConsID + sPass + sTimeStamp;
            try
            {
                var oStream = request.GetRequestStream();
                oStream.Write(byteArray, 0, byteArray.Length);
                oStream.Close();
                WebResponse response = (HttpWebResponse)request.GetResponse();
                Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
                var enc = Encoding.GetEncoding(1252);
                var loResponseStream = new StreamReader(response.GetResponseStream(), enc);
                string stext = loResponseStream.ReadToEnd();
                var encrypt = JsonConvert.DeserializeObject<ResponseEncrypt>(stext);
                GetListWaktuTask result = new GetListWaktuTask();
                if (encrypt.MetaData.Code != "200")
                {
                    result.Metadata = encrypt.MetaData;
                    return result;
                }
                string LZDecrypted = security.Decrypt(key, encrypt.Response);
                string decrypt = LZString.DecompressFromEncodedURIComponent(LZDecrypted);
                var hasil = JsonConvert.DeserializeObject<ResponseWaktuTask>(decrypt);

                result.Metadata = encrypt.MetaData;
                result.Response = hasil;
                return result;
            }
            catch (Exception exception)
            {
                throw new Exception("Gagal membuat data rujukan. " + sURL + exception.Message);
            }
        }
              
        public static DashboardAnTgl wsGetDashboardByTgl(string sTanggal, string sWaktu,string sURL, string sConsID, string sPass)
        {
            string sTimeStamp = clsFunction.ConvertToTimeStamp(DateTime.Now).ToString();
            string sSignature = clsFunction.GenerateSignature(sConsID, sPass, sTimeStamp);
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(sURL + "dashboard/waktutunggu/tanggal/"+sTanggal+"/waktu/"+sWaktu);
            var cache = new CredentialCache();
            request.Method = "GET";
            request.KeepAlive = true;
            request.Credentials = cache;
            request.Headers.Add("x-cons-id", sConsID);
            request.Headers.Add("x-timestamp", sTimeStamp);
            request.Headers.Add("x-signature", sSignature);
            request.Headers.Add("user_key", clsDecrypt.sUserKeyAntrol);
            var key = sConsID + sPass + sTimeStamp;
            try
            {
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
                var enc = Encoding.GetEncoding(1252);
                var loResponseStream = new StreamReader(response.GetResponseStream(), enc);
                string stext = loResponseStream.ReadToEnd();
                var result = JsonConvert.DeserializeObject<DashboardAnTgl>(stext);

                //var encrypt = JsonConvert.DeserializeObject<ResponseEncrypt>(stext);
                //DashboardAnTgl result = new DashboardAnTgl();
                //if (encrypt.MetaData.Code != "200")
                //{
                //    result.Metadata = encrypt.MetaData;
                //    return result;
                //}
                //string LZDecrypted = security.Decrypt(key, encrypt.Response);
                //string decrypt = LZString.DecompressFromEncodedURIComponent(LZDecrypted);
                //var hasil = JsonConvert.DeserializeObject<ResponseDashboard>(decrypt);

                //result.Metadata = encrypt.MetaData;
                //result.Response = hasil;
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + request.RequestUri.AbsoluteUri);
            }
        }

        public static DashboardAnBln wsGetDashboardByBln(string sBulan,string sTahun,string sWaktu,string sURL, string sConsID, string sPass)
        {
            string sTimeStamp = clsFunction.ConvertToTimeStamp(DateTime.Now).ToString();
            string sSignature = clsFunction.GenerateSignature(sConsID, sPass, sTimeStamp);
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(sURL + "dashboard/waktutunggu/bulan/"+sBulan+"/tahun/"+sTahun+"/waktu/"+sWaktu);
            var cache = new CredentialCache();
            request.Method = "GET";
            request.KeepAlive = true;
            request.Credentials = cache;
            request.Headers.Add("X-cons-id", sConsID);
            request.Headers.Add("X-timestamp", sTimeStamp);
            request.Headers.Add("X-signature", sSignature);
            request.Headers.Add("user_key", clsDecrypt.sUserKeyAntrol);
            var key = sConsID + sPass + sTimeStamp;
            try
            {
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
                var enc = Encoding.GetEncoding(1252);
                var loResponseStream = new StreamReader(response.GetResponseStream(), enc);
                string stext = loResponseStream.ReadToEnd();

                var result = JsonConvert.DeserializeObject<DashboardAnBln>(stext);
                //var encrypt = JsonConvert.DeserializeObject<ResponseEncrypt>(stext);
                //DashboardAnBln result = new DashboardAnBln();
                //if (encrypt.MetaData.Code != "200")
                //{
                //    result.Metadata = encrypt.MetaData;
                //    return result;
                //}
                //string LZDecrypted = security.Decrypt(key, encrypt.Response);
                //string decrypt = LZString.DecompressFromEncodedURIComponent(LZDecrypted);
                //var hasil = JsonConvert.DeserializeObject<ResponseDashboardBln>(decrypt);

                //result.Metadata = encrypt.MetaData;
                //result.Response = hasil;
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + request.RequestUri.AbsoluteUri);
            }
        }


    }
}
