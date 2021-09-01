using System;
using System.Collections.Generic;

namespace DontUseElseKeyword.WithoutElseKeyword
{
    public class RecipeBook
    {
        private readonly Func<string> _inputProvider;
        private readonly Action<string> _outputProvider;
        private readonly Dictionary<string,Action> _recipes;


        public RecipeBook(Func<string> inputProvider, Action<string> outputProvider)
        {
            _inputProvider = inputProvider;
            _outputProvider = outputProvider;

            _recipes = new Dictionary<string, Action>
            {
                { "beer",ServeBeer },
                { "juice",ServeJuice },
            };
        }

        public void MakeDrink(string drinkName)
        {
            _recipes[drinkName]();
        }

        public IEnumerable<string> GetAvailableDrinkNames()
        {
            return _recipes.Keys;
        }


        private void ServeBeer()
        {
            _outputProvider("Not so fast. How old are you?");

            if (!int.TryParse(_inputProvider(), out var age))
            {
                HandleInvalidAge();
                return;
            }
            HandleBeerAgeCheck(age);
        }
        private void ServeJuice()
        {
            _outputProvider("Here you go! Fresh and nice juice");
        }

        private void HandleBeerAgeCheck(int age)
        {
            if (age >= 18)
            {
                _outputProvider("Here you go! Cold beer");
                return;
            }

            _outputProvider("Sorry! but you aren't not old enough to drink");
        }

        private void HandleInvalidAge()
        {
            _outputProvider("Could not parse the age provided");
        }
    }
}
