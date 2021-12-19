using System;

class RemoteControlCar
{
    public int speed;
    public int batteryDrain;
    public int battery;
    private int distance;
    
    public RemoteControlCar(int speed, int batteryDrain)
    {
        this.speed = speed;
        this.batteryDrain = batteryDrain;
        this.battery = 100;
        this.distance = 0;
    }

    public bool BatteryDrained()
    {
        return battery < batteryDrain;
    }

    public int DistanceDriven()
    {
        return distance;
    }

    public void Drive()
    {
        if (!BatteryDrained()){
            this.distance = distance + speed;
            this.battery = battery - batteryDrain;
        }
    }

    public static RemoteControlCar Nitro()
    {
        RemoteControlCar nitro;
        nitro = new RemoteControlCar(50,4);
        return nitro;
    }
}

class RaceTrack
{
    private int distance;

    public RaceTrack(int distance)
        {
            this.distance = distance;
        }    

    public bool CarCanFinish(RemoteControlCar car)
    {
        //Number of times the battery can be used is battery/ drain
        //This * speed is the maximum distance:
        return (car.battery/car.batteryDrain) * car.speed >= distance;
    }
}
