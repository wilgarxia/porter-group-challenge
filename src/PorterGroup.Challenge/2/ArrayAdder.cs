using System.Diagnostics;
using System.Numerics;

namespace PorterGroup.Challenge;

public class ArrayAdder
{
    private readonly object _lock = new();

    public BigInteger Sum(int[] array)
    {
        if (array.Length >= 1_000_000)
            throw new ArgumentException("The array must have less than 1 million itens.");

        ParallelOptions options = new()
        {
            MaxDegreeOfParallelism = Process.GetCurrentProcess().Threads.Count
        };

        long partialSum = 0;
        BigInteger totalSum = 0;

        try
        {
            Parallel.ForEach(array, options, item =>
            {
                lock (_lock)
                {
                    if (!TryAdd(item, ref partialSum))
                    {
                        totalSum += partialSum;
                        partialSum = 0;
                        _ = TryAdd(item, ref partialSum);
                    }
                }
            });

            totalSum += partialSum;
        }
        catch (OutOfMemoryException ex)
        {
            Environment.FailFast(string.Format("Out of Memory: {0}", ex.Message));
        }

        return totalSum;
    }

    private static bool TryAdd(int value, ref long sum)
    {
        checked
        {
            try
            {
                sum += value;
            }
            catch (OverflowException)
            {
                return false;
            }
        }

        return true;
    }
}