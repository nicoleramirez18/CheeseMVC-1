using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
//need to add this to call the cheese class (pulls in namespace where cheese class lives)
using CheeseMVC.Models;
//need to add this in order to be able to create and use instances of the classes
using CheeseMVC.ViewModels;

namespace CheeseMVC.Controllers
{
    public class CheeseController : Controller
    {

        //static private List<Cheese> Cheeses = new List<Cheese>;
        //don't need this after creating cheese class

        // GET: /<controller>/
        public IActionResult Index()
        {
            //uses method to obtain data from cheesedata model
            //ViewBag.cheeses = CheeseData.GetAll();
            //equivalent to line above: ViewData["cheese"] = CheeseData.GetAll();

            //use viewmodel to eliminate issues with viewbag
            //pass data into view directly
            List<Cheese> cheeses = CheeseData.GetAll();
            //pass data into view using variable name, makes object available directly in view
            return View(cheeses);
        }

        public IActionResult Add()
        {
            //create new instance of view model
            AddCheeseViewModel addCheeseViewModel = new AddCheeseViewModel();
            return View(addCheeseViewModel);
        }

        /*
         [HttpPost]
         [Route("/Cheese/Add")]
         public IActionResult NewCheese(string name, string description = "")
         {

            //create a new cheese object
            //three lines of code below is the same as:
            //Cheese newCheese = new Cheese();
            //newCheese.Description = description;
            //newCheese.Name = name;

            //can use default constructor instead of code below:
            Cheese newCheese = new Cheese {
                Description = description;
                Name = name;
            };

            //Add new cheese to existing cheeses using newCheese object
            Cheeses.Add(newCheese);

            return Redirect("/Cheese");
         }
         */

        //parameter: we expect to receive a cheese object
        //no longer need to create the object in the method
        //will look for properties of cheese class, create new cheese object, and map those request values to the correct 
        //properties within the cheese class
        //name values (name, description) need to match the names of the properties of the objects in the class
        //model binding: model object you're trying ot bind to the incoming request by the framework (need defualt
        //constructor to work
        /*
         public IActionResult Add(Cheese newCheese)
         {
             /*
             //explanation of what this method is doing: use default constructor and create empty object
              Cheese newCheese = newCheese();
              newCheese.Name = Request.get("name");
              newCheese.Description = Request.get("description");


             // Add the new cheese to my existing cheeses
             CheeseData.Add(newCheese);

             return Redirect("/Cheese");
         }
         */

        //refactor code to use a viewmodel
        [HttpPost]
        public IActionResult Add(AddCheeseViewModel addCheeseViewModel)
        {
            //check if viewmodel is valid according to attributes created before creating new cheese
            if (ModelState.IsValid)
            {

                //add new cheese to existing cheeses by creating instance of cheese class
                //property initializer constructor uses curly braces instead of parentheses
                Cheese newCheese = new Cheese
                {
                    //use viewmodel object for carrier of data between controller and view on both sides of 
                    //add form (front and back end)
                    Name = addCheeseViewModel.Name,
                    Description = addCheeseViewModel.Description,
                    Type = addCheeseViewModel.Type
                };

                CheeseData.Add(newCheese);
                return Redirect("/Cheese");
            }

            //return user to rerender the form
            return View(addCheeseViewModel);
        }

        //display remove cheese form
        public IActionResult Remove()
        {
            ViewBag.title = "Remove Cheeses";
            ViewBag.cheeses = CheeseData.GetAll();
            return View();
        }

        //takes post requests
        [HttpPost]
        //in action receive array cheeseIds (comes from Remove view) that will be deleted
        //framework will populate integers corresponding with parameter cheeseIds
        public IActionResult Remove(int[] cheeseIds)
        {
            /*
            //use LINQ syntax to pull out item that needs to be removed
            //delete each of the cheeses from the list
            //loop over integer cheeseIds that we want to delete
            //match all items in cheeses list where cheese id matches item in loop iteration
            //find cheese with particular id and remove it
            foreach (int cheeseId in cheeseIds)
            {
                Cheese.RemoveAll(x => x.cheeseId == cheeseId);
            }
            */
            foreach (int cheeseId in cheeseIds)
            {
                CheeseData.Remove(cheeseId);
            }

            //redirect to homepage
            return Redirect("/");
        }

        //TODO: after creating ViewModel, use it in both Edit actions
        // initialize the cheeseId in the Edit action that displays the form 
        //(since we're populating the form with the data from an existing cheese
        public IActionResult Edit(int CheeseId)
        {
            AddEditCheeseViewModel addEditCheeseViewModel = new AddEditCheeseViewModel();
            CheeseId = addEditCheeseViewModel.ID;
            return View(addEditCheeseViewModel);
        }

        [HttpPost]
        public IActionResult Edit(int cheeseId, string name, string description)
        {
            //query CheeseData for the cheese with the given id
            var cheese = CheeseData.GetById(cheeseId);

            //update its name and description
           cheese.Name = name;
           cheese.Description = description;

            return Redirect("/");
        }
    }
}
