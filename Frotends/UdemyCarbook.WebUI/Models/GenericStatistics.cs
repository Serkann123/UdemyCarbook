using System;
using System.Net.Http;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace UdemyCarbook.WebUI.Models
{
    public class GenericStatistics
    {
        private readonly HttpClient client;

        public GenericStatistics(IHttpClientFactory httpClientFactory)
        {
             client = httpClientFactory.CreateClient("CarApi");
        }

        public async Task setViewBagData<T>(
                string apiUrl,
                string viewBagKey,
                ViewDataDictionary viewData,
                Func<T, object> selector
                )
        {
           
            var response = await client.GetAsync(apiUrl);

            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<T>(jsonData);

                var dataValue = selector(values);
                viewData[viewBagKey] = dataValue;

                viewData[viewBagKey + "Random"] = new Random().Next(0, 101);
            }
        }
    }
}
