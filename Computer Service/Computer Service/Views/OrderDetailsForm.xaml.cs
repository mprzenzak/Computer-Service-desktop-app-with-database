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
    /// Form for order details input
    /// </summary>
    public sealed partial class OrderDetailsForm : Page
    {
        private DataBaseContext dbContext;
        public OrderDetailsForm()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            dbContext = (DataBaseContext)e.Parameter;
            var servicesList = dbContext.Services.ToList();
            foreach (var service in servicesList)
            {
                serviceLocationComboBox.Items.Add(service.service_location);
            }

            var repairsList = dbContext.PriceList;
            foreach (var repairType in repairsList)
            {
                repairTypeComboBox.Items.Add(repairType.repair_type);
            }
            string selectedRepairType = repairTypeComboBox.SelectedItem as string;
            // TODO null on startup
            // costValue.Text = dbContext.PriceList.FirstOrDefault(c => c.repair_type == selectedRepairType).price.ToString();
        }

        private void SubmitButtonClick(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            var computer = new Computer()
            {
                customer_id = dbContext.Customers
                    .FirstOrDefault(k => k.email == emailInput.Text).customer_id,
                system_name = systemInput.Text,
                processor = processorInput.Text,
                motherboard = motherboardInput.Text,
                ram = ramInput.Text,
                graphics_card = graphicsCardInput.Text,
            };
            dbContext.Computers.Add(computer);
            dbContext.SaveChanges();

            var repair = new Repair()
            {
                computer_id = dbContext.Computers.OrderByDescending(c => c.computer_id).FirstOrDefault().computer_id,
                service_id = dbContext.Services
                    .FirstOrDefault(s => s.service_location == serviceLocationComboBox.SelectedValue).service_id,
                repair_type = (string)repairTypeComboBox.SelectedValue,
                filing_date = (DateTimeOffset)reportDateInput.Date,
                end_date = (DateTimeOffset)estimatedTimeInput.Date,

            };
            dbContext.Repairs.Add(repair);
            dbContext.SaveChanges();

            Frame.Navigate(typeof(EmployeePanel), dbContext);
        }
    }
}
