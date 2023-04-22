using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ST10058057_PROG6221_PortfolioOfEvidencePart1
{
    internal class RecipeMenu
    {
        public Ingrediants ingrediants = new Ingrediants();

        public RecipeMenu()
        {
            string option = "";
            int selectedOption = 0;

            while (String.IsNullOrEmpty(option))
            {
                try
                {
                    Console.WriteLine("Please select one of the following options: \n1. " +
                    "Increase quantity scale \n2. Clear recipe list \n3. Exit Application");
                    selectedOption = Convert.ToInt32(Console.ReadLine());
                    option = "" + selectedOption;
                    switch (selectedOption)
                    {
                        case 1:
                            ingrediants.scaleQuantity();
                            new RecipeMenu();
                            break;
                        case 2:
                            ingrediants.clear();
                            new RecipeMenu();
                            break;
                        case 3:
                            ingrediants.quantityReset();
                            new RecipeMenu();
                            break;
                        case 4:
                            Environment.Exit(0);
                            break;
                        default:
                            Console.WriteLine("Invalid input, please try again.");
                            break;
                    }
                }
                catch (Exception e) 
                {
                    Console.WriteLine("invalid input, please try again");
                }
                
            }
        }

        

    }
}
