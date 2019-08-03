using System;

namespace Shopping
{
    class Program
    {
        static void Main(string[] args)
        {
            Checkout checkout = new Checkout();
            int totalePrice = checkout.calculatesTotalPrice();
        }
    }
}
