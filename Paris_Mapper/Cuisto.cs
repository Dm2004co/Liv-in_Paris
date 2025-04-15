using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using System.Data.Common;
using Microsoft.SqlServer.Server;
using Microsoft.Data.SqlClient;
using Org.BouncyCastle.Asn1;
using Org.BouncyCastle.Crypto.Signers;
using Org.BouncyCastle.Bcpg.OpenPgp;
using Mysqlx.Crud;
using System.Diagnostics.Eventing.Reader;

namespace Paris_Mapper
{
    class Cuisto
    {
        string connexion;
        SqlConnection cuisto;
        string login;
        public Cuisto()
        {
            connexion = "Data Source=(localdb)\\ProjectModels;Initial Catalog=Paris;Persist Security Info=True;User ID=Log_Cuisto;Pooling=False;Multiple Active Result Sets=False;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Authentication=SqlPassword;Application Name=\"Microsoft SQL Server Data Tools, T-SQL Editor\";Column Encryption Setting=Disabled;Command Timeout=0;PWD = 456";
            cuisto = new SqlConnection(connexion);
            cuisto.Open();
            //Console.WriteLine("Mot de passe (Cuisto) :");
            //login = Console.ReadLine();
           
        }
        public void Modifcation_Cuisto()
        {
            
            string query = $"ALTER LOGIN Log_Cui WITH PASSWORD = '@password' ;";
            SqlCommand c = new SqlCommand(query, cuisto);
            c.Parameters.AddWithValue("@password", login);
            try
            {

                c.ExecuteNonQuery();
                Console.WriteLine("Modification du cuisinier réussi");

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

        public void Suppression_Cuisto()
        {

            string query = "DROP USER Cuisto;" + "DROP LOGIN Log_Cui";
            SqlCommand c = new SqlCommand(query, cuisto);

            try
            {

                c.ExecuteNonQuery();
                Console.WriteLine("Suppression du cuisinier réussi");

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
