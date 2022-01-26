using System;
using System.Collections.Generic;
using System.Linq;
public static class Triangle
{
    public static bool IsValid(double side1, double side2, double side3)
    {
        var sides = new [] {side1, side2, side3};
        bool allSidesPos = sides.All(x => x > 0);
        bool inequality = 2 * sides.Max() < sides.Sum();
        return allSidesPos & inequality;
    }
    public static bool IsScalene(double side1, double side2, double side3)
    {
         if (Triangle.IsValid(side1, side2, side3)){
            return (side1 != side2) & (side2 != side3) & (side1 != side3);
        }
        else{
            return false;
        }
        
    }
 
    public static bool IsIsosceles(double side1, double side2, double side3) 
    {
        if (Triangle.IsValid(side1, side2, side3)){
            return (side1 == side2) | (side2 == side3) | (side1 == side3);
        }
        else{
            return false;
        }
    }

    public static bool IsEquilateral(double side1, double side2, double side3) 
    {
        if (Triangle.IsValid(side1, side2, side3)){
            double side = side1;
            return (side == side2) & (side== side3);
        }
        else{
            return false;
        }
    }  
}