namespace Bookie.Model.Book
{
    public class BookFilterCriteria
    {
        public string Title { get; set; }

        public string Author { get; set; }

        public BookFilterCriteria(string title, string author)
        {
            Title = title;
            Author = author;
        }

        public static BookFilterCriteria WithTitleAndAuthor(string title, string author)
        {
            return new BookFilterCriteria(title, author);
        }

        public IEnumerable<string> BuildQuery()
        {
            var queryParams = new List<string>();

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
