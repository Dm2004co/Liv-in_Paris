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
using Org.BouncyCastle.Tls.Crypto.Impl.BC;

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
            Console.WriteLine("Identifiant du cuisto :");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Menu : \n\t 0 : Requetes \n\t 1 : Statistiques \n\t 2 : Filtres");
            int menu = Convert.ToInt32(Console.ReadLine());
            switch (menu)
            {
                case 0:
                    Console.WriteLine("Selection : Requetes \n\t 0 : Lectude de la commande d'un cuisto \n\t 1 : Profil du cuisto ");
                    int req = Convert.ToInt32(Console.ReadLine());
                    switch (req)
                    {
                        case 0:
                            Console.WriteLine("Selection : Lecture de la commande d'un cuisto");

                            //Lecture_Commande(id);
                            break;
                        case 1:
                            Console.WriteLine("Selection : Profil du cuisto");
                            Profil_Cuisto(id);
                            break;
                        case 2:
                            Console.WriteLine();
                            break;
                    }

                    break;
                case 1: 
                    Console.WriteLine("Selection : Statistques \n\t 0 : Moyenne des prix des commandes \n\t 1 : Moyenne des comptes clients \n\t 2 : Nombre de livraisons");
                    int stat = Convert.ToInt32(Console.ReadLine());
                    switch(stat)
                    {
                        case 0:
                            Console.WriteLine("Selection : Moyenne des prix des commandes");
                            Moyenne_Prix_Commande(id);
                            break;
                        case 1:
                            Console.WriteLine("Selection : Moyenne des Comptes Clients");
                            Moyenne_Comptes_Client(id);
                            break;
                        case 2: Console.WriteLine("Selection : Nombre de Livraisons");
                            Nb_Livraisons(id);
                            break;
                        default:
                            bool quitter = false; 
                            if(quitter)
                            {
                                Console.WriteLine("Retour au menu precedent");
                                
                            }
                            else
                            {
                                Console.WriteLine("Selection : Statistques \n\t 0 : Moyenne des prix des commandes \n\t 1 : Moyenne des comptes clients \n\t 2 : Nombre de livraisons");

                                int s = Convert.ToInt32(Console.ReadLine());
                                if( s== 0)
                                {
                                    goto case 1;
                                }
                                if(s == 1)
                                {
                                    goto case 1;
                                }
                                if(s == 2)
                                {
                                    goto case 2;
                                }
                            }
                            break;
                    }
                    break;
                default:

                    break;
            }
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
        #region Requetes 


        public void Profil_Cuisto(int id)
        {
            try
            {


                string query = "select * from Cuisto WHERE ID_Cuisto = @ID_Cuisto ;";
                SqlParameter p = new SqlParameter();
                p.Value = id;
                p.DbType = DbType.Int32;
                p.ParameterName = "@ID_Cuisto";
                SqlCommand c = new SqlCommand(query, cuisto);
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
                    string Adresse = (string)read["Adresse"];
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
        public void Nb_Livraisons(int id_cui)
        {
            try
            {

                SqlParameter cui = new SqlParameter("@ID_Cuisto", DbType.Int32);
                cui.Value = id_cui;
                string query = "select * from Nombre_de_Livraisons WHERE ID_Cuisto = @ID_Cuisto ;";
                SqlCommand c = new SqlCommand(query, cuisto);
                c.Parameters.Add(cui);
                SqlDataReader read = c.ExecuteReader();
                string[] valueString = new string[read.FieldCount];
                Console.WriteLine("ID_Cuisto | Nombre ");
                while (read.Read())


                {
                    int ID_Cuisto = (int)read["ID_Cuisto"];

                    int Nombre = (int)read["Nombre_de_Livraisons"];


                    //DateTime mylastupdate = (DateTime)read["mydate"];

                    Console.WriteLine($"{ID_Cuisto} | {Nombre} ");
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


      
            public void Moyenne_Comptes_Client(int id)
        {

            try
            {
                SqlParameter cui = new SqlParameter("@ID_Cuisto", DbType.Int32);
                cui.Value = id;
                string query = "select SUM(Moyenne_Prix_Commande) as Moy_Compte_Client from (select c.ID_Client, com.ID_Commandes,AVG(com.Nb_de_Personnes * com.Prix_Unitaire) as Moyenne_Prix_Commande from Catalogue cat inner join Commande com on com.ID_Commandes = cat.ID_Commandes inner join Client c on c.ID_Client = cat.ID_Client inner join Cuisto cui on cui.ID_Cuisto = cat.ID_Cuisto WHERE cui.ID_Cuisto = 1 group by c.ID_Client,com.ID_Commandes) as Moyenne_Comptes_Clients;\r\n";
                 SqlCommand c = new SqlCommand(query, cuisto);
                c.Parameters.Add(cui);
                SqlDataReader read = c.ExecuteReader();
                string[] valueString = new string[read.FieldCount];
                Console.WriteLine("Moyenne des Comptes Clients :");
                while (read.Read())


                {

                    decimal Compte = (decimal)read["Moy_Compte_Client"];


                    //DateTime mylastupdate = (DateTime)read["mydate"];

                    Console.WriteLine($"{Compte} ");
                    for (int i = 0; i < read.FieldCount; i++)
                    {
                        valueString[i] = read.GetValue(i).ToString();
                    }

                    Console.WriteLine();

                }

                read.Close();

            }
            catch (SqlException ex)
            {
                Console.WriteLine(" ErreurConnexion : " + ex.ToString());
                return;
            }
        }

        public void Moyenne_Prix_Commande(int id)
        {
            try
            {
                SqlParameter cui = new SqlParameter("@ID_Cuisto", DbType.Int32);
                cui.Value = id;
                string query = "select  AVG(com.Nb_de_Personnes * com.Prix_Unitaire) as Moyenne_Prix_Commande from Commande com\r\n\tINNER JOIN Cuisto cui on cui.ID_Cuisto = com.ID_Cuisto\r\n\tWHERE cui.ID_Cuisto = @ID_Cuisto;";
                SqlCommand c = new SqlCommand(query, cuisto);
                c.Parameters.Add(cui);
                SqlDataReader read = c.ExecuteReader();
                string[] valueString = new string[read.FieldCount];
                Console.WriteLine("Moyenne des Prix ");
                while (read.Read())


                {

                    decimal Moy_Prix = (decimal)read["Moyenne_Prix_Commande"];


                    //DateTime mylastupdate = (DateTime)read["mydate"];

                    Console.WriteLine($"{Moy_Prix} ");
                    for (int i = 0; i < read.FieldCount; i++)
                    {
                        valueString[i] = read.GetValue(i).ToString();
                    }

                    Console.WriteLine();

                }

                read.Close();

            }
            catch (SqlException ex)
            {
                Console.WriteLine(" ErreurConnexion : " + ex.ToString());
                return;
            }
        }
        #endregion

        #region Fonctions

        #endregion

    }
}
