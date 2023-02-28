namespace Lazy;

public static class LazyFactory
{
    public static ILazy<T> CreateLazy<T>(Func<T> supplier)
    {
        if (supplier == null) 
            throw new ArgumentNullException();
        return new Lazy<T>(supplier);
    }

    public static ILazy<T> CreateThreadSafetyLazy<T>(Func<T> supplier)
    {
        if (supplier == null)
            throw new ArgumentNullException();
        return new ThreadSafetyLazy<T>(supplier);
    }
}