using System;

namespace MathLibrary
{
    /// <summary>
    /// Класс для выполнения математических операций
    /// </summary>
    public class MathOperations
    {
        /// <summary>
        /// Возводит число в указанную степень
        /// </summary>
        /// <param name="baseNumber">Основание степени</param>
        /// <param name="exponent">Показатель степени</param>
        /// <returns>Результат возведения в степень</returns>
        /// <exception cref="ArgumentException">Выбрасывается при некорректных аргументах</exception>
        public static double Power(double baseNumber, double exponent)
        {
            ValidatePowerArguments(baseNumber, exponent);
            return Math.Pow(baseNumber, exponent);
        }

        /// <summary>
        /// Вычисляет факториал числа
        /// </summary>
        /// <param name="n">Неотрицательное целое число (максимум 20)</param>
        /// <returns>Факториал числа n</returns>
        /// <exception cref="ArgumentException">Выбрасывается при некорректных аргументах</exception>
        public static long Factorial(int n)
        {
            ValidateFactorialArgument(n);
            return ComputeFactorial(n);
        }

        /// <summary>
        /// Решает квадратное уравнение вида ax^2 + bx + c = 0
        /// </summary>
        /// <param name="a">Коэффициент при x^2 (не может быть равен 0)</param>
        /// <param name="b">Коэффициент при x</param>
        /// <param name="c">Свободный член</param>
        /// <returns>Массив действительных корней уравнения</returns>
        /// <exception cref="ArgumentException">Выбрасывается при a = 0</exception>
        public static double[] SolveQuadratic(double a, double b, double c)
        {
            ValidateQuadraticArguments(a);

            double discriminant = CalculateDiscriminant(a, b, c);
            return FindRoots(a, b, discriminant);
        }

        #region Приватные вспомогательные методы

        private static void ValidatePowerArguments(double baseNumber, double exponent)
        {
            if (double.IsNaN(baseNumber) || double.IsNaN(exponent))
                throw new ArgumentException("Аргументы не могут быть NaN");

            if (double.IsInfinity(baseNumber) || double.IsInfinity(exponent))
                throw new ArgumentException("Аргументы не могут быть бесконечностью");
        }

        private static void ValidateFactorialArgument(int n)
        {
            if (n < 0)
                throw new ArgumentException("Факториал отрицательного числа не определен", nameof(n));

            if (n > 20)
                throw new ArgumentException("Факториал >20 вызывает переполнение", nameof(n));
        }

        private static long ComputeFactorial(int n)
        {
            long result = 1;
            for (int i = 2; i <= n; i++)
            {
                checked
                {
                    result *= i;
                }
            }
            return result;
        }

        private static void ValidateQuadraticArguments(double a)
        {
            if (Math.Abs(a) < double.Epsilon)
                throw new ArgumentException("Коэффициент a не может быть равен 0", nameof(a));
        }

        private static double CalculateDiscriminant(double a, double b, double c)
        {
            return b * b - 4 * a * c;
        }

        private static double[] FindRoots(double a, double b, double discriminant)
        {
            if (discriminant < -1e-10)
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

        /// <summary>
        /// Вычисляет площадь круга
        /// </summary>
        public static double CircleArea(double radius)
        {
            if (radius < 0)
                throw new ArgumentException("Радиус не может быть отрицательным");
            return Math.PI * radius * radius;
        }

        /// <summary>
        /// Конвертирует температуру из Цельсия в Фаренгейт
        /// </summary>
        public static double CelsiusToFahrenheit(double celsius)
        {
            return celsius * 9 / 5 + 32;
        }

        /// <summary>
        /// Вычисляет гипотенузу по двум катетам
        /// </summary>
        public static double Hypotenuse(double a, double b)
        {
            if (a < 0 || b < 0)
                throw new ArgumentException("Катеты не могут быть отрицательными");
            return Math.Sqrt(a * a + b * b);
        }

        #endregion
    }
}