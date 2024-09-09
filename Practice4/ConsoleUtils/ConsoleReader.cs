namespace Practice4.ConsoleUtils
{
    public static class ConsoleReader
    {
        public static int GetOption()
        {
            Console.Write("\nSelect an option: ");

            return Convert.ToInt32(Console.ReadLine());
        }

        public static string GetStringParam(string message)
        {
            Console.Write(message);

            return Console.ReadLine() ?? string.Empty;
        }

        public static decimal GetDecimalParam(string message)
        {
            Console.Write(message);

            return Convert.ToDecimal(Console.ReadLine());
        }
    }
}
