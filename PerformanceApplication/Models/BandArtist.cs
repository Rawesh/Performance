using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PerformanceApplication.Models
{
    public class BandArtist
    {
        public string Name { get; set; }
        public string Descripiton { get; set; }

        public string insert(string name, string descripiton)
        {
            var sql = "Insert into band_artist name, description Values ('name', 'description')";
            return sql;
        }
    }
}