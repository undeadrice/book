using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Bookie.ViewModels
{
    [INotifyPropertyChanged]
    public partial class MainViewModel
    {
        public MainViewModel()
        {
        }

        [RelayCommand]
        public async Task NavigateBookSearch()
        {
            await Shell.Current.GoToAsync(AppShell.BOOK_SEARCH_URL);
        }


        [RelayCommand]
        public async Task NavigateReadBooks()
        {
            await Shell.Current.GoToAsync(AppShell.BOOK_READ_URL);
        }
    }
}
