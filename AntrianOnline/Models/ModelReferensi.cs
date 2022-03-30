using AntrianOnline.AntrianOnline.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace AntrianOnline.AntrianOnline.Models
{
    
    public class ResponseAn
    {
        [JsonProperty("nmpoli")]
        public string nmpoli { get; set; }

        [JsonProperty("nmsubspesialis")]
        public string Nmsubspesialis { get; set; }

        [JsonProperty("kdsubspesialis")]
        public string Kdsubspesialis { get; set; }

        [JsonProperty("kdpoli")]
        public string Kdpoli { get; set; }
    }

    public class refPoliAn
    {

        [JsonProperty("metadata")]
        public MetaData Metadata { get; set; }

        [JsonProperty("response")]
        public List<ResponseAn> Response { get; set; }
    }


    public class ListWaktuTask
    {

        [JsonProperty("wakturs")]
        public string Wakturs { get; set; }

        [JsonProperty("waktu")]
        public string Waktu { get; set; }

        [JsonProperty("taskname")]
        public string Taskname { get; set; }

        [JsonProperty("taskid")]
        public int Taskid { get; set; }

        [JsonProperty("kodebooking")]
        public string Kodebooking { get; set; }
    }

    public class ResponseWaktuTask
    {

        [JsonProperty("list")]
        public IList<ListWaktuTask> List { get; set; }
    }

    public class GetListWaktuTask
    {

        [JsonProperty("response")]
        public ResponseWaktuTask Response { get; set; }

        [JsonProperty("metadata")]
        public MetaData Metadata { get; set; }
    }

    public class ListDashboardAn
    {

        [JsonProperty("kdppk")]
        public string Kdppk { get; set; }

        [JsonProperty("waktu_task1")]
        public int WaktuTask1 { get; set; }

        [JsonProperty("avg_waktu_task4")]
        public double AvgWaktuTask4 { get; set; }

        [JsonProperty("jumlah_antrean")]
        public int JumlahAntrean { get; set; }

        [JsonProperty("avg_waktu_task3")]
        public double AvgWaktuTask3 { get; set; }

        [JsonProperty("namapoli")]
        public string Namapoli { get; set; }

        [JsonProperty("avg_waktu_task6")]
        public double AvgWaktuTask6 { get; set; }

        [JsonProperty("avg_waktu_task5")]
        public double AvgWaktuTask5 { get; set; }

        [JsonProperty("nmppk")]
        public string Nmppk { get; set; }

        [JsonProperty("avg_waktu_task2")]
        public double AvgWaktuTask2 { get; set; }

        [JsonProperty("avg_waktu_task1")]
        public double AvgWaktuTask1 { get; set; }

        [JsonProperty("kodepoli")]
        public string Kodepoli { get; set; }

        [JsonProperty("waktu_task5")]
        public int WaktuTask5 { get; set; }

        [JsonProperty("waktu_task4")]
        public int WaktuTask4 { get; set; }

        [JsonProperty("waktu_task3")]
        public int WaktuTask3 { get; set; }

        [JsonProperty("insertdate")]
        public string Insertdate { get; set; }

        [JsonProperty("tanggal")]
        public string Tanggal { get; set; }

        [JsonProperty("waktu_task2")]
        public int WaktuTask2 { get; set; }

        [JsonProperty("waktu_task6")]
        public int WaktuTask6 { get; set; }
    }

    public class ResponseDashboard
    {

        [JsonProperty("list")]
        public IList<ListDashboardAn> list { get; set; }
    }

    public class DashboardAnTgl
    {

        [JsonProperty("metadata")]
        public MetaData Metadata { get; set; }

        [JsonProperty("response")]
        public ResponseDashboard Response { get; set; }
    }

    public class ListDashboardBln
    {

        [JsonProperty("kdppk")]
        public string Kdppk { get; set; }

        [JsonProperty("waktu_task1")]
        public int WaktuTask1 { get; set; }

        [JsonProperty("avg_waktu_task4")]
        public double AvgWaktuTask4 { get; set; }

        [JsonProperty("jumlah_antrean")]
        public int JumlahAntrean { get; set; }

        [JsonProperty("avg_waktu_task3")]
        public double AvgWaktuTask3 { get; set; }

        [JsonProperty("namapoli")]
        public string Namapoli { get; set; }

        [JsonProperty("avg_waktu_task6")]
        public double AvgWaktuTask6 { get; set; }

        [JsonProperty("avg_waktu_task5")]
        public double AvgWaktuTask5 { get; set; }

        [JsonProperty("nmppk")]
        public string Nmppk { get; set; }

        [JsonProperty("avg_waktu_task2")]
        public double AvgWaktuTask2 { get; set; }

        [JsonProperty("avg_waktu_task1")]
        public double AvgWaktuTask1 { get; set; }

        [JsonProperty("kodepoli")]
        public string Kodepoli { get; set; }

        [JsonProperty("waktu_task5")]
        public int WaktuTask5 { get; set; }

        [JsonProperty("waktu_task4")]
        public int WaktuTask4 { get; set; }

        [JsonProperty("waktu_task3")]
        public int WaktuTask3 { get; set; }

        [JsonProperty("insertdate")]
        public string Insertdate { get; set; }

        [JsonProperty("tanggal")]
        public string Tanggal { get; set; }

        [JsonProperty("waktu_task2")]
        public int WaktuTask2 { get; set; }

        [JsonProperty("waktu_task6")]
        public int WaktuTask6 { get; set; }
    }

    public class ResponseDashboardBln
    {

        [JsonProperty("list")]
        public IList<ListDashboardBln> list { get; set; }
    }

    public class DashboardAnBln
    {

        [JsonProperty("metadata")]
        public MetaData Metadata { get; set; }

        [JsonProperty("response")]
        public ResponseDashboardBln Response { get; set; }
    }

    public class ResponseAnDokter
    {
        [JsonProperty("namadokter")]
        public string Namadokter { get; set; }

        [JsonProperty("kodedokter")]
        public int Kodedokter { get; set; }
    }

    public class refDokterAn
    {

        [JsonProperty("metadata")]
        public MetaData Metadata { get; set; }

        [JsonProperty("response")]
        public List<ResponseAnDokter> Response { get; set; } = new List<ResponseAnDokter>();
    }

    public class ResponseJwDokter
    {
        [JsonProperty("kodesubspesialis")]
        public string Kodesubspesialis { get; set; }

        [JsonProperty("hari")]
        public int Hari { get; set; }

        [JsonProperty("kapasitaspasien")]
        public int Kapasitaspasien { get; set; }

        [JsonProperty("libur")]
        public int Libur { get; set; }

        [JsonProperty("namahari")]
        public string Namahari { get; set; }

        [JsonProperty("jadwal")]
        public string Jadwal { get; set; }

        [JsonProperty("namasubspesialis")]
        public string Namasubspesialis { get; set; }

        [JsonProperty("namadokter")]
        public string Namadokter { get; set; }

        [JsonProperty("kodepoli")]
        public string Kodepoli { get; set; }

        [JsonProperty("namapoli")]
        public string Namapoli { get; set; }

        [JsonProperty("kodedokter")]
        public int Kodedokter { get; set; }

    }

    public class refJwDokter
    {

        [JsonProperty("response")]
        public List<ResponseJwDokter> Response { get; set; }

        [JsonProperty("metadata")]
        public MetaData Metadata { get; set; }
    }
}
