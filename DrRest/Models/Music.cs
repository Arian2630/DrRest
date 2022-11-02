using Microsoft.VisualBasic;

namespace DrRest.Models
{
    public class Music
    {
        public string Title { get; set;}
        public string Artist { get; set;}
        public double Duration { get; set;}
        public int publicationYear { get; set;}
        public int Id { get; set; }

        public Music()
        {

        }

        public Music(string title, string artist, double duration, int publicationYear, int id)
        {
            Title = title;
            Artist = artist;
            Duration = duration;
            this.publicationYear = publicationYear;
            Id = id;
        }
        public void ValidateTitle()
        {
            if (Title == null)
                throw new ArgumentNullException("Title cannot be null");
        }
        public void ValidateArtist()
        {
            if (Artist == null)
                throw new ArgumentNullException("Artist cannot be null");
        }
        public void ValidateDuration()
        {
            if (Duration <= 0)
                throw new ArgumentOutOfRangeException("Duration cannot be negative or 0");
        }
        public void ValidatePublicationYear()
        {
            if (publicationYear <= 1900)
                throw new ArgumentOutOfRangeException("There is no song existing 1900 or before");
        }
        public void Validate()
        {
            ValidateTitle();
            ValidateArtist();
            ValidateDuration();
            ValidatePublicationYear();
        }
    }
}
