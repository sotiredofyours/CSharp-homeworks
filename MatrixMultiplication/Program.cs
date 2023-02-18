using System.Diagnostics;
using MatrixMultiplication;

for (int i = 10; i <= 1000; i+=10) {
    var stopwatch = new Stopwatch();
    MatrixGenerator.GenerateMatrixInFile("matrix1.txt", i, i);
    MatrixGenerator.GenerateMatrixInFile("matrix2.txt", i, i);
    var matrix1 = new Matrix("matrix1.txt");
    var matrix2 = new Matrix("matrix2.txt");
    stopwatch.Start();
    MatrixMultiplier.SequentialMultiplication(matrix1, matrix2);
    stopwatch.Stop();
    Console.WriteLine($"Time of consistent multiplication {i}x{i} " + stopwatch.Elapsed);
    stopwatch = Stopwatch.StartNew();
    MatrixMultiplier.ParallelMultiplication(matrix1, matrix2);
    stopwatch.Stop();
    Console.WriteLine($"Time of parallel multiplication {i}x{i} " + stopwatch.Elapsed);
}