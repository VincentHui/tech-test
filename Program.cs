using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace test
{
    class Program
    {
        //get string from txt file in directory of execution
        static string txtFileContent(string fileName) => File.ReadAllText(Path.Combine(Directory.GetCurrentDirectory(), fileName));

        //use this to test matching logic
        static int getMatchedWordCount(string text, string word) => new Regex($@"\b{word}\b").Matches(text).Count;

        //feel free to extend to account for escape/special characters 
        static string[] getSplitWords(string text) => Regex.Split(text, @"\W+");

        //use linq to get a spiffy top ten list
        static Dictionary<string, int> getTopTen (string text)=>
            getSplitWords(text)               
                .GroupBy(word => word)
                .OrderByDescending(group => group.Count())
                .Take(10)
                .ToDictionary(
                    group => group.Key, 
                    group => group.Count());

        static void Main(string[] args)
        {
            string text = txtFileContent("source.txt");
            foreach (var kvp in getTopTen(text)) {
                Console.WriteLine("{0} : {1}", kvp.Key, kvp.Value);
            }
        }

        //run this for a quick test of top ten values
        static void Test(string text) {
            foreach (var kvp in getTopTen(text))
            {
                Console.WriteLine(kvp.Value == getMatchedWordCount(text, kvp.Key) ? "PASS" : "FAIL");
            }
        }
    }
}
