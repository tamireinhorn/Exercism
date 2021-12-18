using System;

class BirdCount
{
    private int[] birdsPerDay;

    public BirdCount(int[] birdsPerDay)
    {
        this.birdsPerDay = birdsPerDay;
    }

    public static int[] LastWeek()
    {
        int[] LW = new int[] {0, 2, 5, 3, 7, 8, 4};
        return LW;
    }

    public int Today()
    {
        return birdsPerDay[birdsPerDay.Length - 1];
    }

    public void IncrementTodaysCount()
    {
        int today = birdsPerDay[birdsPerDay.Length - 1];
        birdsPerDay[birdsPerDay.Length - 1] =  today+ 1 ;
    }

    public bool HasDayWithoutBirds()
    {
       bool NoBirds = false;
       foreach (int day in birdsPerDay){
           if(day == 0){
               NoBirds = true;
            }
       }
        return NoBirds;
    }

    public int CountForFirstDays(int numberOfDays)
    {
        int count = 0;
        for (int i = 1; i <= numberOfDays; i++){
            
            count += birdsPerDay[i-1];
        };
        return count;
    }

    public int BusyDays()
    {
       int busycount = 0;
       foreach (int day in birdsPerDay){
           if(day >= 5){
                busycount += 1;
           }
        }
        return busycount;
    }
}
