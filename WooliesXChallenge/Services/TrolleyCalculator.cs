using System.Collections.Generic;
using WooliesXChallenge.Dto;
using WooliesXChallenge.Dto.Request;

namespace WooliesXChallenge.Services
{
    public class TrolleyCalculator
    {
        public decimal CalculateCheapestTrolley(Trolley trolley)
        {
            return FindCheapestSpecial(trolley.Specials, trolley.Quantities, trolley.Products, int.MaxValue);

        }

        public decimal FindCheapestSpecial(List<Special> specials, List<Quantity> purchases, List<Product> basePrice,
            int minAmount)
        {
            var minSpecialPrice = decimal.MaxValue;

            foreach (var purchase in purchases)
            {
                foreach (var product in basePrice)
                {
                    specials.Add(new Special
                    {
                        Total = purchase.quantity * product.Price,
                        Quantities = new List<Quantity>
                        {
                            new Quantity
                            {
                                Name = product.Name,
                                quantity = purchase.quantity
                            }
                        }
                    });
                }

                foreach (var special in specials)
                {
                    var specialPrice = 0.0m;

                    foreach (var quantity in special.Quantities)
                    {
                        if (purchase.quantity >= quantity.quantity)
                        {
                            specialPrice = special.Total;

                            if (specialPrice < minSpecialPrice)
                            {
                                minSpecialPrice = specialPrice;
                            }
                        }
                    }
                }
            }

            return minSpecialPrice;
        }

        //public int FindCheapestSpecial(List<Special> specials, List<Quantity> purchases, List<Product> basePrice, int minAmount)
        //{
        //    if (purchases.Sum(p => p.quantity) == 0)
        //    {
        //        return minAmount;
        //    }
        //    else
        //    {
        //        foreach (var special in specials)
        //        {
        //            var thisSpecialAmount = 0;
        //            foreach (var specialQuantity in special.Quantities)
        //            {
        //                foreach (var purchase in purchases)
        //                {
        //                    if (purchase.Name == specialQuantity.Name && purchase.quantity > specialQuantity.quantity)
        //                    {
        //                        thisSpecialAmount += special.Total;
        //                        purchase.quantity = purchase.quantity - specialQuantity.quantity;
        //                    }
        //                    else
        //                    {
        //                        thisSpecialAmount = int.MaxValue;
        //                    }
        //                }
        //            }

        //            if (thisSpecialAmount < minAmount)
        //            {
        //                minAmount = thisSpecialAmount;
        //            }
        //        }

        //        var canSpecialStillBeApplied = FindSpecialCanBeApplied(specials, purchases);

        //        if (canSpecialStillBeApplied)
        //        {
        //            return FindCheapestSpecial(specials, purchases, basePrice, minAmount);
        //        }

                
        //    }
        //}

        //private bool FindSpecialCanBeApplied(List<Special> specials, List<Quantity> purchases)
        //{
        //    foreach (var special in specials)
        //    {
        //        foreach (var quantity in special.Quantities)
        //        {
        //            foreach (var purchase in purchases)
        //            {
        //                if (purchase.quantity > quantity.quantity)
        //                    return true;
        //            }
        //        }
        //    }

        //    return false;
        //}
    }
}
