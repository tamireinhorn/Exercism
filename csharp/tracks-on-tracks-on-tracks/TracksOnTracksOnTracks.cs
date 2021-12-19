using System;
using System.Collections.Generic;
using System.Linq;

public static class Languages
{
    public static List<string> NewList()
    {
        return new List<string>();
    }

    public static List<string> GetExistingLanguages()
    {
        
        List<string> LanguageList = new List<string>()
            
             {
            "C#",
            "Clojure",
            "Elm"
        };
        
        //LanguageList = {"C#"};
        return LanguageList;
    }

    public static List<string> AddLanguage(List<string> languages, string language)
    {
        languages.Add(language);
        return languages;
    }

    public static int CountLanguages(List<string> languages)
    {
        return languages.Count;
    }

    public static bool HasLanguage(List<string> languages, string language)
    {
        return languages.Contains(language);
    }

    public static List<string> ReverseList(List<string> languages)
    {
        languages.Reverse();
        return languages;
    }

    public static bool IsExciting(List<string> languages)
    {
        int NumberLang = Languages.CountLanguages(languages);
        int CIndex = languages.IndexOf("C#");
        return (CIndex == 0) | ((NumberLang == 2 | NumberLang == 3) & CIndex == 1); 
        
    }

    public static List<string> RemoveLanguage(List<string> languages, string language)
    {
        languages.Remove(language);
        return languages;
    }

    public static bool IsUnique(List<string> languages)
    {
        return languages.Distinct().Count() == Languages.CountLanguages(languages);
    }
}
