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

        //insert data in database
        public void insert(string bandName, string bandDescription)
        {
            //open database connection
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBconnection"].ConnectionString);
            conn.Open();

            //insert the data in the database
            string insertQuery = "INSERT INTO band_artist(name, description) VALUES (@name, @description)";
            SqlCommand cmd = new SqlCommand(insertQuery, conn);
            cmd.Parameters.AddWithValue("@name", bandName);
            cmd.Parameters.AddWithValue("@description", bandDescription);
            cmd.ExecuteNonQuery();

            //close connection
            conn.Close();

        }

        public void getAll()
        {
            //open database connection
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBconnection"].ConnectionString);
            conn.Open();

            //get the data from the database with the querybuilder
            string insertQuery = "SELECT * FROM band_artist";
            SqlCommand cmd = new SqlCommand(insertQuery, conn);
            cmd.ExecuteNonQuery();

            //closse databaseconnection
            conn.Close();
        }
    }
}