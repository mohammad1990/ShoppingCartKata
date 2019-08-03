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
    }
}