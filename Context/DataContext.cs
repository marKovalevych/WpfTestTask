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
        public DataHashSet hashSet { get; set; }
        private DataContext(DataList data)
        {
            hashSet = new DataHashSet();
            Set = data;
        }
        private HttpClient GetClient(string param)
        {
            string url = "https://api.coincap.io/v2/";
            var client = new HttpClient();
            client.BaseAddress = new Uri(url+param);
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
            string toUpper = code.ToUpper();
            var param = $"assets?search={toUpper}";
            var client = GetClient(param);
            var response = client.GetAsync(client.BaseAddress).Result;
            if (response.IsSuccessStatusCode)
            {
                var resp = await response.Content.ReadAsStringAsync();
                var data = System.Text.Json.JsonSerializer.Deserialize<DataList>(resp);
                return data.DataSet.FirstOrDefault(x => x.Code == toUpper);
            }
            
            return null;
        }
    }
}
