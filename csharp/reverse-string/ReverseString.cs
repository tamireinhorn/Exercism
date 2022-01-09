using System;
using System.Collections.Generic;
using System.Linq;
public static class ReverseString
{
    public static string Reverse(string input)
    {
        var x = input.ToCharArray();
        int Size = x.Length;
        for(int i = 0;  i < Size; i++){
            x[Size - 1 - i] = input[i];
        }
        return new string(x);

    }
}