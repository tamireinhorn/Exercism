using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

public static class PigLatin
{
    public static readonly List<string> Vowels = new List<string> {"a", "e", "i", "o", "u"};
    public static readonly List<string> OtherSounds = new List<string> {"\\Axr", "\\Ayt"}; //These sounds only work as vowels in the beggining
    
    public static readonly string VowelSounds = String.Join("|", Vowels.Concat(OtherSounds).ToList());
    public const string suffix = "ay";
    
    public static string TranslateWord(this string word)
    {
        word = word.ToLower();
        Regex VowelString = new Regex($"\\A({VowelSounds})");
        string Beg = word.Substring(0,2);
        bool StartsWithVowel = VowelString.Match(Beg).Success;
        if (StartsWithVowel)
        { // Rule 1, matching for vowel sounds. 
            return word + suffix;
        }
        else if (new Regex("^[a-z]y$").IsMatch(word))
        { // Rule 4, matching for two letter words with y at the end. 
            return String.Join("",word.Reverse().ToArray()) + suffix;
        }
        else{ //Starts with a consonant cluster.
            var NextVowel = new Regex($"({VowelSounds}|(?<=[a-z])y)").Match(word);
            var HasQu = new Regex("qu").Match(word);
            if (!NextVowel.Success)
            { //Words with only consonants should be treated like this.
                return word + suffix;
            }
            if (HasQu.Success)
            {
                return word.Substring(HasQu.Index + HasQu.Length) + word.Substring(0, HasQu.Index + HasQu.Length) + suffix;
            }
            return word.Substring(NextVowel.Index) + word.Substring(0, NextVowel.Index) + suffix;
        }
    }
    public static string Translate(string word)
    {
        return string.Join(" ", word.Split().Select(x => x.TranslateWord()));
    }
}