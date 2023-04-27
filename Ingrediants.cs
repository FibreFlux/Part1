using System;
using System.Diagnostics.Contracts;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Xml.Serialization;

namespace ST10058057_PROG6221_PortfolioOfEvidencePart1
{// beginning of namespace
    class Ingrediants
    {
        //-------------------- Global Variables --------------------//
        public static string[] ingrediantNameArr = new string[50];      //Stores ingrediants entered
        public static double[] quantityArr = new double[50];            //Stores the quantity entered
        public static string[] measurementArr = new string[50];         //Stores the unit of measurement selected
        public static string[] stepsArr = new string[50];               //Stores the steps required for the recipe
        public static double[] originalQuantities = new double[50];     //stores the quantity entered before scaling
        public static string[] originalMeasurements = new string[50];   //stores the unit of measurement entered before scaling
        public static bool correctCredentials = false;                  //checks if all credentials entered are valid and correct
        public static int noOfElements = 0;                             //counts the number of elements in each array
        //-------------------- Global Variables --------------------//

        //---- Main Method ----//
        static void Main()
        {
            AddRecipe();
        }
        //---- Main Method ----//

        public static void AddRecipe() //This method is responsible for asking the user to enter ingrediants for a recipe
        {
            // --- Local Variables --- //
            string quantity = "";           //String value used to temporarily store the quantity of the ingrediant
            string noOfIngrediants = "";    //Used to temporarily store the number of ingrediants, this is used with error checking
            int ingrediantCount = 0;        //Variable that holds the number of ingrediants entered by the user
            bool validMeasurements = false; //Checks if the user selected a valid measurement
            // --- Local Variables --- //

            while (correctCredentials == false)
            {// beginning of while loop

                Console.WriteLine("How many ingrediants do you need for your recipe?"); //Asks the user to enter how many ingrediants they need
                noOfIngrediants = Console.ReadLine();

                if (String.IsNullOrEmpty(noOfIngrediants))
                    Console.WriteLine("Empty input, please enter the correct information.");
                else if (IsNumber(noOfIngrediants) == true) //Checks if the value of "noOfIngrediants is a number
                {
                    ingrediantCount = Convert.ToInt32(noOfIngrediants); //Converts the "noOfIngrediants" value to an integer
                }
                else if (IsNumber(noOfIngrediants) == false) //Checks if the value of "noOfIngrediants" is not a number
                    Console.WriteLine("Invalid input, please enter the correct information.");

                int size = 0;
                while (size < ingrediantCount)
                {
                    while (String.IsNullOrEmpty(ingrediantNameArr[size]))   //Code within the while loop continues to execute until the input is entered
                    {//beginning of while loop
                        Console.WriteLine($"What is the name for ingrediant {size + 1}");    //Asks the user for the name of the ingrediant
                        ingrediantNameArr[size] = Console.ReadLine();
                        if (String.IsNullOrEmpty(ingrediantNameArr[size])) //Checks if the user entered an ingrediant
                            Console.WriteLine("Invalid input, please enter the correct information.");
                    }//end of while loop

                    while (String.IsNullOrEmpty(quantity))  //Code within the while loop continues to execute until the input is entered
                    {//beginning of while loop
                        Console.WriteLine("How much " + ingrediantNameArr[size] + " do you need?");
                        quantity = Console.ReadLine();
                        if (String.IsNullOrEmpty(quantity)) //Checks if the user entered a quantity
                            Console.WriteLine("Empty input, please enter the correct information.");
                        else if (IsNumber(quantity) == true) //checks if the quantity entered is a number
                        {
                            quantityArr[size] = Convert.ToDouble(quantity);
                            originalQuantities[size] = quantityArr[size];
                        }
                        else if (IsNumber(quantity) == false) //checks if the quantity entered is not a number
                        {
                            Console.WriteLine("Invalid input, please enter the correct information.");
                            quantity = ""; //resets the quantity entered by the user for the next possible quantity
                        }
                    }//end of while loop

                    while (validMeasurements == false)
                    {//beginning of while loop
                        try //try-catch used to check if the user entered a number
                        {
                            Console.WriteLine($"Please select one of the 3 units of measurement for {ingrediantNameArr[size]}: \n1. teaspoons, " +
                                $"\n2. tablespoons \n3. cups");
                            int measurementChoice = Convert.ToInt32(Console.ReadLine());
                            switch (measurementChoice) //Switch statement to determine if the user selected the correct measurement
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
                    }//end of while loop 
                    noOfElements++; //Number of elements increases
                    size++;
                    if (validMeasurements == true) //checks if the measurement entered is valid
                    {
                        validMeasurements = false; //resets the boolean value for the next ingrediant
                        quantity = ""; //quantity is reset
                    }
                    correctCredentials = true; //confirms that the user has entered all the correct information

                }
            }// end of while loop
            Steps();            //calls the Steps() method
            DisplayRecipe();    //Displays the recipe entered
            new RecipeMenu();   //runs the RecipeMenu() class
            Console.ReadLine();
        }

        public static int Steps()
        {
            // ---- Local Variables ---//
            int noOfSteps = 0;              //Holds the number of steps needed to create a recipe
            bool validStepCount = false;
            string steps = "";              //Temporarily holds the number of steps entered by the user
            // ---- Local Variables ---//
            while (validStepCount == false)
            {//beginning of while loop 
                Console.WriteLine("How many steps are required to complete the recipe?"); //Prompts the user to enter the amount of steps required to complete the recipe
                steps = Console.ReadLine();
                if (String.IsNullOrEmpty(steps)) //Checks if the user has entered the number of steps required
                    Console.WriteLine("Empty input, please enter the correct information.");
                else if (IsNumber(steps) == true) //Checks if the steps entered are numbers
                {
                    noOfSteps = Convert.ToInt32(steps); //converts the value of the "steps" to an integer
                    validStepCount = true;
                }
                else if (IsNumber(steps) == false) //Checks if the steps entered are not numbers
                    Console.WriteLine("Invalid input, please enter the correct information.");
            }//end of while loop

            for (int i = 0; i < noOfSteps; i++)
            {//beginning of for loop
                while (String.IsNullOrEmpty(stepsArr[i]))
                {//beginning of while loop
                    Console.WriteLine($"Enter the description for step {i + 1} ");
                    stepsArr[i] = Console.ReadLine();
                    if (String.IsNullOrEmpty(stepsArr[i])) //checks if the user has entered a description for a step
                        Console.WriteLine("Empty Input, please enter the step description");
                    Console.WriteLine();
                }//end of while loop
            }//end of for loop
            return noOfSteps;
        }



        public static void DisplayRecipe()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            int stepIndex = 1; //used to number the steps
            Console.WriteLine("Ingrediants:");
            for (int i = 0; i < ingrediantNameArr.Length; i++)
                if (ingrediantNameArr[i] != null)   //Checks if the "ingrediantNameArr" array is not null
                {
                    Console.WriteLine("Name: " + ingrediantNameArr[i] + "\t\tQuantity: " + quantityArr[i] + " " + measurementArr[i]);
                }
            Console.WriteLine("\nSteps:");
            foreach (var steps in stepsArr) //For each loop used to display the steps entered
                if (steps != null) //Checks if the step array is not null
                    Console.WriteLine($"{stepIndex++}. " + steps);
            Console.WriteLine();

        }

        public static void ScaleQuantity()
        {
            // --- Local Variables --- //
            bool validScaleOption = false;
            double scale;
            Console.ForegroundColor = ConsoleColor.Yellow;
            // --- Local Variables --- //


            if (ExistingArray() == true) //Checks if the "ingrediantNameArr" array does exist.
            {
                while (validScaleOption == false)
                {//beginnning of while loop
                    try //try-catch statement used to check if the scale entered is a number
                    {
                        Console.WriteLine("Would you like to scale your recipe by 0.5, 2 or 3");
                        scale = Convert.ToDouble(Console.ReadLine());
                        switch (scale) //Switch statement to determine if the user selected the correct scaling option
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
                        Console.WriteLine(e.Message);       //Displays an error message when the user enters a value that is not a number
                    }
                }//end of while loop
                RecipeConversion(); //Runs the RecipeConversion method
                DisplayRecipe();    //Displays the recipe after conversion
                new RecipeMenu();
            }
            else
            {
                Console.WriteLine("No recipe has been recorded.");
                NewRecipe();
            }

        }
        //Method that returns true if the ingrediantNameArr array does exist and returns false if it does not exist
        public static bool ExistingArray()
        {
            bool arrayExists = false;
            for (int i = 0; i < noOfElements; i++)
            {
                if (ingrediantNameArr[i] != null) //Checks if the ingrediantNameArr array exists
                    arrayExists = true;
                else
                    arrayExists = false;
            }
            return arrayExists; //returns the "arrayExists" variable
        }

        //Method that checks if the value entered within the parameter is a number and returns false if it is not a number
        public static bool IsNumber(string value)
        {
            bool isNum = false;
            if ((isNum = int.TryParse(value, out int numValue)) == true) //Checks if the "value" variable is a number
                isNum = true;
            else
                isNum = false;

            return isNum;
        }
        //Method that asks the user to enter a new recipe
        public static void NewRecipe()
        {
            bool validOption = false;   //boolean value that determines if the input entered is valid
            while (validOption == false)
            {//beginning of while loop
                Console.WriteLine("Would you like to enter a new recipe yes/no");   //Asks the user if they would like to enter a new recipe
                string newRecipeChoice = Console.ReadLine();
                if (newRecipeChoice.Equals("yes")) //Checks if the user answered yes to the question
                {
                    correctCredentials = false;
                    AddRecipe();
                    validOption = true;
                }
                else if (newRecipeChoice.Equals("no")) //Checks if the user answered no to the question
                {
                    new RecipeMenu();
                    validOption = true;
                }
                else
                {
                    Console.WriteLine("Please answer either yes or no (answer in lower case)");
                    newRecipeChoice = Console.ReadLine();

                }
            }//end of while loop
        }
        //Method responsible for all the conversions of the quantites and the unit of measurements 
        public static void RecipeConversion()
        {
            int leftoverTableSpoons;
            int leftoverTeaSpoons;
            for (int i = 0; i < quantityArr.Length; i++)
            {
                if (measurementArr[i] != null) //Checks if the user added a unit of measurement
                {
                    if (measurementArr[i].Equals("tablespoons"))
                    {
                        if (quantityArr[i] % 16 == 0 && quantityArr[i] >= 16)   //Checks if the quantity entered is divisible by 16 and is bigger than or equal to 16
                        {
                            quantityArr[i] = (int)quantityArr[i] / 16;
                            measurementArr[i] = "cups";
                        }
                        else if (quantityArr[i] % 16 != 0 && quantityArr[i] >= 16)  //Checks if the quantity entered is divisible by 16 and is bigger than or equal to 16
                        {
                            leftoverTableSpoons = (int)quantityArr[i] % 16;
                            quantityArr[i] = (int)quantityArr[i] / 16;
                            measurementArr[i] = "cups and " + leftoverTableSpoons + " tablespoons";
                        }
                    }
                    else if (measurementArr[i].Equals("teaspoons"))
                    {
                        if (quantityArr[i] % 3 == 0 && quantityArr[i] < 48)   //Checks if the quantity entered is divisible by 3 and is less than 48
                        {
                            quantityArr[i] = (int)quantityArr[i] / 3; //Converts teaspoons to tablespoons
                            measurementArr[i] = "tablespoons";
                        }
                        else if (quantityArr[i] % 3 != 0 && quantityArr[i] < 48) //Checks if the quantity entered is not divisible by 3 and is less than 48
                        {
                            leftoverTeaSpoons = (int)quantityArr[i] % 3; //finds the leftover teaspoons
                            quantityArr[i] = (int)quantityArr[i] / 3; 
                            measurementArr[i] = "tablespoons " + leftoverTeaSpoons + " teaspoons";
                        }
                        else if (quantityArr[i] >= 48 && quantityArr[i] % 48 == 0) //Checks if the quantity entered is divisible by 48 and is more than 48
                        {
                            quantityArr[i] = (int)quantityArr[i] / 48; //converts teaspoons to cups
                            measurementArr[i] = "cups";
                        }
                        else if (quantityArr[i] > 48 && quantityArr[i] % 48 != 0) //Checks if the quantity entered is not divisible by 48 and is more than 48
                        {
                            leftoverTeaSpoons = (int)quantityArr[i] % 48;
                            quantityArr[i] = (int)quantityArr[i] / 48; 
                            measurementArr[i] = "cups and " + leftoverTeaSpoons + " teaspoons";
                            if (leftoverTeaSpoons % 3 == 0)         //Checks if the number of teaspoons are divisible by 3
                            {
                                leftoverTableSpoons = leftoverTeaSpoons / 3; //converts teaspoons to tablespoons
                                measurementArr[i] = "cups and " + leftoverTableSpoons + " tablespoons";
                            }
                            else {
                                leftoverTableSpoons = leftoverTeaSpoons / 3; //converts teaspoons to tablespoons
                                leftoverTeaSpoons %= 3; //finds the remaining teaspoons
                                measurementArr[i] = "cups, " + leftoverTableSpoons + " tablespoons and " + leftoverTeaSpoons + " teaspoons ";
                            }

                        }
                    }
                }
            }
        }

        //This method is responsible for resetting the quantities to their original values
        public static void QuantityReset()
        {
            bool correctChoice = false;
            Console.ForegroundColor = ConsoleColor.Blue;    //Changes the text colour to Blue
            if (ExistingArray() == true) //Checks if the array does exist
            {

                Console.WriteLine("Would you like to reset your quantities to their original values yes/no");
                string reset = Console.ReadLine();
                while (correctChoice == false)
                {//beginning of while loop
                    switch (reset) //Switch statement to determine if the user entered the correct answer
                    {
                        case "yes":
                            for (int i = 0; i < noOfElements; i++)
                            {
                                quantityArr[i] = originalQuantities[i]; //the quantity scaled is set to the original quantity entered
                                measurementArr[i] = originalMeasurements[i];  //the measurement scaled is set to the original measurement entered
                            }
                            DisplayRecipe();
                            new RecipeMenu(); //runs the RecipeMenu() class
                            correctChoice = true;
                            break;
                        case "no":
                            new RecipeMenu(); //runs the RecipeMenu() class
                            correctChoice = true;
                            break;
                        default:
                            Console.WriteLine("Please answer either yes or no (answer in lower case)");
                            reset = Console.ReadLine();
                            break;
                    }
                }//end of while loop
            }
            else
            {
                Console.WriteLine("No recipe has been entered.");
                NewRecipe();
            }

            Console.ResetColor(); //Resets the colour to its original state
        }

        public static void ClearRecipe()
        {
            bool correctClearOption = false;
            Console.ForegroundColor = ConsoleColor.Magenta; //Changes the text colour to Magenta
            if (ExistingArray() == true) //Checks if the array exists 
            {
                while (correctClearOption == false)
                {
                    Console.WriteLine("Are you sure you would like to clear this recipe yes/no");
                    string clearAnswer = Console.ReadLine();
                    if (clearAnswer.Equals("yes")) //Checks if the user answers yes
                    {
                        //Clears all the content within each array
                        Array.Clear(ingrediantNameArr, 0, ingrediantNameArr.Length);
                        Array.Clear(quantityArr, 0, quantityArr.Length);
                        Array.Clear(measurementArr, 0, measurementArr.Length);
                        Array.Clear(stepsArr, 0, stepsArr.Length);
                        //Clears all the content within each array
                        Console.WriteLine("Recipe has been cleared!");
                        NewRecipe();
                        new RecipeMenu();
                        correctClearOption = true;
                    }
                    else if (clearAnswer.Equals("no")) //Checks if the user answers no
                    {
                        new RecipeMenu();
                        correctClearOption = true;
                    }
                    else
                    {
                        //displays an error message if the user enters neither yes nor no
                        Console.WriteLine("Please enter either yes or no (answer in lower case)");
                    }
                }
                DisplayRecipe();
            }
            else
            {
                Console.WriteLine("There is no recipe to clear");
                NewRecipe(); //runs the NewRecipe() method 
            }

            Console.ResetColor(); //Resets the colour to its original state
        }
    }
    class RecipeMenu
    {
        public RecipeMenu()
        {
            // --- Local Variables --- //
            string option = "";
            int selectedOption;
            bool optionSelected = false;
            Console.ForegroundColor = ConsoleColor.Red;
            // --- Local Variables --- //

            while (String.IsNullOrEmpty(option))  //Code within the while loop will continue to run while the option entered is empty or null 
            {//beginning of while loop
                try
                {
                    while (optionSelected == false) //Code within this loop will run until the user has selected a valid menu option
                    {
                        Console.WriteLine("Please select one of the following options: \n1. " +
                        "Increase quantity scale \n2. Quantity reset \n3. Clear recipe \n4. Exit Application");
                        selectedOption = Convert.ToInt32(Console.ReadLine());

                        option = "" + selectedOption;
                        switch (selectedOption) //Switch statement to determine if the user has entered a valid option
                        {
                            case 1:
                                Ingrediants.ScaleQuantity();    //calls the ScaleQuantity method from the Ingrediants class
                                optionSelected = true;
                                break;
                            case 2:
                                Ingrediants.QuantityReset();    //calls the QuantityReset method from the Ingrediants class
                                optionSelected = true;
                                break;
                            case 3:
                                Ingrediants.ClearRecipe();      //calls the ClearRecipe method from the Ingrediants class
                                optionSelected = true;
                                break;
                            case 4:
                                Console.WriteLine("Goodbye");
                                optionSelected = true;
                                Environment.Exit(0);            //ends the application=
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
            }//end of while loop
            Console.ResetColor();   //Resets the colour to its original state


        }
    }

}

