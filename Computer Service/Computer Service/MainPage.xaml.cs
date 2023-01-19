using System;
using System.Linq;
using Windows.UI.Xaml.Controls;
using Computer_Service.Models;
using Computer_Service.Views;
using System.Text;
using System.Text.RegularExpressions;

namespace Computer_Service
{
    public sealed partial class MainPage : Page
    {
        private static string login;
        private static string password;
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void LoginButtonClick(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            login = LoginInput.Text;
            password = PasswordInput.Password;

            if (login != "")
            {
                if (login.Substring(0, 1) == "K")
                {
                    DataBaseContext dbContext = new DataBaseContext("customer");
                    bool passwordIsValid = ValidatePassword(dbContext);
                    if (passwordIsValid)
                    {
                        Frame.Navigate(typeof(CustomerPanel), dbContext);
                    }
                }
                else if (login.Substring(0, 1) == "P")
                {
                    DataBaseContext dbContext = new DataBaseContext("employee");
                    bool passwordIsValid = ValidatePassword(dbContext);
                    if (passwordIsValid)
                    {
                        Frame.Navigate(typeof(EmployeePanel), dbContext);
                    }
                }
                else
                {
                    IncorrectPasswordLabel.Text = "Niepoprawny login lub hasło!";
                }
            }
            else
            {
                IncorrectPasswordLabel.Text = "Podaj login!";
            }
        }

        private bool ValidatePassword(DataBaseContext dbContext)
        {
            var correctPassword = dbContext.Credentials.FirstOrDefault(c => c.login == login);
            if (correctPassword != null && password == correctPassword.password)
            {
                return true;
            }
            else
            {
                IncorrectPasswordLabel.Text = "Niepoprawny login lub hasło!";
                return false;
            }
        }

        private void RegisterButtonClick(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            // clear all alerts
            userAddedInfoLabel.Text = string.Empty;
            noEmailAlert.Text = string.Empty;   
            noNameAlert.Text = string.Empty;
            noLastnameAlert.Text = string.Empty;
            noPasswordAlert.Text = string.Empty;
            noPhoneNumberAlert.Text = string.Empty;
            noEmailAlert.Text = string.Empty;

            bool allRequiredFieldsFulfilled = true;
            int newPhoneNumber = 0;

            if (string.IsNullOrEmpty(registerFirstnameInput.Text))
            {
                noNameAlert.Text = "Podaj imię!";
                allRequiredFieldsFulfilled = false;
            }
            if (string.IsNullOrEmpty(registerLastnameInput.Text))
            {
                noLastnameAlert.Text = "Podaj nazwisko!";
                allRequiredFieldsFulfilled = false;
            }
            if (string.IsNullOrEmpty(registerEmailInput.Text))
            {
                noEmailAlert.Text = "Podaj email!";
                allRequiredFieldsFulfilled = false;
            }
            else
            {
                bool emailIsValid = ValidateEmail(registerEmailInput.Text);
                if (!emailIsValid)
                {
                    noEmailAlert.Text = "Podany email jest niepoprawny!";
                    allRequiredFieldsFulfilled = false;
                }
            }
            if (string.IsNullOrEmpty(registerPhoneNumberInput.Text))
            {
                noPhoneNumberAlert.Text = "Podaj numer telefonu!";
                allRequiredFieldsFulfilled = false;
            }
            else
            {
                bool repairIdIsNumber = int.TryParse(registerPhoneNumberInput.Text, out newPhoneNumber);
                if (!repairIdIsNumber || registerPhoneNumberInput.Text.Length < 9)
                {
                    noPhoneNumberAlert.Text = "Numer telefonu musi składać się z 9 cyfr.";
                    allRequiredFieldsFulfilled = false;
                }
            }

            if (allRequiredFieldsFulfilled && registerPasswordInput.Password == registerPasswordInputRepetition.Password && ValidatePassword(registerPasswordInputRepetition.Password))
            {
                DataBaseContext dbContext = new DataBaseContext("customer");

                var newFirstname = registerFirstnameInput.Text;
                var newLastname = registerLastnameInput.Text;
                var newEmail = registerEmailInput.Text;
                var newCustomerId = GenerateUserID('K', dbContext);
                var newPassword = registerPasswordInputRepetition.Password;

                var newCustomer = new Customer()
                {
                    customer_id = newCustomerId,
                    firstname = newFirstname,
                    lastname = newLastname,
                    email = newEmail,
                    phone = newPhoneNumber,
                };
                dbContext.Customers.Add(newCustomer);

                var newCustomerCredentials = new Credentials()
                {
                    login = newCustomerId,
                    password = newPassword,
                };
                dbContext.Credentials.Add(newCustomerCredentials);
                dbContext.SaveChanges();

                userAddedInfoLabel.Text = "Konto zostało utworzone. Twój numer klienta to: " + newCustomerId;
            }
            else
            {
                userAddedInfoLabel.Text = "Podane hasła nie są jednakowe lub nie spełniają określonych wymogów";
            }
        }

        private bool ValidatePassword(string password)
        {
            return Regex.IsMatch(password, @"^(?=.*[a-zA-Z])(?=.*[0-9])(?=.{8,}).*$");
        }

        bool ValidateEmail(string email)
        {
            var trimmedEmail = email.Trim();

            if (trimmedEmail.EndsWith("."))
            {
                return false;
            }
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == trimmedEmail;
            }
            catch
            {
                return false;
            }
        }

        private string GenerateUserID(char userType, DataBaseContext dbContext)
        {
            string currentLastID = dbContext.Customers.OrderByDescending(c => c.customer_id).FirstOrDefault().customer_id;
            int substringLength = 0;
            for (int charPosition = 1; charPosition <= currentLastID.Length; charPosition++)
            {
                if (currentLastID[charPosition] != '0')
                {
                    substringLength = charPosition;
                    break;
                }

            }
            int newIDValue = Int32.Parse(currentLastID.Substring(substringLength));
            string newIDValueString = (newIDValue + 1).ToString();
            int n = 6 - newIDValueString.Length;
            StringBuilder idDigitsString = new StringBuilder();
            for (int i = 0; i < n; i++)
            {
                idDigitsString.Append('0');
            }

            idDigitsString.Append(newIDValueString);
            string newID = userType + idDigitsString.ToString();
            return newID;
        }

        private void registerPhoneNumberInput_TextChanging(TextBox sender, TextBoxTextChangingEventArgs args)
        {
            var previousValue = registerPhoneNumberInput.Text;
            foreach (Char c in registerPhoneNumberInput.Text)
            {
                if (!Char.IsDigit(c))
                {
                    registerPhoneNumberInput.Text = previousValue.Remove(previousValue.Length - 1);
                    return;
                }
            }
        }
    }
}