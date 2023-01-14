using System;

class Program
{
    //метод для вычисления значения интеграла по формуле Симпсона
    private static double Simpson(Func<double, double> f, double a, double b, int n)
    {
        var h = (b - a) / n;
        var sum1 = 0d;
        var sum2 = 0d;
        for (var k = 1; k <= n; k++)
        {
            var xk = a + k * h;
            if (k <= n - 1)
            {
                sum1 += f(xk);
            }

            var xk_1 = a + (k - 1) * h;
            sum2 += f((xk + xk_1) / 2);
        }

        var result = h / 3d * (1d / 2d * f(a) + sum1 + 2 * sum2 + 1d / 2d * f(b));
        return result;
    }

    static void Main(string[] args)
    {
        //локальная функция
        double f(double x) => x / (x - 1);

        var result = Simpson(f, 4, 10, 1000);
        Console.WriteLine("S = {0}", result);

        Console.ReadKey();
    }
}
