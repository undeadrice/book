using Bookie.Model.Book;
using Bookie.Services.Domain.Book;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Bookie.ViewModels.Book
{
    [INotifyPropertyChanged]
    public partial class BookDetailsViewModel : IQueryAttributable
    {
        private readonly IBookService _bookService;

        [ObservableProperty]
        private BookModel _book;

        public BookDetailsViewModel(IBookService bookService)
        {
            _bookService = bookService;
        }

        public async void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            var id = (string)query["id"];
            Book = await _bookService.Get(id);
        }
    }
}
