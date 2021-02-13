using System.Collections.Generic;

namespace WooliesXChallenge.Dto.Request
{
    public class Special
    {
        public List<Quantity> Quantities { get; set; }
        public decimal Total { get; set; }
    }
}