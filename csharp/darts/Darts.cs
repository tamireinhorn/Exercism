using System;
public static class Darts
{
    public const double target = 10.0;
    public const int targetScore = 1;
    public const double middle = 5.0;
    public const int middleScore = 5;
    public const double inner = 1.0;
    public const int innerScore = 10;
    public const int failScore = 0;
    public static bool InsideCircle(double x, double y, double r)
    {
        return Math.Pow(x, 2) + Math.Pow(y, 2) <= Math.Pow(r,2);
    }
    public static int Score(double x, double y)
    {
       if (InsideCircle(x,y,inner))
       {
           return innerScore;
       }
       else if (InsideCircle(x,y,middle)){
           return middleScore;
       }
       else if (InsideCircle(x,y,target)){
           return targetScore;
       }
       else{
           return failScore;
       }
       
    }
}
