using Bookie.Model.Book;
using System.Text.Json;

namespace Bookie.Services.Domain.Book
{
    public class BookService : IBookService
    {
        private readonly IBookHttpService _bookHttpService;
        private readonly IBookRepository _bookRepository;

        public BookService(IBookHttpService bookHttpService, IBookRepository bookRepository)
        {
            _bookHttpService = bookHttpService;
            _bookRepository = bookRepository;
        }

        public async Task<IEnumerable<BookModel>> GetAll(BookFilterCriteria criteria)
        {
            var responseString = await _bookHttpService.GetAll(criteria);
            var responseObject = JsonSerializer.Deserialize<GoogleBooksApiResponse>(responseString);
            return responseObject.ToBookModels();
        }

        public async Task<BookModel> Get(string id)
        {
            var responseString = await _bookHttpService.Get(id);
            var responseObject = JsonSerializer.Deserialize<GoogleSingleBookApiResponse>(responseString);
            return responseObject.ToBookModel();
        }

        public void AddtoRead(BookModel model)
        {
            _bookRepository.AddToRead(model);
        }

        public void DeleteFromRead(BookModel model)
        {
            _bookRepository.DeleteFromRead(model);
        }

        public IEnumerable<BookModel> GetAllRead()
        {
            return _bookRepository.GetAllRead();
        }
    }
}
