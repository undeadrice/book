using Bookie.Model.Book;

namespace Bookie.Services.Domain.Book
{
    public class BookHttpService : IBookHttpService
    {
        public static string CLIENT_NAME = "GoogleBooksClient";

        private readonly string _token = "AIzaSyCik9kpJTxfKYaCkSHBpu8bDSdtEhpYTrc";

        private readonly IHttpClientFactory _httpClientFactory;

        public BookHttpService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<string> Get(BookFilterCriteria criteria)
        {
            var client = _httpClientFactory.CreateClient(CLIENT_NAME);
            var baseUrl = "https://www.googleapis.com/books/v1/volumes?q=";
            var queryParameters = criteria.BuildQuery();
            var queryString = string.Join("+", queryParameters);
            var url = $"{baseUrl}{queryString}&key={_token}";
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
            var baseUrl = "https://www.googleapis.com/books/v1/volumes?q=";
            var queryParameters = criteria.BuildQuery();
            var queryString = string.Join("+", queryParameters);
            var url = $"{baseUrl}{queryString}&key={_token}";
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
