using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
Console Calculator
Description: Simple console calculator with basic operations
Author: Мария Георгиади
Date: 03,07,2025
*/
namespace ConsoleCalculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Введите первое число:");
                string answer = Console.ReadLine();
                bool check = IsOperand(answer);  // проверка валидности операнда
                while (!check)
                {
                    Console.WriteLine("Введите число");
                    check = IsOperand(Console.ReadLine());
                }
                double x = Convert.ToDouble(answer);  // первое число
                Console.WriteLine("Введите оператор (+, -, *, /):");
                answer = Console.ReadLine();
                check = IsOperator(answer);   // проверка валидности оператора
                while (!check)
                {
                    Console.WriteLine("Введите оператор (+, -, *, /)");
                    check = IsOperator(Console.ReadLine());
                }
                string oper = answer;    // опретор
                Console.WriteLine("Введите второе число:");
                answer = Console.ReadLine();
                check = IsOperand(answer);  // проверка валидности операнда
                while (!check)
                {
                    Console.WriteLine("Введите число");
                    check = IsOperand(Console.ReadLine());
                }
                double y = Convert.ToDouble(answer);  // второе число
                Console.WriteLine($"Результат:{Calculation(x, y, oper) :F2}");
                Console.WriteLine("Продолжить? (Y/N)");
                answer = Console.ReadLine().ToLower();
                while (answer != "y" && answer != "n") // Проверка корректного ввода
                {
                    Console.WriteLine("Введите Y или N");
                    answer = Console.ReadLine().ToLower();
                }
                if (answer == "n")
                {
                    break;
                }

            }
        }
        static bool IsOperand(string s)   // проверка валидности операнда
        {
            return double.TryParse(s, NumberStyles.Any, CultureInfo.CurrentCulture, out _);
        }
        static bool IsOperator(string s)    // проверка валидности оператора
        {
            return s == "+" || s == "-" || s == "*" || s == "/";
        }
        static double Calculation(double x, double y, string oper)
        {
            switch (oper)
            {
                case "+": return x + y;
                case "-": return x - y;
                case "*": return x * y;
                case "/":
                    if (y == 0)
                    {
                        Console.WriteLine("Ошибка: деление на ноль!");
                        return double.NaN;
                    }
                            return x / y;
                default: return -1;
            }
        }
    }
}
