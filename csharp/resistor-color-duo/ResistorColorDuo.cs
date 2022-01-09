using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

public static class ResistorColorDuo
{
    public static readonly ReadOnlyDictionary<string, int> ColorDict = 
     new ReadOnlyDictionary<string,int>(
            new Dictionary<string,int>()
            {
                {"black", 0},
                {"brown", 1},
                {"red", 2},
                {"orange", 3},
                {"yellow", 4},
                {"green", 5},
                {"blue", 6},
                {"violet", 7},
                {"grey", 8},
                {"white", 9}
            }
        );
    public static int Value(string[] colors)
    {
       return Convert.ToInt32(string.Join("", colors.Select(x => ColorDict[x])).Substring(0,2));
    }
}
// * Black: 0
// * Brown: 1
// * Red: 2
// * Orange: 3
// * Yellow: 4
// * Green: 5
// * Blue: 6
// * Violet: 7
// * Grey: 8
// * White: 9