using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLib.Common
{
    public class ClientCollection : BindingList<Client>
    {
        public decimal TotalYTDSales => this.Sum(x => x.YTDSales);
        
        public int CreditHoldCount => this.Where(x => x.IsCreditHold == true).Count();
    }
}
