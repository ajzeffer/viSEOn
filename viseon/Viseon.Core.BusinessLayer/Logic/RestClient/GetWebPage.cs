using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Viseon.Core.BusinessLayer.Logic.RestClient
{
    public partial    class RestClientLogic
    {
        public async Task<string> GetWebPageAsync(string url)
        {
            using (var client = new WebClient())
            {
                try
                {
                    var target = new Uri(url);
                    return await client.DownloadStringTaskAsync(target);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
              
            }
        }
    }
}
