using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assign06
{
    class ClientRepository
    {
        //connection string
        private static string connString = @"Server=tcp:skeena.database.windows.net,1433;
                                            Initial Catalog=comp2614;
                                            User ID=student;
                                            Password=93nu5_zZ5b;
                                            Encrypt=True;
                                            TrustServerCertificate=False;
                                            Connection Timeout=30;";

        public static ClientCollection GetClients()
        {
            ClientCollection clients;

            using(SqlConnection conn = new SqlConnection(connString))
            {
                string query = @"SELECT ClientCode, CompanyName, Address1, Address2,
                                City, Province, PostalCode, YTDSales,
                                CreditHold, Notes
                                FROM Client";

                using(SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = query;
                    cmd.Connection = conn;

                    conn.Open();

                    clients = new ClientCollection();

                    using(SqlDataReader reader = cmd.ExecuteReader())
                    {
                        string clientCode, companyName, address1, address2, city, province, postalCode, notes = String.Empty;
                        decimal ytdSales;
                        bool creditHold = false;

                        while(reader.Read())
                        {

                        }
                    }

                    return clients;
                }
            }
        }
    }
}
