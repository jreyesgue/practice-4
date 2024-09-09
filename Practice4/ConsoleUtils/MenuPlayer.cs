namespace Practice4.ConsoleUtils
{
    public static class MenuPlayer
    {
        public static void DisplayMenu()
        {
            Console.WriteLine("\n----- Menu -----\n");
            Console.WriteLine("1. Get all products.");
            Console.WriteLine("2. Create a new product.");
            Console.WriteLine("3. Get product by name or ID.");
            Console.WriteLine("4. Get daily sales sorted.");
            Console.WriteLine("5. Get sales of the month.");
            Console.WriteLine("6. Get products with no sales.");
            Console.WriteLine("7. Get product sales of the month.");
            Console.WriteLine("8. Exit.");
        }
    }
}
