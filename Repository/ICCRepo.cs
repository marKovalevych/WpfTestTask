using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public interface ICCRepo
    {
        Task<CryptoCurrency> GetByCode(string name);
        DataList GetData();
        Task<(double, CryptoCurrency)> ConvertCurrency(string from, string to);  
    }
}
