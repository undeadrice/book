using Bookie.Model.Book;
using Bookie.Services.Domain.Book;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core.Extensions;

namespace Bookie.ViewModels.Book
{
    [INotifyPropertyChanged]
    public partial class BookSearchViewModel
    {
        private readonly IBookService _bookService;

        [ObservableProperty]
        private string _title;

        [ObservableProperty()]
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
            await Shell.Current.GoToAsync(AppShell.BOOK_DETAILS_URL, false, queryParameters);
        }

        [RelayCommand(CanExecute = nameof(CanExecuteSearch))]
        public async Task Search()
        {
            try
            {
                var result = await _bookService.GetAll(BookFilterCriteria.WithTitleAndAuthor(Title, Author));
                Books = result.ToObservableCollection();
            }
            catch
            {
                await Toast.Make("Wystąpił błąd").Show();
            }
        }

        [RelayCommand]
        public void MarkAsRead(BookModel book)
        {
            try
            {
                _bookService.AddtoRead(book);
                Toast.Make("Dodano do przeczytanych").Show();
            }
            catch
            {
                Toast.Make("Wystąpił błąd").Show();
            }
        }

        public bool CanExecuteSearch()
        {
            return !string.IsNullOrEmpty(Title) || !string.IsNullOrEmpty(Author);
        }

        partial void OnTitleChanged(string value)
        {
            SearchCommand.NotifyCanExecuteChanged();
        }
        partial void OnAuthorChanged(string value)
        {
            SearchCommand.NotifyCanExecuteChanged();
        }
    }
}
