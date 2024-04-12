using Microsoft.AspNetCore.Mvc.ModelBinding;
using Pizza_StoreV2.Pages;
using System;
using System.Collections.Generic;
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
        [Range(70,120,ErrorMessage ="Price must be between 70 and 120 kr.")]
        [DataType(DataType.Currency,ErrorMessage ="Please enter a price")]
        public int Price
        {
            get { return _price; }
            set { _price = value; }
        }
        [Display(Name = "Pizza name")]
        [Required(ErrorMessage = "Pizza name is required"), MaxLength(15)]
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public int PizzaId
        {
            get { return _pizzaId; }
            set { _pizzaId = value; }
        }
        #endregion

        #region Methods
        public override string ToString()
        {
            return $"{PizzaId} {Name} - Price:{Price}";
        }
        #endregion
    }
}
