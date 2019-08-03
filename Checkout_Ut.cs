
using NUnit.Framework;

namespace Shopping
{
    [TestFixture]
    class Checkout_Ut
    {
        [TestCase("apple", 75,3)]
        public void ScanItems(string item, int total,int number)
        {
            Checkout checkout = new Checkout();
            checkout.scanItem(item,number);
            Assert.AreEqual(checkout.Total_price, total);
        }
    
    }
}
