using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
using System.Runtime.CompilerServices;


namespace Paris_Mapper
{
    class Requetes
    {
         public string connexion;
         public SqlConnection connection;
        public Requetes(string connexion, SqlConnection connection)
        {
            this.connexion = connexion;
            this.connection = connection;
        }
        public void Select_Mono_Table()
        {
            //Facultatif car fichier sql 
        }

        public void Client()
        {
            Console.WriteLine("Requetes : \n\t 0 : Lecture de la table Client \n\t 1 : Filtrage par ordre alphabétique \n\t 2 : Adresse des clients \n\t 3 : Facture des clients \n\t 4 : Profil du Client \n\t 5 : Comptes Clients ");
            int client = Convert.ToInt32(Console.ReadLine());
            switch (client)
            {
                case 0: Console.WriteLine("Selection : Lecture de la table Client");
                    Lecture_Client();
                    break;
                case 1: Console.WriteLine("Selection : Filtrage par ordre alphabétique");
                    Filtre_Nom_Client();
                    break;
                case 2: Console.WriteLine("Selection : Adresse des clients");
                    Adresse_Client();
                    break;
                case 3: Console.WriteLine("Selection : Facture des clients");
                    Montant_Client();
                    break;
                case 4: Console.WriteLine("Selection : Profil du Client");
                    Console.WriteLine("Identifiant du Client :");
                    int nombre = Convert.ToInt32(Console.ReadLine());
                    Profil_Client(nombre);
                    break;
                case 5: Console.WriteLine("Selection : Comptes Clients");
                    Comptes_Clients();
                    break;
            }

            void Filtre_Nom_Client()
            {
                try
                {


                    string query = "select c.Prenom,c.Nom from Client c \r\ngroup by c.Nom,c.Prenom\r\norder by c.Nom,c.Prenom;";
                    SqlCommand c = new SqlCommand(query, connection);
                    SqlDataReader read = c.ExecuteReader();
                    string[] valueString = new string[read.FieldCount];

                    while (read.Read())

                    {

                        string Prenom = (string)read["Prenom"];
                        string Nom = (string)read["Nom"];
                        //DateTime mylastupdate = (DateTime)read["mydate"];
                        Console.WriteLine($" {Prenom} , {Nom} ");
                        string val = "";
                        for (int i = 0; i < read.FieldCount; i++)
                        {
                            valueString[i] = read.GetValue(i).ToString();
                        }

                        Console.WriteLine();

                    }

                    read.Close();
                    connection.Close();

                }

                catch (SqlException e)
                {
                    Console.WriteLine(" ErreurConnexion : " + e.ToString());
                    return;
                }
            }
            void Lecture_Client()
            {
                try
                {


                    string query = "select * from Client c ;";
                    SqlCommand c = new SqlCommand(query, connection);
                    SqlDataReader read = c.ExecuteReader();
                    string[] valueString = new string[read.FieldCount];

                    while (read.Read())


                    {
                        int ID_Client = (int)read["ID_Client"];
                        string Prenom = (string)read["Prenom"];
                        string Nom = (string)read["Nom"];
                        string Telephone = (string)read["Telephone"];
                        string Email = (string)read["Email"];
                        //DateTime mylastupdate = (DateTime)read["mydate"];
                        Console.WriteLine($"{ID_Client} , {Prenom} , {Nom} , {Telephone} , {Email} ");
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


            void Adresse_Client()
            {
                try
                {


                    string query = "select * from Adresse_Client;";
                    SqlCommand c = new SqlCommand(query, connection);
                    SqlDataReader read = c.ExecuteReader();
                    string[] valueString = new string[read.FieldCount];

                    while (read.Read())


                    {
                        
                        int Numero = (int)read["Numero"];
                        string Lieu = (string)read["Lieu"];
                        string Ville = (string)read["Ville"];
                        int Code_Postal = (int)read["Code_Postal"];
                        string Region = (string)read["Region"];

                        //DateTime mylastupdate = (DateTime)read["mydate"];
                        Console.WriteLine($" {Numero} , {Lieu} , {Ville},{Code_Postal},{Region}");
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

            void Montant_Client()
            {
                try
                {


                    string query = "select c.ID_Client,c.Prenom,c.Nom,(SUM(com.Nb_de_Personnes * com.Prix_Unitaire)) as Montant from Client c\r\njoin Commandes com on com.ID_Client = c.ID_Client\r\ngroup by c.ID_Client,c.Prenom,c.Nom\r\norder by c.ID_Client,c.Prenom,c.Nom;";
                    SqlCommand c = new SqlCommand(query, connection);

                    SqlDataReader read = c.ExecuteReader();
                    string[] valueString = new string[read.FieldCount];

                    while (read.Read())


                    {
                        int ID_Client = (int)read["ID_Client"];
                        string Prenom = (string)read["Prenom"];
                        string Nom = (string)read["Nom"];
                        decimal Montant = (decimal)read["Montant"];
                        //DateTime mylastupdate = (DateTime)read["mydate"];
                        Console.WriteLine($"{ID_Client},{Prenom},{Nom},{Montant} ");
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

        }
        
         public void Profil_Client(int id)
        {
            try
            {


                string query = "select * from Profil_Client WHERE ID_Client = @ID_Client ;";
                SqlParameter p = new SqlParameter();
                p.Value = id;
                p.DbType = DbType.Int32;
                p.ParameterName = "@ID_Client";
                SqlCommand c = new SqlCommand(query, connection);
                c.Parameters.Add(p);
                SqlDataReader read = c.ExecuteReader();
                string[] valueString = new string[read.FieldCount];

                while (read.Read())


                {
                    
                    string Prenom = (string)read["Prenom"];
                    string Nom = (string)read["Nom"];
                    string Telephone = (string)read["Telephone"];
                    string Email = (string)read["Email"];
                    //string Adresse = (string)read["Adresse"];
                    //DateTime mylastupdate = (DateTime)read["mydate"];
                    Console.WriteLine($" {Prenom} , {Nom} , {Telephone} , {Email} ");
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

         public void Comptes_Clients()
        {
            try
            {

                string query = "SELECT * FROM Comptes_Clients";
                SqlCommand c = new SqlCommand(query, connection);

                SqlDataReader read = c.ExecuteReader();
                string[] valueString = new string[read.FieldCount];

                while (read.Read())


                {
                    double Compte = (double)read["Compte_Client"];
                    
                   
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

            catch (SqlException e)
            {
                Console.WriteLine(" ErreurConnexion : " + e.ToString());
                return;
            }
        }


        #region Cuisinier
        public void Cuisinier()
        {
            Console.WriteLine("Requetes : \n\t 0 : Lecture de la table Cuisto \n\t 1 : Profil du Cuisto  \n\t 2 : Plat du Jour \n\t 3 : Adresse des cuisiniers \n\t 4 :  \n\t 5 : ");
            int cui = Convert.ToInt32(Console.ReadLine());
            switch(cui)
            {
                case 0:
                    Console.WriteLine("Selection : Lecture de la table Cuisto"); 
                    Lecture_Cuisto();
                    break;
                case 1:
                    Console.WriteLine("Selection : Profil du Cuisto");
                    Console.WriteLine("Identifiant : ");
                    int id = Convert.ToInt32(Console.ReadLine());
                    Profil_Cuisto(id);
                    break;
                case 2:
                    Console.WriteLine("Selection : Plat du Jour");
                    break;
                case 3:
                    Console.WriteLine("Selection : Adresse des cuisiniers");
                    Adresse_Cuisto();
                    break;
                case 4:
                    Console.WriteLine("Selection : ");
                    break;
            }
             

         }

        void Lecture_Cuisto()
        {
            try
            {


                string query = "select * from Cuisto cui ;";
                SqlCommand c = new SqlCommand(query, connection);
                SqlDataReader read = c.ExecuteReader();
                string[] valueString = new string[read.FieldCount];

                while (read.Read())


                {
                    int ID_Cuisto = (int)read["ID_Cuisto"];
                    string Prenom = (string)read["Prenom"];
                    string Nom = (string)read["Nom"];
                    string Telephone = (string)read["Telephone"];
                    string Email = (string)read["Email"];
                    //DateTime mylastupdate = (DateTime)read["mydate"];
                    Console.WriteLine($"{ID_Cuisto} , {Prenom} , {Nom} , {Telephone} , {Email} ");
                    for (int i = 0; i < read.FieldCount; i++)
                    {
                        valueString[i] = read.GetValue(i).ToString();
                    }

                    Console.WriteLine();

                }

                read.Close();


            }

            catch (MySqlException e)
            {
                Console.WriteLine(" ErreurConnexion : " + e.ToString());
                return;
            }
        }


        public void Profil_Cuisto(int id)
        {
            try
            {


                string query = "select * from Profil_Cuisto WHERE ID_Cuisto = @ID_Cuisto ;";
                SqlParameter p = new SqlParameter();
                p.Value = id;
                p.DbType = DbType.Int32;
                p.ParameterName = "@ID_Cuisto";
                SqlCommand c = new SqlCommand(query, connection);
                c.Parameters.Add(p);
                SqlDataReader read = c.ExecuteReader();
                string[] valueString = new string[read.FieldCount];

                while (read.Read())


                {

                    string Prenom = (string)read["Prenom"];
                    string Nom = (string)read["Nom"];
                    string Telephone = (string)read["Telephone"];
                    string Email = (string)read["Email"];
                    string Adresse = (string)read["Adresse"];
                    //DateTime mylastupdate = (DateTime)read["mydate"];
                    Console.WriteLine($" {Prenom} , {Nom} , {Telephone} , {Email} ");
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
       public void Adresse_Cuisto()
        {
            try
            {


                string query = "select * from Adresse_Cuisto;";
                SqlCommand c = new SqlCommand(query, connection);
                SqlDataReader read = c.ExecuteReader();
                string[] valueString = new string[read.FieldCount];

                while (read.Read())


                {

                    int Numero = (int)read["Numero"];
                    string Lieu = (string)read["Lieu"];
                    string Ville = (string)read["Ville"];
                    int Code_Postal = (int)read["Code_Postal"];
                    string Region = (string)read["Region"];

                    //DateTime mylastupdate = (DateTime)read["mydate"];
                    Console.WriteLine($" {Numero} , {Lieu} , {Ville},{Code_Postal},{Region}");
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
        #region Statistiques
        public void Stats()
            {
            Console.WriteLine("Requetes : 0 : Nombre de Livraisons par cuisiniers \n\t 1 : Commandes selon une période de temps \n\t 2 : Moyenne des prix des commandes \n\t 3 :  Moyenne des comptes clients");
                int stat = Convert.ToInt32(Console.ReadLine());
                switch(stat)
                {
                case 0: Console.WriteLine("Selection : Nombre de Livraisons par cuisiniers");
                    Nb_Livraisons();
                    break;
                case 1: Console.WriteLine("Selection : Commandes selon une periode de temps ");
                    Console.WriteLine("Temps : 0 : Annee en cours  \n\t 1 : Mois en cours  \n\t 2 : Jour en cours \n\t 3 : Annee d'inscritption \n\t  4 : Date d'inscription ");
                    int choix = Convert.ToInt32(Console.ReadLine());
                    switch(choix)
                    {
                        case 0: Console.WriteLine("Selection : Annee en cours");
                            break;
                        case 1: Console.WriteLine("Selection : Mois en cours");
                            Commande_Mois();
                            break;
                        case 2: Console.WriteLine("Selection : Jour en cours");
                            break;
                        case 3:
                            Console.WriteLine("Selection : Annee d'inscription");
                            break;
                        case 4:
                            Console.WriteLine("Selection : Date d'inscription");
                            break;
                    }
                    break;
                case 2: Console.WriteLine("Selection : Moyenne des prix des commandes ");
                    Moyenne_Prix_Commande();
                    break;
                case 3:
                    Console.WriteLine("Selection : Moyenne des comptes clients");
                    Moyenne_Comptes_Client();
                    break;

            }
            }
        public  void Nb_Livraisons()
        {
            try
            {


                string query = "select * from Nombre_de_Livraisons ;";
                SqlCommand c = new SqlCommand(query, connection);
                SqlDataReader read = c.ExecuteReader();
                string[] valueString = new string[read.FieldCount];

                while (read.Read())


                {
                    int ID_Cuisto = (int)read["ID_Cuisto"];
                    string Nom = (string)read["Nom"];
                    string Prenom = (string)read["Prenom"];
                    int Nombre = (int)read["Nombre_de_Livraisons"];
                    
                   
                    //DateTime mylastupdate = (DateTime)read["mydate"];
                    Console.WriteLine($"{ID_Cuisto} , {Nombre} , {Nom},{Prenom}");
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
       
        public void Moyenne_Comptes_Client()
        {

            try
            {

                string query = "SELECT * FROM Moyenne_Comptes_Clients";
                SqlCommand c = new SqlCommand(query, connection);

                SqlDataReader read = c.ExecuteReader();
                string[] valueString = new string[read.FieldCount];

                while (read.Read())


                {
                    double Compte = (double)read["Moy_Compte_Client"];


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
        public void Moyenne_Prix_Commande()
        {
            try
            {

                string query = "SELECT * FROM Moyenne_Prix_Commande";
                SqlCommand c = new SqlCommand(query, connection);

                SqlDataReader read = c.ExecuteReader();
                string[] valueString = new string[read.FieldCount];

                while (read.Read())


                {
                    int ID_Com = (int)read["ID_Commandes"];
                    double Moy_Prix = (double)read["Moyenne_Prix_Commande"];


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
        public void Commande_Mois()
        {
            try
            {

                string query = "SELECT * FROM Commande_du_Mois";
                SqlCommand c = new SqlCommand(query, connection);

                SqlDataReader read = c.ExecuteReader();
                string[] valueString = new string[read.FieldCount];

                while (read.Read())


                {
                    int ID_Com = (int)read["ID_Commandes"];
                    DateTime Mois = (DateTime)read["Mois_en_cours"];


                    //DateTime mylastupdate = (DateTime)read["mydate"];
                    Console.WriteLine($"{ID_Com} ,{Mois} ");
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
        public void Commande_An()
        {

        }
        public void Commande_Inscription()
        {

        }
        public void Commande_Annee_Inscription()
        {

        }
        public void Commande_Jour()
        {

        }
        #endregion
        public void Autres()
            {

            }
      
    }
}
