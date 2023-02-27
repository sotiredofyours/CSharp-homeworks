namespace Lazy;

public class Lazy<T> : ILazy<T>
{
    private bool isCalculated;
    private T result;
    private Func<T> supplier;

    public Lazy(Func<T> supplier) => this.supplier = supplier;
    
    public T Get()
    {
        if (isCalculated) 
            return result;
        result = supplier();
        isCalculated = true;
        supplier = null;
        
        return result;
    }
}