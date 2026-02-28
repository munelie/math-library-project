using System;

namespace MathLibrary
{
    public class MathOperations
    {
        // Метод для возведения в степень с проверками
        public static double Power(double baseNumber, double exponent)
        {
            if (double.IsNaN(baseNumber) || double.IsNaN(exponent))
                throw new ArgumentException("Аргументы не могут быть NaN");

            if (double.IsInfinity(baseNumber) || double.IsInfinity(exponent))
                throw new ArgumentException("Аргументы не могут быть бесконечностью");

            return Math.Pow(baseNumber, exponent);
        }

        // Метод для вычисления факториала с проверками
        public static long Factorial(int n)
        {
            if (n < 0)
                throw new ArgumentException("Факториал отрицательного числа не определен");

            if (n > 20)
                throw new ArgumentException("Факториал >20 вызывает переполнение типа long");

            long result = 1;
            for (int i = 2; i <= n; i++)
            {
                checked // Проверяем переполнение
                {
                    result *= i;
                }
            }
            return result;
        }

        // Метод для решения квадратного уравнения с проверками
        public static double[] SolveQuadratic(double a, double b, double c)
        {
            if (Math.Abs(a) < double.Epsilon)
                throw new ArgumentException("Коэффициент a не может быть равен 0");

            double discriminant = b * b - 4 * a * c;

            // Нет действительных корней
            if (discriminant < -1e-10)
                return new double[0];

            // Один корень (дискриминант близок к нулю)
            if (Math.Abs(discriminant) < 1e-10)
                return new double[] { -b / (2 * a) };

            // Два корня
            double sqrtDiscriminant = Math.Sqrt(discriminant);
            return new double[]
            {
                (-b + sqrtDiscriminant) / (2 * a),
                (-b - sqrtDiscriminant) / (2 * a)
            };
        }
    }
}