using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinaiHeadersDownloader.Model.Interfaces
{
    public interface ISerializer<T> 
        where T:class
    {
        void Save(T data);
        T Load();
    }
}
