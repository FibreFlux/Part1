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
    internal class Ingrediants
    {
        public string recipe;
        public string[] ingNameArr = new string[50];
        public int[] quantityArr = new int[50];
        public string[] measurementArr = new string[50];
        public string[] stepsArr = new string[50];

        static void Main()
        {
            new Ingrediants().addRecipe();
        }

        public void addRecipe() 
        {
            int ingCount = 0;
            int stepCount = 0;
            Console.WriteLine("Please enter the recipe that you would like to make");
            recipe = Console.ReadLine();
            Console.WriteLine("Please enter how much ingrediants for your recipe");
            int noOfIngrediants = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < noOfIngrediants; i++)
            {
                Console.WriteLine("Please enter the name of the ingrediant");
                ingNameArr[i] = Console.ReadLine();

                Console.WriteLine("Please enter how much " + ingNameArr[i] + " you need to add to the recipe");
                quantityArr[i] = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Please enter the ingrediant's unit of measurement");
                measurementArr[i] = Console.ReadLine();
                ingCount++;
            }

            Console.WriteLine("How many steps are required to make this recipe");
            stepCount = Convert.ToInt32(Console.ReadLine());
            steps(stepCount);
            displayRecipe();
            new RecipeMenu();
        }

        public int steps(int noOfSteps)
        {
            
            for (int i = 0; i < noOfSteps; i++)
            {
                Console.WriteLine($"Enter the description for step {i+1} ");
                stepsArr[i] = Console.ReadLine();
                Console.WriteLine();
            }  
            return noOfSteps;
        }

        public void displayRecipe()
        {
            int stepIndex = 1;
            
            Console.WriteLine("Recipe: {0}", recipe + "\n");
            Console.WriteLine("Ingrediants:");
            for (int i = 0; i < ingNameArr.Length; i++)
            {
                if (ingNameArr[i] != null)
                    Console.WriteLine("Name: " + ingNameArr[i] + "\tQuantity: " + quantityArr[i] + " " + measurementArr[i]);

            }
            
            Console.WriteLine("\nSteps:");
            foreach (var steps in stepsArr)
                if (steps != null)
                    Console.WriteLine($"{stepIndex++}. " + steps);
            Console.WriteLine();

        }

        public void scaleQuantity() 
        {
        }

        public void quantityReset() 
        { 
        }
        public void clear() {
            Console.WriteLine("Are you sure you would like to clear this recipe Yes/No");
            string clearAnswer = Console.ReadLine();
            if (clearAnswer.Equals("Yes"))
            {
                Array.Clear(ingNameArr, 0, ingNameArr.Length);
                Array.Clear(quantityArr, 0, quantityArr.Length);
                Array.Clear(measurementArr, 0, measurementArr.Length);
                Array.Clear(stepsArr, 0, stepsArr.Length);
                Console.WriteLine("Recipe has been cleared!");
                new RecipeMenu();

            }
            else if (clearAnswer.Equals("No")){
                new RecipeMenu();
            }
            
        }

    }
}
