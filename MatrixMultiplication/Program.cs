using System.Diagnostics;
using MatrixMultiplication;

var stopwatch = new Stopwatch();

MatrixGenerator.GenerateMatrixInFile("matrix1.txt", 100, 100);
MatrixGenerator.GenerateMatrixInFile("matrix2.txt", 100, 100);

var matrix1 = new Matrix("matrix1.txt");
var matrix2 = new Matrix("matrix2.txt");

stopwatch.Start();
MatrixMultiplier.SequentialMultiplication(matrix1, matrix2);
stopwatch.Stop();
Console.WriteLine($"Time of consistent multiplication " + stopwatch.Elapsed);

stopwatch = Stopwatch.StartNew();
MatrixMultiplier.ParallelMultiplication(matrix1, matrix2);
stopwatch.Stop();
Console.WriteLine($"Time of parallel multiplication " + stopwatch.Elapsed);
