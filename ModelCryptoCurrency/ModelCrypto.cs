using Entity;
using System;

namespace ModelCryptoCurrency
{
    public class ModelCrypto
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public double Price { get; set; }
        public double PriceChange { get; set; }
        public string Market { get; set; }

        public ModelCrypto(CryptoCurrency currency)
        {
            Name = currency.Name;
            Code = currency.Code;
            if (currency.Price == null)
            {
                currency.Price = "0";
            }
            var replacedPrice = currency.Price.Replace('.', ',');
            Price = double.TryParse(replacedPrice, out double price) ? Math.Round(price, 5) : 0;
            if(currency.PriceChange == null)
            {
                currency.PriceChange = "0";
            }
            var replacedPriceChange = currency.PriceChange.Replace('.', ',');
            PriceChange = double.TryParse(replacedPriceChange, out double priceChange) ? Math.Round(priceChange,5) : 0;
            Market = currency.Market;
        }
    }
}
