using Entity;
using ModelCryptoCurrency;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public interface ICCRepo
    {
        Task<ModelCrypto> GetByCode(string name);
        DataList GetData();
        Task<(double, ModelCrypto, ModelCrypto)> ConvertCurrency(string from, string to);  
    }
}
