using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CheeseMVC.Models
{
    //enum: short for enumeration (stores finite set of values)
    //used for categorical, fixed types of data
    public enum CheeseType
    {
        //use enums instead of defining each type of cheese in a class
        //public const string Hard = "hard";
        //public const string Soft = "soft";

        //enum values are internally represented as integers
        //named constant integers that were defined in this enum
        Hard, Soft, Fake
    }
}
