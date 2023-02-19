namespace MatrixMultiplication;

/// <summary>
/// A class for generating matrices.
/// </summary>
public class MatrixGenerator
{
    /// <summary>
    /// Generate matrix with random values.
    /// </summary>
    /// <param name="rows">Number of rows.</param>
    /// <param name="columns">Number of columns.</param>
    /// <returns></returns>
    public static Matrix GenerateMatrix(int rows, int columns)
    {
        var rnd = new Random();
        var matrix = new int[rows, columns];
        for (int row = 0; row < rows; row++)
        {
            for (int column = 0; column < columns; column++)
            {
                matrix[row, column] = rnd.Next(Int32.MaxValue);
            }
        }

        return new Matrix(matrix);
    }
    
    /// <summary>
    /// Generate and write matrix in file
    /// </summary>
    /// <param name="filename">Name of file.</param>
    /// <param name="rows">Number of rows.</param>
    /// <param name="columns">Number of columns.</param>
    public static void GenerateMatrixInFile(string filename, int rows, int columns)
    {
        var rnd = new Random();
        using var streamWriter = new StreamWriter(filename, false);
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                streamWriter.Write($"{rnd.Next(Int32.MaxValue)}" + (j == columns-1 ? string.Empty : " "));
            }
            streamWriter.WriteLine();
        }
    }
}