using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CheeseMvc.Models;
using CheeseMvc.ViewModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CheeseMvc.Controllers
{
    public class CheeseController : Controller
    {
        // GET: /<controller>/
        
        public IActionResult Index()
        {
            // to get list of all data from ClassData and form the view
  
            List<Cheese> cheeses = CheeseData.GetAll();
            return View(cheeses);
        }
        public IActionResult Add()
        {
            AddCheeseViewModel addCheeseViewModel = new AddCheeseViewModel();
            return View(addCheeseViewModel);
        }

        [HttpPost]
        [Route("/Cheese/Add")]
        public IActionResult Add(AddCheeseViewModel addCheeseViewModel)
            // the giveing  object parameter insted of name and description
        {
            if (ModelState.IsValid)
            {
                Cheese newCheese = addCheeseViewModel.CreateCheese();
              
                CheeseData.Add(newCheese);
                return Redirect("/Cheese");
            }

            return View(addCheeseViewModel);   
           
        }
        public IActionResult Remove()
        {
            ViewBag.title = "Remove Cheese";
            // to get all list
            ViewBag.cheeses = CheeseData.GetAll();
            return View();
        }
        [HttpPost]
        public IActionResult Remove(int[] cheeseIds)
        {
            foreach(int cheeseId in cheeseIds)
            {
                //calling method form cheesedata to remove cheeses
                CheeseData.Remove(cheeseId);
            }
            return Redirect("/");
        }
        public IActionResult Edit(int cheeseId)
        {
            Cheese ch = CheeseData.GetById(cheeseId);
            AddEditCheeseViewModel vm = new AddEditCheeseViewModel(ch);
            return View(vm);
        }
        [HttpPost]
        public IActionResult Edit(AddEditCheeseViewModel vm)
        {
            if (ModelState.IsValid)
            {
                Cheese ch = CheeseData.GetById(vm.CheeseId);
                ch.Name = vm.Name;
                ch.Description = vm.Description;
                ch.Type = vm.Type;
                ch.Rating = vm.Rating;
                Console.WriteLine("This is Name" + ch.Name);
                return Redirect("/Cheese");
            }
          
            return View(vm);

        }
    }
}
