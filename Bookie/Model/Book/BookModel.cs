namespace Bookie.Model.Book
{
    public class BookModel
    {
        public BookModel(string id, string author, string title, string releaseDate, string coverUrl, string description)
        {
            Id = id;
            Author = author;
            Title = title;
            ReleaseDate = releaseDate;
            CoverUrl = coverUrl;
            Description = description;
        }

        public string Id { get; set; }

        public string Author { get; set; }

        public string Title { get; set; }

        public string ReleaseDate { get; set; }

        public string Description { get; set; }

        public string CoverUrl { get; set; }
    }
}
