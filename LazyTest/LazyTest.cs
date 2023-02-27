using System;
using System.Threading;
using Lazy;
using NUnit.Framework;

namespace LazyTest;

[TestFixture]
public class Tests
{
    [Test]
    public void NullSupplier()
    {
        Assert.Throws<ArgumentNullException>(() => LazyFactory.CreateLazy<double>(null));
        Assert.Throws<ArgumentNullException>(() => LazyFactory.CreateThreadSafetyLazy<double>(null));
    }

    [Test]
    public void OneThreadLazyTest()
    {
        var val = 0;
        var func = new Func<int>(() => ++val);

        var lazy = LazyFactory.CreateLazy(func);

        Assert.AreEqual(1, lazy.Get());
        Assert.AreEqual(1, lazy.Get());
    }
    
    [Test]
    [Repeat(15)]
    public void MultiThreadedLazyTest()
    {
        var val = 0;
        var func = new Func<int>(() => ++val);
        
        var mtLazy = LazyFactory.CreateThreadSafetyLazy(func);

        var results = new int[3];
        
        var threads = new Thread[3];
        for (int i = 0; i < 3; i++)
        {
            var localI = i;
            threads[i] = new Thread(() =>
            {
                results[localI] = mtLazy.Get();
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

        foreach (var result in results)
        {
            Assert.AreEqual(1, result);
        }
    }
}