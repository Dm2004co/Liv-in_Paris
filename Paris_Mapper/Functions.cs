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
using System.Reflection.Metadata;
using System.Net.Sockets;
using System.Reflection.Metadata.Ecma335;



namespace Paris_Mapper
{
    class Functions
    {
        string connexion;
        SqlConnection connection;
        public Functions(string connexion , SqlConnection connection)
        {
            this.connexion = connexion;
            this.connection = connection;
        }
        
        
        public void Plat_du_Jour()
        {
            string q = "INSERT Plat_du_Jour(ID_Cuisto,Date_depart,Nom_Menu)\r\nSELECT cui.ID_Cuisto, com.Date_depart,menu.Nom_Menu from Commandes com\r\nJOIN Cuisto cui ON cui.ID_Cuisto = com.ID_Cuisto\r\nJOIN Contenu_du_Menu menu on menu.Nom_Menu = com.Nom_Menu\r\nWHERE com.Date_depart IS NOT NULL;";
            SqlCommand c = new SqlCommand(q, connection);
            try
            {

                c.ExecuteNonQuery();
                Console.Write("Insertion réussite");

            }



            catch (SqlException e)
            {
                Console.WriteLine(" ErreurConnexion : " + e.ToString());
                return;
            }
            finally
            {
                c.Dispose();
                ;
            }
        }

        public void Prix_C(int nombre , decimal prix)
        {

            SqlParameter r = new SqlParameter("@return_value",DbType.Decimal);
            SqlParameter p = new SqlParameter("@Prix_Uni", DbType.Decimal);
            p.Value = prix;
            SqlParameter n = new SqlParameter("@Nombre_de_Personne", DbType.Int32);
            n.Value = nombre;
            string q = "DECLARE\t@return_value Decimal(5, 3)\r\n\r\nEXEC\t@return_value = [dbo].[Prix_C]\r\n\t\t@Nombre_de_Personnes = @Nombre_de_Personne ,\r\n\t\t@Prix_Unitaire = @Prix_Uni\r\n\r\nSELECT\t@return_value as 'Prix de la Commande'\r\n\r\nGO";
            SqlCommand c = new SqlCommand(q, connection);
            c.Parameters.Add(r);
            c.Parameters.Add(p);
            c.Parameters.Add(n);
            try
            {

                c.ExecuteNonQuery();
                Console.Write("Insertion réussite");

            }



            catch (SqlException e)
            {
                Console.WriteLine(" ErreurConnexion : " + e.ToString());
                return;
            }
            finally
            {
                c.Dispose();
                ;
            }

        }
    }
}
