using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinaiHeadersDownloader.Model.Interfaces
{
    interface ICharsCounter
    {
        Dictionary<char, int> CountChars(List<string> Headers);
    }
}
