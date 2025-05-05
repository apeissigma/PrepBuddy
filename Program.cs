using static System.Console;

namespace MealPlanDemo2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Title = "Prep Buddy";
            Planner planner = new Planner();
            planner.Run();
        }
    }
}
