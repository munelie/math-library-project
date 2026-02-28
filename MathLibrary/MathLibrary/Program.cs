using System;
using MathLibrary;

class Program
{
    static void Main()
    {
        // Возведение в степень
        double powerResult1 = MathOperations.Power(2, 3);
        Console.WriteLine($"   2^3 = {powerResult1} (ожидается 8)");

        double powerResult2 = MathOperations.Power(5, 2);
        Console.WriteLine($"   5^2 = {powerResult2} (ожидается 25)");

        double powerResult3 = MathOperations.Power(10, 0);
        Console.WriteLine($"   10^0 = {powerResult3} (ожидается 1)\n");

        //Факториал

        long factResult1 = MathOperations.Factorial(5);
        Console.WriteLine($"   5! = {factResult1} (ожидается 120)");

        long factResult2 = MathOperations.Factorial(10);
        Console.WriteLine($"   10! = {factResult2} (ожидается 3628800)\n");

        // Квадратные уравнения

        var roots1 = MathOperations.SolveQuadratic(1, -3, 2);
        Console.WriteLine($"   x^2 - 3x + 2 = 0");
        Console.WriteLine($"   Корни: {string.Join(" и ", roots1)} (ожидается 2 и 1)\n");

        var roots2 = MathOperations.SolveQuadratic(1, -4, 4);
        Console.WriteLine($"   x^2 - 4x + 4 = 0");
        Console.WriteLine($"   Корни: {string.Join(" и ", roots2)} (ожидается 2)\n");

        var roots3 = MathOperations.SolveQuadratic(1, 0, 1);
        Console.WriteLine($"   x^2 + 1 = 0");
        Console.WriteLine($"   Корней: {roots3.Length} (ожидается 0)\n");
    }
}