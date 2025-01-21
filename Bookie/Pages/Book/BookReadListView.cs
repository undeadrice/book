using Bookie.ViewModels.Book;

namespace Bookie.Pages.Book
{
	public partial class BookReadListView : ContentPage
	{
		public BookReadListView(BookReadViewModel viewModel)
		{
			BindingContext = viewModel;
			InitializeComponent();
		}
	}
}