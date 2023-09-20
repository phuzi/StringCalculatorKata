namespace StringCalculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            if (args.Length != 1)
            {
                Console.WriteLine("Please specify a single expression to add!\n");
                return;
            }

            var expression = args[0] ?? string.Empty;

            var result = StringCalculator.Add(expression);

            Console.WriteLine($"The result is: {result}");
        }
    }
}