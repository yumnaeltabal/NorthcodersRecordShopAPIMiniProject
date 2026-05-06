namespace NorthcodersRecordShopAPIMiniProject.Models
{
    public class Album
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Artist { get; set; }
        public int ReleaseYear { get; set; }
        public string Genre { get; set; }

        public Album( string title, string artist, int releaseYear, string genre)
        {
            Title = title;
            Artist = artist;
            ReleaseYear = releaseYear;
            Genre = genre;
        }
    }
}
