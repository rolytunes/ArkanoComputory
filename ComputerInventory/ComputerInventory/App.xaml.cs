using Xamarin.Forms;
using ComputerInventory.Views;
using ComputerInventory.Services.NavigationService;
using ComputerInventory.ViewModels.Base;
using System.Threading.Tasks;

namespace ComputerInventory
{
    public partial class App : Application
    {
        private INavigationService _navigationService = ViewModelLocator.Resolve<INavigationService>();
        public App()
        {
            InitializeComponent();
            MainPage = new DashboardView();
        }



        protected override void OnStart()
        {
            // Handle when your app starts
            base.OnStart();

            _navigationService.InitializeAsync();

            base.OnResume();
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
            _navigationService.InitializeAsync();
        }
    }
}
