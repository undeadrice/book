using System.Text.Json.Serialization;

namespace Bookie.Model.Book
{
    public class VolumeInfo
    {
        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("authors")]
        public List<string> Authors { get; set; }

        [JsonPropertyName("publishedDate")]
        public string PublishedDate { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("imageLinks")]
        public ImageLinks ImageLinks { get; set; }
    }
}
