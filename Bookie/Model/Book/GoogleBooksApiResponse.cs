using System.Text.Json.Serialization;

namespace Bookie.Model.Book
{
    public class GoogleBooksApiResponse
    {
        [JsonPropertyName("items")]
        public List<BookItem> Items { get; set; }

        public IEnumerable<BookModel> ToBookModels()
        {
            var result = new List<BookModel>();

            foreach (var item in Items)
            {
                var model = new BookModel(
                    item.Id,
                    item.VolumeInfo?.Authors.FirstOrDefault(),
                    item.VolumeInfo?.Title,
                    item.VolumeInfo?.PublishedDate,
                    item.VolumeInfo?.ImageLinks?.Thumbnail,
                    item.VolumeInfo?.Description);

                result.Add(model);
            }

            return result;
        }
    }

    public class BookItem
    {
        [JsonPropertyName("kind")]
        public string Kind { get; set; }

        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("volumeInfo")]
        public VolumeInfo VolumeInfo { get; set; }
    }

    public class VolumeInfo
    {
        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("authors")]
        public List<string> Authors { get; set; }

        [JsonPropertyName("publisher")]
        public string Publisher { get; set; }

        [JsonPropertyName("publishedDate")]
        public string PublishedDate { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("pageCount")]
        public int PageCount { get; set; }

        [JsonPropertyName("imageLinks")]
        public ImageLinks ImageLinks { get; set; }

        [JsonPropertyName("language")]
        public string Language { get; set; }
    }

    public class IndustryIdentifier
    {
        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("identifier")]
        public string Identifier { get; set; }
    }

    public class ReadingModes
    {
        [JsonPropertyName("text")]
        public bool Text { get; set; }

        [JsonPropertyName("image")]
        public bool Image { get; set; }
    }

    public class ImageLinks
    {
        [JsonPropertyName("smallThumbnail")]
        public string SmallThumbnail { get; set; }

        [JsonPropertyName("thumbnail")]
        public string Thumbnail { get; set; }
    }
}
