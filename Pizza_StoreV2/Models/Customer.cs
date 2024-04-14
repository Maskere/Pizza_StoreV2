using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Pizza_StoreV2.Catalogs;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace Pizza_StoreV2.Models
{
    public class Customer
    {
        #region Instance Field
        private string _customerName;
        private string _email;
        private string _phoneNumber;
        private int _customerId;
        #endregion

        #region Constructor
        public Customer()
        {
            _customerName = CustomerName;
            _phoneNumber = PhoneNumber;
            _email = Email;
            _customerId = CustomerId;
        }
        #endregion

        #region Properties
        [Display(Name ="Customer name")]
        [Required(ErrorMessage ="Please enter a name")]
        public string CustomerName
        {
            get { return _customerName; }
            set { _customerName = value; }
        }
        [DataType(DataType.PhoneNumber)]
        [Range(8,8,ErrorMessage ="Phone number must have 8 digits")]
        public string PhoneNumber
        {
            get { return _phoneNumber; }
            set { _phoneNumber = value; }
        }
        [DataType(DataType.EmailAddress)]
        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }
        
        public int CustomerId
        {
            get { return _customerId; }
            set { _customerId = value; }
        }
        #endregion

        #region Methods
        public override string ToString()
        {
            return $"{CustomerId}-{CustomerName}";
        }
        #endregion
    }
}
