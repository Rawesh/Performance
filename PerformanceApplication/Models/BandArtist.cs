using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;


namespace PerformanceApplication.Models
{
    public class BandArtist
    {
        public string Id { get; set; }

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

        public virtual DataSet getAll()
        {
            //make a set of data
            DataSet ds = new DataSet();
            
            //make connection with the database
            string constr = ConfigurationManager.ConnectionStrings["DBconnection"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(constr))
            {
                //Make connection wth database and send query to database
                string query = "SELECT * FROM band_artist";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                   //transfering the data from the dataset to the databsae with the SqlDataAdapter
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        //Adapter gets the data from database and fill the dataset with the data
                        sda.Fill(ds);
                    }
                }
            }
            return ds;
        }
    }
}