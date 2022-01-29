using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections.ObjectModel;
public static class RomanNumeralExtension
{
    public const char One = 'I';
    public const char Five = 'V';

    public const char Ten = 'X';

    public const char Fifty = 'L';

    public const char Hundred = 'C';

    public const char FiveHundred = 'D';

    public const char Thousand = 'M';

    public static readonly Tuple<char, char, char> First = new Tuple<char, char, char>(One,Five, Ten);

    public static readonly Tuple<char, char, char> Second = new Tuple<char, char, char>(Ten, Fifty, Hundred);

    public static readonly Tuple<char, char, char> Third = new Tuple<char, char, char>(Hundred, FiveHundred, Thousand);
    private static readonly Tuple<char, char, char> tuple = new Tuple<char, char, char>(Thousand, Thousand, Thousand);
    public static readonly List<Tuple<char, char, char>> t =  new List<Tuple<char, char, char>> {tuple, Third, Second, First};
    

    public static string Reverse(this string s )
    {
        char[] charArray = s.ToCharArray();
        Array.Reverse( charArray );
        return new string( charArray );
    }

    public static string Pad(this string s, int desiredLength)
    {
        int paddingSpace = desiredLength - s.Length;
        if(paddingSpace <= 0){
            return s;
        }
        string padding = new string('0', paddingSpace);
        return padding + s;
    }

    public static string ToRoman(this int value)
    {

        //Stringify the number, reverse it then pad it to look like a thousands:
        string number = value.ToString().Pad(4);
        var zipped = Enumerable.Zip(number, t);
        var answer = "";
        foreach (var item in zipped)
        {
            int digit = (int)char.GetNumericValue(item.First);
            Tuple<char, char, char> possibilities = item.Second;
            if(digit == 0)
            {
                continue;
            }
            if(digit <= 3)
            { 
                answer += new string(possibilities.Item1, digit);
            }
            else if(digit <= 5)
            {

                answer += new string(possibilities.Item1, 5 - digit) + new string(possibilities.Item2,1);
            }
            else if(digit <= 8)
            {

                answer += new string(possibilities.Item2,1) +  new string(possibilities.Item1, digit - 5) ;
            }
            else 
            {
               answer += new string(possibilities.Item1, 1) + new string(possibilities.Item3,1);
            }
        }
        return answer;
    } 
}