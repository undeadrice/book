using Bookie.Services;

namespace Bookie
{
    public partial class App : Application
    {
        public App(IInitializable initializable)
        {
            initializable.Initialize();
            InitializeComponent();
            MainPage = new AppShell();
        }
    }
}
