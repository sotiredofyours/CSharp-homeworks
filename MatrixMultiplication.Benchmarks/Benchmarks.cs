using BenchmarkDotNet.Attributes;

namespace MatrixMultiplication.Tests;

[RankColumn]
public class Benchmarks
{
    private readonly (Matrix, Matrix)[] _data = new (Matrix, Matrix)[3];

    public Benchmarks()
    {
        for (int i = 0; i < 3; i++)
        {
            _data[i] = (MatrixGenerator.GenerateMatrix((i+1) * 100, (i+1) * 100),
                MatrixGenerator.GenerateMatrix((i+1) * 100, (i+1) * 100));
        }
    }

    [Benchmark]
    public void Parallel()
    {
        foreach (var matrix in _data) 
            MatrixMultiplier.ParallelMultiplication(matrix.Item1, matrix.Item2);
    }

    [Benchmark]
    public void Sequential()
    {
        foreach (var matrix in _data) 
            MatrixMultiplier.SequentialMultiplication(matrix.Item1, matrix.Item2);
    }

    [Benchmark]
    public void Tasks()
    {
        foreach (var matrix in _data) 
            MatrixMultiplier.ParallelWithTasks(matrix.Item1, matrix.Item2);
    }
}
