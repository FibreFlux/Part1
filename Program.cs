using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ST10058057_PROG6221_PortfolioOfEvidencePart1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int ingCount = 1;
            Console.WriteLine("Please enter how much ingrediants for your recipe");
            int noOfIngrediants = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < noOfIngrediants; i++)
            {
                Console.WriteLine("Please enter the name of the ingrediant");
                string nameOfIngrediant = Console.ReadLine();
                Console.WriteLine("Please enter how much " + nameOfIngrediant + " you need to add to the recipe");
                int quantity = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Please enter the ingredaint's unit of measurement");
                string unitOfMeasurement = Console.ReadLine();
                Console.WriteLine("Ingrediant No. " + ingCount + "\nName: " + nameOfIngrediant + "\nQuanitity: " + quantity + "\nUnit of Measurement: " + unitOfMeasurement);
                ingCount++;
            }

        }
    }
}
