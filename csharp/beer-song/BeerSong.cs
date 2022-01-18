using System;
using System.Collections.Generic;

public static class BeerSong
{
    public static string Verse(int Bottles)
    {
        switch(Bottles){
            case 0:
                return "No more bottles of beer on the wall, no more bottles of beer.\nGo to the store and buy some more, 99 bottles of beer on the wall.";
            case 1:
                return "1 bottle of beer on the wall, 1 bottle of beer.\nTake it down and pass it around, no more bottles of beer on the wall.";
            case 2:
                return "2 bottles of beer on the wall, 2 bottles of beer.\nTake one down and pass it around, 1 bottle of beer on the wall.";
            default:
                return $"{Bottles} bottles of beer on the wall, {Bottles} bottles of beer.\nTake one down and pass it around, {Bottles-1} bottles of beer on the wall.";
        }
    }

    public static string Recite(int startBottles, int takeDown)
    {
       List<string> song = new List<string>();
       while(takeDown > 0)
       {
           song.Add(Verse(startBottles));
           takeDown -= 1;
           startBottles -= 1;
       }
       return string.Join("\n\n", song);
    }
}