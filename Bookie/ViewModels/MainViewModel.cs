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
            await Shell.Current.GoToAsync(AppShell.BookSearchUrl);
        }


        [RelayCommand]
        public async Task NavigateFinishedBooks()
        {
            await Shell.Current.GoToAsync(AppShell.BookReadUrl);
        }
    }
}
