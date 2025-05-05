using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace MealPlanDemo2
{
    internal class Day
    {
        public string DayName;
        public Meal DayMeal;

        Meal meal = new Meal();

        public Day()
        {

        }

        public Day(string name, Meal meal)
        {
            DayName = name;
            DayMeal = meal;
        }
    }
}
