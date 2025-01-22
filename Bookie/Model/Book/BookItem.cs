using System.Text.Json.Serialization;

namespace Bookie.Model.Book
{
    public class BookItem
    {
        [JsonPropertyName("kind")]
        public string Kind { get; set; }

        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("volumeInfo")]
        public VolumeInfo VolumeInfo { get; set; }
    }
}
