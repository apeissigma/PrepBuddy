using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace MealPlanDemo2
{
    internal class Planner
    {
        private string Logo = @"
_____  _____  _____  _____    _____  __ __  _____  _____ ___ ___
/  _  \/  _  \/   __\/  _  \  /  _  \/  |  \|  _  \|  _  \\  |  /
|   __/|  _  <|   __||   __/  |  _  <|  |  ||  |  ||  |  | |   | 
\__/   \__|\_/\_____/\__/     \_____/\_____/|_____/|_____/ \___/ 
               

";
        private string Description = "Welcome to PREP BUDDY, your go-to weekly meal planner!";

        // Array of weekdays to loop through
        private string[] DaysOfWeek = new string[7] { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" };
        // Array that stores each day's plan
        private List<Day> WeeklyPlan = new List<Day>();

        // Instantiated classes
        User user = new User();
        Day day = new Day();
        Meal meal = new Meal();
        IngredientShoppingList shoppingList = new IngredientShoppingList();

        public void Run()
        {
            DisplayIntro();
            WaitForKey();
            user.SetUserInfo();
            WaitForKey();
            Clear();
            SetDayMeal();
            Clear();
            DisplayPlan();
            shoppingList.DisplayShoppingList();

            ForegroundColor = ConsoleColor.DarkGray;
            WriteLine("\n> Press any key to exit...");
            ResetColor();
            ReadKey(true);
        }

        private void DisplayIntro()
        {
            ForegroundColor = ConsoleColor.DarkCyan;
            Write(Logo);
            ResetColor();
            WriteLine(Description);
        }

        private void SetDayMeal()
        {
            // Loop through each day of the week in DaysOfWeek array
            for (int i = 0; i < DaysOfWeek.Length; i++)
            {
                // Get day from array and assign to Day class's DayName
                day.DayName = DaysOfWeek[i];
                // Convert day.DayName to local dayName string
                string dayName = day.DayName;

                // Begin meal creation
                WriteLine($"\n-------------------------  {dayName}  -------------------------");
                WriteLine($"\nCreate a meal to make for {dayName}!");

                // Display leftovers hint
                ForegroundColor = ConsoleColor.DarkCyan;
                WriteLine($"* HINT! If you plan on having leftovers on {dayName}, write 'leftovers' as the meal name.");
                ResetColor();

                // Set meal name
                Write("\nEnter the name of the meal: ");
                string MealName = ReadLine().Trim();

                // Create meal's ingredients list
                List<Ingredient> MealIngredients = new List<Ingredient>();

                // Check if user chose leftovers as meal
                bool CreateIngredientLoop = true;

                // Check if user chose leftovers as meal; if true, skip CreateIngredientsLoop
                if (MealName == "leftovers")
                {
                    MealIngredients.Add(new Ingredient("None"));
                    CreateIngredientLoop = false;
                }
                
                // Loop through ingredient creation, assign to MealIngredients and ShoppingList
                while (CreateIngredientLoop)
                {
                    // Set ingredient name
                    Console.Write("\nEnter an ingredient: ");
                    string IngredientName = ReadLine();

                    // Add ingredient to MealIngredients and ShoppingList
                    MealIngredients.Add(new Ingredient(IngredientName));
                    shoppingList.ShoppingList.Add(new Ingredient(IngredientName));

                    // Display current ingredients in meal
                    WriteLine($"\nCurrent ingredients in {MealName}:");
                    /*
                     * Created with assistance from Ciarenn Hollis
                     */
                    for (int x = 0; x < MealIngredients.Count - 1; x++)
                    {
                        Write($"{MealIngredients[x].IngredientName}, ");
                    }
                    Write($"{MealIngredients[MealIngredients.Count - 1].IngredientName}");
                    
                    // Loop that handles exceptions (if user does not type 'y' or 'n')
                    bool UserIsChoosing = true;
                    while (UserIsChoosing)
                    {
                        Write("\n\nAdd another ingredient to the meal? (y/n): ");
                        var choice = ReadLine().ToLower().Trim();
                        switch (choice)
                        {
                            case ("y"):
                                CreateIngredientLoop = true;
                                UserIsChoosing = false;
                                break;
                            case ("n"):
                                // Exit loop
                                CreateIngredientLoop = false;
                                UserIsChoosing = false;
                                break;
                            default:
                                ForegroundColor = ConsoleColor.DarkGray;
                                WriteLine("Please enter a valid option.");
                                ResetColor();
                                UserIsChoosing = true;
                                break;
                        }
                    }
                    // Clear the console
                    Clear();

                    // Rewrite top portion of screen
                    WriteLine($"\n-------------------------  {dayName}  -------------------------");
                    WriteLine($"\nCreate a meal to make for {dayName}!");
                    ForegroundColor = ConsoleColor.DarkCyan;
                    WriteLine($"* HINT! If you plan on having leftovers on {dayName}, write 'leftovers' as the meal name.");
                    ResetColor();
                    WriteLine($"\nEnter the name of the meal: {MealName}");
                }

                // Create an instance of the Day object with the user set DayName and Meal
                /*
                 * Created with assistance from Prof. Janell Baxter
                 */
                WeeklyPlan.Add(new Day(dayName, new Meal(MealName, MealIngredients)));

                // Display meal

                WriteLine("\n---------------------------------------------");
                /*
                 * Created with assistance from Prof. Janell Baxter
                 */
                WriteLine(WeeklyPlan[i].DayMeal.DisplayMeal());
                WriteLine("---------------------------------------------");

                WaitForKey();
                Clear();
                // Loop to next day
            }
        }

        // Display weekly plan
        private void DisplayPlan()
        {
            ForegroundColor = ConsoleColor.DarkCyan;
            WriteLine("\n* HINT! Take a screenshot of this plan to save it for later!\n");
            ResetColor();
            WriteLine($"{user.UserName}'s meal plan for the week:");
            WriteLine("----------------------------------------------------------------------------------------------------------");
            WriteLine(" Day           | Meal               | Ingredients                                                      ");
            WriteLine("----------------------------------------------------------------------------------------------------------");
            /*
             * Created with reference to:
             * https://learn.microsoft.com/en-us/dotnet/api/system.string.format?view=net-8.0
             * https://medium.com/@patelrajni31/how-to-do-alignment-within-string-format-in-c-9ebd001da344
             */
            foreach (Day day in WeeklyPlan)
            {
                string output = String.Format("  {0,-13}|  {1, -18}|  {2, -5}", day.DayName, day.DayMeal.MealName, day.DayMeal.DisplayIngredients());
                WriteLine(output);
            }
            WriteLine("----------------------------------------------------------------------------------------------------------");
        }

        private void WaitForKey()
        {
            ForegroundColor = ConsoleColor.DarkGray ;
            WriteLine("\n> Press any key to continue...");
            ResetColor();
            ReadKey(true);
        }
    }   
}
