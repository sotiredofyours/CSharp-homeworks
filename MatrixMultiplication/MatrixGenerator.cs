namespace MatrixMultiplication;

public class MatrixGenerator
{
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