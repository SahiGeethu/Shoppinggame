using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoppingGame.Models
{
    public class CheckoutCal: Ipricing
    {
        public IDictionary<string, int> cart_sku = new Dictionary<string, int>();
        public IDictionary<string, double> cart_price = new Dictionary<string, double>();
        public void scan(string sku, double amount)
        {
            int count = 0;
            if (!cart_price.ContainsKey(sku))
            {
                cart_price.Add(sku, amount);
            }
            if (cart_sku.ContainsKey(sku))
            {
               
                count = cart_sku[sku];
            }
            
            cart_sku[sku] = count + 1;
           
        }

        public double Total()
        {
            double total = 0;
            bool _mbpExists = false;

            foreach (var item in cart_sku)
            {
                foreach (var item1 in cart_price)
                {
                    if (item1.Key == item.Key)
                    {
                        if (item.Key.Contains("atv") && item.Value > 2)
                        {
                            total += item1.Value * 2;
                            break;
                        }
                        else if (item.Key.Contains("ipd") && item.Value > 4)
                        {
                            total = total + (499.99 * item.Value);
                            break;
                        }
                        else if (item.Key.Contains("mbp"))
                        {
                            total += item1.Value * item.Value;
                            _mbpExists = true;
                            break;
                        }
                        else if (item.Key.Contains("vtg"))
                        {
                            if (_mbpExists == false)
                            {
                                total += item1.Value * item.Value;
                            }
                            break;
                        }
                        else
                        {
                            total += item1.Value * item.Value;
                        }
                    }

                }
            }
            return total;
        }

    }
}