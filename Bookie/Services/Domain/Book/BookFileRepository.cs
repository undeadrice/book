using Bookie.Model.Book;
using System.Text.Json;

namespace Bookie.Services.Domain.Book
{
    public class BookFileRepository : IBookRepository, IInitializable
    {
        public static string FILE_NAME = "books.txt";

        public void Initialize()
        {
            string fileName = Path.Combine(FileSystem.AppDataDirectory, FILE_NAME);

            if (!File.Exists(fileName))
            {
                using (var stream = File.Create(fileName))
                {
                    var emptyJson = JsonSerializer.Serialize(new List<BookModel>());
                    byte[] bytes = System.Text.Encoding.UTF8.GetBytes(emptyJson);
                    stream.Write(bytes, 0, bytes.Length);
                }
            }
        }

        public void AddToRead(BookModel model)
        {
            var json = ReadJson();
            var list = JsonSerializer.Deserialize<IList<BookModel>>(json);
            list.Add(model);

            SaveJsonList(list);
        }

        public void DeleteFromRead(BookModel model)
        {
            var json = ReadJson();
            var list = JsonSerializer.Deserialize<IList<BookModel>>(json);
            var bookToRemove = list.FirstOrDefault(b => b.Id == model.Id);
            list.Remove(bookToRemove);

            SaveJsonList(list);
        }

        public IEnumerable<BookModel> GetAllRead()
        {
            string fileName = Path.Combine(FileSystem.AppDataDirectory, FILE_NAME);
            var json = File.ReadAllText(fileName);
            return JsonSerializer.Deserialize<IList<BookModel>>(json);
        }

        private static string ReadJson()
        {
            string fileName = Path.Combine(FileSystem.AppDataDirectory, FILE_NAME);
            return File.ReadAllText(fileName);
        }

        private static void SaveJsonList(IEnumerable<BookModel> models)
        {
            string fileName = Path.Combine(FileSystem.AppDataDirectory, FILE_NAME);
            var listWithAddedModelJson = JsonSerializer.Serialize(models);
            File.WriteAllText(fileName, listWithAddedModelJson);
        }
    }
}
