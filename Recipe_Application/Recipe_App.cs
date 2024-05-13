using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace Recipe_Application
{
    // Modified the application from a single recipe application to a unlimited number of recipes application
    internal class Recipe_App 
    {
        public static void Main(string[] args)
        {

            // Dictionary to store the recipes
            SortedDictionary<string, Recipe> recipes = new SortedDictionary<string, Recipe>();
            string recipeName = " ";

            // Loop through the main menu list 
            while (true)
            {
                Console.WriteLine("\n------ Please choose an option from main menu ------");
                Console.WriteLine("1. Enter new recipe details");
                Console.WriteLine("2. Select a recipe");
                Console.WriteLine("3. Exit");

                Console.Write("\nEnter your choice of option: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        // Method to call the GetRecipeName 
                        Console.Write("\nEnter the recipe name: ");
                        recipeName = Console.ReadLine();

                        // Create new recipe and collect all the recipe details    
                        Recipe recipe = new Recipe(recipeName);
                        recipe.GetRecipeDetails();

                        // Add recipe to SortedDictionary
                        recipes.Add(recipeName, recipe);
                        break;
                    case "2":
                        // Select a recipe
                        if (recipes.Count == 0)
                        {
                            Console.WriteLine("\nPlease ensure that you enter the recipe details first, before displaying the recipe!");
                            continue;
                        }
                        else
                        {
                            Console.WriteLine("\n------- Available recipes -------");
                            int numRecipe = 1;
                            foreach (var name in recipes.Keys)
                            {
                                Console.WriteLine($"\n{numRecipe}.{name}");
                                numRecipe++;
                            }
                            Console.Write("\nEnter the name of the recipe you want to select: ");
                            string selectedRecipe = Console.ReadLine();


                            if (recipes.ContainsKey(selectedRecipe))
                            {

                                // Display selected menu
                                while (true)
                                {
                                    Console.WriteLine("\n------ Please choose an option you want to view of the selected recipe ------");
                                    Console.WriteLine("\n1. Display recipe");
                                    Console.WriteLine("2. Scaling Factors");
                                    Console.WriteLine("3. Quantity Reset");
                                    Console.WriteLine("4. Clear recipe");
                                    Console.WriteLine("5. Back to main menu");

                                    Console.Write("\nEnter your choice of option: ");
                                    string recipeChoice = Console.ReadLine();

                                    switch (recipeChoice)
                                    {
                                        case "1":

                                            // Displays recipe
                                            recipes[selectedRecipe].DisplayRecipe(selectedRecipe);
                                            break;

                                        case "2":
                                            // Method to call to scale the recipe by factors like 0.5, 2, 3
                                            recipes[selectedRecipe].RecipeScale();
                                            break;

                                        case "3":
                                            // Method to call to reset the quantities to the original values
                                            recipes[selectedRecipe].QuantityReset();
                                            break;

                                        case "4":
                                            // Method to call to clear the full recipe
                                            recipes[selectedRecipe].ClearRecipe();
                                            Console.WriteLine("\nRecipe successfully cleared!");
                                            break;

                                        case "5":
                                            // Back to main menu
                                            break;

                                        default:
                                            Console.WriteLine("\nInvalid choice.Please enter one of the choices from the list of options!");
                                            break;
                                    }
                                    if (recipeChoice == "5") 
                                    Console.WriteLine("\nReturend to Main menu!"); break;
                                }
                            }
                            else
                            {
                                Console.WriteLine("\nRecipe not found!");
                            }
                        }
                            break;

                    case "3":
                                // exit the application
                                return;


                            default:
                                Console.WriteLine("\nInvalid choice.Please enter one of the choices from the list of options!");
                                break;    
                    
                }
            }
        }
    }
}