using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ST10058057_PROG6221_PortfolioOfEvidencePart1
{
    class Ingrediants
    {
        public static string recipe;
        public static string[] ingNameArr = new string[50];
        public static double[] quantityArr = new double[50];
        public static string[] measurementArr = new string[50];
        public static string[] stepsArr = new string[50];
        public static double[] originalQuantities = new double[50];
        static void Main()
        {
            AddRecipe();
        }

        public static void AddRecipe() 
        {
            int ingCount = 0;
            int stepCount;
            Console.WriteLine("Please enter the recipe that you would like to make");
            recipe = Console.ReadLine();
            Console.WriteLine("Please enter how much ingrediants for your recipe");
            int noOfIngrediants = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < noOfIngrediants; i++)
            {
                Console.WriteLine("Please enter the name of the ingrediant");
                ingNameArr[i] = Console.ReadLine();

                Console.WriteLine("Please enter how much " + ingNameArr[i] + " you need to add to the recipe");
                quantityArr[i] = Convert.ToDouble(Console.ReadLine());
                originalQuantities[i] = quantityArr[i];

                Console.WriteLine("Please enter the ingrediant's unit of measurement");
                measurementArr[i] = Console.ReadLine();
                ingCount++;
            }

            Console.WriteLine("How many steps are required to make this recipe");
            stepCount = Convert.ToInt32(Console.ReadLine());
            Steps(stepCount);
            RecipeConversion();
            DisplayRecipe();
            new RecipeMenu();
        }

        public static int Steps(int noOfSteps)
        {
            
            for (int i = 0; i < noOfSteps; i++)
            {
                Console.WriteLine($"Enter the description for step {i+1} ");
                stepsArr[i] = Console.ReadLine();
                Console.WriteLine();
            }  
            return noOfSteps;
        }

        public static void DisplayRecipe()
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

        public static void ScaleQuantity() 
        {
            Console.WriteLine("Would you like to scale your recipe by 0.5, 2 or 3");
            double scale = Convert.ToDouble(Console.ReadLine());
            switch (scale)
            {
                case 0.5:
                    for (int i = 0; i < quantityArr.Length; i++)
                        quantityArr[i] *= scale;
                    break;
                case 2:
                    for (int i = 0; i < quantityArr.Length; i++)
                        quantityArr[i] *= scale;
                    break;
                case 3:
                    for (int i = 0; i < quantityArr.Length; i++)
                        quantityArr[i] *= scale;
                    break;
                default:
                    Console.WriteLine("Scaling option not avaliable");
                    break;
            }
            RecipeConversion();
            DisplayRecipe();
        }

        public static void RecipeConversion()
        {
            int remainder;

            for (int j = 0; j < quantityArr.Length; j++)
            {
                if (measurementArr[j] != null)
                {
                    if (measurementArr[j].Equals("tablespoons"))
                    {
                        remainder = (int)quantityArr[j] % 16;
                        if (quantityArr[j] >= 16 && remainder == 0)
                        {
                            quantityArr[j] = quantityArr[j] / 16;
                            measurementArr[j] = "cups";
                        }
                        else if (quantityArr[j] >= 16 && remainder > 0)
                        {
                            quantityArr[j] = (int)quantityArr[j] / 16;
                            measurementArr[j] = "cups and " + remainder + " tablespoons";
                        }
                    }

                    else if (measurementArr[j].Equals("teaspoons")) 
                    {
                         remainder = (int)quantityArr[j] % 3;
                         if (quantityArr[j] >= 3 && remainder == 0)
                         {
                            quantityArr[j] = quantityArr[j] / 3;
                            measurementArr[j] = "cups";
                         }
                         else if (quantityArr[j] >= 3 && remainder > 0)
                         {
                            quantityArr[j] = (int)quantityArr[j] / 3;
                            measurementArr[j] = "tablespoons and " + remainder + " teaspoons";
                         }
                    }
                }
            }
        }

        public static void QuantityReset()
        {
            Console.WriteLine("Would you like to reset your quantities to their original values Yes/No");
            string reset = Console.ReadLine();
            if (reset.Equals("Yes"))
            {
                for (int i = 0; i < quantityArr.Length; i++)
                {
                    quantityArr[i] = originalQuantities[i];
                }
                DisplayRecipe();

            }
            else if (reset.Equals("No"))
            {
                new RecipeMenu();
            }


        }

        public static void ClearRecipe() {
            Console.WriteLine("Are you sure you would like to clear this recipe Yes/No");
            string clearAnswer = Console.ReadLine();
            if (clearAnswer.Equals("Yes"))
            {
                recipe = "";
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
    class RecipeMenu
    {
        public RecipeMenu()
        {
            string option = "";
            int selectedOption;

            while (String.IsNullOrEmpty(option))
            {
                try
                {
                    Console.WriteLine("Please select one of the following options: \n1. " +
                    "Increase quantity scale \n2. Clear recipe list \n3. Quantity Reset \n4. Exit Application");
                    selectedOption = Convert.ToInt32(Console.ReadLine());
                    switch (selectedOption)
                    {
                        case 1:
                            Ingrediants.ScaleQuantity();
                            new RecipeMenu();
                            break;
                        case 2:
                            Ingrediants.ClearRecipe();
                            new RecipeMenu();
                            break;
                        case 3:
                            Ingrediants.QuantityReset();
                            new RecipeMenu();
                            break;
                        case 4:
                            Console.WriteLine("Goodbye");
                            Environment.Exit(0);
                            break;
                        default:
                            Console.WriteLine("Invalid input, please try again.");
                            break;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

            }
        }


    }
}
