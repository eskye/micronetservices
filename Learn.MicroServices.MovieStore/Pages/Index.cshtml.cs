using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace Learn.MicroServices.MovieStore.Pages
{
    public class IndexModel : PageModel
    {
        private readonly HttpClient _client;
        public IndexModel(IHttpClientFactory clientFactory)
        {
            _client = clientFactory.CreateClient("api");
        }

        public string[] Values { get; set; }
        public async Task OnGet()
        {
            var response = await _client.GetAsync("/api/values");
            var content = await response.Content.ReadAsStringAsync();
            Values = JsonConvert.DeserializeObject<string[]>(content);
        }
    }
}
