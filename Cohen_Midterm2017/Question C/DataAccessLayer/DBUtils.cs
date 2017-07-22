using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Cohen_Midterm2017.Question_C.BusinessLogicLayer;
using System.Web.Configuration;
using System.Web;

namespace Cohen_Midterm2017.Question_C.DataAccessLayer
{
    public class DBUtils
    {
        private static readonly string _connectionString = string.Empty;
        /// <summary>
        /// Initialize the data access layer by
        /// loading the database connection string from
        /// the Web.Config file
        /// </summary>
        static DBUtils()
        {
            _connectionString = WebConfigurationManager.ConnectionStrings["Midterm"].ConnectionString;
            if (string.IsNullOrEmpty(_connectionString))
            {
                throw new Exception("No connection string configured in Web.Config file");
            }
        }
        /// <summary>
        /// Selects all movies from the database
        /// </summary>
        public List<Movie> MovieSelectAll()
        {
            // Create Movie Collection
            List<Movie> colMovies = new List<Movie>();

            // Create Connection
            SqlConnection con = new SqlConnection(_connectionString);

            // Create Command
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "SELECT MovieID, MovieTitle FROM Movies";

            // Execute command
            using (con)
            {
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    colMovies.Add(new Movie(
                        (int)reader["MovieID"],
                        (string)reader["MovieTitle"]));
                }
            }
            return colMovies;
        }
        /// <summary>
        /// Inserts a new movie into the database
        /// </summary>
        /// <param name="newMovie">Movie</param>
        public void MovieInsert(Movie newMovie)
        {
            // Create Connection
            SqlConnection con = new SqlConnection(_connectionString);

            // Create Command
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "INSERT Movies(MovieTitle) VALUES (@Movietitle)";

            // Add Parameters
            cmd.Parameters.AddWithValue("@MovieTitle", newMovie.Title);

            // Execute Command
            using (con)
            {
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
        /// <summary>
        /// Updates an existing Movie into the database
        /// </summary>
        /// <param name="movieToUpdate">Movie</param>
        public void MovieUpdate(Movie movieToUpdate)
        {
            // Create Connection
            SqlConnection con = new SqlConnection(_connectionString);

            // Create Command
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "UPDATE Movies SET MovieTitle=@MovieTitle WHERE MovieID=@Id";

            // Add Parameters
            cmd.Parameters.AddWithValue("@MovieTitle", movieToUpdate.Title);
            cmd.Parameters.AddWithValue("@Id", movieToUpdate.Id);

            // Execute Command
            using (con)
            {
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Deletes an existing movie in the database
        /// </summary>
        /// <param name="Id">Movie Id</param>
        public void MovieDelete(int Id)
        {
            //Create Connection
            SqlConnection con = new SqlConnection(_connectionString);

            // Create Command
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "DELETE Movies WHERE MovieID=@Id";

            // Add Parameters
            cmd.Parameters.AddWithValue("@Id", Id);

            //Execute Command
            using (con)
            {
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

    }


}