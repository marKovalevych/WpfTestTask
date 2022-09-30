using Context;
using Entity;
using System;
using System.Threading.Tasks;

namespace Repository
{
    public class CCRepo : ICCRepo
    {
        private readonly DataContext _dataContext;

        private CCRepo(DataContext context)
        {
            _dataContext = context;
        }
        static public async Task<CCRepo> SetRepo()
        {
            var cont = await DataContext.SetData();
            return new CCRepo(cont);
        }
        public async Task<(double, CryptoCurrency)> ConvertCurrency(string from, string to)
        {
            var fromCC = await _dataContext.GetByCode(from);
            var toCC = await _dataContext.GetByCode(to);

            return new(toCC.Price/fromCC.Price, toCC);
        }

        

        public async Task<CryptoCurrency> GetByCode(string code)
        {
            return await _dataContext.GetByCode(code);
        }

        public DataList GetData()
        {
            return _dataContext.Set;
        }
    }
}
