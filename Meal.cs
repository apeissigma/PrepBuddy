using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace MealPlanDemo2
{
    internal class Meal
    {
        public string MealName { get; private set; }
        List<Ingredient> MealIngredients = new List<Ingredient>();

        Ingredient ingredient = new Ingredient();

        public Meal()
        {

        }

        public Meal(string name, List<Ingredient> mealIngredients)
        {
            MealName = name;
            MealIngredients = mealIngredients;
        }

        /*
         * Created with assistance from Prof. McDonald 
         */
        public string DisplayMeal()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"Meal: {MealName}");
            sb.Append("\nIngredients: ");
            foreach (Ingredient ingredient in MealIngredients)
            {
                sb.Append($"\n    > {ingredient.IngredientName}");
            }
            return sb.ToString();
        }

        public string DisplayIngredients()
        {
            StringBuilder sb = new StringBuilder();
            /*
             * Created with assistance from Ciarenn Hollis
             */
            for (int i = 0; i < (MealIngredients.Count - 1); i++)
            {
                sb.Append($"{MealIngredients[i].IngredientName}, ");
            }
            sb.Append($"{MealIngredients[MealIngredients.Count - 1].IngredientName}");

            return sb.ToString();
        }
    }
}
