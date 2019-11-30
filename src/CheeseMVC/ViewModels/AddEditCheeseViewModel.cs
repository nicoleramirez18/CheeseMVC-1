using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using CheeseMVC.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CheeseMVC.ViewModels
{
    public class AddEditCheeseViewModel : AddCheeseViewModel
    {
        public int ID { get; set; }

        public static AddEditCheeseViewModel AddEditCheese(Cheese cheese)
        {
            AddEditCheeseViewModel edit = new AddEditCheeseViewModel
            {
                ID = cheese.CheeseId,
                Name = cheese.Name,
                Description = cheese.Description,
            };
            return edit;
        }
 
    }
}
