using System;

public static class LogAnalysis 
{
    
    public static string SubstringAfter(this string str, string delimiter)
    { 
        
        return str.Substring(str.IndexOf(delimiter) + delimiter.Length);
    }

    public static string SubstringBetween(this string str, string delimiter1, string delimiter2)
    {
        int beg = str.IndexOf(delimiter1) + delimiter1.Length;
        return str.Substring(beg, str.IndexOf(delimiter2) - beg);
    }
    
    // TODO: define the 'Message()' extension method on the `string` type
    public static string Message(this string str)
    {
        return str.SubstringAfter(": ");
    }
    // TODO: define the 'LogLevel()' extension method on the `string` type
    public static string LogLevel(this string str)
    {
        return str.SubstringBetween("[", "]");
    }
}