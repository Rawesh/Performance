using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;

namespace PerformanceApplication.Models
{
    public class Performance
    {
        public virtual DataSet GetAll()
        {
            //make a set of data
            DataSet ds = new DataSet();

            //make connection with the database
            string constr = ConfigurationManager.ConnectionStrings["DBconnection"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(constr))
            {
                //Make connection wth database and send query to database
                string query = "SELECT band_artist.name, performance.start_date, performance.end_date, stage.name" +
                                " FROM performance " +
                                "INNER JOIN band_artist ON performance.band_artist_id = band_artist.id " +
                                "INNER JOIN stage ON performance.stage_id = stage.id";
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

        public void Insert(string bandArtistId, string stageId, string startDatetime, string endDatetime)
        {
            //open database connection
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBconnection"].ConnectionString);
            conn.Open();

            //insert the data in the database
            string insertQuery = "INSERT INTO performance(band_artist_id, stage_id, start_date, end_date) VALUES (@band_artist_id, @stage_id, @start_date, @end_date)";
            SqlCommand cmd = new SqlCommand(insertQuery, conn);
            cmd.Parameters.AddWithValue("@band_artist_id", bandArtistId);
            cmd.Parameters.AddWithValue("@stage_id", stageId);
            cmd.Parameters.AddWithValue("@start_date", startDatetime);
            cmd.Parameters.AddWithValue("@end_date", endDatetime);
            cmd.ExecuteNonQuery();

            //close connection
            conn.Close();
        }
    }
}