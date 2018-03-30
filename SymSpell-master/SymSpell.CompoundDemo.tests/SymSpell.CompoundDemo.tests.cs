using System;
using System.Collections.Generic;
using System.IO;
using System.Diagnostics;

// uses SymSpellCompound.cs 
// *alternatively* use SymSpellCompound as NuGet package from https://www.nuget.org/packages/symspellcompound

// Usage: single word + Enter:  Display spelling suggestions
//        Enter without input:  Terminate the program

namespace symspell.CompoundDemo
{
    class Program
    {
        //Load a frequency dictionary or create a frequency dictionary from a text corpus
        public static void Main(string[] args)
        {
            //set parameters
            const int initialCapacity = 82765;
            const int maxEditDistance = 2;
            const int prefixLength = 7;
            SymSpell symSpell = new SymSpell(initialCapacity, maxEditDistance, prefixLength);

            string input;
            string path;

            // Console.WriteLine("Test 1");
            // Didn't manage to get it up and running
            // path = AppDomain.CurrentDomain.BaseDirectory + "../../../../../lists/bonjour.txt";
            // if (!SymSpellCompound.CreateDictionary(path, 0, 1)) Console.Error.WriteLine("File not found: " + Path.GetFullPath(path));
            // input = "bonjor";
            // Correct(input, symSpell);
            // Console.WriteLine();


            Console.WriteLine("Test 2");
            // 
            path = AppDomain.CurrentDomain.BaseDirectory + "../../../../../lists/bonjour.1.txt";
            if (!symSpell.LoadDictionary(path, 0, 1)) { Console.Error.WriteLine("\rFile not found: " + Path.GetFullPath(path)); Console.ReadKey();return; }
            input = "bonjuor";
            Correct(input, symSpell);
            Console.WriteLine();


            Console.WriteLine("Test 3");
            // 
            path = AppDomain.CurrentDomain.BaseDirectory + "../../../../../lists/bonjour.2.txt";
            if (!symSpell.LoadDictionary(path, 0, 1)) { Console.Error.WriteLine("\rFile not found: " + Path.GetFullPath(path)); Console.ReadKey();return; }
            Correct("bonjur hallo", symSpell);
            Console.WriteLine();

            Console.WriteLine("Test 4");
            // breaks with "བཀྲ་ཤས་་", breaks with "བཀྲ་ཤིན་", doesn't recognize "བཀྲ་ཤེས་", or "སཀྲ་ཤིས་"
            path = AppDomain.CurrentDomain.BaseDirectory + "../../../../../lists/tib.txt";
            if (!symSpell.LoadDictionary(path, 0, 1)) { Console.Error.WriteLine("\rFile not found: " + Path.GetFullPath(path)); Console.ReadKey();return; }
            input = "སཀྲ་ཤིས་";
            Correct(input, symSpell);
            Console.WriteLine();

            Console.WriteLine("Test 5");
            path = AppDomain.CurrentDomain.BaseDirectory + "../../../../../lists/tib.1.txt";
            if (!symSpell.LoadDictionary(path, 0, 1)) { Console.Error.WriteLine("\rFile not found: " + Path.GetFullPath(path)); Console.ReadKey();return; }
            input = "དཀྲ'ཤེས'";
            Correct(input, symSpell);
        }

        private static void Correct(string input, SymSpell symSpell)
        {
            List<SymSpell.SuggestItem> suggestions = null;

            //check if input term or similar terms within edit-distance are in dictionary, return results sorted by ascending edit distance, then by descending word frequency     
            suggestions = symSpell.LookupCompound(input, symSpell.MaxDictionaryEditDistance);

            //display term and frequency
            foreach (var suggestion in suggestions)
            {
                Console.WriteLine(suggestion.term + " " + suggestion.distance.ToString() + " " + suggestion.count.ToString("N0"));
            }
        }
    }
}
