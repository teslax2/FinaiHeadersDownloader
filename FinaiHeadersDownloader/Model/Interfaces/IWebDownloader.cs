using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinaiHeadersDownloader.Model.Interfaces
{
    public interface IWebDownloader
    {
        List<string> DownloadHeaders(string path);
    }
}
