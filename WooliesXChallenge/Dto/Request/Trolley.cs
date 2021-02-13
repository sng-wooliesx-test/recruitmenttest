using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WooliesXChallenge.Dto.Request
{
    public class Trolley
    {
        [Required]
        public List<Product> Products { get; set; }

        [Required]
        public List<Special> Specials { get; set; }

        [Required]
        public List<Quantity> Quantities { get; set; }
    }


}
