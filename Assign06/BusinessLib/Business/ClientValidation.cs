using BusinessLib.Common;
using BusinessLib.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BusinessLib.Business
{
    public class ClientValidation
    {
        private static List<string> errotList;

        public static string ErrorMessage
        {
            get
            {
                string meassage = "";

                foreach(string msg in errotList)
                {
                    meassage += msg + "\r\n";
                }
                return meassage;
            }
        }

        static ClientValidation()
        {
            errotList = new List<string>();
        }

        public static int AddClient(Client client)
        {
            if(validate(client))
            {
                return ClientRepository.AddClient(client);
            }
            return -1;
        }

        public static int UpdateClient(Client client)
        {
            if (validate(client))
            {
                return ClientRepository.UpdateClient(client);
            }
            return -1;
        }

        public static int DeleteClient(Client client)
        {
            return ClientRepository.DeleteClient(client);
        }

        public static ClientCollection GetClients()
        {
            return ClientRepository.GetClients();
        }

        private static bool validate(Client client)
        {
            //ClientCode cannot be empty
            //CompanyName cannot be empty
            //Address1 cannot be empty
            //Province cannot by empty
            //YTDSales cannot be negative

            bool valid = true;
            errotList.Clear();
            string regExClientCode = @"[A-Z]{5}$";
            string regExProvince = @"[A-Z]{2}$";
            string regExCdnPostalCode = @"^[A-Z]\d[A-Z] \d[A-Z]\d$";

            if (string.IsNullOrWhiteSpace(client.ClientCode))
            {
                errotList.Add("Entry must have a ClientCode");
                valid = false;
            }
            else if (!Regex.IsMatch(client.ClientCode, regExClientCode))
            {
                errotList.Add("Client Code must be in the form AAAAA");
                valid = false;
            }

            if (string.IsNullOrWhiteSpace(client.CompanyName))
            {
                errotList.Add("CompanyName cannot be empty");
                valid = false;
            }

            if (string.IsNullOrWhiteSpace(client.Address1))
            {
                errotList.Add("Address1 field cannot be empty");
                valid = false;
            }

            if (string.IsNullOrWhiteSpace(client.Province))
            {
                errotList.Add("Province cannot be empty");
                valid = false;
            }

            else if(!Regex.IsMatch(client.Province, regExProvince))
            {
                errotList.Add("Valid Format for Province is AA");
                valid = false;
            }

            if (!Regex.IsMatch(client.PostalCode, regExCdnPostalCode))
            {
                errotList.Add("Postal Code Format is Incorrect");
            }

            if (client.YTDSales < 0.00m)
            {
                errotList.Add("Year To Date sales must be positive");
                valid = false;
            }
            return valid;
        }
    }
}
