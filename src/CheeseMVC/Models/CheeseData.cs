using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CheeseMVC.Models
{
    public class CheeseData
    {
        //pull list from cheese controller and put here
        static private List<Cheese> cheeses = new List<Cheese>();

        //include mthods that correspond with ways that you might access data
        //refactor controller to include these methods

        // GetAll
        public static List<Cheese> GetAll()
        {
            return cheeses;
        }

        // Add
        //have to use void when it will not return anything
        public static void Add(Cheese newCheese)
        {
            cheeses.Add(newCheese);
        }

        // Remove
        public static void Remove(int id)
        {
            Cheese cheeseToRemove = GetById(id);
            cheeses.Remove(cheeseToRemove);
        }

        // GetById
        public static Cheese GetById(int id)
        {
            //LINQ syntax
            //single: query /find from the list / collection of a single element / item
            //will throw an exception if there's more than one item found
            return cheeses.Single(x => x.CheeseId == id);
        }


    }
}
