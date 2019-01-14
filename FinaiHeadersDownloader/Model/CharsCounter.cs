using FinaiHeadersDownloader.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinaiHeadersDownloader.Model
{
    public class CharsCounter : ICharsCounter
    {
        private Dictionary<char, int> chars;

        public Dictionary<char, int> CountChars(List<string> Headers)
        {
            if (Headers == null || Headers.Count == 0)
                return null;

            chars = new Dictionary<char, int>();

            foreach (var item in Headers)
            {
                var lowerCase = item.ToLower();
                foreach (var letter in lowerCase)
                {
                    if (Char.IsLetter(letter))
                    {
                        if (!chars.ContainsKey(letter))
                        {
                            chars.Add(letter, 0);
                        }
                        chars[letter] += 1;
                    }
                }
            }
            return chars;
        }
    }
}
