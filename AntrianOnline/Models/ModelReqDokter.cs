using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace AntrianOnline.AntrianOnline.Models
{
   public class ModelReqDokter
    {
        public class JadwalDokter
        {

            [JsonProperty("hari")]
            public string Hari { get; set; }

            [JsonProperty("buka")]
            public string Buka { get; set; }

            [JsonProperty("tutup")]
            public string Tutup { get; set; }
        }

        public class reqUpdateJwDokter
        {

            [JsonProperty("kodepoli")]
            public string Kodepoli { get; set; }

            [JsonProperty("kodesubspesialis")]
            public string Kodesubspesialis { get; set; }

            [JsonProperty("kodedokter")]
            public int Kodedokter { get; set; }

            [JsonProperty("jadwal")]
            public IList<JadwalDokter> Jadwal { get; set; }
        }
    }
}
