namespace Lazy;

public class ThreadSafetyLazy<T> : ILazy<T>
{
    private T? result; 
    private Func<T> supplier;
    private volatile bool isCalculated;

    private readonly object lockObj = new();

    public ThreadSafetyLazy(Func<T> supplier) => this.supplier = supplier;
    public T? Get()
    {
        if (isCalculated) 
            return result; 
        lock (lockObj)
        {
            if (isCalculated) 
                 return result; 
            result = supplier();
            isCalculated = true;
            supplier = null;
            return result;
        }
    }
}