using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;

namespace MovieDB
{
    /// <summary>
    /// A class representing a database of movies
    /// </summary>
    public static class MovieDatabase
    {
        private static List<Movie> _movies = new List<Movie>();

        /// <summary>
        /// Loads the movie database from the JSON file
        /// </summary>
        static MovieDatabase()
        {

            using (StreamReader file = System.IO.File.OpenText("movies.json"))
            {
                string json = file.ReadToEnd();
                _movies = JsonConvert.DeserializeObject<List<Movie>>(json);
            }
        }

        /// <summary>
        /// Gets all the movies in the database
        /// </summary>
        public static IEnumerable<Movie> All => _movies;
    }
}
