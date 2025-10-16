//// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");

using System;
    class Calculator
    {
        public double Add(double a, double b)
        {
            return a + b;
        }
        public double Subtract(double a, double b)
        {
            return a - b;
        }
        public double Multiply(double a, double b)
        {
            return a * b;
        }
        public double Divide(double a, double b)
        {
            if (b == 0)
            {
                Console.WriteLine("Cannot divide by zero!");
                return 0;
            }
            return a / b;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Calculator calc = new Calculator();
            while (true)
            {
                Console.Write("Enter first number: ");
                double num1 = Convert.ToDouble(Console.ReadLine());
                Console.Write("Enter second number: ");
                double num2 = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("Choose operation (+, -, *, /): ");
                char op = Convert.ToChar(Console.ReadLine());
                double result = 0;                
                switch (op)
                {
                    case '+': result = calc.Add(num1, num2); break;
                    case '-': result = calc.Subtract(num1, num2); break;
                    case '*': result = calc.Multiply(num1, num2); break;
                    case '/': result = calc.Divide(num1, num2); break;
                    default:
                        Console.WriteLine("Invalid operator!");
                        continue;
                }
                Console.WriteLine($"Result: {result}\n");
                Console.Write("Do you want to continue? (y/n) ");
                string choice = Console.ReadLine();
                if (choice.ToLower() != "y")
                    break;
            }
        }
    }
