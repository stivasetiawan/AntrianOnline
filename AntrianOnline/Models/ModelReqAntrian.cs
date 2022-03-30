using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace AntrianOnline.AntrianOnline.Models
{
   public class ModelReqAntrian
    {
        public class ReqAntrian
        {

            [JsonProperty("kodebooking")]
            [DefaultValue("kodebooking yang dibuat unik")]
            public string Kodebooking { get; set; }

            [JsonProperty("jenispasien")]
            [DefaultValue("JKN / NON JKN")]
            public string Jenispasien { get; set; }

            [JsonProperty("nomorkartu")]
            [DefaultValue("noka pasien BPJS,diisi kosong jika NON JKN")]
            public string Nomorkartu { get; set; }

            [JsonProperty("nik")]
            [DefaultValue("nik pasien")]
            public string Nik { get; set; }

            [JsonProperty("nohp")]
            [DefaultValue("no hp pasien")]
            public string Nohp { get; set; }

            [JsonProperty("kodepoli")]
            [DefaultValue("memakai kode poli BPJS")]
            public string Kodepoli { get; set; }

            [JsonProperty("namapoli")]
            [DefaultValue("nama poli BPJS")]
            public string Namapoli { get; set; }

            [JsonProperty("pasienbaru")]
            [DefaultValue("1(Ya),0(Tidak)")]
            public int Pasienbaru { get; set; }

            [JsonProperty("norm")]
            [DefaultValue("no rekam medis pasien")]
            public string Norm { get; set; }

            [JsonProperty("tanggalperiksa")]
            [DefaultValue("Format Tanggal yyyy-MM-dd")]
            public string Tanggalperiksa { get; set; }

            [JsonProperty("kodedokter")]
            [DefaultValue("kode dokter BPJS")]
            public int? Kodedokter { get; set; }

            [JsonProperty("namadokter")]
            [DefaultValue("nama dokter")]
            public string Namadokter { get; set; }

            [JsonProperty("jampraktek")]
            [DefaultValue("jam praktek dokter")]
            public string Jampraktek { get; set; }

            [JsonProperty("jeniskunjungan")]
            [DefaultValue("1 (Rujukan FKTP), 2 (Rujukan Internal), 3 (Kontrol), 4 (Rujukan Antar RS)")]
            public int Jeniskunjungan { get; set; }

            [JsonProperty("nomorreferensi")]
            [DefaultValue("norujukan/kontrol pasien JKN,diisi kosong jika NON JKN")]
            public string Nomorreferensi { get; set; }

            [JsonProperty("nomorantrean")]
            [DefaultValue("nomor antrean pasien")]
            public string Nomorantrean { get; set; }

            [JsonProperty("angkaantrean")]
            [DefaultValue("angka antrean")]
            public int Angkaantrean { get; set; }

            [JsonProperty("estimasidilayani")]
            [DefaultValue("waktu estimasi dilayani dalam miliseconds")]
            public long Estimasidilayani { get; set; }

            [JsonProperty("sisakuotajkn")]
            [DefaultValue("sisa kuota JKN")]
            public int Sisakuotajkn { get; set; }

            [JsonProperty("kuotajkn")]
            [DefaultValue("kuota JKN")]
            public int Kuotajkn { get; set; }

            [JsonProperty("sisakuotanonjkn")]
            [DefaultValue("sisa kuota non JKN")]
            public int Sisakuotanonjkn { get; set; }

            [JsonProperty("kuotanonjkn")]
            [DefaultValue("kuota non JKN")]
            public int Kuotanonjkn { get; set; }

            [JsonProperty("keterangan")]
            [DefaultValue("informasi untuk pasien")]
            public string Keterangan { get; set; }
        }

        public class ReqUpdateAntrian
        {

            [JsonProperty("kodebooking")]
            public string Kodebooking { get; set; }

            [JsonProperty("taskid")]
            public int Taskid { get; set; }

            [JsonProperty("waktu")]
            public long Waktu { get; set; }
        }

        public class ReqBatalAntrian
        {

            [JsonProperty("kodebooking")]
            public string Kodebooking { get; set; }

            [JsonProperty("keterangan")]
            public string Keterangan { get; set; }
        }

    }
}
