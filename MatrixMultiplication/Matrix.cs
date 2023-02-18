namespace MatrixMultiplication;

public class Matrix
{
    public int Columns => _matrix.GetLength(1);
    public int Rows => _matrix.GetLength(0);
    
    private readonly int[,] _matrix;
    
    public Matrix(string path)
    {
        _matrix = ReadMatrixFromFile(path);
    }

    public Matrix(int[,] matrix)
    { 
        var rows = matrix.GetLength(0);
        var columns = matrix.GetLength(1);
        _matrix = new int[rows, columns];
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                _matrix[i, j] = matrix[i, j];
            }
        }
    }

    public int this[int row, int column]
    {
        get => _matrix[row, column];
        set => _matrix[row, column] = value;
    }

    public override bool Equals(object? obj)
    {
        if (obj is null || obj.GetType() != GetType()) 
            return false;
        
        var other = (Matrix) obj;
        if (Rows != other.Rows || Columns != other.Columns)
            return false;
        
        for (int i = 0; i < Rows; i++)
        {
            for (int j = 0; j < Columns; j++)
            {
                if (this[i, j] != other[i, j]) return false;
            }
        }

        return true;
    }

    private int[,] ReadMatrixFromFile(string path)
    {
        var text = File.ReadLines(path);
        
        var numberOfRows = text.Count();
        using var linesEnumerator = text.GetEnumerator();
        linesEnumerator.MoveNext();
        if (linesEnumerator.Current == null) return new int[0, 0];
        var numberOfColumns = linesEnumerator.Current.Split().Length;
        var resultMatrix = new int[numberOfRows, numberOfColumns];
        
        for (int row = 0; row < numberOfRows; row++)
        {
            var line = linesEnumerator.Current.Split();
            var parsedLine = Array.ConvertAll(line, int.Parse);
            for (int column = 0; column < numberOfColumns; column++)
            {
                resultMatrix[row, column] = parsedLine[column];
            }
            
            linesEnumerator.MoveNext();
        }

        return resultMatrix;
    }

    private void WriteMatrixInFile(string path)
    {
        using var writer = new StreamWriter(path);
        for (int row = 0; row < Rows; row++)
        {
            for (int column = 0; column < Columns; column++)
            {
                writer.Write(_matrix[row,column] + (column == Columns-1 ? string.Empty : " "));
            }

            if (row != Rows - 1) writer.WriteLine();
        }
    }
}