using Computer_Service.Models;
using System;
using System.Linq;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;


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
        }

        private async void SubmitButtonClick(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            bool allRequiredFieldsFulfilled = true;
            Customer customer = dbContext.Customers.FirstOrDefault(k => k.email == emailInput.Text);

            if (string.IsNullOrEmpty(serviceLocationComboBox.SelectedValue.ToString()))
            {
                LocationIsRequiredNotification.Text = "Lokalizacja jest wymagana!";
                allRequiredFieldsFulfilled = false;
            }
            if (!reportDateInput.Date.HasValue)
            {
                fillingDateIsRequiredNotification.Text = "Data zgłoszenia jest wymagana!";
                allRequiredFieldsFulfilled = false;
            }
            if (!estimatedTimeInput.Date.HasValue)
            {
                endDateIsRequiredNotification.Text = "Data zakończenia naprawy jest wymagana!";
                allRequiredFieldsFulfilled = false;
            }
            if (string.IsNullOrEmpty(repairTypeComboBox.SelectedValue.ToString()))
            {
                repairTypeIsRequiredNotification.Text = "Typ usterki jest wymagany!";
                allRequiredFieldsFulfilled = false;
            }
            if (string.IsNullOrEmpty(processorInput.Text))
            {
                processorRequiredNotification.Text = "Model procesora jest wymagany!";
                allRequiredFieldsFulfilled = false;
            }
            if (string.IsNullOrEmpty(motherboardInput.Text))
            {
                motherboardIsRequiredNotification.Text = "Model płyty głównej jest wymagany!";
                allRequiredFieldsFulfilled = false;
            }
            if (string.IsNullOrEmpty(ramInput.Text))
            {
                ramModelIsRequiredNotification.Text = "Model RAMu jest wymagany!";
                allRequiredFieldsFulfilled = false;
            }
            if (customer == null)
            {
                customerDoesNotExistWarning.Text = "Taki klient nie istnieje...";
                allRequiredFieldsFulfilled = false;
            }
            if (estimatedTimeInput.Date - reportDateInput.Date < new TimeSpan(72, 0, 0))
            {
                endDateIsRequiredNotification.Text = "Naprawa nie może trwać krócej niż 3 dni!";
                allRequiredFieldsFulfilled = false;
            }

            var a = estimatedTimeInput.Date - reportDateInput.Date;


            if (allRequiredFieldsFulfilled)
            {
                var computer = new Computer()
                {
                    customer_id = customer.customer_id,
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
                        .FirstOrDefault(s => s.service_location == serviceLocationComboBox.SelectedValue.ToString()).service_id,
                    repair_type = (string)repairTypeComboBox.SelectedValue,
                    filling_date = (DateTimeOffset)reportDateInput.Date,
                    end_date = (DateTimeOffset)estimatedTimeInput.Date,

                };
                dbContext.Repairs.Add(repair);
                dbContext.SaveChanges();

                var newRepairID = dbContext.Repairs.ToList().IndexOf(repair) + 1;

                ContentDialog noWifiDialog = new ContentDialog()
                {
                    Title = "Podaj klientowi numer zgłoszenia",
                    Content = "Numer zgłoszenia to: " + newRepairID,
                    CloseButtonText = "OK"
                };

                await noWifiDialog.ShowAsync();
                Frame.Navigate(typeof(EmployeePanel), dbContext);
            }
        }

        private void comeBackButtonClick(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(EmployeePanel), dbContext);
        }

        private void repairTypeComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string selectedRepairType = repairTypeComboBox.SelectedItem as string;
            costValue.Text = dbContext.PriceList.FirstOrDefault(c => c.repair_type == selectedRepairType).price.ToString("0.00") + " zł";
        }
    }
}
