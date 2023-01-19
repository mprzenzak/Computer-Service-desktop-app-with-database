using Computer_Service.Models;
using System.Linq;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace Computer_Service.Views
{
    /// <summary>
    /// Page where logged in customer can type repair id and see cost and end date.
    /// </summary>
    public sealed partial class CustomerPanel : Page
    {
        private DataBaseContext dbContext;
        public CustomerPanel()
        {
            InitializeComponent();
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            dbContext = (DataBaseContext)e.Parameter;
        }

        private void SubmitButtonClick(object sender, RoutedEventArgs e)
        {
            int repairId;
            bool repairIdIsNumber = int.TryParse(repairIdInput.Text, out repairId);
            if (!repairIdIsNumber)
            {
                wrongRepairIdAlert.Text = "Numer zlecenia składa się z cyfr.";
            }
            FetchRepairData(repairId);
        }
        private void FetchRepairData(int repairId)
        {
            var repair = dbContext.Repairs.FirstOrDefault(r => r.repair_id == repairId);
            var end_date = repair.end_date.Date.Day.ToString() + "." + repair.end_date.Date.Month.ToString() + "." + repair.end_date.Date.Year.ToString();
            var repair_type = repair.repair_type;
            var cost = dbContext.PriceList.FirstOrDefault(p => p.repair_type == repair_type).price;

            costValueLabel.Text = cost.ToString("0.00") + " zł";
            endDateLabel.Text = end_date;
        }

        private void LogOutButtonClick(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MainPage), dbContext);
        }
    }
}
