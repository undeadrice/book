using Bookie.ViewModels.Book;

namespace Bookie.Pages.Book
{
	public partial class BookSearch : ContentPage
	{
		public BookSearch(BookSearchViewModel viewModel)
		{
			BindingContext = viewModel;
			InitializeComponent();
		}
	}
}