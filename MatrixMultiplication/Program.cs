using System.Diagnostics;
using MatrixMultiplication;


    var stopwatch = new Stopwatch();
    MatrixGenerator.GenerateMatrixInFile("matrix1.txt", 2000, 500);
    MatrixGenerator.GenerateMatrixInFile("matrix2.txt", 500, 1600);
    var matrix1 = new Matrix("matrix1.txt");
    var matrix2 = new Matrix("matrix2.txt");
    stopwatch.Start();
    MatrixMultiplier.ConsistentMultiplication(matrix1, matrix2);
    stopwatch.Stop();
    Console.WriteLine($"Time of consistent multiplication  " + stopwatch.Elapsed );
    stopwatch = Stopwatch.StartNew();
    MatrixMultiplier.ParallelMultiplication(matrix1, matrix2);
    stopwatch.Stop();
    Console.WriteLine($"Time of parallel multiplication  " + stopwatch.Elapsed);
