using System.Collections.Generic;

namespace Shopping
{
    class Checkout
    {
        private Dictionary<string, int> _prices;
        private Dictionary<string, int> _itemCount;
        private Dictionary<string, Offer> _offers;
        public Checkout()
        {
            _prices = new Dictionary<string, int> { };
            _itemCount = new Dictionary<string, int>() { };
            _prices = new Dictionary<string, int> {
                { "apple", 30 },
                { "banana",50},
                { "Peach", 60},

            };
            _itemCount = new Dictionary<string, int>(){
                {"apple",3},
                {"banana",3},
                {"Peach",1}
            };
            _offers = new Dictionary<string, Offer>(){
                {"apple",new Offer{Discount=45,NumberOfPiece=2}},
                {"banana",new Offer{Discount=130,NumberOfPiece=3}}
            };
        }
        private int total_price;
        public int Total_price { get; set; }
        public int calculatesTotalPrice()
        {

            foreach (KeyValuePair<string, int> entry in _itemCount)
            {
                scanItem(entry.Key, entry.Value);
            }
            return Total_price;
        }
        public void scanItem(string key, int value)
        {
            if (OfferFound(key))
            {
                int numberOfCoverDiscount = GetOfferNumber(key);
                numberOfCoverDiscount = value - numberOfCoverDiscount;
                if (numberOfCoverDiscount == 0)
                {
                    int discountPrice = GetOfferPrice(key);
                    Total_price += discountPrice;
                }
                else if (numberOfCoverDiscount > 0)
                {
                    int discountPrice = GetOfferPrice(key);
                    Total_price += discountPrice;
                    Total_price += calculatePrice(key, numberOfCoverDiscount);
                }
                else if (numberOfCoverDiscount < 0)
                {
                    Total_price += calculatePrice(key, value);
                }
            }
            else
            {
                Total_price += calculatePrice(key, value);
            }
        }
        private int calculatePrice(string key, int value)
        {
            int itemPrice = 0;
            itemPrice = scan(key);
            return value * itemPrice;
        }
        private int scan(string item)
        {
            if (_prices.ContainsKey(item))
            {
                int itemPrices = 0;
                if (_prices.TryGetValue(item, out itemPrices))
                {
                    return itemPrices;
                }
            }
            return -1;

        }
        private bool OfferFound(string item)
        {
            if (_offers.ContainsKey(item))
            {
                return true;
            }
            return false;
        }
        private int GetOfferPrice(string item)
        {
            Offer numberOfItem = null;
            if (_offers.TryGetValue(item, out numberOfItem))
            {
                return numberOfItem.Discount;
            }
            return -1;
        }
        private int GetOfferNumber(string item)
        {
            Offer numberOfItem = null;
            if (_offers.TryGetValue(item, out numberOfItem))
            {
                return numberOfItem.NumberOfPiece;
            }
            return -1;
        }
    }
}