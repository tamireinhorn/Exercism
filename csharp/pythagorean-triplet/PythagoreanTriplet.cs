using System;
using System.Collections.Generic;
using System.Linq;

// # We can solve this with math:
// # a < b < c (0)
// # a^2 + b^2 = c^2 (1)
// # a + b + c = N (2)
// # From (2), we get c = N - a - b
// # Applying that to (1):
// # a ^2 + b^2 = (N - a - b)^2
// # a^2 + b^2 = N ^2 + a^2 + b^2 - 2Na - 2Nb + 2ab
// # 0 = N ^2 - 2Na - 2Nb + 2ab => 2Nb - 2ab = N^2 - 2Na
// # 2b(N - a) = N^2 - 2Na
// # b = (N^2 - 2Na)/ 2(N-a)
// # If b is an integer, we got it!
// # But we don't need to stop there.
// # Using (0) with c, we get: a < b < N - a - b => a < N - a -b => a < (N-b) /2
// # Also, b < N - a -b => b < (N-a) / 2 and since a < b, we get: a < (N-a) /2 => 2a < (N -a)
// # So, 3a < N => a < N/3!

public static class PythagoreanTriplet
{
    public static IEnumerable<(int a, int b, int c)> TripletsWithSum(int number)
    {
        var x = new List<(int a, int b, int c)>();
        var c_list = new List<int> (){0};
        foreach(var a in Enumerable.Range(1, (int)number/3 -1)){
            var b = ((number * number) - (2 * number * a)) / (2 * (number - a));
            if(b % 1 == 0){
                var previous_a = a;
                var c_2 = (number - a - b) * (number - a - b);
                var c = (int)Math.Sqrt(c_2);
                if((a * a + b * b == c_2) &(!c_list.Contains(c))){ // We don't ever want to repeat a c, because it's just a,b or b,a!
                    c_list.Add(c);
                    x.Add((a, b, c));
                }
            }
        }
        return x;
    }
}