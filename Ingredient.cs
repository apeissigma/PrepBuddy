using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace MealPlanDemo2
{
    internal class Ingredient
    {
        public string IngredientName { get; private set; }

        public Ingredient()
        {
     
        }

        public Ingredient(string name)
        {
            IngredientName = name;
        }
    }
}
