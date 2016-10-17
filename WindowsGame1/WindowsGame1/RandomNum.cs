
using System;
using System.Threading;

public static class RandomNum
{
    private static int seed;

    private static ThreadLocal<Random> threadLocal = new ThreadLocal<Random>(() => new Random(Interlocked.Increment(ref seed)));

    static RandomNum()
    {
        seed = Environment.TickCount;
    }

    public static Random Instance
    {
        get
        {
            return threadLocal.Value;
        }
    }
}