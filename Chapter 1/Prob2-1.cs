using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Study
{
    class Program
    {
        static void Main(string[] args)
        {   
            Song[] songs = new Song[3];
            songs[0] = new Song("A", "AA", 150);
            songs[1] = new Song("B", "BB", 350);
            songs[2] = new Song("C", "CC", 777);

            for (int i = 0; i < songs.Length; i++)
            {
                Console.WriteLine(songs[i].Title + " " + songs[i].ArtistName + " " + songs[i].SecToMin());
            }
        }    
    }

    public class Song
    {
        public string Title { get; set; }
        public string ArtistName { get; set; }
        public int Length { get; set; } // seconds

        public Song(string title, string artistName, int length)
        {
            this.Title = title;
            this.ArtistName = artistName;
            this.Length = length;
        }

        public string SecToMin()
        {
            return Length / 60 + ":" + Length % 60;
        }
    }
}
