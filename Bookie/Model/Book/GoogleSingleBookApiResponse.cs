using System.Text.Json.Serialization;

namespace Bookie.Model.Book
{
    public class GoogleSingleBookApiResponse
    {
        [JsonPropertyName("kind")]
        public string Kind { get; set; }

        [JsonPropertyName("id")]
        public string Id { get; set; } 

        [JsonPropertyName("volumeInfo")]
        public VolumeInfo VolumeInfo { get; set; }

        public BookModel ToBookModel()
        {
            return new BookModel(
                Id,
                VolumeInfo?.Authors?.FirstOrDefault(),
                VolumeInfo?.Title,
                VolumeInfo?.PublishedDate,
                (VolumeInfo?.ImageLinks?.Thumbnail + ".jpg").Replace("http", "https"),
                VolumeInfo?.Description?
                .Replace("<p>", string.Empty)
                .Replace("<i>", string.Empty)
                .Replace("<b>", string.Empty)
                .Replace("</p>", string.Empty)
                .Replace("</i>", string.Empty)
                .Replace("</b>", string.Empty));
        }
    }
}