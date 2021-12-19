using System;

static class AssemblyLine
{
    public const int CarsPerHour  = 221;
    public static double SuccessRate(int speed) 
    {
       double sucess_rate;
       switch (speed) 
       {
           case < 0:
               throw new ArgumentException("Speed cannot be a negative number");
           case 0:
               sucess_rate = 0;
               break;
           case <= 4:
               sucess_rate = 1.0;
               break;
           case <= 8:
               sucess_rate = 0.9;
               break;
           case 9:
               sucess_rate = 0.8;
               break;
           default:
               sucess_rate = 0.77;
               break;        
       }
        return sucess_rate; 
    }
    public static double ProductionRatePerHour(int speed)
    {
        double sucess_rate =  SuccessRate(speed);
        return sucess_rate * (speed * CarsPerHour);
    }

    public static int WorkingItemsPerMinute(int speed)
    {
        int ProductionRate = (int)AssemblyLine.ProductionRatePerHour(speed);
        return ProductionRate / 60;
    }
}
