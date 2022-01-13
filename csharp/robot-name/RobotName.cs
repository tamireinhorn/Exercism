using System;
using System.Linq;
using System.Collections.Generic;
public class Robot 
{
    private const string alpha = "ABCDEFGHIJKLMNOPQRSTUVQXYZ";
    private const int numberOfLetters = 2;
    private const int numberOfDigits = 3;
    
    public string name;
    private static Random RandomRobot = new Random(); //Instatiating a STATIC random here will guarantee that the random is seeded already and the sequence is 'the same'.

    private static HashSet<string> existingNames = new HashSet<string>(); // A Hash Set is an unsorted data type
    // This allows for high performance operations where you don't care about sorting
    // Way better performance than a list. 
    // It DOESN'T store duplicates (it's a set, after all), so HashSet.Add returns true if the new element is added
    // Hence, we can use it for adding the robot's name. If it's false, generate a new one!
    // Yes, while List.Append(element) returns list, HashSet.Append(element) modifies HashSet if true.


    public static string GetRandomString(string text, Random rng, int desiredLength)
    {
        char[] randomText = new char[desiredLength];
        foreach(int i in Enumerable.Range(0,desiredLength)){
            randomText[i] = text[rng.Next(text.Length)];
        }

        return new string(randomText);
    }
    public Robot(){
        name = AddName();
    }
    public string Name 
    {
        get{return name;}
    }
    //This method provides the name generation without repetition
    private string AddName()
    {
        while(!existingNames.Add(name))
        {
            var digitPart = RandomRobot.Next((int)Math.Pow(10.0, numberOfDigits - 1.0), (int)Math.Pow(10.0, numberOfDigits * 1.0)).ToString();
            name = GetRandomString(alpha, RandomRobot, numberOfLetters) + digitPart; 
        }
        existingNames.Add(name);
        return name;
    }
    public void Reset()
    {
        name = AddName();
    }
}