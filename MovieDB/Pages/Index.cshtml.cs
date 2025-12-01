using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MovieDB.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public string SearchTerms { get; set; }

        /// <summary>
        /// The filtered MPAA Ratings
        /// </summary>
        public string[] MPAARatings { get; set; }

        public IEnumerable<Movie> Movies { get; set; }

        public string[] Genres { get; set; }

        public double? IMDBMax { get; set; }
        public double? IMDBMin { get; set; }

        public double? RottenTomatoesMax { get; set; }
        public double? RottenTomatoesMin { get; set; }

        public void OnGet(string SearchTerms, string[] MPAARatings, string[] Genres, double? IMDBMin, double? IMDBMax, double? RottenTomatoesMin, double? RottenTomatoesMax)
        {
            //this is called whenever there is a get request to the server
            this.SearchTerms = SearchTerms;
            this.MPAARatings = MPAARatings;
            this.Genres = Genres;
            this.IMDBMin = IMDBMin;
            this.IMDBMax = IMDBMax;
            this.RottenTomatoesMax = RottenTomatoesMax;
            this.RottenTomatoesMin = RottenTomatoesMin;
            Movies = MovieDatabase.Search(SearchTerms);
            Movies = MovieDatabase.FilterByMPAARating(Movies, MPAARatings);
            Movies = MovieDatabase.FilterByGenre(Movies, Genres);
            Movies = MovieDatabase.FilterByIMDBRating(Movies, IMDBMin, IMDBMax);
            Movies = MovieDatabase.FilterByRottenTomatoes(Movies, RottenTomatoesMin, RottenTomatoesMax);

        }
    }
}