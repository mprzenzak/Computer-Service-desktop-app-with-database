using Computer_Service.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

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
            this.InitializeComponent();
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            dbContext = (DataBaseContext)e.Parameter;
        }

        private void SubmitButtonClick(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            var repairId = Int16.Parse(repairIdInput.Text);
            FetchRepairData(repairId);
        }
        private void FetchRepairData(int repairId)
        {
            var repair = dbContext.Repairs.FirstOrDefault(r => r.repair_id == repairId);
            var end_date = repair.end_date;
            var repair_type = repair.repair_type;
            var cost = dbContext.PriceList.FirstOrDefault(p => p.repair_type == repair_type).price;

            costValueLabel.Text = cost.ToString();
            endDateLabel.Text = end_date.ToString();
        }
    }
}
