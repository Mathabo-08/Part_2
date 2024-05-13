using NUnit.Framework;
using Recipe_Application; // Import the Recipe_Application namespace to access the Ingredients class


namespace TotalCaloriesCalculate
{

    [TestFixture]
    public class Tests // Define the Tests class for unit testing
    {
        private Ingredients ingredients; // Declare a private instance of the Ingredients class for testing

        [SetUp]  // Attribute to mark the setup method that is executed before each test method


        public void Setup()
        {
            ingredients = new Ingredients();
        }

        [Test]

        // Define the test method to test total calorie calculation
        public void TotalCaloriesCalculation()
        {
            // Set up the ingredient calories array
            ingredients.ingredientCalories = new int[] {100, 200, 150 };

            // Call the GetTotalCalories method to calculate total calories
            int totalCalories = ingredients.GetTotalCalories();

            // Verify that the total calories match the expected value
            Assert.AreEqual(450, totalCalories);    
        }
    }
}