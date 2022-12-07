using Computer_Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Computer_Service.ViewModels
{
    public class CustomerViewModel
    {
        public CustomerViewModel(Customer model)
        {
            Model = model ?? new Customer();
        }

        /// <summary>
        /// The underlying customer model. Internal so it is 
        /// not visible to the RadDataGrid. 
        /// </summary>
        internal Customer Model { get; set; }

        /// <summary>
        /// Gets or sets whether the underlying model has been modified. 
        /// This is used when sync'ing with the server to reduce load
        /// and only upload the models that changed.
        /// </summary>
        internal bool IsModified { get; set; }

        public string FirstName
        {
            get => Model.firstname;
            set
            {
                if (value != Model.firstname)
                {
                    Model.firstname = value;
                    IsModified = true;
                }
            }
        }

        /// <summary>
        /// Gets or sets the customer's last name.
        /// </summary>
        public string LastName
        {
            get => Model.lastname;
            set
            {
                if (value != Model.lastname)
                {
                    Model.lastname = value;
                    IsModified = true;
                }
            }
        }

        /// <summary>
        /// Gets or sets the customer's email address.
        /// </summary>
        public string email
        {
            get => Model.email;
            set
            {
                if (value != Model.email)
                {
                    Model.email = value;
                    IsModified = true;
                }
            }
        }

        /// <summary>
        /// Gets or sets the customer's phone number.
        /// </summary>
        public int Phone
        {
            get => Model.phone;
            set
            {
                if (value != Model.phone)
                {
                    Model.phone = value;
                    IsModified = true;
                }
            }
        }
    }
}
