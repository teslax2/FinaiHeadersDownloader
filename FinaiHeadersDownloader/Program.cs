using FinaiHeadersDownloader.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinaiHeadersDownloader
{
    class Program
    {
        static void Main(string[] args)
        {
            var console = new ConsoleOutput();
            var storage = new StoredResults(console);
            var downloader = new SeleniumWebDownloader();
            var charsCounter = new CharsCounter();
            var sinceLastUpdate = TimeSpan.FromMinutes(1);
            var results = new List<Dictionary<char, int>>();
            DateTime lastUpdate = DateTime.Now;

            while (!(Console.KeyAvailable && Console.ReadKey(true).Key == ConsoleKey.Escape))
            {
                if (sinceLastUpdate >= TimeSpan.FromMinutes(0.5))
                {
                    results = storage.Load();
                    var headers = downloader.DownloadHeaders("https://www.finai.pl/blog");
                    var charsCount = charsCounter.CountChars(headers);
                    if (charsCount != null)
                    {
                        results.Add(charsCount);
                    }
                    if (results.Count > 5)
                    {
                        results.RemoveAt(0);
                    }
                    storage.Save(results);
                    console.WriteAllChars(results);
                    lastUpdate = DateTime.Now;
                }
                sinceLastUpdate = DateTime.Now - lastUpdate;
            }
        }
    }
}
