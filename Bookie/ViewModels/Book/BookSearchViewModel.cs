using Bookie.Model.Book;
using Bookie.Services.Domain.Book;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using CommunityToolkit.Maui.Alerts;

namespace Bookie.ViewModels.Book
{
    [INotifyPropertyChanged]
    public partial class BookSearchViewModel
    {
        private readonly IBookService _bookService;

        [ObservableProperty]
        private string _title;

        [ObservableProperty]
        private string _author;

        [ObservableProperty]
        private ObservableCollection<BookModel> _books;

        public BookSearchViewModel(IBookService bookService)
        {
            _bookService = bookService;
        }
        [RelayCommand]
        public async Task NavigateDetails(BookModel book)
        {
            var queryParameters = new Dictionary<string, object>{
                { "id", book.Id }
            };

            await Shell.Current.GoToAsync(AppShell.BookDetailsUrl, false, queryParameters);
        }

        [RelayCommand]
        public async Task Search()
        {
            var result = await _bookService.GetAll(BookFilterCriteria.WithTitleAndAuthor(Title, Author));
            Books = new ObservableCollection<BookModel>(result);
        }

        [RelayCommand]
        public void MarkAsRead(BookModel book)
        {
            _bookService.MarkAsRead(book);
            Toast.Make("Dodano do przeczytanych").Show();
        }
    }
}
