using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Data.Common;
using Microsoft.SqlServer.Server;
using Microsoft.Data.SqlClient;
using Org.BouncyCastle.Asn1;
using System.Data;
using Org.BouncyCastle.Crypto.Signers;
using System.Web;

namespace Paris_Mapper
{
    class Client
    {
        string connexion;
        SqlConnection client;
        string login;
        public Client()
        {
            connexion = "Data Source=(localdb)\\ProjectModels;Initial Catalog=Paris;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";
             client = new SqlConnection(connexion);
            client.Open();
            Console.WriteLine("Mot de passe (Client) :");
            login = Console.ReadLine();

        }
        
       
        public void Modification_Client()
        {
            
            
            string query =  "ALTER LOGIN Log_C WITH PASSWORD = '@password' ;";
            SqlCommand c = new SqlCommand(query, client);
            c.Parameters.AddWithValue("@password", login);
            try
            { 
                
                c.ExecuteNonQuery();
                Console.WriteLine("Modification du client réussi");

            }


            catch (SqlException e)
            {
                Console.WriteLine(" ErreurConnexion : " + e.ToString());
                return;
            }
            finally
            {
                c.Dispose();
                
            }

        }
        public void Suppression_Client()
        {
            string query = "DROP USER C ;" + "DROP LOGIN Log_C";
            SqlCommand c = new SqlCommand(query, client);

            try
            {

                c.ExecuteNonQuery();
                Console.WriteLine("Suppression du client réussi");

            }


            catch (SqlException e)
            {
                Console.WriteLine(" ErreurConnexion : " + e.ToString());
                return;
            }
            finally
            {
                c.Dispose();
                
            }

        }
        
       
        
        
       
    }
}
