using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
public static class ProteinTranslation
{

     public static ReadOnlyDictionary<string, string> ProteinSequence = 
        new ReadOnlyDictionary<string, string>(new Dictionary<string, string>()
        {
            {"AUG", "Methionine"},
            {"UUU", "Phenylalanine"},
            {"UUC", "Phenylalanine"},
            {"UUA", "Leucine"},
            {"UUG", "Leucine"},
            {"UCU", "Serine"},
            {"UCC", "Serine"},
            {"UCA", "Serine"},
            {"UCG", "Serine"},
            {"UAU", "Tyrosine"},
            {"UAC", "Tyrosine"},
            {"UGU", "Cysteine"},
            {"UGC", "Cysteine"},
            {"UGG", "Tryptophan"},
            {"UAA", "STOP"},
            {"UAG", "STOP"},
            {"UGA", "STOP"}
        });
    public const int CodonSize = 3;
    public static string[] Proteins(string strand)
    {
        // I want to create something to deal with the fact that proteinNumber should always be int. 
        var Div = Math.DivRem(strand.Length, CodonSize);
        if (Div.Remainder > 0){
            throw new ArgumentException($"The RNA strand should be a multiple of {CodonSize}");
        }
        int proteinNumber = Div.Quotient;
        //Create codons:
        var codons = Enumerable.Range(0, proteinNumber)
    .Select(i => strand.Substring(i * CodonSize, CodonSize));
        var answer = new List<string> ();
        foreach(string codon in codons)
        {
            string currentProtein = ProteinSequence.GetValueOrDefault(codon);
            if (currentProtein == "STOP"){
                break;
            }
            answer.Add(currentProtein);
        }
        return answer.ToArray();
    }
} 