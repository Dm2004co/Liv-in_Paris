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
using Azure.Core.Pipeline;
using Microsoft.Identity.Client.TelemetryCore.TelemetryClient;
using System.ComponentModel.Design;
using System.Runtime;

namespace Paris_Mapper
{
    class Client
    {
        string connexion;
        SqlConnection client;
        string login;
        public Client()
        {

            connexion = "Data Source=(localdb)\\ProjectModels;Initial Catalog=Paris;Persist Security Info=True;User ID=Log_Client;Pooling=False;Multiple Active Result Sets=False;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Authentication=SqlPassword;Application Name=\"Microsoft SQL Server Data Tools, T-SQL Editor\";Column Encryption Setting=Disabled;Command Timeout=0;PWD = 123";
            client = new SqlConnection(connexion);
            client.Open();
            
            //Console.WriteLine("Mot de passe (Client) :");
            //login = Console.ReadLine();
            Console.WriteLine("Identifiant du client :");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Menu : \n\t 0 : Requetes \n\t");
            int menu = Convert.ToInt32(Console.ReadLine());
            switch(menu)
            {
                case 0:Console.WriteLine("Selection : Requetes \n\t Lectude de la commande d'un client \n\t Profil du Client ");
                    int req = Convert.ToInt32(Console.ReadLine());
                    switch(req)
                    {
                        case 0:
                            Console.WriteLine("Selection : Lecture de la commande d'un client");
                           
                            Lecture_Commande(id);
                                break;
                        case 1: Console.WriteLine("Selection : Profil du Client");
                            Profil_Client(id);
                            break;
                    }

                    break;
                default:
                    
                    break;
            }
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

        #region Requetes 
            
        
         public void Lecture_Commande(int id_client)
        {

            SqlParameter cl = new SqlParameter("@ID_Client", DbType.Int32);
            cl.Value = id_client;
            string q = "SELECT c.ID_Client,c.Prenom,c.Nom,c.Telephone,c.Email,c.Adresse,com.ID_Commandes,com.Nom_Menu,com.Nb_de_Personnes,com.Pays_d_origine,com.Regime,com.Prix_Unitaire,com.Date_depart,com.Date_arrivee FROM Commande com \r\n\t JOIN Client c on c.ID_Client = com.ID_Client\r\n\t WHERE c.ID_Client = @ID_Client\r\n\t group by c.ID_Client,c.ID_Client,c.Prenom,c.Nom,c.Telephone,c.Email,c.Adresse,com.ID_Commandes,com.Nom_Menu,com.Nb_de_Personnes,com.Pays_d_origine,com.Regime,com.Prix_Unitaire,com.Date_depart,com.Date_arrivee\r\n\t order by c.ID_Client;";
            SqlCommand c = client.CreateCommand();
            c.Parameters.Add(cl);
            c.CommandText = q;
            SqlDataReader read = c.ExecuteReader();
            string[] val = new string[read.FieldCount];
            while(read.Read())
            {
                int ID_Client = (int)read["ID_Client"];
                string Prenom = (string)read["Prenom"];
                string Nom = (string)read["Nom"];
                string tel = (string)read["Telephone"];
                string email = (string)read["Email"];
                string adresse = (string)read["Adresse"];
                int ID_Commande = (int)read["ID_Commandes"];
                int nb = (int)read["Nb_de_Personnes"];
                DateTime depart = (DateTime)read["Date_depart"];
                DateTime arrivee = (DateTime)read["Date_arrivee"];
                string menu = (string)read["Nom_Menu"];
                decimal prix = (decimal)read["Prix_Unitaire"];
                //string regime = (string)read["Regime"];
                string nationalite = (string)read["Pays_d_origine"];


                //DateTime mylastupdate = (DateTime)read["mydate"];

                Console.WriteLine($"{ID_Client} | {Prenom} | {Nom} | {tel} | {email} | {adresse} | {ID_Commande} | {nb} | {depart} | {arrivee} | {menu} | {prix} | {nationalite}");
                for (int i = 0; i < read.FieldCount; i++)
                {
                    val[i] = read.GetValue(i).ToString();
                }

                Console.WriteLine();

            }
            read.Close();
        }

        public void Profil_Client(int id)
        {
            try
            {


                string query = "select * from Client WHERE ID_Client = @ID_Client ;";
                SqlParameter p = new SqlParameter();
                p.Value = id;
                p.DbType = DbType.Int32;
                p.ParameterName = "@ID_Client";
                SqlCommand c = new SqlCommand(query, client);
                c.Parameters.Add(p);
                SqlDataReader read = c.ExecuteReader();
                string[] valueString = new string[read.FieldCount];
                Console.WriteLine("Prenom | Nom | Telephone | Email");
                while (read.Read())


                {

                    string Prenom = (string)read["Prenom"];
                    string Nom = (string)read["Nom"];
                    string Telephone = (string)read["Telephone"];
                    string Email = (string)read["Email"];
                    //string Adresse = (string)read["Adresse"];
                    //DateTime mylastupdate = (DateTime)read["mydate"];

                    Console.WriteLine($" {Prenom} | {Nom} | {Telephone} | {Email} ");
                    for (int i = 0; i < read.FieldCount; i++)
                    {
                        valueString[i] = read.GetValue(i).ToString();
                    }

                    Console.WriteLine();

                }

                read.Close();


            }

            catch (SqlException e)
            {
                Console.WriteLine(" ErreurConnexion : " + e.ToString());
                return;
            }
        }


        #endregion

        #region Fonctions




        #endregion





    }
}
