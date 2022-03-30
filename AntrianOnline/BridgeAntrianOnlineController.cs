using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Net;
using SmartMedika.Bridge.VClaim.AntrianOnline.DAL;
using System;
using System.IO;
using System.Threading.Tasks;
using System.Linq;
using NSwag.Annotations;
using static AntrianOnline.AntrianOnline.Models.ModelReqDokter;
using static AntrianOnline.AntrianOnline.Models.ModelReqAntrian;
using AntrianOnline.AntrianOnline.DAL;
using AntrianOnline.AntrianOnline.Utills;

namespace AntrianOnline.AntrianOnline
{
    [Route("[controller]")]
    [ApiController]
    public class BridgeAntrianOnlineController : ControllerBase
    {
        string sConsIDs = "";
        string sPasss = "";
        string sURLs = "";
        string sURLsAntrol = "";
        string sTanggals = "";

        /// <summary>
        /// Constructor Bridge VClaim BPJS
        /// </summary>
        /// <param name="JknDataSep">JKN Data SEP</param>
        /// <param name="logger"></param>
        public BridgeAntrianOnlineController()
        {
            //Ambil konfigurasi bridging dengan vclaim
            System.IO.StreamReader konfig = new StreamReader(string.Concat(System.IO.Directory.GetCurrentDirectory(), "\\VClaim.smdk"));
            sConsIDs = konfig.ReadLine();
            sPasss = konfig.ReadLine();
            sURLs = konfig.ReadLine();
            clsDecrypt.sUserKey = konfig.ReadLine();
            sURLsAntrol = konfig.ReadLine();
            clsDecrypt.sUserKeyAntrol = konfig.ReadLine();
            sTanggals = DateTime.Now.ToString("yyyy-MM-dd");
            konfig.Close();
        }
              
        /// <summary>
        /// Get Data Fasilitas Kesehatan 
        /// </summary>
        /// <param name="sSearchKey">Pencarian Berdasarkan Nama</param>
        /// <param name="sJenisFaskes">Jenis Faskes => 1.PPK1, 2.PPK2 </param>
        [HttpGet("Referensi/Poli")]
        [SwaggerTag("BridgingAntrol", AddToDocument = true, DocumentationDescription = "Web Service Bridging Antrian Online")]
        public ActionResult GetRefPoli()
        {
            try
            {
                var task = Task.Run(() => ReferensiDAL.wsRefPoliAn(sURLsAntrol, sConsIDs, sPasss));

                if (task.Wait(TimeSpan.FromSeconds(29)))
                {
                    if (task.Result.Metadata.Code != "1")
                    {
                        return Ok(new ApiResponse(201, null, task.Result.Metadata.Message));
                    }
                    return Ok(new ApiResponse(200, task.Result.Response, "Suksess"));
                }
                else
                {
                    return StatusCode(StatusCodes.Status408RequestTimeout, new ApiResponse(StatusCodes.Status408RequestTimeout, task.Result.Metadata.Message));
                }
            }
            catch (Exception ex)
            {
                return Ok(new ApiResponse(400, "Proses tidak dapat dijalankan : " + ex.Message + ""));
            }
        }

        [HttpGet("Referensi/Dokter")]
        [SwaggerTag("BridgingAntrol", AddToDocument = true)]
        public ActionResult GetRefDokter()
        {
            try
            {              
                var task = Task.Run(() => ReferensiDAL.wsRefDokterAn(sURLsAntrol, sConsIDs, sPasss));

                if (task.Wait(TimeSpan.FromSeconds(29)))
                {
                    if (task.Result.Metadata.Code != "1")
                    {
                        return Ok(new ApiResponse(201, null, task.Result.Metadata.Message));
                    }
                    return Ok(new ApiResponse(200, task.Result.Response, "Suksess"));
                }
                else
                {
                    return StatusCode(StatusCodes.Status408RequestTimeout, new ApiResponse(StatusCodes.Status408RequestTimeout, task.Result.Metadata.Message));
                }
            }
            catch (Exception ex)
            {
                return Ok(new ApiResponse(400, "Proses tidak dapat dijalankan : " + ex.Message + ""));
            }
        }

        [HttpPost("JadwalDokter")]     
        [SwaggerTag("BridgingAntrol", AddToDocument = true)]
        public async Task<ActionResult> UpdateJwDokter([FromBody] reqUpdateJwDokter value)
        {
            try
            {
                var task = Task.Run(() => RequestDAL.wsUpdateJwDokter(value, sURLsAntrol, sConsIDs, sPasss));

                if (task.Wait(TimeSpan.FromSeconds(29)))
                {
                    if (task.Result.MetaData.Code != "200")
                    {
                        return Ok(new ApiResponse(201, null, task.Result.MetaData.Message));
                    }
                    return Ok(new ApiResponse(200, task.Result.Response, "Suksess"));
                }
                else
                {
                    return StatusCode(StatusCodes.Status408RequestTimeout, new ApiResponse(StatusCodes.Status408RequestTimeout, task.Result.MetaData.Message));
                }
            }
            catch (Exception ex)
            {
                return Ok(new ApiResponse(400, "Proses tidak dapat dijalankan : " + ex.Message + ""));
            }
        }

        [HttpPost("TambahAntrean")]
        [SwaggerTag("BridgingAntrol", AddToDocument = true)]
        public async Task<ActionResult> TambahAntrean([FromBody] ReqAntrian value)
        {
            try
            {               
                var task = Task.Run(() => RequestDAL.wsInsertAntrian(value, sURLsAntrol, sConsIDs, sPasss));

                if (task.Wait(TimeSpan.FromSeconds(29)))
                {
                    if (task.Result.MetaData.Code != "200")
                    {
                        return Ok(new ApiResponse(201, null, task.Result.MetaData.Message));
                    }
                    return Ok(new ApiResponse(200, task.Result.Response, "Suksess"));
                }
                else
                {
                    return StatusCode(StatusCodes.Status408RequestTimeout, new ApiResponse(StatusCodes.Status408RequestTimeout, task.Result.MetaData.Message));
                }
            }
            catch (Exception ex)
            {
                return Ok(new ApiResponse(400, null, "Proses tidak dapat dijalankan : " + ex.Message + ""));
            }
        }

        [HttpPost("UpdateAntrian")]
        [SwaggerTag("BridgingAntrol", AddToDocument = true)]
        public async Task<ActionResult> UpdateAntrean([FromBody] ReqUpdateAntrian value)
        {
            try
            {               
                var task = Task.Run(() => RequestDAL.wsUpdateAntrian(value, sURLsAntrol, sConsIDs, sPasss));

                if (task.Wait(TimeSpan.FromSeconds(29)))
                {
                    if (task.Result.MetaData.Code != "200")
                    {
                        return Ok(new ApiResponse(201, null, task.Result.MetaData.Message));
                    }
                    return Ok(new ApiResponse(200, task.Result.Response, "Suksess"));
                }
                else
                {
                    return StatusCode(StatusCodes.Status408RequestTimeout, new ApiResponse(StatusCodes.Status408RequestTimeout, task.Result.MetaData.Message));
                }
            }
            catch (Exception ex)
            {
                return Ok(new ApiResponse(400, null, "Proses tidak dapat dijalankan : " + ex.Message + ""));
            }
        }

        [HttpPost("BatalAntrian")]
        [SwaggerTag("BridgingAntrol", AddToDocument = true)]
        public async Task<ActionResult> BatalAntrian([FromBody] ReqBatalAntrian value)
        {
            try
            {
                var task = Task.Run(() => RequestDAL.wsBatalAntrian(value, sURLsAntrol, sConsIDs, sPasss));

                if (task.Wait(TimeSpan.FromSeconds(29)))
                {
                    if (task.Result.MetaData.Code != "200")
                    {
                        return Ok(new ApiResponse(201, null, task.Result.MetaData.Message));
                    }
                    return Ok(new ApiResponse(200, task.Result.Response, task.Result.MetaData.Message));
                }
                else
                {
                    return StatusCode(StatusCodes.Status408RequestTimeout, new ApiResponse(StatusCodes.Status408RequestTimeout, task.Result.MetaData.Message));
                }
            }
            catch (Exception ex)
            {
                return Ok(new ApiResponse(400, null, "Proses tidak dapat dijalankan : " + ex.Message + ""));
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="RuangBpjs">Kode Poli BPJS</param>
        /// <param name="Tanggal">Format Tanggal "yyyy-MM-dd"</param>
        /// <returns></returns>
        [HttpGet("Referensi/JadwalDokter/{RuangBpjs}/{Tanggal}")]
        [SwaggerTag("BridgingAntrol", AddToDocument = true)]
        public ActionResult GetRefJwDokter(string RuangBpjs, string Tanggal)
        {
            try
            {               
                var task = Task.Run(() => ReferensiDAL.wsRefJwDokterAn(RuangBpjs, Tanggal, sURLsAntrol, sConsIDs, sPasss));

                if (task.Wait(TimeSpan.FromSeconds(29)))
                {
                    if (task.Result.Metadata.Code != "200")
                    {
                        return Ok(new ApiResponse(201, null, task.Result.Metadata.Message));
                    }
                    return Ok(new ApiResponse(200, task.Result.Response, task.Result.Metadata.Message));
                }
                else
                {
                    return StatusCode(StatusCodes.Status408RequestTimeout, new ApiResponse(StatusCodes.Status408RequestTimeout, task.Result.Metadata.Message));
                }
            }
            catch (Exception ex)
            {
                return Ok(new ApiResponse(400, null, "Proses tidak dapat dijalankan : " + ex.Message + ""));
            }
        }

        [HttpGet("Referensi/GetWaktuTask/{KodeBooking}")]
        [SwaggerTag("BridgingAntrol", AddToDocument = true)]
        public ActionResult GetWaktuTask(string KodeBooking)
        {
            try
            {
                var task = Task.Run(() => ReferensiDAL.wsListWaktuTaskAn(KodeBooking, sURLsAntrol, sConsIDs, sPasss));

                if (task.Wait(TimeSpan.FromSeconds(29)))
                {
                    if (task.Result.Metadata.Code != "200")
                    {
                        return Ok(new ApiResponse(201, null, task.Result.Metadata.Message));
                    }
                    return Ok(new ApiResponse(200, task.Result.Response, task.Result.Metadata.Message));
                }
                else
                {
                    return StatusCode(StatusCodes.Status408RequestTimeout, new ApiResponse(StatusCodes.Status408RequestTimeout, task.Result.Metadata.Message));
                }
            }
            catch (Exception ex)
            {
                return Ok(new ApiResponse(400, null, "Proses tidak dapat dijalankan : " + ex.Message + ""));
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Tanggal">Format Tanggal "yyyy-MM-dd"</param>
        /// <param name="Waktu">Diisikan "rs" atau "server"</param>
        /// <returns></returns>
        [HttpGet("DashboardByTgl/{Tanggal}/{Waktu}")]
        [SwaggerTag("BridgingAntrol", AddToDocument = true)]
        public ActionResult DashboardByTgl(string Tanggal, string Waktu)
        {
            try
            {
                var task = Task.Run(() => ReferensiDAL.wsGetDashboardByTgl(Tanggal, Waktu, sURLsAntrol, sConsIDs, sPasss));

                if (task.Wait(TimeSpan.FromSeconds(29)))
                {
                    if (task.Result.Metadata.Code != "200")
                    {
                        return Ok(new ApiResponse(201, null, task.Result.Metadata.Message));
                    }
                    return Ok(new ApiResponse(200, task.Result.Response, task.Result.Metadata.Message));
                }
                else
                {
                    return StatusCode(StatusCodes.Status408RequestTimeout, new ApiResponse(StatusCodes.Status408RequestTimeout, task.Result.Metadata.Message));
                }
            }
            catch (Exception ex)
            {
                return Ok(new ApiResponse(400, null, "Proses tidak dapat dijalankan : " + ex.Message + ""));
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Bulan">Format Bulan "MM"</param>
        /// <param name="Tahun">Format Tahun "yyyy"</param>
        /// <param name="Waktu">Diisikan "rs" atau "server"</param>
        /// <returns></returns>
        [HttpGet("DashboardByBln/{Bulan}/{Tahun}/{Waktu}")]
        [SwaggerTag("BridgingAntrol", AddToDocument = true)]
        public ActionResult DashboardByBln(string Bulan, string Tahun, string Waktu)
        {
            try
            {
                var task = Task.Run(() => ReferensiDAL.wsGetDashboardByBln(Bulan, Tahun, Waktu, sURLsAntrol, sConsIDs, sPasss));

                if (task.Wait(TimeSpan.FromSeconds(29)))
                {
                    if (task.Result.Metadata.Code != "200")
                    {
                        return Ok(new ApiResponse(201, null, task.Result.Metadata.Message));
                    }
                    return Ok(new ApiResponse(200, task.Result.Response, task.Result.Metadata.Message));
                }
                else
                {
                    return StatusCode(StatusCodes.Status408RequestTimeout, new ApiResponse(StatusCodes.Status408RequestTimeout, task.Result.Metadata.Message));
                }
            }
            catch (Exception ex)
            {
                return Ok(new ApiResponse(400, null, "Proses tidak dapat dijalankan : " + ex.Message + ""));
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Poli">Kode Poli BPJS</param>
        /// <param name="Bulan">Format Bulan "MM"</param>
        /// <param name="Tahun">Format Tahun "yyyy"</param>
        /// <param name="Waktu">Diisikan "rs" atau "server"</param>
        /// <returns></returns>
        [HttpGet("DashboardByBlnPoli/{Poli}/{Bulan}/{Tahun}/{Waktu}")]
        [SwaggerTag("BridgingAntrol", AddToDocument = true)]
        public ActionResult DashboardByBln(string Poli,string Bulan, string Tahun, string Waktu)
        {
            try
            {
                var task = Task.Run(() => ReferensiDAL.wsGetDashboardByBln(Bulan, Tahun, Waktu, sURLsAntrol, sConsIDs, sPasss));

                var hasil = task.Result.Response.list.Where(a => a.Kodepoli == Poli).ToList();
                if (task.Wait(TimeSpan.FromSeconds(29)))
                {
                    if (task.Result.Metadata.Code != "200")
                    {
                        return Ok(new ApiResponse(201, null, task.Result.Metadata.Message));
                    }
                    return Ok(new ApiResponse(200, hasil, task.Result.Metadata.Message));
                }
                else
                {
                    return StatusCode(StatusCodes.Status408RequestTimeout, new ApiResponse(StatusCodes.Status408RequestTimeout, task.Result.Metadata.Message));
                }
            }
            catch (Exception ex)
            {
                return Ok(new ApiResponse(400, null, "Proses tidak dapat dijalankan : " + ex.Message + ""));
            }
        }
    }
}

