using Entity;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Linq;

namespace Context
{
    public class DataContext
    {
        public DataList Set { get; set; }
        private DataContext(DataList data)
        {
            Set = data;
        }
        private HttpClient GetClient()
        {
            string url = "https://api.coincap.io/v2/";
            var client = new HttpClient();
            client.BaseAddress = new Uri(url);
            return client;
        }

        static public async Task<DataContext> SetData()
        {
            string url = "https://api.coincap.io/v2/";
            var client = new HttpClient();
            client.BaseAddress = new Uri(url);
            var param = "assets?limit=10";
            var response = client.GetAsync(param).Result;
            if (response.IsSuccessStatusCode)
            {
                var resp = await response.Content.ReadAsStringAsync();
                var data = System.Text.Json.JsonSerializer.Deserialize<DataList>(resp);
                return new DataContext(data);
            }

            return null;
        }

        public async Task<CryptoCurrency> GetByCode(string code)
        {
            var client = GetClient();
            var param = $"assets?search={code}";
            var response = client.GetAsync(param).Result;
            if (response.IsSuccessStatusCode)
            {
                var resp = await response.Content.ReadAsStringAsync();
                var data = System.Text.Json.JsonSerializer.Deserialize<DataHashSet>(resp);
                return data.DataSet.FirstOrDefault(x => x.CurrencyId == code);
            }

            return null;
        }
    }
}
