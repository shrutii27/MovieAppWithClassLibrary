using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace MovieAppWithClassLibrary
{
    public class MovieManager
    {
        private static List<Movie> movieList;
        private const string filePath = @"D:\Training\Session 5 Sep\movie.txt";

        public MovieManager()
        {
            movieList = DataSerializer.BinaryDeserializer(filePath);
        }

        public List<Movie> GetMoviesList()
        {
            return movieList;
        }

        //show all movies
        public string DisplayMovies()
        {
            if (movieList.Count == 0)
            {
                return "No movies in the list.";
            }

            StringBuilder result = new StringBuilder();
            foreach (Movie movie in movieList)
            {
                result.AppendLine($"ID: {movie.MovieId}, Name: {movie.MovieName}," +
                    $" Year: {movie.Year}, Director: {movie.Director}");
            }
            return result.ToString();
        }

        public string AddMovie(int id, string name, int year, string director)
        {
            if (movieList.Count >= 5)
            {
                throw new InvalidOperationException("Storage is full. Cannot add more movies");
            }

            movieList.Add(new Movie { MovieId = id, MovieName = name, Year = year, Director = director });

            DataSerializer.BinarySerializer(movieList, filePath);

            return "Movie added successfully.";
        }

        public string FindMovieByYear(int year)
        {
            string result = "";

            foreach (Movie movie in movieList)
            {
                if (movie.Year == year)
                {
                    result += $"ID: {movie.MovieId}, Name: {movie.MovieName}," +
                        $" Director: {movie.Director}\n";
                    result += "----------------------------------------\n";
                }
            }

            if (!string.IsNullOrWhiteSpace(result))
            {
                return $"Found movies for year {year}:\n{result}";
            }
            return "No movies found for the given year.";
        }

        public string RemoveMovieByName(string name)
        {
            List<Movie> moviesToRemove = new List<Movie>();

            foreach (Movie movie in movieList)
            {
                if (movie.MovieName.Equals(name, StringComparison.OrdinalIgnoreCase))
                {
                    moviesToRemove.Add(movie);
                }
            }

            int removedCount = moviesToRemove.Count;

            movieList.RemoveAll(movie => moviesToRemove.Contains(movie));

            DataSerializer.BinarySerializer(movieList, filePath);

            if (removedCount > 0)
            {
                return $"Successfully removed {removedCount} movie(s) with the name '{name}'.";
            }
            return $"No movies found with the name '{name}'.";
        }

        public string ClearMovieList()
        {
            movieList.Clear();
            DataSerializer.BinarySerializer(movieList, filePath);
            return "Movie list cleared.";
        }
    }
}

