using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipe_Application
{
    // Added Calories section in the 'Display Recipe' method to display the information regarding calories
    internal class Recipe
    {
        // Declare variables
        private Ingredients ingredients;
        private Steps steps;
        private string recipeName;
        private bool displaySelectedRecipe; // Use as flag to track if '1. Display Recipe' option from the seleceted recipe menu list 

        // Constructor -> Allows Recipe class to have access to the properties and methods of the Ingredients Class and Steps Class
        public Recipe(string name)
        {
            ingredients = new Ingredients();
            steps = new Steps();
            recipeName = name;
            displaySelectedRecipe = false;

            // Subscribe to the OnRecipeCaloriesExceed event to handle notifications
            ingredients.OnRecipeCaloriesExceed += HandleRecipeCaloriesExceed;
        }

        // Method to handle the notification when the total calories exceed 300
        private void HandleRecipeCaloriesExceed(int totalCalories)
        {
            if (displaySelectedRecipe)
            {
                Console.WriteLine($"\nThe total calories of the recipe '{recipeName}' exceed 300!");
            }
        }

        // Method to prompt user to enter recipe name
        public string GetRecipeName()
        {
            Console.Write("\nEnter the recipe name: ");
            string recipeName = Console.ReadLine();
            return recipeName;
        }

        // Method to ask user to enter input for the recipe details
        public void GetRecipeDetails()
        {
            ingredients.GetIngreDetails();
            steps.GetStepsDetails();
        }

        // Method to print the the full recipe
        public void DisplayRecipe(string recipeName)
        {
            Console.WriteLine("\n-------- Recipe -------");
            Console.WriteLine("\nRecipe Name: " + recipeName);

            Console.WriteLine("\n ***** Ingredients *****");
            ingredients.DisplayIngredients();

            int totalCalories = ingredients.GetTotalCalories();
            Console.WriteLine("\n***** Calories *****");
            // Display the message if the total calories exceed 300. Flag is resetted before displaying total calories
            displaySelectedRecipe = true;
            Console.WriteLine("\nTotal Calories: " + totalCalories);
            // Call HandleRecipeCaloriesExceed only after displaying total calories
            HandleRecipeCaloriesExceed(totalCalories);


            Console.WriteLine("\n ***** Steps ***** ");
            steps.DisplaySteps();
        }

        // Method to scale the recipe ingredients by factors (0.5, 2, 3)
        public void RecipeScale()
        {
            Console.Write("\n------ Scaling Factors ------\n0.5\n2\n3\nEnter the scaling factor of your choice:");
            double factor = Convert.ToDouble(Console.ReadLine());
            ingredients.IngredientsScale(factor);
        }
        // Method resetting the ingredient quantities to the original values
        public void QuantityReset()
        {
            Console.WriteLine("\n----- Quantity Reset -----");
            ingredients.QuantityReset();
        }

        // Method to display the steps
        public void GetStepsDetails()
        {
            steps.GetStepsDetails();
        }

        // Method to clear the full recipe
        public void ClearRecipe()
        {
            ingredients.ClearIngredients();
            steps.ClearSteps();
        }
    }
}
