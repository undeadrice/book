using Bookie.Model.Book;
using Bookie.Services.Domain.Book;
using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core.Extensions;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;

namespace Bookie.ViewModels.Book
{
    [INotifyPropertyChanged]
    public partial class BookReadViewModel : IQueryAttributable
    {
        private readonly IBookService _bookService;

        [ObservableProperty]
        private ObservableCollection<BookModel> _books;

        public BookReadViewModel(IBookService bookService)
        {
            _bookService = bookService;
        }

        [RelayCommand]
        public void MarkAsUnread(BookModel book)
        {
            try
            {
                _bookService.DeleteFromRead(book);
                Books.Remove(book);
                Toast.Make("Usunięto z przeczytanych").Show();
            }
            catch(Exception e)
            {
                Toast.Make(e.Message).Show();
            }
        }

        // TODO method used as form of initialize function. Not the best way.
        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            Books = _bookService.GetAllRead().ToObservableCollection();
        }
    }
}
