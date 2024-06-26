﻿using System;
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
                Console.WriteLine("------- Main Menu -------");
                Console.WriteLine("\nPlease choose an option from main menu: ");
                Console.WriteLine("1. Enter new recipe details");
                Console.WriteLine("2. Select a recipe from available recipes");
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
                                Console.WriteLine($"\n{numRecipe}.{name}" + " " + "recipe");
                                numRecipe++;
                            }
                            Console.Write("\nEnter the name of the recipe you want to select: ");
                            string choosenRecipe = Console.ReadLine() + " " + "recipe";


                            if (recipes.ContainsKey(choosenRecipe))
                            {

                                // Display selected menu
                                while (true)
                                {
                                    Console.WriteLine("------- Selected Recipe Menu -------");
                                    Console.WriteLine($"\nPlease choose an option you want to view of '{choosenRecipe}' recipe");
                                    Console.WriteLine($"\n1. Display {choosenRecipe} recipe details");
                                    Console.WriteLine($"2. Scaling Factors of {choosenRecipe} recipe");
                                    Console.WriteLine($"3. Quantity Reset for {choosenRecipe} recipe");
                                    Console.WriteLine($"4. Clear {choosenRecipe} recipe");
                                    Console.WriteLine("5. Back to main menu");

                                    Console.Write("\nEnter your choice of option: ");
                                    string recipeSelectedChoice = Console.ReadLine();

                                    switch (recipeSelectedChoice)
                                    {
                                        case "1":

                                            // Displays recipe
                                            recipes[choosenRecipe].DisplayRecipe(choosenRecipe);
                                            break;

                                        case "2":
                                            // Method to call to scale the recipe by factors like 0.5, 2, 3
                                            recipes[choosenRecipe].RecipeScale();
                                            break;

                                        case "3":
                                            // Method to call to reset the quantities to the original values
                                            recipes[choosenRecipe].QuantityReset();
                                            break;

                                        case "4":
                                            // Method to call to clear the full recipe
                                            recipes[choosenRecipe].ClearRecipe();
                                            Console.WriteLine($"\nRecipe {choosenRecipe} successfully cleared!");
                                            break;

                                        case "5":
                                            // Back to main menu
                                            break;

                                        default:
                                            Console.WriteLine("\nInvalid choice.Please enter one of the choices from the list of options!");
                                            break;
                                    }
                                    if (recipeSelectedChoice == "5") 
                                    Console.WriteLine("\nReturend to Main menu!"); break;
                                }
                            }
                            else
                            {
                                Console.WriteLine("\nRecipe unavailable!");
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