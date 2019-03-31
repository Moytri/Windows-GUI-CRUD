using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assign06.Common
{
    public class Client
    {
        public string ClientCode { get; set; }
        public string CompanyName { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string Province { get; set; }
        public string PostalCode { get; set; }
        public decimal YTDSales { get; set; }
        public bool IsCreditHold { get; set; }
        public string Notes { get; set; }

        public Client(string clientCode, string companyName, string address1, string address2,
                      string city, string province, string postalCode, decimal ytdSales, 
                      bool isCreditHold, string notes)
        {
            ClientCode = clientCode;
            CompanyName = companyName;
            Address1 = address1;
            Address2 = address2;
            City = city;
            Province = province;
            PostalCode = postalCode;
            YTDSales = ytdSales;
            IsCreditHold = isCreditHold;
            Notes = notes;
        }

        public Client()
        {

        }
    }
}
