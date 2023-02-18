using System;
using NUnit.Framework;

namespace MatrixMultiplication.Tests;

[TestFixture]
public class MatrixMultiplicationTests
{
    [Test]
    public void SimpleMatrixTest()
    {
        var array1 = new int[2, 3] { { 1, 2, 3 },
            { 4, 5, 6 } };

        var array2 = new int[3, 2] { { -2, -1 },
            { 0, 1 },
            { 2, 3 } };

        var expectedArray = new int[2, 2] { { 4, 10 },
            { 4, 19 } };

        var matrix1 = new Matrix(array1);
        var matrix2 = new Matrix(array2);
        var expected = new Matrix(expectedArray);
        
        var sequential = MatrixMultiplier.SequentialMultiplication(matrix1, matrix2);
        var parallel =  MatrixMultiplier.ParallelMultiplication(matrix1, matrix2);
        
        Assert.AreEqual(expected, parallel);
        Assert.AreEqual(expected, sequential);
    }
    
    [Test]
    public void EmptyMatrixTest()
    {
        var array1 = new int[0, 0];
        var array2 = new int[0, 0];
        var expectedArray = new int[0, 0];

        var matrix1 = new Matrix(array1);
        var matrix2 = new Matrix(array2);
        var expected = new Matrix(expectedArray);
        
        var sequential = MatrixMultiplier.SequentialMultiplication(matrix1, matrix2);
        var parallel =  MatrixMultiplier.ParallelMultiplication(matrix1, matrix2);
        
        Assert.AreEqual(expected, parallel);
        Assert.AreEqual(expected, sequential);
    }
    
    [Test]
    public void UnitMatrixTest()
    {
        var array1 = new int[,] { { 1 } };
        var array2 = new int[,] { { 1 } };
        var expectedArray = new int[,] { { 1 } };

        var matrix1 = new Matrix(array1);
        var matrix2 = new Matrix(array2);
        var expected = new Matrix(expectedArray);
        
        var consistent = MatrixMultiplier.SequentialMultiplication(matrix1, matrix2);
        var parallel =  MatrixMultiplier.ParallelMultiplication(matrix1, matrix2);
        
        Assert.AreEqual(expected, parallel);
        Assert.AreEqual(expected, consistent);
    }
    
}