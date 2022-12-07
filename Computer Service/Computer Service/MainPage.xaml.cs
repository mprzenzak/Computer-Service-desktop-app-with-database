﻿using System;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using Windows.UI.Xaml.Controls;
using Computer_Service.Models;
using Computer_Service.Views;
using Windows.Security.Isolation;
using System.Text;

namespace Computer_Service
{
    public sealed partial class MainPage : Page
    {
        private DataBaseContext dbContext = new DataBaseContext();

        private static string login;
        private static string password;
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void LoginButtonClick(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            login = LoginInput.Text;
            password = PasswordInput.Text;

            var correctPassword = dbContext.Credentials.FirstOrDefault(c => c.login == login);
            if (correctPassword != null && password == correctPassword.password)
            {
                if(login.Substring(0, 1) == "K")
                {
                    Frame.Navigate(typeof(CustomerPanel), dbContext);
                }
                else
                {
                    Frame.Navigate(typeof(EmployeePanel), dbContext);
                }
            }
            else
            {
                IncorrectPasswordLabel.Text = "Niepoprawny login lub hasło!";
            }
        }

        private void RegisterButtonClick(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            var newFirstname = registerFirstnameInput.Text;
            var newLastname = registerLastnameInput.Text;
            var newEmail = registerEmailInput.Text;
            var newPhoneNumber = Int32.Parse(registerPhoneNumberInput.Text);

            var newCustomer = new Customer()
            {
                customer_id = GenerateUserID('K'),
                firstname = newFirstname,
                lastname = newLastname,
                email = newEmail,
                phone = newPhoneNumber,
            };
            dbContext.Customers.Add(newCustomer);
            dbContext.SaveChanges();

            userAddedInfoLabel.Text = "Konto zostało utworzone";
        }

        private string GenerateUserID(char userType)
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