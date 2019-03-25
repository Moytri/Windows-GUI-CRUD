using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assign06
{
    public class ClientCollection : BindingList<Client>
    {
        public decimal TotalYTDSales ()
        {
            return this.Sum(x => x.YTDSales);
        }

        public int CreditHoldCount()
        {
            return this.Where(x => x.IsCreditHold == true).Count();
        }
    }
}
