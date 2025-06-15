using System;

public class IntegralCalculator
{
    public double CalculateLeftRectangle(Func<double, double> func, double a, double b, int n)
    {
        if (n <= 0)
        {
            throw new ArgumentException("Кількість прямокутників (n) має бути додатною.");
        }
        if (b <= a)
        {
            throw new ArgumentException("Верхня межа (b) має бути більшою за нижню (a).");
        }

        double h = (b - a) / n;
        double sum = 0.0;

        for (int i = 0; i < n; i++)
        {
            double x = a + i * h;
            sum += func(x);
        }

        return h * sum;
    }
}

public class Program
{
    public static double Parabola(double x)
    {
        return x * x;
    }

    public static double Sinusoid(double x)
    {
        return Math.Sin(x);
    }

    public static void Main(string[] args)
    {
        var calculator = new IntegralCalculator();
        int precision = 1000;

        Console.WriteLine($"Точність обчислень: {precision} кроків.\n");

        double result1 = calculator.CalculateLeftRectangle(Parabola, 0, 1, precision);
        Console.WriteLine($"Інтеграл від x^2 на [0, 1]: {result1:F6}");
        Console.WriteLine("(Точне значення: 0.333333)\n");

        double result2 = calculator.CalculateLeftRectangle(Sinusoid, 0, Math.PI, precision);
        Console.WriteLine($"Інтеграл від sin(x) на [0, PI]: {result2:F6}");
        Console.WriteLine("(Точне значення: 2.000000)\n");

        double result3 = calculator.CalculateLeftRectangle(x => 1.0 / x, 1, 2, precision);
        Console.WriteLine($"Інтеграл від 1/x на [1, 2]: {result3:F6}");
        Console.WriteLine("(Точне значення: 0.693147)\n");
    }
}