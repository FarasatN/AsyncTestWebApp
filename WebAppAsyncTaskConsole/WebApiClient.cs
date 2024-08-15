using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAppAsyncTaskConsole
{
    public class WebApiClient
    {
        private const string url = "https://localhost:7000/api/test/";
     
        public async Task CallSync()
        {
            HttpClient client = new HttpClient()
            {
                BaseAddress = new Uri(url)
            };
            await client.GetAsync("Sync");
        }

        public async Task CallAsync()
        {
            HttpClient client = new HttpClient()
            {
                BaseAddress = new Uri(url)
            };
            await client.GetAsync("Async");
        }
    }
}
