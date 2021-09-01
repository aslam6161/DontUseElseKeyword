using DontUseElseKeyword.WithoutElseKeyword;
//using DontUseElseKeyword.ExampleWithElseKeyword; //Used to check with else keyword
using System;

namespace DontUseElseKeyword
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");

            //var bartender = new Bartender(Console.ReadLine, Console.WriteLine);//Used to check with else keyword

            var recipeBook = new RecipeBook(Console.ReadLine, Console.WriteLine);
            var bartender = new Bartender(Console.ReadLine, Console.WriteLine, recipeBook);
            while(true)
            {
                bartender.AskForDrink();
            }
        }
    }
}
