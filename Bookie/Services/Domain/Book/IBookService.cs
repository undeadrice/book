using Bookie.Model.Book;

namespace Bookie.Services.Domain.Book
{
    public interface IBookService
    {
        public Task<IEnumerable<BookModel>> GetAll(BookFilterCriteria criteria);

        public Task<BookModel> Get(string id);

        public IEnumerable<BookModel> GetAllRead();

        public void AddtoRead(BookModel model);

        public void DeleteFromRead(BookModel model);
    }
}
