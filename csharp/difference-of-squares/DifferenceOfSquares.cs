using System;
using System.Linq;
public static class DifferenceOfSquares
{ 
    public static int CalculateSquareOfSum(int max)
    {
        return (int)Math.Pow((double)Enumerable.Range(1, max).Select(x => x).Sum(),2.0);
    }

    public static int CalculateSumOfSquares(int max)
    {
       return Enumerable.Range(1, max).Select(n => n * n).Sum();
    }

    public static int CalculateDifferenceOfSquares(int max)
    {
        return CalculateSquareOfSum(max) - CalculateSumOfSquares(max);
    }
}