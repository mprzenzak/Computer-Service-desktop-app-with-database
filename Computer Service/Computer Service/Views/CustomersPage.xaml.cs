using Computer_Service.Models;
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
using System;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Diagnostics;
using Windows.UI.Xaml.Controls;
using Computer_Service.Models;


namespace Computer_Service.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class CustomersView : Page
    {
        public CustomersView()
        {
            this.InitializeComponent();
            CustomersList.ItemsSource = GetProducts((App.Current as App).ConnectionString);
        }

        // Display all customers
        public ObservableCollection<Customer> GetProducts(string connectionString)
        {
            const string GetProductsQuery = "SELECT customer_id, firstname, lastname, phone, email" +
                                            " FROM dbo.Customers";
            var customers = new ObservableCollection<Customer>();
            try
            {
                //// const string connectionString2 = "SERVER=HP\\MPRZENZAKSQL;Database=Computer_Service_Project; USER ID = sa; PASSWORD = Babkaloj1202";
                //const string connectionString2 =
                //    "Server=HP\\MPRZENZAKSQL; Database=ComputerService; Trusted_Connection=True";   

                //const string connectionString2 =
                //    @"Server=HP\MPRZENZAKSQL; Initial Catalog=Computer_Service; Integrated Security=true; USER ID = sa; PASSWORD = P@ssw0rd; TrustServerCertificate = true";
                //const string connectionString2 = "Server=HP\\MPRZENZAKSQL; Database=ComputerService; Trusted_Connection=True";
                //const string connectionString2 = "Server=tcp:computer-service.database.windows.net,1433;Initial Catalog=Computer Service;Persist Security Info=False;User ID=zzub;Password=P@ssw0rd;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
                const string connectionString2 =
                    "Data Source=HP\\MPRZENZAKSQL;Initial Catalog=Computer_Service;Persist Security Info=True;User ID=sa;Password=P@ssw0rd";
                using (SqlConnection conn = new SqlConnection(connectionString2))
                {
                    conn.Open();
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
                                    customer.customer_id = reader.GetString(0);
                                    customer.firstname = reader.GetString(1);
                                    customer.lastname = reader.GetString(2);
                                    customer.phone = reader.GetInt32(3);
                                    customer.email = reader.GetString(4);
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