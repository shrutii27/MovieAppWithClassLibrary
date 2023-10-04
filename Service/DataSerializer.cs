using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MovieAppWithClassLibrary
{
    internal class DataSerializer
    {
        public static void BinarySerializer(List<Movie> movies, string filePath)
        {
            using (FileStream fileStream = new FileStream(filePath, FileMode.Create))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(fileStream, movies);
            }
        }

        public static List<Movie> BinaryDeserializer(string filePath)
        {
            List<Movie> movies = new List<Movie>();
            if (File.Exists(filePath))
            {
                using (FileStream fileStream = new FileStream(filePath, FileMode.Open))
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    movies = (List<Movie>)formatter.Deserialize(fileStream);
                }
            }
            return movies;
        }
    }
}
