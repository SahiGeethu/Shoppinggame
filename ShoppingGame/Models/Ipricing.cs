using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingGame.Models
{
   public interface Ipricing
    {
        void scan(string sku, double amount);
        double Total();
      
    }
}
