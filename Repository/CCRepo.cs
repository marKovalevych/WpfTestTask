using Context;
using Entity;
using ModelCryptoCurrency;
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
        public async Task<(double, ModelCrypto, ModelCrypto)> ConvertCurrency(string from, string to)
        {
            var fromCC = await _dataContext.GetByCode(from);
            var toCC = await _dataContext.GetByCode(to);
            if (fromCC == null || toCC == null)
            {
                return (0, null, null);
            }
            var fromModel = new ModelCrypto(fromCC);
            var toModel = new ModelCrypto(toCC);
            
            return new(fromModel.Price/toModel.Price, toModel, fromModel);
        }

        

        public async Task<ModelCrypto> GetByCode(string code)
        {
            
            var toReturn = await _dataContext.GetByCode(code);
            if(toReturn == null)
            {
                return null;
            }
            return new ModelCrypto(toReturn);
        }

        public DataList GetData()
        {
            return _dataContext.Set;
        }
    }
}
