using System;
using System.Diagnostics.Contracts;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Xml.Serialization;

namespace ST10058057_PROG6221_PortfolioOfEvidencePart1
{
    class Ingrediants
    {
        public static string[] ingrediantNameArr = new string[50];
        public static double[] quantityArr = new double[50];
        public static string[] measurementArr = new string[50];
        public static string[] stepsArr = new string[50];
        public static double[] originalQuantities = new double[50];
        public static string[] originalMeasurements = new string[50];
        public static bool correctCredentials = false;
        public static int noOfElements = 0;
        static void Main()
        {
            AddRecipe();
        }

        public static void AddRecipe()
        {
            string quantity = "";
            string noOfIngrediants = "";
            int ingrediantCount = 0;
            bool validMeasurements = false;
            while (correctCredentials == false)
            {
                Console.WriteLine("How many ingrediants do you need for your recipe?");
                noOfIngrediants = Console.ReadLine();

                if (String.IsNullOrEmpty(noOfIngrediants))
                    Console.WriteLine("Empty input, please enter the correct information.");
                else if (IsNumber(noOfIngrediants) == true)
                {
                    ingrediantCount = Convert.ToInt32(noOfIngrediants);
                }
                else if (IsNumber(noOfIngrediants) == false)
                    Console.WriteLine("Invalid input, please enter the correct information.");

                int size = 0;
                while (size < ingrediantCount)
                {
                    while (String.IsNullOrEmpty(ingrediantNameArr[size]))
                    {
                        Console.WriteLine($"What is the name for ingrediant{size + 1}");
                        ingrediantNameArr[size] = Console.ReadLine();
                        if (String.IsNullOrEmpty(ingrediantNameArr[size]))
                            Console.WriteLine("Invalid input, please enter the correct information.");
                    }

                    while (String.IsNullOrEmpty(quantity))
                    {
                        Console.WriteLine("How much " + ingrediantNameArr[size] + " do you need?");
                        quantity = Console.ReadLine();
                        if (String.IsNullOrEmpty(quantity))
                            Console.WriteLine("Empty input, please enter the correct information.");
                        else if (IsNumber(quantity) == true)
                        {
                            quantityArr[size] = Convert.ToDouble(quantity);
                            originalQuantities[size] = quantityArr[size];
                        }
                        else if (IsNumber(quantity) == false)
                        {
                            Console.WriteLine("Invalid input, please enter the correct information.");
                            quantity = "";
                        }
                    }
                    while (validMeasurements == false)
                    {
                        try
                        {
                            Console.WriteLine($"Please select one of the 3 units of measurement for {ingrediantNameArr[size]}: \n1. teaspoons, " +
                                $"\n2. tablespoons \n3. cups");
                            int measurementChoice = Convert.ToInt32(Console.ReadLine());
                            switch (measurementChoice)
                            {
                                case 1:
                                    measurementArr[size] = "teaspoons";
                                    originalMeasurements[size] = measurementArr[size];
                                    validMeasurements = true;
                                    break;
                                case 2:
                                    measurementArr[size] = "tablespoons";
                                    originalMeasurements[size] = measurementArr[size];
                                    validMeasurements = true;
                                    break;
                                case 3:
                                    measurementArr[size] = "cups";
                                    originalMeasurements[size] = measurementArr[size];
                                    validMeasurements = true;
                                    break;
                                default:
                                    Console.WriteLine("That option is not avaliable, please enter a valid option");
                                    break;
                            }
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                    }
                    noOfElements++;
                    size++;
                    if (validMeasurements == true)
                    {
                        validMeasurements = false;
                        quantity = "";
                    }
                    correctCredentials = true;

                }
            }
            Steps();
            DisplayRecipe();
            new RecipeMenu();
            Console.ReadLine();
        }

        public static int Steps()
        {
            int noOfSteps = 0;
            bool validStepCount = false;
            string steps = "";
            while (validStepCount == false)
            {
                Console.WriteLine("How many steps are required to complete the recipe?");
                steps = Console.ReadLine();
                if (String.IsNullOrEmpty(steps))
                    Console.WriteLine("Empty input, please enter the correct information.");
                else if (IsNumber(steps) == true)
                {
                    noOfSteps = Convert.ToInt32(steps);
                    validStepCount = true;
                }
                else if (IsNumber(steps) == false)
                    Console.WriteLine("Invalid input, please enter the correct information.");
            }

            for (int i = 0; i < noOfSteps; i++)
            {
                while (String.IsNullOrEmpty(stepsArr[i]))
                {
                    Console.WriteLine($"Enter the description for step {i + 1} ");
                    stepsArr[i] = Console.ReadLine();
                    if (String.IsNullOrEmpty(stepsArr[i]))
                        Console.WriteLine("Empty Input, please enter the step description");
                    Console.WriteLine();
                }
            }
            return noOfSteps;
        }



        public static void DisplayRecipe()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            int stepIndex = 1;
            Console.WriteLine("Ingrediants:");
            for (int i = 0; i < ingrediantNameArr.Length; i++)
                if (ingrediantNameArr[i] != null)
                {
                    Console.WriteLine("Name: " + ingrediantNameArr[i] + "\tQuantity: " + quantityArr[i] + " " + measurementArr[i]);
                }


            Console.WriteLine("\nSteps:");
            foreach (var steps in stepsArr)
                if (steps != null)
                    Console.WriteLine($"{stepIndex++}. " + steps);
            Console.WriteLine();

        }

        public static void ScaleQuantity()
        {
            bool validScaleOption = false;
            double scale;
            Console.ForegroundColor = ConsoleColor.Yellow;
            if (ExistingArray() == true)
            {
                while (validScaleOption == false)
                {
                    try
                    {
                        Console.WriteLine("Would you like to scale your recipe by 0.5, 2 or 3");
                        scale = Convert.ToDouble(Console.ReadLine());
                        switch (scale)
                        {
                            case 0.5:
                                for (int i = 0; i < quantityArr.Length; i++)
                                    quantityArr[i] *= scale;
                                validScaleOption = true;
                                break;
                            case 2:
                                for (int i = 0; i < quantityArr.Length; i++)
                                    quantityArr[i] *= scale;
                                validScaleOption = true;
                                break;
                            case 3:
                                for (int i = 0; i < quantityArr.Length; i++)
                                    quantityArr[i] *= scale;
                                validScaleOption = true;
                                break;
                            default:
                                Console.WriteLine("Scaling option not avaliable, please select a valid option");
                                break;
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
                RecipeConversion();
                DisplayRecipe();
                new RecipeMenu();
            }
            else
            {
                Console.WriteLine("No recipe has been recorded.");
                NewRecipe();
            }

        }

        public static bool ExistingArray()
        {
            bool arrayExists = false;
            for (int i = 0; i < noOfElements; i++)
            {
                if (ingrediantNameArr[i] != null)
                    arrayExists = true;
                else
                    arrayExists = false;
            }
            return arrayExists;
        }

        public static bool IsNumber(string value)
        {
            bool isNum = false;
            if ((isNum = int.TryParse(value, out int numValue)) == true)
                isNum = true;
            else
                isNum = false;

            return isNum;
        }

        public static void NewRecipe()
        {
            bool validOption = false;
            while (validOption == false)
            {
                Console.WriteLine("Would you like to enter a new recipe yes/no");
                string newRecipeChoice = Console.ReadLine();
                if (newRecipeChoice.Equals("yes"))
                {
                    correctCredentials = false;
                    AddRecipe();
                    validOption = true;
                }
                else if (newRecipeChoice.Equals("no"))
                {
                    new RecipeMenu();
                    validOption = true;
                }
                else
                {
                    Console.WriteLine("Please answer either yes or no (answer in lower case)");
                    newRecipeChoice = Console.ReadLine();

                }
            }
        }
        public static void RecipeConversion()
        {
            int remainder;
            int leftover;
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
                        if (quantityArr[j] >= 3 && quantityArr[j] < 48 && remainder == 0)
                        {
                            quantityArr[j] = quantityArr[j] / 3;
                            measurementArr[j] = "tablespoons";
                        }
                        else if (quantityArr[j] >= 3 && quantityArr[j] < 48 && remainder > 0)
                        {
                            quantityArr[j] = (int)quantityArr[j] / 3;
                            measurementArr[j] = "tablespoons and " + remainder + " teaspoons";
                        }
                        else if (quantityArr[j] >= 48 && remainder == 0)
                        {
                            quantityArr[j] = quantityArr[j] / 48;
                            measurementArr[j] = "cups";
                        }
                        else if (quantityArr[j] >= 48 && remainder > 0)
                        {
                            quantityArr[j] = (int)quantityArr[j] / 48;
                            measurementArr[j] = "cups and " + remainder + " teaspoons";

                            leftover = remainder % 3;
                            if (remainder / 3 == 0 && remainder % 3 > 0)
                            {
                                measurementArr[j] = "cups, " + remainder + " tablespoons and " + leftover + " teaspoons";
                            }
                        }

                    }
                }
            }
        }

        public static void QuantityReset()
        {
            bool correctChoice = false;
            Console.ForegroundColor = ConsoleColor.Blue;
            if (ExistingArray() == true)
            {

                Console.WriteLine("Would you like to reset your quantities to their original values yes/no");
                string reset = Console.ReadLine();
                while (correctChoice == false)
                {
                    switch (reset)
                    {
                        case "yes":
                            for (int i = 0; i < noOfElements; i++)
                            {

                                quantityArr[i] = originalQuantities[i];
                                measurementArr[i] = originalMeasurements[i];
                            }
                            DisplayRecipe();
                            new RecipeMenu();
                            correctChoice = true;
                            break;
                        case "no":
                            new RecipeMenu();
                            correctChoice = true;
                            break;
                        default:
                            Console.WriteLine("Please answer either yes or no (answer in lower case)");
                            break;
                    }
                }
                if (correctChoice == true)
                    correctChoice = false;
            }
            else
            {
                Console.WriteLine("No recipe has been entered.");
                NewRecipe();
            }
        }

        public static void ClearRecipe()
        {
            bool correctClearOption = false;
            Console.ForegroundColor = ConsoleColor.Magenta;
            if (ExistingArray() == true)
            {
                while (correctClearOption == false)
                {
                    Console.WriteLine("Are you sure you would like to clear this recipe yes/no");
                    string clearAnswer = Console.ReadLine();
                    if (clearAnswer.Equals("yes"))
                    {
                        Array.Clear(ingrediantNameArr, 0, ingrediantNameArr.Length);
                        Array.Clear(quantityArr, 0, quantityArr.Length);
                        Array.Clear(measurementArr, 0, measurementArr.Length);
                        Array.Clear(stepsArr, 0, stepsArr.Length);
                        Console.WriteLine("Recipe has been cleared!");
                        NewRecipe();
                        new RecipeMenu();
                        correctClearOption = true;
                    }
                    else if (clearAnswer.Equals("no"))
                    {
                        new RecipeMenu();
                        correctClearOption = true;
                    }
                    else
                    {
                        Console.WriteLine("Please enter either yes or no (answer in lower case)");
                    }
                }
                DisplayRecipe();
            }
            else
            {
                Console.WriteLine("There is no recipe to clear");
                NewRecipe();
            }


        }
    }
    class RecipeMenu
    {
        public RecipeMenu()
        {
            string option = "";
            int selectedOption;
            bool optionSelected = false;
            Console.ForegroundColor = ConsoleColor.Red;
            while (String.IsNullOrEmpty(option))
            {
                try
                {
                    while (optionSelected == false)
                    {
                        Console.WriteLine("Please select one of the following options: \n1. " +
                        "Increase quantity scale \n2. Quantity reset \n3. Clear recipe \n4. Exit Application");
                        selectedOption = Convert.ToInt32(Console.ReadLine());

                        option = "" + selectedOption;
                        switch (selectedOption)
                        {
                            case 1:
                                Ingrediants.ScaleQuantity();
                                optionSelected = true;
                                break;
                            case 2:
                                Ingrediants.QuantityReset();
                                optionSelected = true;
                                break;
                            case 3:
                                Ingrediants.ClearRecipe();
                                optionSelected = true;
                                break;
                            case 4:
                                Console.WriteLine("Goodbye");
                                optionSelected = true;
                                Environment.Exit(0);
                                break;
                            default:
                                Console.WriteLine("Invalid input, please try again.");
                                break;
                        }
                    }

                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            Console.ResetColor();


        }
    }

}

