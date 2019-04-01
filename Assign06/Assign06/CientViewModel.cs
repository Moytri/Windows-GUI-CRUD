using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Assign06.Common;
using Assign06.Data;

namespace Assign06
{
    public class CientViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private Client client;
        public Client Client
        {
            get { return client; }
            set { client = value; OnPropertyChanged("Client"); }
        }

        public ClientCollection Clients { get; set; }

        public CientViewModel()
        {
            try
            {
                this.Clients = ClientRepository.GetClients();
                this.Client = new Client();
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Data Access Error\n\n{0}\n\n{1}", ex.Message, ex.StackTrace);
            }

            catch (Exception ex)
            {
                Console.WriteLine("Processing Error\n\n{0}\n\n{1}", ex.Message, ex.StackTrace);
            }
        }
        public void SetDisplayClient(Client client)
        {
            Client = new Client
            {
                ClientCode = client.ClientCode,
                CompanyName = client.CompanyName,
                Address1 = client.Address1,
                Address2 = client.Address2,
                City = client.City,
                Province = client.Province,
                PostalCode = client.PostalCode,
                YTDSales = client.YTDSales,
                IsCreditHold = client.IsCreditHold,
                Notes = client.Notes
            };
        }

        public Client GetDisplayClient()
        {
            OnPropertyChanged("Client");
            return Client;
        }
    }
}
