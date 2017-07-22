using System;
using System.Collections.Generic;
using System.Linq;
using Cohen_Midterm2017.Question_C.DataAccessLayer;
using System.Web;

namespace Cohen_Midterm2017.Question_C.BusinessLogicLayer
{
    /// <summary>
    /// Represents a store Movie and all the methods 
    /// for selecting, inserting, and updating a customer
    /// </summary>
    public class Movie
    {
        private int _id = 0;
        private string _title = String.Empty;
        private string title;
    
        /// <summary>
        /// Movie Unique Identifier
        /// </summary>  
        public int Id
        {
            get { return _id; }
        }

        /// <summary>
        /// Movie Title
        /// </summary>
        public string Title
        {
            get { return _title; }
        }

        /// <summary>
        /// Retrieves all Movies
        /// </summary> 
        /// <returns></returns>
        public static List<Movie> SelectAll()
        {
            DBUtils dataAccessLayer = new DBUtils();
            return dataAccessLayer.MovieSelectAll();
        }

        /// <summary>
        /// Updates a particular customer
        /// </summary> 
        /// <param name="id">Movie Id</param>
        /// <param name="title">Movie Title</param>
        public static void Update(int id, string title)
        {
            Movie movieToUpdate = new Movie(id, title);
            movieToUpdate.Save();
        }

        /// <summary>
        /// Inserts a new Movie
        /// </summary>
        /// <param name="id">Movie Id</param>
        /// <param name="title">Movie Title</param>
        public static void Insert(string title)
        {
            Movie newMovie = new Movie(title);
            newMovie.Save();
        }

        /// <summary>
        /// Deletes an existing Movie
        /// </summary> 
        /// <param name="id">Movie Id</param>
        public static void Delete(int id)
        {
            DBUtils dataAccessLayer = new DBUtils();
            dataAccessLayer.MovieDelete(id);
        }

        /// <summary>
        /// Validates Movie information before Saving Movie
        /// Properties to the database
        /// </summary>
        private void Save()
        { 
            DBUtils dataAccessLayer = new DBUtils();
            if (_id > 0)
            {
                dataAccessLayer.MovieUpdate(this);
            }
            else
            {
                dataAccessLayer.MovieInsert(this);
            }
                
        }
        /// <summary>
        /// Initialize Movie
        /// </summary>
        /// <param name="id">Movie Id</param>
        /// <param name="title">Movie Title</param>
        public Movie(string title)
            : this(0, title)
        { }


        /// <summary>
        /// Initialize Movie
        /// </summary>
        /// <param name="id">Movie Id</param>
        /// <param name="title">Movie Title</param>
        public Movie(int id, string title)
        {
            _id = id;
            _title = title;
          
        }


    }
}