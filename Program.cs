using System;
using System.Linq;

class Program
{
    static double CalculatePearsonCorrelation(double[] x, double[] y)
    {
        // �������� ������� ����������� ���������� ��������� � ����� ��������
        if (x.Length != y.Length)
            throw new ArgumentException("��� ������� ������ ����� ���������� �����.");

        int n = x.Length;
       
        double sumX = x.Sum();
        double sumY = y.Sum();
        double sumX2 = x.Select(xx => xx * xx).Sum();
        double sumY2 = y.Select(yy => yy * yy).Sum();
        double sumXY = x.Zip(y, (xx, yy) => xx * yy).Sum();

        // ������ ���������� �������
        double numerator = n * sumXY - sumX * sumY;
        double denominator = Math.Sqrt((n * sumX2 - sumX * sumX) * (n * sumY2 - sumY * sumY));
        double correlation = numerator / denominator;

        return correlation;
    }

    static void Main()
    {
        // ������ �������������
        double[] array1 = { 1, 2, 3, 4, 5 };
        double[] array2 = { 2, 4, 6, 8, 10 };

        double correlation = CalculatePearsonCorrelation(array1, array2);

        Console.WriteLine("���������� �������: " + correlation);
        Console.ReadLine();
    }
}