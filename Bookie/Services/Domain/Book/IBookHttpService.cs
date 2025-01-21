using Bookie.Model.Book;

namespace Bookie.Services.Domain.Book
{
    public interface IBookHttpService
    {
        public Task<string> GetAll(BookFilterCriteria criteria);

        public Task<string> Get(BookFilterCriteria criteria);
    }
}
