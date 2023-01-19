using Computer_Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace Computer_Service.Views
{
    /// <summary>
    /// Page that displays repair details based on repair_id and customer_id
    /// </summary>
    public sealed partial class CheckOrderForm : Page
    {
        private DataBaseContext dbContext;
        public CheckOrderForm()
        {
            InitializeComponent();
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            dbContext = (DataBaseContext)e.Parameter;
            system.Visibility = Visibility.Collapsed;
            repairType.Visibility = Visibility.Collapsed;
            cost.Visibility = Visibility.Collapsed;
            startDate.Visibility = Visibility.Collapsed;
            endDate.Visibility = Visibility.Collapsed;

            systemValue.Visibility = Visibility.Collapsed;
            processor.Visibility = Visibility.Collapsed;
            motherboard.Visibility = Visibility.Collapsed;
            graphicsCard.Visibility = Visibility.Collapsed;
            ram.Visibility = Visibility.Collapsed;
        }

        private Tuple<Repair, Computer> FetchRepairData(int repairId, string customerId)
        {
            var computers = new List<Computer>();

            computers = dbContext.Computers.ToList();
            
            foreach (Computer computer in computers)
            {
                if (computer.customer_id == customerId)
                {
                    Repair selectedRepair = dbContext.Repairs.FirstOrDefault(r => r.repair_id == repairId && r.computer == computer);
                    return Tuple.Create(selectedRepair, computer);
                }
            }
            wrongRepairIdAlert.Text = "Taka naprawa nie istnieje.";
            return null;
        }

        private void submitButton_Click()
        {
            int repairId;
            bool repairIdIsNumber = int.TryParse(repairIdInput.Text, out repairId);
            if (!repairIdIsNumber)
            {
                wrongRepairIdAlert.Text = "Numer zlecenia składa się z cyfr.";
            }
            var customerId = customerIdInput.Text;
            (Repair repair, Computer computer) = FetchRepairData(repairId, customerId);

            if (repair != null)
            {
                system.Visibility = Visibility.Visible;
                repairType.Visibility = Visibility.Visible;
                cost.Visibility = Visibility.Visible;
                startDate.Visibility = Visibility.Visible;
                endDate.Visibility = Visibility.Visible;

                systemValue.Visibility = Visibility.Visible;
                processor.Visibility = Visibility.Visible;
                motherboard.Visibility = Visibility.Visible;
                graphicsCard.Visibility = Visibility.Visible;
                ram.Visibility = Visibility.Visible;

                // repair values to display
                var repair_type = repair.repair_type;
                costValue.Text = dbContext.PriceList.FirstOrDefault(p => p.repair_type == repair_type).price.ToString("0.00") + " zł";
                repairTypeValue.Text = repair_type;
                startDateValue.Text = repair.filling_date.Date.Day.ToString() + "." + repair.filling_date.Date.Month.ToString() + "." + repair.filling_date.Date.Year.ToString();
                endDateValue.Text = repair.end_date.Date.Day.ToString() + "." + repair.end_date.Date.Month.ToString() + "." + repair.end_date.Date.Year.ToString();

                //computer values to display
                if (computer.system_name != null)
                {
                    systemValue.Text = computer.system_name;
                }
                else
                {
                    systemValue.Text = "Brak systemu";
                }
                processorValue.Text = computer.processor;
                motherboardValue.Text = computer.motherboard;
                if (computer.graphics_card != null)
                {
                    graphicsCardValue.Text = computer.graphics_card;
                }
                else
                {
                    graphicsCardValue.Text = "Brak karty graficznej";
                }
                ramValue.Text = computer.ram;
            }
        }

        private void comeBackButtonClick()
        {
            Frame.Navigate(typeof(EmployeePanel), dbContext);
        }
    }
}
