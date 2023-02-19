using System;
using System.Diagnostics;
using System.IO;
using NUnit.Framework;

namespace MatrixMultiplication.Tests;

[TestFixture]
public class TestsInTable
{
    private double RMSE(long[] values)
    {
        var n = values.Length;
        var sum = 0d;
        var avg = Avg(values);
        for (int i = 0; i < n; i++)
        {
            sum += Math.Pow(values[i] - avg, 2) / n;
        }

        return Math.Sqrt(sum);
    }

    private double Avg(long[] values)
    {
        var sum = 0d;
        var n = values.Length;
        
        foreach (var value in values)
        {
            sum += value;
        }
        return sum / n; 
    }

    private void BuildHeader(StreamWriter stringWriter)
    {
        var header =
            @"
+---------+--------------------------+------------------------+
|   Size  |        Sequential        |        Parallel        |
|         |  Avg (ms)  |  RMSE(ms)   |  Avg (ms)  |  RMSE(ms) |
+---------+--------------------------+------------+-----------+";
        stringWriter.WriteLine(header);
    }

    [Test]
    public void TestsFactory()
    {
        var timesToRepeat = 20;
        using var streamWriter = new StreamWriter("table.txt");
        BuildHeader(streamWriter);
        var stopwatch = new Stopwatch();
        for (int i = 100; i <= 500 ; i+= 50)
        {
            var valuesFromSeq = new long[timesToRepeat];
            var valuesFromParallel = new long[timesToRepeat];
            
            MatrixGenerator.GenerateMatrixInFile("matrix1.txt", i, i);
            MatrixGenerator.GenerateMatrixInFile("matrix2.txt", i, i);
            
            var matrix1 = new Matrix("matrix1.txt");
            var matrix2 = new Matrix("matrix2.txt");
            for (int j = 0; j < timesToRepeat; j++)
            {
                stopwatch = Stopwatch.StartNew();
                MatrixMultiplier.SequentialMultiplication(matrix1, matrix2);
                stopwatch.Stop();
                valuesFromSeq[j] = stopwatch.ElapsedMilliseconds;
                stopwatch = Stopwatch.StartNew();
                MatrixMultiplier.ParallelMultiplication(matrix1, matrix2);
                stopwatch.Stop();
                valuesFromParallel[j] = stopwatch.ElapsedMilliseconds;
            }

            var resultsSeq = $"| {i:000}x{i:000} |   {Avg(valuesFromSeq):0000000}   |  {RMSE(valuesFromSeq):000000.0}  |";
            var resultsParallel =  $"  {Avg(valuesFromParallel):0000000}   | {RMSE(valuesFromParallel):000000.0}  |";
            streamWriter.Write(resultsSeq);
            streamWriter.WriteLine(resultsParallel);
        }
        
        streamWriter.WriteLine("+---------+--------------------------+------------+-----------+");
    }
}