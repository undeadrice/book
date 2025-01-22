using System.Text.Json.Serialization;

namespace Bookie.Model.Book
{
    public class ImageLinks
    {
        [JsonPropertyName("smallThumbnail")]
        public string SmallThumbnail { get; set; }

        [JsonPropertyName("thumbnail")]
        public string Thumbnail { get; set; }
    }
}
