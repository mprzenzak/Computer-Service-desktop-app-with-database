using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Diagnostics;
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
using Computer_Service.Models;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Computer_Service
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            InventoryList.ItemsSource = GetProducts((App.Current as App).ConnectionString);
        }

        // Display all customers
        public ObservableCollection<Customer> GetProducts(string connectionString)
        {
            const string GetProductsQuery = "SELECT client_id, firstname, lastname, phone, email" +
                                            " FROM dbo.Klienci";
            var customers = new ObservableCollection<Customer>();
            try
            {
                //// const string connectionString2 = "SERVER=HP\\MPRZENZAKSQL;Database=Computer_Service_Project; USER ID = AS; PASSWORD = Babkaloj1202";
                //const string connectionString2 =
                //    "Server=HP\\MPRZENZAKSQL; Database=ComputerService; Trusted_Connection=True";   
                
                const string connectionString2 =
                    @"Server=HP\MPRZENZAKSQL; Initial Catalog=Computer_Service; Integrated Security=true; USER ID = root; PASSWORD = P@ssw0rd; TrustServerCertificate = true";
                using (SqlConnection conn = new SqlConnection(connectionString2))
                {
                    conn.Open();
                    Console.WriteLine(conn.State.ToString());
                    if (conn.State == System.Data.ConnectionState.Open)
                    {
                        using (SqlCommand cmd = conn.CreateCommand())
                        {
                            cmd.CommandText = GetProductsQuery;
                            using (SqlDataReader reader = cmd.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    var customer = new Customer();
                                    customer.clientID = reader.GetInt32(0);
                                    customer.email = reader.GetString(1);
                                    customer.firstname = reader.GetString(2);
                                    customer.lastname = reader.GetString(3);
                                    customer.phone = reader.GetInt32(4);
                                    customers.Add(customer);
                                }
                            }
                        }
                    }
                }

                return customers;
            }
            catch (Exception eSql)
            {
                Debug.WriteLine($"Exception: {eSql.Message}");
            }

            return null;
        }
    }
}