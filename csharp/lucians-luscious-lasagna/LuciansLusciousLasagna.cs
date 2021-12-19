class Lasagna
{
    public int ExpectedMinutesInOven(){
         return 40;
    }
    public int RemainingMinutesInOven(int x){

        return ExpectedMinutesInOven() - x;
    }
       

    public int PreparationTimeInMinutes(int layers){

        return layers * 2;
    }

    public int ElapsedTimeInMinutes(int layers, int oven_time){
        var layer_time = PreparationTimeInMinutes(layers);
        return layer_time + oven_time;
        
    }

    // TODO: define the 'ElapsedTimeInMinutes()' method
}

