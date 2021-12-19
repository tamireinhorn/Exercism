using System;

static class LogLine
{
    public static string Message(string logLine)
    {
        return logLine.Substring(logLine.IndexOf(']') + 2).Trim();
        
    }

    public static string LogLevel(string logLine)
    {
        int beginning = logLine.IndexOf('[');
        int end = logLine.IndexOf(']');
        return logLine.Substring(beginning +1, end -1).Trim().ToLower();
    }

    public static string Reformat(string logLine)
    {
        string reformat = LogLine.Message(logLine) + " (" + LogLine.LogLevel(logLine) + ")";
        return reformat;
    }
}
