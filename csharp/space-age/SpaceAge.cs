using System;

public class SpaceAge
{
    
    private const double Earth = 31557600;
    private readonly double Mercury = Earth * 0.2408467; //Readonlys are not usabele in expressions, but const are.
    private readonly double Venus = Earth *  0.61519726;
    private readonly double Mars = Earth * 1.8808158;
    private readonly double Jupiter = Earth * 11.862615;
    private readonly double Saturn = Earth * 29.447498; 
    private readonly double Uranus = Earth *  84.016846;
    private readonly double Neptune =  Earth * 164.79132;

    public double seconds{get; private set;} //You have to declare this field as something that can be set.
    public SpaceAge(int seconds)
    {
       if(seconds < 0) throw new ArgumentOutOfRangeException("Age must be a positive number."); //This allows us to remove invalid values.
       this.seconds = seconds;
    }


    public double OnEarth()
    {
        return seconds / Earth; 
    }

    public double OnMercury()
    {
        return seconds / Mercury;
    }

    public double OnVenus()
    {
        return seconds / Venus; 
    }

    public double OnMars()
    {
       return seconds / Mars;
    }

    public double OnJupiter()
    {
        return seconds / Jupiter;
    }

    public double OnSaturn()
    {
        return seconds / Saturn;
    }

    public double OnUranus()
    {
        return seconds / Uranus;
    }

    public double OnNeptune()
    {
        return seconds / Neptune;
    }
}