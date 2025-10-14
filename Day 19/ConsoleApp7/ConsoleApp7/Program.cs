//// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");


using System;
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("=== Simple Calculator ===");

        Console.Write("Enter first number: ");
        double num1 = Convert.ToDouble(Console.ReadLine());

        Console.Write("Enter second number: ");
        double num2 = Convert.ToDouble(Console.ReadLine());

        Console.WriteLine("Choose an operation: +  -  *  /");
        char operation = Convert.ToChar(Console.ReadLine());

        double result = 0;

        switch (operation)
        {
            case '+':
                result = num1 + num2;
                break;
            case '-':
                result = num1 - num2;
                break;
            case '*':
                result = num1 * num2;
                break;
            case '/':
                if (num2 != 0)
                    result = num1 / num2;
                else
                {
                    Console.WriteLine("Cannot divide by zero!");
                    return;
                }
                break;
            default:
                Console.WriteLine("Invalid operation!");
                return;
        }

        Console.WriteLine($"Result: {result}");
        Console.WriteLine("Press any key to exit...");
        Console.ReadKey();
    }
}