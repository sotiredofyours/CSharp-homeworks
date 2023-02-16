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
}