using System;
using System.Collections.Generic;
using System.Linq;
public static class SecretHandshake
{
    public static readonly List<string> CommandList = new List<string>{"wink", "double blink", "close your eyes", "jump"};
    
    
    public static string[] Commands(int commandValue)
    {
        List<string> answer = new List<string>{};
        var binary = Convert.ToString(commandValue, 2).Reverse();
        var zipped = Enumerable.Zip(binary, CommandList);
        foreach (var item in zipped)
        {
           if(item.First == '1')
           {
               answer.Add(item.Second);
           }
        }
        if (binary.Last() == '1' & binary.Count() > CommandList.Count())
        {
            answer.Reverse();
        }
        return answer.ToArray();
    }
}
