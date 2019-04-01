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

        private static readonly string clientTableName = "Client062206";

        public static int AddClient(Client client)
        {
            string query = $@"INSERT INTO {clientTableName}
                              (ClientCode, CompanyName, Address1, Address2, City, Province, PostalCode, YTDSales, CreditHold, Notes)
                               VALUES(@clientCode, @companyName, @address1, @address2, @city, @province, @postalCode, @ytdSales, @creditHold, @notes)";
            return processQuery(query, client);
        }

        public static int UpdateClient(Client client)
        {     
            string query = $@"UPDATE {clientTableName}
                              SET CompanyName = @companyName,
                                  Address1 = @address1,
                                  Address2 = @address2,
                                  City = @city,
                                  Province = @province,
                                  PostalCode = @postalCode,
                                  YTDSales = @ytdSales,
                                  CreditHold = @creditHold,
                                  Notes = @notes
                              WHERE ClientCode = @clientCode";
            return processQuery(query, client);
        }

        private static int processQuery(string query, Client client)
        {
            int rowsAffected;
            using(SqlConnection conn = new SqlConnection(connString))
            {
                using(SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = query;
                    cmd.Connection = conn;

                    cmd.Parameters.AddWithValue("@clientCode", client.ClientCode);
                    cmd.Parameters.AddWithValue("@companyName", client.CompanyName);
                    cmd.Parameters.AddWithValue("@address1", client.Address1);

                    if(client.Address2 != null)
                    {
                        cmd.Parameters.AddWithValue("@address2", client.Address2);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@address2", DBNull.Value);
                    }

                    if (client.City != null)
                    {
                        cmd.Parameters.AddWithValue("@city", client.City);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@city", DBNull.Value);
                    }

                    cmd.Parameters.AddWithValue("@province", client.Province);

                    if (client.PostalCode != null)
                    {
                        cmd.Parameters.AddWithValue("@postalCode", client.PostalCode);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@postalCode", DBNull.Value);
                    }

                    cmd.Parameters.AddWithValue("@ytdSales", client.YTDSales);
                    cmd.Parameters.AddWithValue("@creditHold", client.IsCreditHold);

                    if (client.Notes != null)
                    {
                        cmd.Parameters.AddWithValue("@notes", client.Notes);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@notes", DBNull.Value);
                    }

                    conn.Open();

                    rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected;
                }
            }
        }

        public static ClientCollection GetClients()
        {
            ClientCollection clients;

            using(SqlConnection conn = new SqlConnection(connString))
            {
                string query = $@"SELECT ClientCode, CompanyName, Address1, Address2,
                                City, Province, PostalCode, YTDSales,
                                CreditHold, Notes
                                FROM {clientTableName}";

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
