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
using static System.Runtime.InteropServices.JavaScript.JSType;



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
        
        
        public void Plat_du_Jour(int id_cui,DateTime date_d ,string nom_menu,string nom_entree,int quantite_entree,string ingredients_entree,string volumes_entree,string unite_entree,string nom_dessert,int quantite_dessert,string ingredient_dessert,string volumes_dessert,string unite_dessert,string nom_plat,string quantite_plat,string ingredient_plats,string volumes_plat,string unite_plat)
        {

            SqlParameter id_cuisto = new SqlParameter("@ID_Cuisto", DbType.Int32);
            id_cuisto.Value = id_cui;
            SqlParameter depart = new SqlParameter("@Date_depart", DbType.DateTime);
            depart.Value = date_d;
            SqlParameter menu = new SqlParameter("@Nom_Menu",DbType.String);
            menu.Value = nom_menu;
            
            string q = "SELECT * FROM Plat_du_Jour(@ID_Cuisto AS ID,\r\n\t\t\t@Date_depart AS Depart,\r\n\t\t\t@Nom_Menu as Menu,\r\n\t\t\t@Nom_Entree as Entree,\r\n\t\t\t@Nombre_Ingredient_entree as Quantite_entree ,\r\n\t\t\t@Ingredient_Entree as Ingredient_Entree,\r\n\t\t\t@Volume_entree as Volume_entree,\r\n\t\t\t@Unite_de_mesure_entree as Unite_de_mesure_entree,\r\n\t\t\t@Nom_Dessert as Dessert,\r\n\t\t\t@Nombre_Ingredient_dessert as Quantite_dessert,\r\n\t\t\t@Ingredient_Dessert as Ingredient_Dessert,\r\n\t\t\t@Volume_dessert as Volume_dessert,\r\n\t\t\t@Unite_de_mesure_dessert as Unite_de_mesure_dessert,\r\n\t\t\t@Nom_Plat as Plat,\r\n\t\t\t@Nombre_Ingredient_plat as Quantite_plat,\r\n\t\t\t@Ingredient_Plat as Ingredient_Plat,\r\n\t\t\t@Volume_plat as Volume_plat,\r\n\t\t\t@Unite_de_mesure_plat as Unite_de_mesure_plat)";
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

        public void Prix_C(int nombre , decimal prix, SqlTransaction t)
        {

           
           
            string q = $"DECLARE\t@return_value Decimal(5, 3)\r\n\r\nEXEC\t@return_value = [dbo].[Prix_C]\r\n\t\t@Nombre_de_Personnes = {nombre} ,\r\n\t\t@Prix_Unitaire = {prix}\r\n\r\nSELECT\t@return_value as 'Prix de la Commande'";
            SqlCommand c = new SqlCommand(q, connection);
            c.Transaction = t;
            SqlDataReader read = c.ExecuteReader();
            string[] valueString = new string[read.FieldCount];

            
            try
            {
                while (read.Read())


                {
                    decimal p = (decimal)read["Prix de la Commande"];

                    Console.WriteLine($"{p}");
                    
                    for (int i = 0; i < read.FieldCount; i++)
                    {
                        valueString[i] = read.GetValue(i).ToString();

                    }


                }

                read.Close();


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
        public int Num_Commande(int id_c , int id_cui)
        {
            string g = $"DECLARE\t@return_value Int\r\n\r\nEXEC\t@return_value = [dbo].[Num_Commande]\r\n\t\t@ID1 = {id_c},\r\n\t\t@ID2 = {id_cui}\r\n\r\nSELECT\t@return_value as 'Numero de la Commande'";
            SqlCommand c = new SqlCommand(g, connection);
           
            SqlDataReader read = c.ExecuteReader();
            string[] valueString = new string[read.FieldCount];
            int n = 0;

            try
            {
                while (read.Read())


                {
                    n = (int)read["Numero de la Commande"];

                    Console.WriteLine($"{n}");

                    for (int i = 0; i < read.FieldCount; i++)
                    {
                        valueString[i] = read.GetValue(i).ToString();

                    }


                }

                read.Close();

                return n;
            }


            
            catch (SqlException e)
            {
                Console.WriteLine(" ErreurConnexion : " + e.ToString());
                return 0;
            }
            finally
            {
                c.Dispose();
                ;
            }

        }
    }
}
