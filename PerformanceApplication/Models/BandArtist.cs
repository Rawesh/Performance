﻿using System;
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
        //insert data in database
        public void Insert(string name, string description)
        {
            //open database connection
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBconnection"].ConnectionString);
            conn.Open();

            //insert the data in the database
            string insertQuery = "INSERT INTO band_artist(name, description) VALUES (@name, @description)";
            SqlCommand cmd = new SqlCommand(insertQuery, conn);
            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@description", description);
            cmd.ExecuteNonQuery();

            //close connection
            conn.Close();
        }

        public virtual DataSet GetAll()
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

        public virtual DataSet GetOne(int id)
        {
            //make a set of data
            DataSet ds = new DataSet();

            //make connection with the database
            string constr = ConfigurationManager.ConnectionStrings["DBconnection"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(constr))
            {
                //Make connection wth database and send query to database
                string query = "SELECT * FROM band_artist WHERE id =" + id;
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

        public void SaveOne(int id, string name, string description)
        {
            //open database connection
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBconnection"].ConnectionString);
            conn.Open();

            //Update the data in the database
            string insertQuery = "UPDATE Band_artist SET name = @name, description = @description WHERE id = @id";
            SqlCommand cmd = new SqlCommand(insertQuery, conn);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@description", description);
            cmd.ExecuteNonQuery();

            //close connection
            conn.Close();
        }

        public void DeleteOne(int id)
        {
            //open database connection
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBconnection"].ConnectionString);
            conn.Open();

            //Update the data in the database
            string insertQuery = "DELETE FROM band_artist WHERE id = @id";
            SqlCommand cmd = new SqlCommand(insertQuery, conn);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();

            //close connection
            conn.Close();
        }
    }
}