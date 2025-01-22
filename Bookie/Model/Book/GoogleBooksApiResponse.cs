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
                    item.VolumeInfo?.Authors?.FirstOrDefault(),
                    item.VolumeInfo?.Title,
                    item.VolumeInfo?.PublishedDate,
                    item.VolumeInfo?.ImageLinks?.Thumbnail,
                    item.VolumeInfo?.Description);

                result.Add(model);
            }

            return result;
        }
    }
}
