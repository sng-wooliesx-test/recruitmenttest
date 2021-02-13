using System.Collections.Generic;

namespace WooliesXChallenge.Dto
{
    public class ShopperOrder
    {
        public int CustomerId { get; set; }

        public List<Product> Products { get; set; }
    }
}
