using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelCryptoCurrency
{
    public class ModelDataSet
    {
        public List<ModelCrypto> DataSet { get; set; }

        public ModelDataSet(DataList dataList)
        {
            DataSet = new List<ModelCrypto>();
            foreach (var item in dataList.DataSet)
            {
                DataSet.Add(new ModelCrypto(item));
            }
        }

    }
}
