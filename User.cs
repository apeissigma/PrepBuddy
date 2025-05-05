using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace MealPlanDemo2
{
    internal class User
    {
        public string UserName { get; private set; }

        public void SetUserInfo()
        {
            Write("\nPlease enter your name: ");
            UserName = ReadLine();
            WriteLine($"Hello {UserName}!");
        }
    }
}
