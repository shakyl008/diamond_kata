using diamond_kata.DiamondGenerator;
using diamond_kata.OutputWriter;
using System.Runtime.CompilerServices;

[assembly:InternalsVisibleTo("diamond_kata_tests")]
namespace diamond_kata
{
    internal class Program
    {
        internal static void Main(string[] args)
        {
            char inputChar = GetInput();

            // for production I would consider having a factory class to orchestrate the creation of the generator and writer
            // however, I was advised not to over engineer the solution thus using the simple approach

            IDiamondGenerator generator = new DiamondGenerator.DiamondGenerator();
            string[] diamond = generator.CreateDiamond(inputChar);

            IOutputWriter outputWriter = new OutputWriter.ConsoleWriter();
            outputWriter.Write(diamond);
        }

        private static char GetInput()
        {
            char inputChar;
            while (true)
            {
                Console.WriteLine("Enter a letter from A to Z");
                string input = Console.ReadLine();

                if (string.IsNullOrEmpty(input) || input.Length != 1 || !char.IsLetter(input[0]))
                {
                    Console.WriteLine("Invalid input.");
                }
                else
                {
                    inputChar = char.ToUpper(input[0]);
                    break;
                }
            }
            return inputChar;
        }
    }
}
