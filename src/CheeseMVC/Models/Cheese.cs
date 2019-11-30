using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CheeseMVC.Models
{
    public class Cheese
    {
        public string Name { get; set; }
        public string Description { get; set; }
        //added class to describe each cheese type
        //CheeseType is the class that holds the values for the types of cheese
        public CheeseType Type { get; set; }
        //data field that is unique to each object
        public int CheeseId { get; set; }
        //used internally to initially be one
        private static int nextId = 1;

        //need public constructor to create new cheese class
        /*
         * public Cheese(string name, string description)
        {
            Name = name;
            Description = description;
        }
        */

        //default constructor (empty) is automatically called when created
        //set CheeseId to next available integer, then increment id for the next cheese object created
        public Cheese()
        {
            CheeseId = nextId;
            nextId++;

            //if you want to put a default property into the constructor
            //Type = CheeseType.Hard;
        }
    }
}
