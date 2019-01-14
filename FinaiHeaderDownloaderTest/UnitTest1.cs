using System;
using FinaiHeadersDownloader.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FinaiHeadersDownloaderTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void SeleniumWebDownloader_Download_ShouldReturn20Items()
        {
            var downloader = new SeleniumWebDownloader();
            var items = downloader.DownloadHeaders("https://www.finai.pl/blog");
            Assert.IsTrue(items.Count == 20);
        }

        [TestMethod]
        public void CharsCounter_CountChars_ShouldReturnCounter()
        {
            var downloader = new SeleniumWebDownloader();
            var items = downloader.DownloadHeaders("https://www.finai.pl/blog");
            var counter = new CharsCounter();
            var lettersCounted = counter.CountChars(items);
            CollectionAssert.AllItemsAreUnique(lettersCounted);
        }
    }
}
