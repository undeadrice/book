using Bookie.ViewModels.Book;

namespace Bookie.Pages.Book
{
	public partial class BookFinishedListView : ContentPage
	{
		public BookFinishedListView(BookFinishedViewModel viewModel)
		{
			BindingContext = viewModel;
			InitializeComponent();
		}
	}
}