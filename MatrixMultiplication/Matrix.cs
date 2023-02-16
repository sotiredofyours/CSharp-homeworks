namespace MatrixMultiplication;

public class Matrix
{
    private readonly int _rows;
    private readonly int _columns; 
    private readonly int[,] _matrix;

    public Matrix(string path)
    {
        _matrix = ReadMatrixFromFile(path);
        _rows = _matrix.GetLength(0);
        _columns = _matrix.GetLength(1);
    }

    public Matrix(int[,] matrix)
    { 
        _rows = matrix.GetLength(0);
        _columns = matrix.GetLength(1);
        for (int i = 0; i < _rows; i++)
        {
            for (int j = 0; j < _columns; j++)
            {
                _matrix[i, j] = matrix[i, j];
            }
        }
    }

    public int Rows => _rows;
    public int Columns => _columns;
    public int[,] GetMatrix => _matrix;

    private int[,] ReadMatrixFromFile(string path)
    {
        var text = File.ReadLines(path);
        
        var numberOfRows = text.Count();
        using var linesEnumerator = text.GetEnumerator();
        linesEnumerator.MoveNext();
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
        for (int row = 0; row < _rows; row++)
        {
            for (int column = 0; column < _columns; column++)
            {
                writer.Write(_matrix[row,column] + (column == _columns-1 ? string.Empty : " "));
            }

            if (row != _rows - 1) writer.WriteLine();
        }
    }
}