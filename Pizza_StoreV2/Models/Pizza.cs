using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Pizza_StoreV2.Pages;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
namespace Pizza_StoreV2.Models
{
    public class Pizza
    {
        #region Instance Field
        private int _price;
        private string _name;
        private int _pizzaId;
        #endregion

        #region Constructor
        public Pizza()
        {
            _name = Name;
            _price = Price;
            _pizzaId = PizzaId;
        }
        #endregion

        #region Properties
        [BindProperty]
        [Display(Name="Pizza price")]
        [Required(ErrorMessage ="The '{0}' is required")]
        [Range(70,120,ErrorMessage ="Price must be between 70 and 120 kr.")]
        [DataType(DataType.Currency)]
        public int Price
        {
            get;set;
        }
        [Display(Name = "Pizza name")]
        [Required(ErrorMessage = "Please enter a pizza name"), MaxLength(15)]
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        [Display(Name="Pizza ID")]
        [Required(ErrorMessage ="The '{0}' is required")]
        [Range(1,10)]
        public int PizzaId
        {
            get;set;
        }
        #endregion

        #region Methods
        public override string ToString()
        {
            return $"{PizzaId}-{Name} - Price:{Price}";
        }
        #endregion
    }
}
