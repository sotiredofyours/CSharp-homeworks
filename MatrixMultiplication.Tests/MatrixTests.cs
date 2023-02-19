using System.IO;
using NUnit.Framework;

namespace MatrixMultiplication.Tests;

[TestFixture]
public class MatrixTests
{
    [Test]
    public void MatrixFromFile()
    {
        var matrixInString = "1 1\n1 1";
        var array = new int[,] { {1, 1}, {1, 1} };
        using var streamWriter = new StreamWriter("test1.txt", false);
        streamWriter.WriteLine(matrixInString);
        streamWriter.Close();
        
        var matrix = new Matrix("test1.txt");
        
        Assert.AreEqual(2, matrix.Rows);
        Assert.AreEqual(2, matrix.Columns);
        Assert.AreEqual(new Matrix(array), matrix);
    }
    
    [Test]
    public void MatrixFromEmptyFile()
    {
        using var streamWriter = new StreamWriter("test2.txt", false);
        streamWriter.Close();
        var matrix = new Matrix("test2.txt");
        var emptyMatrix = new Matrix(0, 0);
        Assert.AreEqual(matrix, emptyMatrix);
    }
    
    [Test]
    public void MatrixFromArrayTest()
    {
        var expected = new int[1, 1] { { 0 } };
        var matrix = new Matrix(expected);

        expected[0, 0] = -1;
        Assert.AreNotEqual(expected[0, 0], matrix[0, 0]);
    }
    
    [Test]
    public void EqualsTest()
    {
        var array1 = new int[1, 1] { { 1 } };
        var matrix1 = new Matrix(array1);

        var array2 = new int[2, 1] { { 1 }, { 2 } };
        var matrix2 = new Matrix(array2);

        Assert.IsFalse(matrix1.Equals(matrix2));
        Assert.IsTrue(matrix1.Equals(matrix1));
        Assert.IsFalse(matrix1.Equals(array1));
    }

    [Test]
    public void IndexatorTest()
    {
        var array = new int[,] { { 1 }, { 4 } };
        var matrix = new Matrix(2, 2)
        {
            [0, 0] = 1,
            [1, 0] = 4
        };

        for (int i = 0; i < array.GetLength(0); i++)
        {
            for (int j = 0; j < array.GetLength(1); j++)
            {
                array[i, j] = matrix[i, j];
            }
        }
    }
}