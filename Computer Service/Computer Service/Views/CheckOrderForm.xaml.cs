using Computer_Service.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Devices.Sensors.Custom;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
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
            Repair repair = new Repair();
            var computers = dbContext.Computers;
            foreach (Computer computer in computers)
            {
                if (computer.customer_id == customerId)
                {
                    Repair selectedRepair = dbContext.Repairs.FirstOrDefault(r => r.repair_id == repairId && r.Computer == computer);
                    return Tuple.Create(selectedRepair, computer);
                }
            }
            return null;
        }

        private void submitButton_Click(object sender, RoutedEventArgs e)
        {
            var repairId = Int16.Parse(repairIdInput.Text);
            var customerId = customerIdInput.Text;
            (Repair repair, Computer computer) = FetchRepairData(repairId, customerId);

            // repair values to display
            var repair_type = repair.repair_type;
            costValue.Text = dbContext.PriceList.FirstOrDefault(p => p.repair_type == repair_type).price.ToString("0.00") + " zł";
            repairTypeValue.Text = repair_type;
            startDateValue.Text = repair.filling_date.ToString();
            endDateValue.Text = repair.end_date.ToString();

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
}
