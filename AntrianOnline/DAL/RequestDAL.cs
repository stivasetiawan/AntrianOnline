using AntrianOnline.AntrianOnline.Models;
using AntrianOnline.AntrianOnline.Utills;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Net;
using System.Text;
using static AntrianOnline.AntrianOnline.Models.ModelReqAntrian;
using static AntrianOnline.AntrianOnline.Models.ModelReqDokter;

namespace SmartMedika.Bridge.VClaim.AntrianOnline.DAL
{
    public class RequestDAL
    {
        public static clsDecrypt security = new clsDecrypt();

        public static ResponseEncrypt wsInsertAntrian(ReqAntrian sData, string sURL, string sConsID, string sPass)
        {
            string sReturn = "InValid";
            string sTimeStamp = clsFunction.ConvertToTimeStamp(DateTime.Now).ToString();
            string sSignature = clsFunction.GenerateSignature(sConsID, sPass, sTimeStamp);
            var request = WebRequest.Create(sURL + "antrean/add");
            var cache = new CredentialCache();
            string sPostData;
            var oDTO = new ReqAntrian();
            oDTO = sData;
            sPostData = JsonConvert.SerializeObject(oDTO);
            var byteArray = Encoding.UTF8.GetBytes(sPostData);
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = byteArray.Length;
            request.Credentials = cache;
            request.Headers.Add("X-cons-id", sConsID);
            request.Headers.Add("X-timestamp", sTimeStamp);
            request.Headers.Add("X-signature", sSignature);
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

                return encrypt;

            }
            catch (Exception ex)
            {                
                throw new Exception(ex.InnerException == null ? ex.Message : ex.InnerException.Message);
            }
        }

        public static ResponseEncrypt wsUpdateAntrian(ReqUpdateAntrian sData, string sURL, string sConsID, string sPass)
        {
            string sReturn = "InValid";
            string sTimeStamp = clsFunction.ConvertToTimeStamp(DateTime.Now).ToString();
            string sSignature = clsFunction.GenerateSignature(sConsID, sPass, sTimeStamp);
            var request = WebRequest.Create(sURL + "antrean/updatewaktu");
            var cache = new CredentialCache();
            string sPostData;
            var oDTO = new ReqUpdateAntrian();
            oDTO = sData;
            sPostData = JsonConvert.SerializeObject(oDTO);
            var byteArray = Encoding.UTF8.GetBytes(sPostData);
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = byteArray.Length;
            request.Credentials = cache;
            request.Headers.Add("X-cons-id", sConsID);
            request.Headers.Add("X-timestamp", sTimeStamp);
            request.Headers.Add("X-signature", sSignature);
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

                return encrypt;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.InnerException == null ? ex.Message : ex.InnerException.Message);
            }
        }

        public static ResponseEncrypt wsBatalAntrian(ReqBatalAntrian sData, string sURL, string sConsID, string sPass)
        {
            string sReturn = "InValid";
            string sTimeStamp = clsFunction.ConvertToTimeStamp(DateTime.Now).ToString();
            string sSignature = clsFunction.GenerateSignature(sConsID, sPass, sTimeStamp);
            var request = WebRequest.Create(sURL + "antrean/batal");
            var cache = new CredentialCache();
            string sPostData;
            var oDTO = new ReqBatalAntrian();
            oDTO = sData;
            sPostData = JsonConvert.SerializeObject(oDTO);
            var byteArray = Encoding.UTF8.GetBytes(sPostData);
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = byteArray.Length;
            request.Credentials = cache;
            request.Headers.Add("X-cons-id", sConsID);
            request.Headers.Add("X-timestamp", sTimeStamp);
            request.Headers.Add("X-signature", sSignature);
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

                return encrypt;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.InnerException == null ? ex.Message : ex.InnerException.Message);
            }
        }

        public static ResponseEncrypt wsUpdateJwDokter(reqUpdateJwDokter sData, string sURL, string sConsID, string sPass)
        {
            string sReturn = "InValid";
            string sTimeStamp = clsFunction.ConvertToTimeStamp(DateTime.Now).ToString();
            string sSignature = clsFunction.GenerateSignature(sConsID, sPass, sTimeStamp);
            var request = WebRequest.Create(sURL + "jadwaldokter/updatejadwaldokter");
            var cache = new CredentialCache();
            string sPostData;
            var oDTO = new reqUpdateJwDokter();
            oDTO = sData;
            sPostData = JsonConvert.SerializeObject(oDTO);
            var byteArray = Encoding.UTF8.GetBytes(sPostData);
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = byteArray.Length;
            request.Credentials = cache;
            request.Headers.Add("X-cons-id", sConsID);
            request.Headers.Add("X-timestamp", sTimeStamp);
            request.Headers.Add("X-signature", sSignature);
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
                
                return encrypt;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.InnerException == null ? ex.Message : ex.InnerException.Message);
            }
        }
    }
}
