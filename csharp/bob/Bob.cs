using System;
using System.Linq;

public static class Bob
{
    public static string Response(string statement)
    {
       
        statement = statement.Trim();
        bool isEmpty = string.IsNullOrEmpty(statement);
        if(isEmpty){
            return "Fine. Be that way!";
        }
        bool isAlpha = statement.Any(s => char.IsLetter(s));
        bool isYell = statement == statement.ToUpper() && isAlpha;
        bool isQuestion = false;
        isQuestion = statement.EndsWith('?');
        if (isQuestion && isYell){
            return "Calm down, I know what I'm doing!";
            }
        else if (isQuestion){
            return "Sure.";
        }
        else if(isYell){
            return "Whoa, chill out!";
            
        }
        
        else {
            return "Whatever.";
        }
        

        
    }
}