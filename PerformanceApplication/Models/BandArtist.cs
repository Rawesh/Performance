using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PerformanceApplication.Models
{
    public class BandArtist
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }

        [Key]
        public string Name { get; set; }
        public string Descripiton { get; set; }

        public void insert(string bandName, string bandDescription)
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBconnection"].ConnectionString);
            conn.Open();

            string insertQuery = "INSERT INTO band_artist(name, description) VALUES (@name, @description)";
            SqlCommand cmd = new SqlCommand(insertQuery, conn);
            cmd.Parameters.AddWithValue("@name", bandName);
            cmd.Parameters.AddWithValue("@description", bandDescription);
            cmd.ExecuteNonQuery();

            conn.Close();

        }
    }
}