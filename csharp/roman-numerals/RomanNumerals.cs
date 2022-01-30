using System;
using System.Collections.Generic;
using System.Linq;

public static class RomanNumeralExtension
{
    public const char One = 'I';
    public const char Five = 'V';

    public const char Ten = 'X';

    public const char Fifty = 'L';

    public const char Hundred = 'C';

    public const char FiveHundred = 'D';

    public const char Thousand = 'M';

    public static readonly (char, char, char) First = (One,Five, Ten);

    public static readonly (char, char, char) Second = (Ten, Fifty, Hundred);
    public static readonly (char, char, char) Third = (Hundred, FiveHundred, Thousand);
    private static readonly (char, char, char) tuple = (Thousand, Thousand, Thousand);
    public static readonly List<(char, char, char)> t =  new List<(char, char, char)> {tuple, Third, Second, First};
    

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

        //Stringify the number then pad it to look like a thousands:
        string number = value.ToString().Pad(4);
        var zipped = Enumerable.Zip(number, t);
        var answer = "";
        foreach (var item in zipped)
        {
            int digit = (int)char.GetNumericValue(item.First);
            (char, char, char) possibilities = item.Second;
            switch(digit){
                case 0: continue;
                case <= 3:  answer += new string(possibilities.Item1, digit); break;
                case <= 5:  answer += new string(possibilities.Item1, 5 - digit) + new string(possibilities.Item2,1); break;
                case <= 8:  answer += new string(possibilities.Item2,1) +  new string(possibilities.Item1, digit - 5) ; break;
                default: answer += new string(possibilities.Item1, 1) + new string(possibilities.Item3,1); break;
            }
        }
        return answer;
    } 
}