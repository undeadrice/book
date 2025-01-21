using Bookie.Model.Book;

namespace Bookie.Services.Domain.Book
{
    public interface IBookService
    {
        public Task<IEnumerable<BookModel>> GetAll(BookFilterCriteria criteria);

        // TODO na id
        public Task<BookModel> Get(BookFilterCriteria criteria);

        public IEnumerable<BookModel> GetAllRead();

        // TODO return na bool
        public void MarkAsRead(BookModel model);

        public void UnmarkRead(BookModel model);
    }
}
