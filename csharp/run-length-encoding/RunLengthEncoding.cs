using System;
using System.Text.RegularExpressions;
public static class RunLengthEncoding
{
    public static string Encode(string input)
    {
        string answer = "";
        int accumulated = 0;
        while(accumulated < input.Length)
        {
            string currentInput = input.Substring(accumulated);
            char currentLetter = input[accumulated];
            int size = new Regex($"{Convert.ToString(currentLetter)}+").Match(currentInput).Length;
            string repeat = size == 1 ? "" : Convert.ToString(size);
            accumulated += size;
            answer += $"{repeat}{currentLetter}";
        }
        return answer;
    }

    public static string Decode(string input)
    {
        MatchCollection encodedPattern = new Regex(@"(\d*)([A-Z]|\s)", RegexOptions.IgnoreCase).Matches(input);
        string answer = "";
        foreach(Match x in encodedPattern)
        {
            int counter = x.Groups[1].Value == "" ? 1 : Convert.ToInt32(x.Groups[1].Value) ;
            answer += new string(Convert.ToChar(x.Groups[2].Value), counter);
        }
        return answer;
    }
}
