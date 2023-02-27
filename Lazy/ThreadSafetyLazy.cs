namespace Lazy;

public class ThreadSafetyLazy<T> : ILazy<T>
{
    private T result; 
    private Func<T> supplier;
    private bool isCalculated;

    private readonly object lockObj = new();

    public ThreadSafetyLazy(Func<T> supplier) => this.supplier = supplier;
    public T Get()
    {
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