using FinaiHeadersDownloader.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinaiHeadersDownloader.Model
{
    class ConsoleOutput : IOutput
    {
        public void WriteLine(string line)
        {
            Console.WriteLine(line);
        }

        public void WriteAllChars(List<Dictionary<char, int>> data)
        {
            if (data == null)
                return;
            int line = 1;
            foreach (var item in data)
            {
                var sortedData = item.OrderBy(x => x.Key);
                Console.WriteLine("");
                Console.WriteLine(line++);
                foreach (var letter in sortedData)
                {
                    var entry = String.Format("| {0}:{1} ", letter.Key, letter.Value);
                    Console.Write(entry);
                }
            }
        }
    }
}
