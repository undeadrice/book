using Bookie.Model.Book;

namespace Bookie.Services.Domain.Book
{
    public interface IBookRepository
    {
        void AddToRead(BookModel model);

        void DeleteFromRead(BookModel model);

        IEnumerable<BookModel> GetAllRead();
    }
}
