using CheeseMvc.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CheeseMvc.ViewModels
{
    public class AddCheeseViewModel
    {
        [Required (ErrorMessage="You must have Name")]
        [Display(Name="Cheese Name") ]
   
        public string  Name { get; set; }
        [Required(ErrorMessage = "You must Have Description")]
        [Display(Name = "Cheese Description")]
        public string Description { get; set; }
        public CheeseType Type { get; set; }
        public List<SelectListItem> CheeseTypes{ get; set; }
        [Required]
        [Range(1,5)]
        public int Rating{ get; set; }
        public AddCheeseViewModel()
        {
             CheeseTypes= new List<SelectListItem>();
            CheeseTypes.Add(new SelectListItem
            {
                Value =((int)CheeseType.Hard).ToString(),
                Text = CheeseType.Hard.ToString()
            });
            CheeseTypes.Add(new SelectListItem
            {
                Value = ((int)CheeseType.Soft).ToString(),
                Text = CheeseType.Soft.ToString()
            });
            CheeseTypes.Add(new SelectListItem
            {
                Value = ((int)CheeseType.Fake).ToString(),
                Text = CheeseType.Fake.ToString()
            });
        }
        public Cheese CreateCheese()
        {
            return new Cheese
            {
                Name = this.Name,
                Description = this.Description,
                Type = this.Type,
                Rating = this.Rating
            };
        }


    }
}
