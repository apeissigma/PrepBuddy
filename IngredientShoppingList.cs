using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace MealPlanDemo2
{
    internal class IngredientShoppingList
    {
        public List<Ingredient> ShoppingList = new List<Ingredient>();

        public IngredientShoppingList()
        {

        }

        public void DisplayShoppingList()
        {
            WriteLine($"\nYour shopping list for the week:");
            foreach (Ingredient ingredient in ShoppingList)
            {
                WriteLine($"    > {ingredient.IngredientName}");
            }    
        }
    }
}
