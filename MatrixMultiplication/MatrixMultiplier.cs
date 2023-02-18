namespace MatrixMultiplication;

/// <summary>
/// A class for multiplying matrices.
/// </summary>
public static class MatrixMultiplier
{
    /// <summary>
    /// Sequential multiplication of matrix.
    /// </summary>
    /// <param name="left">First of matrix for a multiplication.</param>
    /// <param name="right">Second of matrix to multiplication.</param>
    /// <returns>Result of multiplication</returns>
    public static Matrix SequentialMultiplication(Matrix left, Matrix right)
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
    
    /// <summary>
    /// Parallel multiplication of matrix.
    /// </summary>
    /// <param name="left">First of matrix for a multiplication.</param>
    /// <param name="right">Second of matrix to multiplication.</param>
    /// <returns>Result of multiplication</returns>
    public static Matrix ParallelMultiplication(Matrix left, Matrix right)
    {
        if (left.Columns != right.Rows)
        {
            throw new ArithmeticException("Can`t multiply this matrix!");
        }

        var resultMatrix = new int[left.Rows, right.Columns];
        var threads = new Thread[Environment.ProcessorCount];
        var chunkSize = Math.Max(1, left.Rows / threads.Length);
        
        for (int i = 0; i < threads.Length; i++)
        {
            var localI = i;
            threads[i] = new Thread(() =>
            {
                for (int rows = localI * chunkSize; rows < (localI + 1) * chunkSize && rows < left.Rows; ++rows)
                {
                    for (int columns = 0; columns < right.Columns; columns++)
                    {
                        resultMatrix[rows, columns] = DotProduct(left, right, rows, columns);
                    }
                }
            });
        }

        foreach (var thread in threads)
        {
            thread.Start();
        }

        foreach (var thread in threads)
        {
            thread.Join();
        }

        return new Matrix(resultMatrix);
    }

    private static int DotProduct(Matrix left, Matrix right, int row, int column)
    {
        var sum = 0;
        for (int i = 0; i < left.Columns; i++)
        {
            sum += left[row, i] * right[i, column];
        }

        return sum;
    }
}