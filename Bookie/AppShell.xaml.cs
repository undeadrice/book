using Bookie.Pages.Book;
using Bookie.ViewModels.Book;

namespace Bookie
{
    public partial class AppShell : Shell
    {
        public static readonly string HomeUrl = "main";
        public static readonly string BookSearchUrl = "book/search";
        public static readonly string BookReadUrl = "book/read";
        public static readonly string BookDetailsUrl = "book/details";

        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(HomeUrl, typeof(MainPage));
            Routing.RegisterRoute(BookSearchUrl, typeof(BookSearch));
            Routing.RegisterRoute(BookReadUrl, typeof(BookFinishedListView));
            Routing.RegisterRoute(BookDetailsUrl, typeof(BookDetailsView));
        }
    }
}
