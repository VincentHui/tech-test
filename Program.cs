using System;
using System.IO;
using System.Text.RegularExpressions;

namespace test
{
    class Program
    {
        //expression body definition for aesthetic style
        static int getMatchedWordCount(string text, string word) => new Regex($@"\b{word}\b").Matches(text).Count;
        //get string from txt file in directory of execution
        static string txtFileContent(string fileName) => File.ReadAllText(Path.Combine(Directory.GetCurrentDirectory(), fileName));

        static void Main(string[] args)
        {
            string text = txtFileContent("source.txt");
            Console.WriteLine("amount of occurances = {0}", getMatchedWordCount(text, args[0]));
        }

    }
}
