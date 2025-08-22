using System;

public static class RNG
{
    private static Random rng = new Random();

    /// <summary>
    /// Returns a random integer between min [inclusive] and max [exclusive].
    /// </summary>
    public static int NextInt(int min, int max)
    {
        return rng.Next(min, max);
    }

    /// <summary>
    /// Returns a random float between 0.0 and 1.0.
    /// </summary>
    public static float NextFloat()
    {
        return (float)rng.NextDouble();
    }
}
