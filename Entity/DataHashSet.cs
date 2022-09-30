using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Entity
{
    public class DataHashSet
    {
        [JsonPropertyName("data")]
        public HashSet<CryptoCurrency> DataSet { get; set; }
    }
}
