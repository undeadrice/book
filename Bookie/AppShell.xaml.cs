using Bookie.Pages.Book;
using Bookie.ViewModels.Book;

namespace Bookie
{
    public partial class AppShell : Shell
    {
        public static readonly string HOME_URL = "main";
        public static readonly string BOOK_SEARCH_URL = "book/search";
        public static readonly string BOOK_READ_URL = "book/read";
        public static readonly string BOOK_DETAILS_URL = "book/details";

        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(HOME_URL, typeof(MainPage));
            Routing.RegisterRoute(BOOK_SEARCH_URL, typeof(BookSearch));
            Routing.RegisterRoute(BOOK_READ_URL, typeof(BookReadListView));
            Routing.RegisterRoute(BOOK_DETAILS_URL, typeof(BookDetailsView));
        }
    }
}
