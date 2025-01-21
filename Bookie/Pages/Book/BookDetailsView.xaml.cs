using Bookie.ViewModels.Book;

namespace Bookie.Pages.Book
{
	public partial class BookDetailsView : ContentPage
	{
		public BookDetailsView(BookDetailsViewModel viewModel)
		{
			BindingContext = viewModel;
			InitializeComponent();
		}
	}
}