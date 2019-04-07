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
        //Sum all the YTDSales 
        public decimal TotalYTDSales => this.Sum(x => x.YTDSales);

        //Count the number of Credit Holders;
        public int CreditHoldCount => this.Where(x => x.IsCreditHold == true).Count();
    }
}
