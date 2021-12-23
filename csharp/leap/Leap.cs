using System;

public static class Leap
{
    public static bool IsLeapYear(int year)
    {
        if (year % 4 == 0){
            bool isDivisibleby100 = year % 100 == 0;
            bool isDivisibleby400 = year % 400 == 0;
            if(isDivisibleby100){
                if(isDivisibleby400){
                    return true;
                }
                else{
                    return false;
                }
            }
            else{
                return true;
            }
        }
        else{
            return false;
        }
    }
}