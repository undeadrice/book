namespace Bookie.Model.Book
{
    public class BookFilterCriteria
    {
        public string Id { get; set; }

        public string Title { get; set; }

        public string Author { get; set; }

        public BookFilterCriteria(string id, string title, string author)
        {
            Id = id;
            Title = title;
            Author = author;
        }

        public static BookFilterCriteria WithId(string id)
        {
            return new BookFilterCriteria(id, null, null);
        }

        public static BookFilterCriteria WithTitleAndAuthor(string title, string author)
        {
            return new BookFilterCriteria(null, title, author);
        }

        public IEnumerable<string> BuildQuery()
        {
            var queryParams = new List<string>();

            if (!string.IsNullOrEmpty(Id))
            {
                queryParams.Add($"id:{Uri.EscapeDataString(Id)}");
            }

            if (!string.IsNullOrEmpty(Title))
            {
                queryParams.Add($"intitle:{Uri.EscapeDataString(Title)}");
            }

            if (!string.IsNullOrEmpty(Author))
            {
                queryParams.Add($"inauthor:{Uri.EscapeDataString(Author)}");
            }

            return queryParams;
        }
    }
}
