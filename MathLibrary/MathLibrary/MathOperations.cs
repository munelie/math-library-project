using System;

namespace MathLibrary
{
    public class MathOperations
    {
        // Метод для возведения в степень
        public static double Power(double baseNumber, double exponent)
        {
            return Math.Pow(baseNumber, exponent);
        }

        // Метод для вычисления факториала
        public static long Factorial(int n)
        {
            if (n < 0)
                throw new ArgumentException("Факториал отрицательного числа не определен");

            long result = 1;
            for (int i = 2; i <= n; i++)
                result *= i;
            return result;
        }

        // Метод для решения квадратного уравнения
        public static double[] SolveQuadratic(double a, double b, double c)
        {
            if (a == 0)
                throw new ArgumentException("Коэффициент a не может быть равен 0");

            double discriminant = b * b - 4 * a * c;

            if (discriminant < 0)
                return new double[0];

            if (Math.Abs(discriminant) < 1e-10)
                return new double[] { -b / (2 * a) };

            double sqrtDiscriminant = Math.Sqrt(discriminant);
            return new double[]
            {
                (-b + sqrtDiscriminant) / (2 * a),
                (-b - sqrtDiscriminant) / (2 * a)
            };
        }
    }
}