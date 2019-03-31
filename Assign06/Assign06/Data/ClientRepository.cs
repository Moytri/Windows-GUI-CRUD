using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assign06.Common;

namespace Assign06.Data
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
                        string clientCode, companyName, address1, address2 = null, city = null, province, postalCode = null, notes = null;
                        decimal ytdSales;
                        bool isCreditHold = false;

                        while(reader.Read())
                        {
                            clientCode = reader["ClientCode"] as string;
                            companyName = reader["CompanyName"] as string;
                            address1 = reader["Address1"] as string;

                            if(!reader.IsDBNull(3))
                            {
                                address2 = reader["Address2"] as string;
                            }

                            if (!reader.IsDBNull(4))
                            {
                                city = reader["City"] as string;
                            }

                            province = reader["Province"] as string;

                            if(!reader.IsDBNull(6))
                            {
                                postalCode = reader["PostalCode"] as string;
                            }

                            ytdSales = (decimal)reader["YTDSales"];
                            isCreditHold = (bool)reader["CreditHold"];

                            if(!reader.IsDBNull(9))
                            {
                                notes = reader["Notes"] as string;
                            }

                            clients.Add(new Client(clientCode, companyName, address1, address2, city, province, postalCode, ytdSales, isCreditHold, notes));
                            address2 = null;
                            city = null;
                            postalCode = null;
                            notes = null;
                        }
                    }

                    return clients;
                }
            }
        }
    }
}
