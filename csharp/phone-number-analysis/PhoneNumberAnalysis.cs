using System;

public static class PhoneNumber
{
    public const string NewYork = "212";
    public const string Fake = "555";
    public static (bool IsNewYork, bool IsFake, string LocalNumber) Analyze(string phoneNumber)
    {
    
        bool IsNewYork = phoneNumber.Substring(0,3) == NewYork;
        bool IsFake = phoneNumber.Substring(4,3) == Fake;
        string LocalNumber = phoneNumber.Substring(8);
        return (IsNewYork, IsFake,  LocalNumber);
    }

    public static bool IsFake((bool IsNewYork, bool IsFake, string LocalNumber) phoneNumberInfo)
    {
        return phoneNumberInfo.IsFake;
    }
}
