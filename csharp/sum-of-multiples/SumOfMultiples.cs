using System;
using System.Linq;
using System.Collections.Generic;

// Given a number, find the sum of all the unique multiples of particular numbers up to
// but not including that number.

// If we list all the natural numbers below 20 that are multiples of 3 or 5,
// we get 3, 5, 6, 9, 10, 12, 15, and 18.

// The sum of these multiples is 78.
 
// This exercise requires you to process a collection of data. You can simplify your code by using LINQ (Language Integrated Query).
// For more information, see [this page](https://docs.microsoft.com/en-us/dotnet/articles/standard/using-linq).
public static class SumOfMultiples
{
    public static int Sum(IEnumerable<int> multiples, int max)
    { 
      int n;
      int answer = 0;
      List<int> x = new List<int>();
      foreach(int multiple in multiples){
        if(multiple == 0){
          n = 0;
        }
        else if(Math.DivRem(max, multiple).Remainder == 0){
          n = (max / multiple) - 1;     
        }
        else{
          n = (max / multiple);
        }
        x.AddRange(Enumerable.Range(1, n).ToList().Select(x => x * multiple));
      }
      answer = x.Distinct().Sum();
      return answer;
    }
}