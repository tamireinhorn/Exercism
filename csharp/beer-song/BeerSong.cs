using System;
using System.Collections.Generic;

public static class BeerSong
{
    public static string Plural(int Bottles)
    {
        return Bottles != 1 ? "s" : ""; 
    }

    public static string Capitalize(this string text)

    {
        return text.Substring(0, 1).ToUpper() + text.Substring(1); 
    }
    

    public static string FormatVerse(int startBottles)
    {
        string first_s = Plural(startBottles);
        string second_s = Plural(startBottles - 1);
        string currentBottles = startBottles == 0 ? "no more" : $"{startBottles}";
        var one = startBottles -1 == 0 ? "it" : "one";
        var next_bottles = startBottles -1 == 0 ? "no more" : $"{startBottles - 1}";
        string SecondVerse;
        string FirstVerse = $"{currentBottles} bottle{first_s} of beer on the wall, {currentBottles} bottle{first_s} of beer.\n".Capitalize();
        
        if (currentBottles == "no more")
            {
            SecondVerse = "Go to the store and buy some more, 99 bottles of beer on the wall.";
            }
        else
            {
            SecondVerse = $"Take {one} down and pass it around, {next_bottles} bottle{second_s} of beer on the wall.";
            }
        return FirstVerse + SecondVerse;
    }
    public static string Recite(int startBottles, int takeDown)
    {
       List<string> song = new List<string>();
       while(takeDown > 0)
       {
           song.Add(FormatVerse(startBottles));
           takeDown -= 1;
           startBottles -= 1;
       }
       return string.Join("\n\n", song);
    }
}