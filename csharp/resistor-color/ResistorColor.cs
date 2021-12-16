using System;

public static class ResistorColor
{
    public static int ColorCode(string color)
    {
        int code;
        switch(color){
            case "Black":
                code = 0;
                break;
            case "Brown":
                code = 1;
                break;
            case "Red":
                code = 2;
                break;
            case "Orange":
                code = 3;
                break;
            case "Yellow":
                code = 4;
                break;
            case "Green":
                code = 5;
                break;
            case "Blue":
                code = 6;
                break;
            case "Violet":
                code = 7;
                break;
            case "Grey":
                code = 8;
                break;
            case "White":
                code = 9;
                break;
                
            default:
                code = -1;
                break;
    }
    return code;
    }
    public static string[] Colors()
    {
        throw new NotImplementedException("You need to implement this function.");
    }
}