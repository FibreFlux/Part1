using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ST10058057_PROG6221_PortfolioOfEvidencePart1
{
    internal class Program
    {
        public static string[] recipeArr = new string[50];
        

        static void Main(string[] args)
        {
            int ingCount = 0;
            string nameOfIngrediant;
            int quantity;
            string unitOfMeasurement;
            string recipe;
            Console.WriteLine("Please enter the recipe that you would like to make");
            recipe = Console.ReadLine();
            Console.WriteLine("Please enter how much ingrediants for your recipe");
            int noOfIngrediants = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < noOfIngrediants; i++)
            {
                Console.WriteLine("Please enter the name of the ingrediant");
                nameOfIngrediant = Console.ReadLine();
                Console.WriteLine("Please enter how much " + nameOfIngrediant + " you need to add to the recipe");
                quantity = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Please enter the ingrediant's unit of measurement");
                unitOfMeasurement = Console.ReadLine();
                recipeArr[i] = "Ingrediant: " + nameOfIngrediant + "\nQuantity: " + quantity + " " + unitOfMeasurement + "\n";
                ingCount++;
                
            }

            foreach (var recipes in recipeArr)
            {
                if (recipes != null)
                    Console.WriteLine(recipes);
            }
           
        }

        
    }
}
