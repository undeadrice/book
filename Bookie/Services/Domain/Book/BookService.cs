using Bookie.Model.Book;
using System.Text.Json;

namespace Bookie.Services.Domain.Book
{
    public class BookService : IBookService
    {
        private readonly IBookHttpService _bookHttpService;

        public BookService(IBookHttpService bookHttpService)
        {
            _bookHttpService = bookHttpService;
        }

        public async Task<IEnumerable<BookModel>> GetAll(BookFilterCriteria criteria)
        {
            var responseString = await _bookHttpService.GetAll(criteria);
            var responseObject = JsonSerializer.Deserialize<GoogleBooksApiResponse>(responseString); 
            return responseObject.ToBookModels();
        }

        public async Task<BookModel> Get(BookFilterCriteria criteria)
        {
            var responseString = await _bookHttpService.Get(criteria);
            var responseObject = JsonSerializer.Deserialize<GoogleSingleBookApiResponse>(responseString);
            return responseObject.ToBookModel();
        }

        public void MarkAsRead(BookModel model)
        {
            string fileName = Path.Combine(FileSystem.AppDataDirectory, "books4.txt");

            if (!File.Exists(fileName))
            {
                using (var stream = File.Create(fileName))
                {
                    var emptyJson = JsonSerializer.Serialize(new List<BookModel>());
                    byte[] bytes = System.Text.Encoding.UTF8.GetBytes(emptyJson);
                    stream.Write(bytes, 0, bytes.Length);
                }
            }
            try
            {
                var json = File.ReadAllText(fileName);

                var list = JsonSerializer.Deserialize<IList<BookModel>>(json);
                list.Add(model);

                var listWithAddedModelJson = JsonSerializer.Serialize(list);

                File.WriteAllText(fileName, listWithAddedModelJson);
            }
            catch (Exception e)
            {

            }
        }

        public void UnmarkRead(BookModel model)
        {
            string fileName = Path.Combine(FileSystem.AppDataDirectory, "books4.txt");

            if (!File.Exists(fileName))
            {
                using (var stream = File.Create(fileName))
                {
                    var emptyJson = JsonSerializer.Serialize(new List<BookModel>());
                    byte[] bytes = System.Text.Encoding.UTF8.GetBytes(emptyJson);
                    stream.Write(bytes, 0, bytes.Length);
                }
            }
            try
            {
                var json = File.ReadAllText(fileName);

                var list = JsonSerializer.Deserialize<IList<BookModel>>(json);
                list.Remove(model);

                var listWithAddedModelJson = JsonSerializer.Serialize(list);

                File.WriteAllText(fileName, listWithAddedModelJson);
            }
            catch (Exception e)
            {

            }
        }
    }
}
