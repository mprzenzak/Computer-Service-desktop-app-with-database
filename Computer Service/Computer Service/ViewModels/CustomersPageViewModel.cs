using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Computer_Service.ViewModels
{
    public class CustomersPageViewModel : INotifyPropertyChanged
    {
        public CustomersPageViewModel()
        {
            Task.Run(GetCustomerListAsync);
        }

        public bool EnableCommandBar => !AddingNewCustomer;

        private bool addingNewCustomer = false;

        public bool AddingNewCustomer
        {
            get => addingNewCustomer;
            set
            {
                OnPropertyChanged(nameof(EnableCommandBar));
                if (addingNewCustomer != value)
                {
                    addingNewCustomer = value;
                    OnPropertyChanged();
                }
            }
        }

        private CustomerViewModel _newCustomer;

        public CustomerViewModel NewCustomer
        {
            get => _newCustomer;
            set
            {
                if (_newCustomer != value)
                {
                    _newCustomer = value;
                    OnPropertyChanged();
                }
            }
        }

        private ObservableCollection<CustomerViewModel> _customers = new ObservableCollection<CustomerViewModel>();

        public ObservableCollection<CustomerViewModel> Customers { get => _customers; }


        private CustomerViewModel _selectedCustomer;

        public CustomerViewModel SelectedCustomer
        {
            get => _selectedCustomer;
            set
            {
                if (_selectedCustomer != value)
                {
                    _selectedCustomer = value;
                    OnPropertyChanged();
                }
            }
        }

        public async Task CreateNewCustomerAsync()
        {
            //CustomerViewModel newCustomer = new CustomerViewModel(new Models.Customer());
            //NewCustomer = newCustomer;
            //await App.Repository.Customers.UpsertAsync(NewCustomer.Model);
            //AddingNewCustomer = true;

            //const string query =
            //    "INSERT INTO Customers(customer_id,firstname,lastname,phone,email) VALUES (5,'Jacek','Elacek','523456789','e@gmail.com')";
        }

        public async Task DeleteNewCustomerAsync()
        {
            /*if (NewCustomer != null)
            {
                await App.Repository.Customers.DeleteAsync(_newCustomer.Model.Id);
                AddingNewCustomer = false;
            }*/
        }

        public async void DeleteAndUpdateAsync()
        {
            //if (SelectedCustomer != null)
            //{
            //    await App.Repository.Customers.DeleteAsync(_selectedCustomer.Model.Id);
            //}
            //await UpdateCustomersAsync();
        }

        public async Task GetCustomerListAsync()
        {
            //var customers = await App.Repository.Customers.GetAsync();
            //if (customers == null)
            //{
            //    return;
            //}
            //await DispatcherHelper.ExecuteOnUIThreadAsync(() =>
            //{
            //    Customers.Clear();
            //    foreach (var c in customers)
            //    {
            //        Customers.Add(new CustomerViewModel(c));
            //    }
            //});
        }

        public async Task SaveInitialChangesAsync()
        {
            //await App.Repository.Customers.UpsertAsync(NewCustomer.Model);
            //await UpdateCustomersAsync();
            //AddingNewCustomer = false;
        }

        public async Task UpdateCustomersAsync()
        {
            //foreach (var modifiedCustomer in Customers
            //             .Where(x => x.IsModified).Select(x => x.Model))
            //{
            //    await App.Repository.Customers.UpsertAsync(modifiedCustomer);
            //}
            //await GetCustomerListAsync();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected bool SetField<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(field, value)) return false;
            field = value;
            OnPropertyChanged(propertyName);
            return true;
        }
    }
}
