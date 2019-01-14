using FinaiHeadersDownloader.Model.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinaiHeadersDownloader.Model
{
    public class StoredResults : ISerializer<List<Dictionary<char, int>>>
    {
        readonly string path = "record.json";
        private IOutput output;

        public StoredResults(IOutput output)
        {
            this.output = output;
        }

        public List<Dictionary<char, int>> Load()
        {
            try
            {
                var dataFromFile = File.ReadAllText(path);
                var dataLoaded = JsonConvert.DeserializeObject<List<Dictionary<char, int>>>(dataFromFile);
                return dataLoaded;
            }
            catch (Exception)
            {
                output.WriteLine("Failed to load results");
                return new List<Dictionary<char, int>>();
            }

        }

        public void Save(List<Dictionary<char, int>> data)
        {
            if (data == null)
                return;
            var serializedData = JsonConvert.SerializeObject(data);
            try
            {
                File.WriteAllText(path, serializedData);
            }
            catch (Exception)
            {
                output.WriteLine("Failed to save results");
            }

        }
    }
}
