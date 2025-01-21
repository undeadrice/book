using Bookie.Model.Book;

namespace Bookie.Services.Domain.Book
{
    public interface IBookService
    {
        public Task<IEnumerable<BookModel>> GetAll(BookFilterCriteria criteria);

        public Task<BookModel> Get(BookFilterCriteria criteria);

        public void MarkAsRead(BookModel model);

        public void UnmarkRead(BookModel model);
    }
}
