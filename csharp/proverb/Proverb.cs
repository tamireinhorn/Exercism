using System;
using System.Collections.Generic;
public static class Proverb
{
    public static string[] Recite(string[] subjects)
    {
        List<string> song = new List<string> ();
        int subjects_size = subjects.Length;
        if(subjects_size > 1){
            for(int i = 1; i < subjects_size; i++){
                string first_subject = subjects[i-1];
                string second_subject = subjects[i];
                song.Add($"For want of a {first_subject} the {second_subject} was lost.");
            }
        }
        
        if(subjects_size != 0){
            string reason = subjects[0];
            song.Add($"And all for the want of a {reason}.");
            }
        return song.ToArray();
    }
}