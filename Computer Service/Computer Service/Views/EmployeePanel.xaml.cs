using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using Computer_Service.Models;

namespace Computer_Service.Views
{
    /// <summary>
    /// Page where logged in employee can choose what to do
    /// </summary>
    public sealed partial class EmployeePanel : Page
    {
        private DataBaseContext dbContext;
        public EmployeePanel()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            dbContext = (DataBaseContext)e.Parameter;
        }

        private void InputOrderDetailsButtonClick(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            Frame.Navigate(typeof(OrderDetailsForm), dbContext);
        }

        private void CheckOrderDetailsButtonClick(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            Frame.Navigate(typeof(CheckOrderForm), dbContext);
        }

        private void LogOutButtonClick(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MainPage), dbContext);
        }
    }
}
