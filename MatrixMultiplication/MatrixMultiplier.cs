namespace MatrixMultiplication;

public class MatrixMultiplier
{
    public static Matrix ConsistentMultiplication(Matrix left, Matrix right)
    {
        if (left.Columns != right.Rows)
        {
            throw new ArithmeticException("Can`t multiply this matrix!");
        }

        var resultMatrix = new int[left.Rows, right.Columns];
        for (int row = 0; row < left.Rows; row++)
        {
            for (int column = 0; column < right.Columns; column++)
            {
                resultMatrix[row, column] = DotProduct(left, right, row, column);
            }
        }

        return new Matrix(resultMatrix);
    }

    private static int DotProduct(Matrix left, Matrix right, int row, int column)
    {
        var sum = 0;
        for (int i = 0; i < left.Rows; i++)
        {
            sum += left.GetMatrix[row, i] * right.GetMatrix[i, column];
        }

        return sum;
    }

    public static Matrix ParallelMultiplication(Matrix left, Matrix right)
    {
        throw new NotImplementedException();
    }
}