using Bookie.Model.Book;

namespace Bookie.Services.Domain.Book
{
    public class BookHttpService : IBookHttpService
    {
        public static string CLIENT_NAME = "GoogleBooksClient";

        public static string BASE_URL = "https://www.googleapis.com/books/v1/volumes?q=";

        public static string BASE_URL_BY_ID = "https://www.googleapis.com/books/v1/volumes/";

        private readonly string _token = ""; // Token is held here for simplicity

        private readonly IHttpClientFactory _httpClientFactory;

        public BookHttpService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<string> Get(string id)
        {
            var client = _httpClientFactory.CreateClient(CLIENT_NAME);
            var url = $"{BASE_URL_BY_ID}{id}?key={_token}";
            var response = await client.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsStringAsync();
            }
            else
            {
                throw new Exception($"Error occurred: {response.StatusCode}");
            }
        }

        public async Task<string> GetAll(BookFilterCriteria criteria)
        {
            var client = _httpClientFactory.CreateClient(CLIENT_NAME);
            var queryString = string.Join("+", criteria.BuildQuery());
            var url = $"{BASE_URL}{queryString}&key={_token}";
            var response = await client.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsStringAsync();
            }
            else
            {
                throw new Exception($"Error occurred: {response.StatusCode}");
            }
        }
    }
}