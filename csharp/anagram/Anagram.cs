using System;
using System.Linq;
using System.Collections.Generic;


public class Anagram
{
    public static string word;
    public Anagram(string baseWord)
    {
        Anagram.word = baseWord.ToLower();
    }

    public List<Tuple<char, int>> StringCounter(string s)
    {   
      var x = s.GroupBy(x => x)
       .Select(c => new {Letter = c.Key, total = c.Count()})
       .AsEnumerable()
       .Select(c => new Tuple<char, int>(c.Letter, c.total))
       .ToList()
       ;
       return x;
    }
    public string[] FindAnagrams(string[] potentialMatches)
    {
        var baseWordCounter = StringCounter(Anagram.word);
        List<String> matches = new List<string>();
        foreach(string word in potentialMatches){
            var wordCounter = StringCounter(word);
            if(word != Anagram.word & wordCounter == baseWordCounter)
            {
                matches.Add(word);
            }
        }
        return matches.ToArray();

    }
} 