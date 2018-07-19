using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace BloomFilterKata
{
    class Program
    {
        private static Random random = new Random();

        static void Main(string[] args)
        {

            Console.WriteLine("Downloading please wait...");
            WebClient webClient = new WebClient();
            string result = webClient.DownloadString("http://codekata.com/data/wordlist.txt");
            string[] lines = result.Split('\n');
            Console.WriteLine("Download successful");
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();

            Bloom bloom = new Bloom();
            List<string> list = new List<string>();
            foreach (var line in lines)
                bloom.AddData(line);

            for (int i = 0; i < 100000; i++)
            {
                string test = RandomString(5);
                if (bloom.Lookup(test))
                {
                    Console.WriteLine($"{test} {bloom.Lookup(test)} ");
                    Console.ReadLine();                }
            }
            Console.ReadLine();
        }
        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}