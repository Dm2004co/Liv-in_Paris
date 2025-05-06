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
using Org.BouncyCastle.Asn1.Cms;
using System.Drawing;


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
            Console.WriteLine("Requetes : \n\t 0 : Lecture de la table Client \n\t 1 : Filtrage par ordre alphabétique \n\t 2 : Adresse des clients \n\t 3 : Facture des clients \n\t 4 : Profil du Client \n\t 5 : Comptes Clients \n\t 6 : Clients servis par tranche de temps ");
            int client = Convert.ToInt32(Console.ReadLine());
          
            switch (client)
            {

                case 0:
                    Console.WriteLine("Selection : Lecture de la table Client");
                    Lecture_Client();
                    goto default;

                case 1:
                    Console.WriteLine("Selection : Filtrage par ordre alphabétique");
                    Filtre_Nom_Client();
                    goto default;
                case 2:
                    Console.WriteLine("Selection : Adresse des clients");
                    Adresse_Client();
                    goto default;
                case 3:
                    Console.WriteLine("Selection : Facture des clients");
                    Montant_Client();
                    goto default;
                case 4:
                    Console.WriteLine("Selection : Profil du Client");
                    Console.WriteLine("Identifiant du Client :");
                    int nombre = Convert.ToInt32(Console.ReadLine());
                    Profil_Client(nombre);
                    goto default;
                case 5:
                    Console.WriteLine("Selection : Comptes Clients");
                    Comptes_Clients();
                    goto default;
                case 6:
                    Console.WriteLine("Selection : Clients servis par tranche de temps");
                    Console.WriteLine("Temps :  0 : Annee en cours  \n\t 1 : Mois en cours  \n\t 2 : Jour en cours \n\t 3 : Annee d'inscritption \n\t 4 : Date d'inscription ");
                    int temps = Convert.ToInt32(Console.ReadLine());
                    switch (temps)
                    {
                        case 0:
                            Console.WriteLine("Selection : Annee en cours");
                            Client_An();
                            goto default;
                        case 1:
                            Console.WriteLine("Selection : Mois en cours");
                            Client_Mois();
                            goto default;
                        case 2:
                            Console.WriteLine("Selection : Jour en cours");
                            Client_Jour();
                            goto default;
                        case 3:
                            Console.WriteLine("Selection : Annee d'inscription");
                            Client_Annee_Inscription();
                            goto default;
                        case 4:
                            Console.WriteLine("Selection : Date d'inscription");
                            Client_Inscription();
                            goto default;

                        default:
                            bool quitter31 = false;
                            Console.WriteLine("Quitter : \n\t True \n\t False ");
                            quitter31 = Convert.ToBoolean(Console.ReadLine());
                            if (quitter31)
                            {
                                Console.WriteLine("Retour au menu precedent");
                            }
                            else
                            {
                                Console.WriteLine("Temps :  0 : Annee en cours  \n\t 1 : Mois en cours  \n\t 2 : Jour en cours \n\t 3 : Annee d'inscritption \n\t 4 : Date d'inscription ");
                                int cs = Convert.ToInt32(Console.ReadLine());
                                if (cs == 0)
                                {
                                    goto case 0;
                                }
                                if (cs == 1)
                                {
                                    goto case 1;
                                }
                                if (cs == 2)
                                {
                                    goto case 2;
                                }
                                if (cs == 3)
                                {
                                    goto case 3;
                                }
                                if (cs == 4)
                                {
                                    goto case 4;
                                }

                            }
                            break;
                    }
                    goto default;
                default:
                    bool quitter30 = false;
                    
                    Console.WriteLine("Quitter : \n\t True \n\t False ");
                    
                    quitter30 = Convert.ToBoolean(Console.ReadLine());
                   
                    if (quitter30)
                    {
                        Console.WriteLine("Retour au menu precedent ");
                    }
                    else
                    {
                        Console.WriteLine("Requetes : \n\t 0 : Lecture de la table Client \n\t 1 : Filtrage par ordre alphabétique \n\t 2 : Adresse des clients \n\t 3 : Facture des clients \n\t 4 : Profil du Client \n\t 5 : Comptes Clients \n\t 6 : Clients servis par tranche de temps ");
                        int cs = Convert.ToInt32(Console.ReadLine());
                        if (cs == 0)
                        {
                            goto case 0;
                        }
                        if (cs == 1)
                        {
                            goto case 1;
                        }
                        if (cs == 2)
                        {
                            goto case 2;
                        }
                        if (cs == 3)
                        {
                            goto case 3;
                        }
                        if (cs == 4)
                        {
                            goto case 4;
                        }
                        if (cs == 5)
                        {
                            goto case 5;
                        }
                        if (cs == 6)
                        {
                            goto case 6;
                        }
                    }
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
                    Console.WriteLine("Prenom | Nom");

                    while (read.Read())

                    {

                        string Prenom = (string)read["Prenom"];
                        string Nom = (string)read["Nom"];
                        //DateTime mylastupdate = (DateTime)read["mydate"];

                        Console.WriteLine($" {Prenom} | {Nom} ");
                        string val = "";
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
            void Lecture_Client()
            {
                try
                {


                    string query = "select * from Client c ;";
                    SqlCommand c = new SqlCommand(query, connection);
                    SqlDataReader read = c.ExecuteReader();
                    string[] valueString = new string[read.FieldCount];
                    Console.WriteLine("ID_Client | Prenom | Nom | Telephone | Email");
                    while (read.Read())


                    {
                        int ID_Client = (int)read["ID_Client"];
                        string Prenom = (string)read["Prenom"];
                        string Nom = (string)read["Nom"];
                        string Telephone = (string)read["Telephone"];
                        string Email = (string)read["Email"];
                        //DateTime mylastupdate = (DateTime)read["mydate"];

                        Console.WriteLine($"{ID_Client} | {Prenom} | {Nom} | {Telephone} | {Email} ");
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
                    Console.WriteLine("Numero | Lieu | Ville | Code Postal | Region");
                    while (read.Read())


                    {

                        int Numero = (int)read["Numero"];
                        string Lieu = (string)read["Lieu"];
                        string Ville = (string)read["Ville"];
                        int Code_Postal = (int)read["Code_Postal"];
                        string Region = (string)read["Region"];

                        //DateTime mylastupdate = (DateTime)read["mydate"];

                        Console.WriteLine($" {Numero} | {Lieu} | {Ville} | {Code_Postal} | {Region}");
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


                    string query = "select c.ID_Client,c.Prenom,c.Nom,c.Telephone,c.Email,c.Adresse,(SUM(com.Nb_de_Personnes * com.Prix_Unitaire)) as Montant from Client c\r\njoin Commande com on com.ID_Client = c.ID_Client\r\ngroup by c.ID_Client,c.Prenom,c.Nom,c.Telephone,c.Email,c.Adresse\r\norder by c.ID_Client,c.Prenom,c.Nom,c.Telephone,c.Email,c.Adresse;";
                    SqlCommand c = new SqlCommand(query, connection);

                    SqlDataReader read = c.ExecuteReader();
                    string[] valueString = new string[read.FieldCount];
                    Console.WriteLine("ID_Client | Prenom | Nom | Telephone | Email | Adresse | Montant");
                    while (read.Read())


                    {
                        int ID_Client = (int)read["ID_Client"];
                        string Prenom = (string)read["Prenom"];
                        string Nom = (string)read["Nom"];
                        string tel = (string)read["Telephone"];
                        string email = (string)read["Email"];
                        string adresse = (string)read["Adresse"];
                        decimal Montant = (decimal)read["Montant"];
                        //DateTime mylastupdate = (DateTime)read["mydate"];

                        Console.WriteLine($"{ID_Client}| {Prenom}| {Nom}| {tel} | {email} | {adresse} | {Montant} ");
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


                string query = "select * from Client WHERE ID_Client = @ID_Client ;";
                SqlParameter p = new SqlParameter();
                p.Value = id;
                p.DbType = DbType.Int32;
                p.ParameterName = "@ID_Client";
                SqlCommand c = new SqlCommand(query, connection);
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
                    int ID = (int)read["ID"];
                    decimal Compte = (decimal)read["Compte_Client"];


                    //DateTime mylastupdate = (DateTime)read["mydate"];
                    Console.WriteLine($"{ID} | {Compte} ");
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
        public void Client_Mois()
        {
            try
            {

                string query = "SELECT * FROM Client_M";
                SqlCommand c = new SqlCommand(query, connection);

                SqlDataReader read = c.ExecuteReader();
                string[] valueString = new string[read.FieldCount];
                Console.WriteLine("ID_Client | Mois en cours");
                while (read.Read())


                {
                    int ID_Com = (int)read["ID_Client"];
                    int Mois = (int)read["Mois_en_cours"];


                    //DateTime mylastupdate = (DateTime)read["mydate"];

                    Console.WriteLine($"{ID_Com} | {Mois} ");
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
        public void Client_Jour()
        {
            try
            {

                string query = "SELECT * FROM Client_J";
                SqlCommand c = new SqlCommand(query, connection);

                SqlDataReader read = c.ExecuteReader();
                string[] valueString = new string[read.FieldCount];
                Console.WriteLine("ID_Client | Jour en cours");
                while (read.Read())


                {
                    int ID_C = (int)read["ID_Client"];
                    int Jour = (int)read["Jour_en_cours"];


                    //DateTime mylastupdate = (DateTime)read["mydate"];

                    Console.WriteLine($"{ID_C} | {Jour} ");
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
        public void Client_An()
        {
            try
            {

                string query = "SELECT * FROM Client_Annee";
                SqlCommand c = new SqlCommand(query, connection);

                SqlDataReader read = c.ExecuteReader();
                string[] valueString = new string[read.FieldCount];
                Console.WriteLine("ID_Client | Année en cours");
                while (read.Read())


                {
                    int ID_C = (int)read["ID_Client"];
                    int A = (int)read["Annee_en_cours"];


                    //DateTime mylastupdate = (DateTime)read["mydate"];

                    Console.WriteLine($"{ID_C} | {A} ");
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
        public void Client_Annee_Inscription()
        {
            try
            {

                string query = "SELECT * FROM Client_Annee_Inscription";
                SqlCommand c = new SqlCommand(query, connection);

                SqlDataReader read = c.ExecuteReader();
                string[] valueString = new string[read.FieldCount];
                Console.WriteLine("ID_Client | Année d'inscription");
                while (read.Read())


                {
                    int ID_C = (int)read["ID_Client"];
                    int AI = (int)read["Annee_Inscription"];


                    //DateTime mylastupdate = (DateTime)read["mydate"];

                    Console.WriteLine($"{ID_C} | {AI} ");
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

        public void Client_Inscription()
        {
            try
            {

                string query = "SELECT * FROM Client_Inscription";
                SqlCommand c = new SqlCommand(query, connection);

                SqlDataReader read = c.ExecuteReader();
                string[] valueString = new string[read.FieldCount];
                Console.WriteLine("ID_Client | Date d'inscription");
                while (read.Read())


                {
                    int ID_C = (int)read["ID_Client"];
                    DateTime DI = (DateTime)read["Date_Inscription"];


                    //DateTime mylastupdate = (DateTime)read["mydate"];

                    Console.WriteLine($"{ID_C} | {DI} ");
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

        #region Cuisinier
        public void Cuisinier()
        {
            Console.WriteLine("Requetes : \n\t 0 : Lecture de la table Cuisto \n\t 1 : Profil du Cuisto  \n\t 2 : Plat du Jour \n\t 3 : Adresse des cuisiniers \n\t 4 :  \n\t 5 : ");
            int cui = Convert.ToInt32(Console.ReadLine());
            switch (cui)
            {
                case 0:
                    Console.WriteLine("Selection : Lecture de la table Cuisto");
                    Lecture_Cuisto();
                    goto default;
                case 1:
                    Console.WriteLine("Selection : Profil du Cuisto");
                    Console.WriteLine("Identifiant : ");
                    int id = Convert.ToInt32(Console.ReadLine());
                    Profil_Cuisto(id);
                    goto default;
                case 2:
                    Console.WriteLine("Selection : Plat du Jour");
                    goto default;
                case 3:
                    Console.WriteLine("Selection : Adresse des cuisiniers");
                    Adresse_Cuisto();
                    goto default;
                case 4:
                    Console.WriteLine("Selection : ");
                    goto default;
                default:
                    bool quitter31 = false;
                    Console.WriteLine("Quitter : \n\t True \n\t False ");
                    quitter31 = Convert.ToBoolean(Console.ReadLine());
                    if (quitter31)
                    {
                        Console.WriteLine("Retour au menu precedent ");
                    }
                    else
                    {
                        Console.WriteLine("Requetes : \n\t 0 : Lecture de la table Cuisto \n\t 1 : Profil du Cuisto  \n\t 2 : Plat du Jour \n\t 3 : Adresse des cuisiniers \n\t 4 :  \n\t 5 : ");
                        int cs = Convert.ToInt32(Console.ReadLine());
                        if (cs == 0)
                        {
                            goto case 0;
                        }
                        if (cs == 1)
                        {
                            goto case 1;
                        }
                        if (cs == 2)
                        {
                            goto case 2;
                        }
                        if (cs == 3)
                        {
                            goto case 3;
                        }
                        if (cs == 4)
                        {
                            goto case 4;
                        }
                        
                    }
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
                Console.WriteLine("ID Cuisto | Prenom | Nom | Telephone | Email");
                while (read.Read())


                {
                    int ID_Cuisto = (int)read["ID_Cuisto"];
                    string Prenom = (string)read["Prenom"];
                    string Nom = (string)read["Nom"];
                    string Telephone = (string)read["Telephone"];
                    string Email = (string)read["Email"];
                    //DateTime mylastupdate = (DateTime)read["mydate"];

                    Console.WriteLine($"{ID_Cuisto} | {Prenom} | {Nom} | {Telephone} | {Email} ");
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


                string query = "select * from Cuisto WHERE ID_Cuisto = @ID_Cuisto ;";
                SqlParameter p = new SqlParameter();
                p.Value = id;
                p.DbType = DbType.Int32;
                p.ParameterName = "@ID_Cuisto";
                SqlCommand c = new SqlCommand(query, connection);
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
        public void Adresse_Cuisto()
        {
            try
            {


                string query = "select * from Adresse_Cuisto;";
                SqlCommand c = new SqlCommand(query, connection);
                SqlDataReader read = c.ExecuteReader();
                string[] valueString = new string[read.FieldCount];
                Console.WriteLine(" Numero | Lieu | Ville | Code_Postal | Region");
                while (read.Read())


                {

                    int Numero = (int)read["Numero"];
                    string Lieu = (string)read["Lieu"];
                    string Ville = (string)read["Ville"];
                    int Code_Postal = (int)read["Code_Postal"];
                    string Region = (string)read["Region"];

                    //DateTime mylastupdate = (DateTime)read["mydate"];

                    Console.WriteLine($" {Numero} | {Lieu} | {Ville} | {Code_Postal} | {Region}");
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
            Console.WriteLine("Requetes : \n\t 0 : Nombre de Livraisons par cuisiniers \n\t 1 : Commandes selon une période de temps \n\t 2 : Moyenne des prix des commandes \n\t 3 :  Moyenne des comptes clients \n\t 4 : Filtre par nationalité");
            int stat = Convert.ToInt32(Console.ReadLine());
            switch (stat)
            {
                case 0:
                    Console.WriteLine("Selection : Nombre de Livraisons par cuisiniers");
                    Nb_Livraisons();
                    goto default;
                case 1:
                    Console.WriteLine("Selection : Commandes selon une periode de temps ");
                    Console.WriteLine("Temps :  0 : Annee en cours  \n\t 1 : Mois en cours  \n\t 2 : Jour en cours \n\t 3 : Annee d'inscritption \n\t 4 : Date d'inscription ");
                    int choix = Convert.ToInt32(Console.ReadLine());
                    switch (choix)
                    {
                        case 0:
                            Console.WriteLine("Selection : Annee en cours");
                            Commande_An();
                            goto default;
                        case 1:
                            Console.WriteLine("Selection : Mois en cours");
                            Commande_Mois();
                            goto default;
                        case 2:
                            Console.WriteLine("Selection : Jour en cours");
                            Commande_Jour();
                            goto default;
                        case 3:
                            Console.WriteLine("Selection : Annee d'inscription");
                            Commande_Annee_Inscription();
                            goto default;
                        case 4:
                            Console.WriteLine("Selection : Date d'inscription");
                            Commande_Inscription();
                            goto default;
                        
                        default:
                            bool quitter31 = false;
                            Console.WriteLine("Quitter : \n\t True \n\t False ");
                            quitter31 = Convert.ToBoolean(Console.ReadLine());
                            if (quitter31)
                            {
                                Console.WriteLine("Retour au menu precedent");
                            }
                            else
                            {
                                Console.WriteLine("Temps :  0 : Annee en cours  \n\t 1 : Mois en cours  \n\t 2 : Jour en cours \n\t 3 : Annee d'inscritption \n\t 4 : Date d'inscription ");
                                int cs = Convert.ToInt32(Console.ReadLine());
                                if (cs == 0)
                                {
                                    goto case 0;
                                }
                                if (cs == 1)
                                {
                                    goto case 1;
                                }
                                if (cs == 2)
                                {
                                    goto case 2;
                                }
                                if (cs == 3)
                                {
                                    goto case 3;
                                }
                                if (cs == 4)
                                {
                                    goto case 4;
                                }

                            }
                            break;
                    }
                    goto default;
                case 2:
                    Console.WriteLine("Selection : Moyenne des prix des commandes ");
                    Moyenne_Prix_Commande();
                    goto default;
                case 3:
                    Console.WriteLine("Selection : Moyenne des comptes clients");
                    Moyenne_Comptes_Client();
                    goto default;
                case 4:
                    Console.WriteLine("Selection : Filtre par nationalité");
                    Commande_Nationalite();
                    goto default;
                case 5:
                    Console.WriteLine("Selection : Compte Clients");
                    goto default;
                default:
                    bool quitter30 = false;
                    Console.WriteLine("Quitter : \n\t True \n\t False ");
                    quitter30 = Convert.ToBoolean(Console.ReadLine());
                    if (quitter30)
                    {
                        Console.WriteLine("Retour au menu precedent");
                    }
                    else
                    {
                        Console.WriteLine("Requetes : \n\t 0 : Nombre de Livraisons par cuisiniers \n\t 1 : Commandes selon une période de temps \n\t 2 : Moyenne des prix des commandes \n\t 3 :  Moyenne des comptes clients \n\t 4 : Filtre par nationalité");
                        int cs = Convert.ToInt32(Console.ReadLine());
                        if (cs == 0)
                        {
                            goto case 0;
                        }
                        if (cs == 1)
                        {
                            goto case 1;
                        }
                        if (cs == 2)
                        {
                            goto case 2;
                        }
                        if (cs == 3)
                        {
                            goto case 3;
                        }
                        if (cs == 4)
                        {
                            goto case 4;
                        }
                        if (cs == 5)
                        {
                            goto case 5;
                        }

                    }
                    break;

            }
        }
        public void Nb_Livraisons()
        {
            try
            {


                string query = "select * from Nombre_de_Livraisons ;";
                SqlCommand c = new SqlCommand(query, connection);
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

        public void Moyenne_Comptes_Client()
        {

            try
            {

                string query = "SELECT * FROM Moyenne_Comptes_Clients";
                SqlCommand c = new SqlCommand(query, connection);

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

        public void Moyenne_Prix_Commande()
        {
            try
            {

                string query = "SELECT * FROM Moyenne_Prix_Commande";
                SqlCommand c = new SqlCommand(query, connection);

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
        public void Commande_Mois()
        {
            try
            {

                string query = "SELECT * FROM Commandes_du_Mois";
                SqlCommand c = new SqlCommand(query, connection);

                SqlDataReader read = c.ExecuteReader();
                string[] valueString = new string[read.FieldCount];
                Console.WriteLine("ID_Com | Mois en cours");
                while (read.Read())


                {
                    int ID_Com = (int)read["ID_Commandes"];
                    int Mois = (int)read["Mois_en_cours"];


                    //DateTime mylastupdate = (DateTime)read["mydate"];

                    Console.WriteLine($"{ID_Com} | {Mois} ");
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
            try
            {

                string query = "SELECT * FROM Commandes_Annee";
                SqlCommand c = new SqlCommand(query, connection);

                SqlDataReader read = c.ExecuteReader();
                string[] valueString = new string[read.FieldCount];
                Console.WriteLine("ID_Com | Année en cours");
                while (read.Read())


                {
                    int ID_Com = (int)read["ID_Commandes"];
                      int An = (int)read["Annee_en_cours"];


                    //DateTime mylastupdate = (DateTime)read["mydate"];

                    Console.WriteLine($"{ID_Com} | {An} ");
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
        public void Commande_Inscription()
        {
            try
            {

                string query = "SELECT * FROM Commande_Inscription";
                SqlCommand c = new SqlCommand(query, connection);

                SqlDataReader read = c.ExecuteReader();
                string[] valueString = new string[read.FieldCount];
                Console.WriteLine("ID_Com | Date d'inscription");
                while (read.Read())


                {
                    int ID_Com = (int)read["ID_Commandes"];
                    DateTime d = (DateTime)read["Date_Inscription"];


                    //DateTime mylastupdate = (DateTime)read["mydate"];

                    Console.WriteLine($"{ID_Com} | {d} ");
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
        public void Commande_Annee_Inscription()
        {
            try
            {

                string query = "SELECT * FROM Commandes_Annee_Inscription";
                SqlCommand c = new SqlCommand(query, connection);

                SqlDataReader read = c.ExecuteReader();
                string[] valueString = new string[read.FieldCount];
                Console.WriteLine("ID_Com | Année d'inscription");
                while (read.Read())


                {
                    int ID_Com = (int)read["ID_Commandes"];
                    int An = (int)read["Annee_Inscription"];


                    //DateTime mylastupdate = (DateTime)read["mydate"];

                    Console.WriteLine($"{ID_Com} | {An} ");
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
        public void Commande_Jour()
        {
            try
            {

                string query = "SELECT * FROM Commandes_du_Jour";
                SqlCommand c = new SqlCommand(query, connection);

                SqlDataReader read = c.ExecuteReader();
                string[] valueString = new string[read.FieldCount];
                Console.WriteLine("ID_Com | Jour en cours");
                while (read.Read())


                {
                    int ID_Com = (int)read["ID_Commandes"];
                    int Jour = (int)read["Jour_en_cours"];


                    //DateTime mylastupdate = (DateTime)read["mydate"];

                    Console.WriteLine($"{ID_Com} | {Jour} ");
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
      
        public void Commande_Nationalite()
        {
            try
            {

                string query = "SELECT * FROM Commande_Nationalite WHERE Pays_d_origine IS NOT NULL";
                SqlCommand c = new SqlCommand(query, connection);

                SqlDataReader read = c.ExecuteReader();
                string[] valueString = new string[read.FieldCount];

                Console.WriteLine("ID_Cuisto | ID_Comandes | Nombre de Personnes | Date de depart | Date d'arrivee | Nom du menu | Prix par personne | Regime | Nationalité");
                while (read.Read())


                {
                    int ID = (int)read["ID_Cuisto"];
                    int ID_Commande = (int)read["ID_Commandes"];
                    int nb = (int)read["Nb_de_Personnes"];
                    DateTime depart = (DateTime)read["Date_depart"];
                    DateTime arrivee = (DateTime)read["Date_arrivee"];
                    string menu = (string)read["Nom_Menu"];
                    decimal prix = (decimal)read["Prix_Unitaire"];
                    string regime = (string)read["Regime"];
                    string nationalite = (string)read["Pays_d_origine"];


                    //DateTime mylastupdate = (DateTime)read["mydate"];

                    Console.WriteLine($"{ID} | {ID_Commande} | {nb} | {depart} | {arrivee} | {menu} | {prix} | {regime} | {nationalite}");
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
        public void Autres()
        {
            Console.WriteLine("Requetes : \n\t 0 : Lecture de tables \n\t 1 : Vues du menu de l'application");
            int autres = Convert.ToInt32(Console.ReadLine());
            switch (autres)
            {
                case 0:
                    Console.WriteLine("Selection :  Lecture de tables");
                    Console.WriteLine("Table :  0 : Commandes \n\t 1 : Contenu du Menu \n\t 2 : Catalogue \n\t 3 : Entree \n\t 4 : Plat \n\t 5 : Dessert \n\t 6 : Ingredient \n\t 7 : Volume \n\t 8 : Metro \n\t 9 : Application_Site ");

                    int table = Convert.ToInt32(Console.ReadLine());
                    switch (table)
                    {
                        case 0:
                            Console.WriteLine("Table : Commandes");
                            Lecture_Commande();
                            goto default;
                        case 1:
                            Console.WriteLine("Table : Contenu du Menu");
                            break;
                        case 2:
                            Console.WriteLine("Table : Catalogue");
                            int choix = Convert.ToInt32(Console.ReadLine());
                            switch(choix)
                            {
                                case 0:
                                    break;
                                case 1:
                                    break;
                            }
                           
                            goto default;
                        case 3:
                            Console.WriteLine("Table : Entree");
                            break;
                        case 4:
                            Console.WriteLine("Table : Plat");
                            break;
                        case 5:
                            Console.WriteLine("Table : Dessert");
                            break;
                        case 6:
                            Console.WriteLine("Table : Ingredient");
                            Lecture_Ingredient_1();
                            goto default;
                        case 7:
                            Console.WriteLine("Table : Volume");
                            Lecture_Volume();
                            goto default;
                        case 8:
                            Console.WriteLine("Table : Metro");

                            goto default;

                        case 9:
                            Console.WriteLine("Table : Application_Site");
                            Console.WriteLine("Selection : \n\t 0 : Client \n\t 1 : Cuisto");
                            int personne = Convert.ToInt32(Console.ReadLine());
                            switch (personne)
                            {
                                case 0:
                                    Console.WriteLine("Selection : Client");
                                    Clients_Inscrits();
                                    goto default;
                                case 1:
                                    Console.WriteLine("Selection : Cuisto");
                                    Cuisto_Inscrits();
                                    goto default;
                                default:
                                    bool quitter30 = false;
                                    Console.WriteLine("Quitter : \n\t True \n\t False ");
                                    quitter30 = Convert.ToBoolean(Console.ReadLine());
                                    if (quitter30)
                                    {
                                        Console.WriteLine("Retour au menu precedent");
                                    }
                                    else
                                    {
                                        Console.WriteLine("Selection : \n\t 0 : Client \n\t 1 : Cuisto");
                                        int cs = Convert.ToInt32(Console.ReadLine());
                                        if (cs == 0)
                                        {
                                            goto case 0;
                                        }
                                        if (cs == 1)
                                        {
                                            goto case 1;
                                        }
                                    }
                                    break;
                                    
                                    
                            }
                            goto default;
                        default:
                            bool quitter90 = false;
                            Console.WriteLine("Quitter : \n\t True \n\t False");
                            quitter90 = Convert.ToBoolean(Console.ReadLine());
                            if(quitter90)
                            {
                                Console.WriteLine("Retour au menu precedent");
                            }
                            else
                            {
                                Console.WriteLine("Table :  0 : Commandes \n\t 1 : Contenu du Menu \n\t 2 : Catalogue \n\t 3 : Entree \n\t 4 : Plat \n\t 5 : Dessert \n\t 6 : Ingredient \n\t 7 : Volume \n\t 8 : Metro \n\t 9 : Application_Site ");
                                int select = Convert.ToInt32(Console.ReadLine());
                                if(select  == 0)
                                {
                                    goto case 0;
                                }
                                if(select == 1)
                                {
                                    goto case 1;
                                }
                               if(select == 2)
                                {
                                    goto case 2;
                                }
                               if(select  == 3)
                                {
                                    goto case 3;
                                }
                               if(select == 4)
                                {
                                    goto case 4;
                                }
                               if(select ==5)
                                {
                                    goto case 5;
                                }
                               if(select == 6)
                                {
                                    goto case 6;
                                }
                               if(select == 7)
                                {
                                    goto case 7;
                                }
                               if(select == 8)
                                {
                                    goto case 8;
                                }
                               if(select == 9 )
                                {
                                    goto case 9;
                                }


                            }
                            break;
                    }

                    goto default;
                case 1:
                    Console.WriteLine("Selection : Vues du menu de l'application");
                    int repas = Convert.ToInt32(Console.ReadLine());
                    switch(repas)
                    {
                        case 0:
                            break;
                        case 1:
                            break;
                        case 2:
                            break;
                        case 3:
                            break;
                        default:
                            break;
                    }
                    break;

                default: break;

            }

        }
        public void Clients_Inscrits()
        {
            string query = "SELECT app.ID_Application,app.ID_Client,app.Mdp,app.Date_inscription FROM Application_Site app \r\nWHERE app.ID_Client IS NOT NULL;";
            SqlCommand c = new SqlCommand(query, connection);
            SqlDataReader read = c.ExecuteReader();
            string[] val = new string[read.FieldCount];
            Console.WriteLine("ID_Applicaiton | ID_Client | Mdp | Date d'inscription");

            try
            {
                while (read.Read())


                {
                    int ID = (int)read["ID_Application"];
                    int id_c = (int)read["ID_Client"];
                    string mdp = (string)read["Mdp"];
                    DateTime date_inscrits = (DateTime)read["Date_inscription"];


                    Console.WriteLine($"{ID} | {id_c} | {mdp} | {date_inscrits}");

                    for (int i = 0; i < read.FieldCount; i++)
                    {
                        val[i] = read.GetValue(i).ToString();

                    }


                }

                read.Close();
            }
            catch(SqlException ex)
            {
                Console.WriteLine(" ErreurConnexion : " + ex.ToString());


                return;
            }
           
        }
        public void Cuisto_Inscrits()
        {
            string query = "SELECT app.ID_Application,app.ID_Cuisto,app.Mdp,app.Date_inscription FROM Application_Site app \r\nWHERE app.ID_Cuisto IS NOT NULL;";
            SqlCommand c = new SqlCommand(query, connection);
            SqlDataReader read = c.ExecuteReader();
            string[] val = new string[read.FieldCount];
            Console.WriteLine("ID_Applicaiton | ID_Cuisto | Mdp | Date d'inscription");

            try
            {
                while (read.Read())


                {
                    int ID = (int)read["ID_Application"];
                    int id_c = (int)read["ID_Cuisto"];
                    string mdp = (string)read["Mdp"];
                    DateTime date_inscrits = (DateTime)read["Date_inscription"];


                    Console.WriteLine($"{ID} | {id_c} | {mdp} | {date_inscrits}");

                    for (int i = 0; i < read.FieldCount; i++)
                    {
                        val[i] = read.GetValue(i).ToString();

                    }


                }

                read.Close();
            }
            catch (SqlException ex)
            {
                Console.WriteLine(" ErreurConnexion : " + ex.ToString());


                return;
            }
        }
        public void Lecture_Catalogue()
        {
            try
            {


                string selecton_ing = ";";
                SqlCommand command2 = new SqlCommand(selecton_ing, connection);

                SqlDataReader read = command2.ExecuteReader();
                string[] valueString = new string[read.FieldCount];
                Console.WriteLine("ID | Ingredient | Quantite | Date de fabrication | Date de peremption");

                while (read.Read())


                {
                    int ID = (int)read["ID_Ingredient"];
                    string ingredient = (string)read["Ingredient"];
                    DateTime f = (DateTime)read["Date_2_Fabrication"];
                    DateTime p = (DateTime)read["Date_2_Peremption"];
                    int Q = (int)read["Quantite"];

                    Console.WriteLine($"{ID} | {ingredient} | {Q} | {f} | {p}");
                    string val = "";
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
        }
        public void Lecture_Commande()
        {
            try
            {


                string selecton_ing = "SELECT * FROM Commande;";
                SqlCommand command2 = new SqlCommand(selecton_ing, connection);

                SqlDataReader read = command2.ExecuteReader();
                string[] valueString = new string[read.FieldCount];
                Console.WriteLine("ID_Client | ID_Cuisto | ID_Commandes | Nb_de_Personnes | Prix_Unitaire");

                while (read.Read())


                {
                    int ID_c = (int)read["ID_Client"];
                    int ID_Cui = (int)read["ID_Cuisto"];
                   
                    int ID_Com = (int)read["ID_Commandes"];
                    int nb = (int)read["Nb_de_Personnes"];
                 
                  
                    decimal prix = (decimal)read["Prix_Unitaire"];

                    Console.WriteLine($"{ID_Com} | {ID_c} | {ID_Cui} | {nb} | {prix}");
                    string val = "";
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
        }
        public void Lecture_Ingredient_1()
        {
            try
            {


                string selecton_ing = "SELECT * FROM Ingredient;";
                SqlCommand command2 = new SqlCommand(selecton_ing, connection);
                
                SqlDataReader read = command2.ExecuteReader();
                string[] valueString = new string[read.FieldCount];
                Console.WriteLine("ID | Ingredient | Quantite | Date de fabrication | Date de peremption");

                while (read.Read())


                {
                    int ID = (int)read["ID_Ingredient"];
                    string ingredient = (string)read["Ingredient"];
                    DateTime f = (DateTime)read["Date_2_Fabrication"];
                    DateTime p = (DateTime)read["Date_2_Peremption"];
                    int Q = (int)read["Quantite"];

                    Console.WriteLine($"{ID} | {ingredient} | {Q} | {f} | {p}");
                    string val = "";
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

        }
        public void Lecture_Volume()
        {
            try
            {


                string selecton_ing = "SELECT * FROM Volume;";
                SqlCommand command2 = new SqlCommand(selecton_ing, connection);

                SqlDataReader read = command2.ExecuteReader();
                string[] valueString = new string[read.FieldCount];
                Console.WriteLine("ID_V | Volume | Unite de mesure");

                while (read.Read())


                {

                    int ID_V = (int)read["ID_Volume"];
                    decimal volume = (decimal)read["Volume"];
                    string unite = (string)read["Unite_de_mesure"];
                    //DateTime mylastupdate = (DateTime)read["mydate"];

                    Console.WriteLine($"{ID_V} | {volume} | {unite}");

                    for (int i = 0; i < read.FieldCount; i++)
                    {


                        valueString[i] = read.GetValue(i).ToString();

                    }


                }

                read.Close();

            }
            catch (MySqlException e)
            {
                Console.WriteLine(" ErreurConnexion : " + e.ToString());
                return;
            }

        }
        public void Commande()
        {
            Console.WriteLine("Requetes : \n\t 0 : Prix d'une commande avec son numero \n\t 1 : Calcul des trajets des adresses");
            int com = Convert.ToInt32(Console.ReadLine());
            switch(com)
            {
                case 0 :
                    Prix();
                    goto default;
                case 1:
                    goto default;
                default:
                    bool quitter30 = false;
                    Console.WriteLine("Quitter le menu actuelle : \n\t True \n\t False ");
                    quitter30 = Convert.ToBoolean(Console.ReadLine());
                    if (quitter30)
                    {
                        Console.WriteLine("Retour au menu precedent");
                    }
                    else
                    {
                        Console.WriteLine("Requetes : \n\t 0 : Prix d'une commande avec son numero \n\t 1 : Calcul des trajets des adresses");
                        int cs = Convert.ToInt32(Console.ReadLine());
                        if (cs == 0)
                        {
                            goto case 0;
                        }
                        if (cs == 1)
                        {
                            goto case 1;
                        }
                    }
                    break;

            }

        }
        public void Prix()
        {
            string query = "SELECT * FROM Prix";
            SqlCommand c = new SqlCommand(query, connection);
            SqlDataReader read = c.ExecuteReader();
            string[] val = new string[read.FieldCount];
            Console.WriteLine("ID_Commndes | Prix");
            try
            {
                while (read.Read())
                {
                    int ID = (int)read["ID_Commandes"];
                    decimal prix = (decimal)read["Prix_Commande"];
                    Console.WriteLine($"{ID} | {prix} ");

                    for (int i = 0; i < read.FieldCount; i++)
                    {


                        val[i] = read.GetValue(i).ToString();

                    }


                }
                read.Close();
            }
           
             catch (SqlException e)
            {
                Console.WriteLine(" ErreurConnexion : " + e.ToString());
                return;
            }

        }
        public string Trajet(int id_c , int id_cui , int id_com)
        {
            
                
                Noeud<int> d = new Noeud<int>(id_c);
                Noeud<int> a = new Noeud<int>(id_cui);
                List<int> temp = PCC_FWR(d, a).Item2;
            string trajet = 
            temp.ToString();


            return "";
        }
        #region FWR
        Graphe<int> graphe = new Graphe<int>();
        public void Affichage_FWR(List<int> FWR)
        {
            string orden = "";
            foreach (var s in FWR)
            {
                orden += Convert.ToString(s) + "|";
            }

            Console.WriteLine();
            Console.WriteLine($"L'ordre de visite : {orden}");
        }

        public void Affichage_Ordre_FWR_Noeud(List<Noeud<int>> BFS)
        {
            Console.WriteLine();
            string[] orden = new string[13];
            foreach (Noeud<int> n in BFS)
            {
                string s1 = "";
                string s = "";
                for (int i = 0; i < 13; i++)
                {
                    orden[0] = Convert.ToString($"ID = {n.ID}");
                    orden[1] = Convert.ToString($"Coordonnees = {n.Coordonnees}");
                    orden[2] = Convert.ToString($"Ligne = {n.Numero_2_ligne}");
                    orden[3] = Convert.ToString($"Code Postal : {n.Code_Postal}");
                    orden[4] = Convert.ToString($"Commune : {n.Commune}");
                    foreach (var cor in n.Correspondance)
                    {
                        orden[4] = Convert.ToString($"Correspondance de {n.Station} : {cor}");
                    }
                    orden[5] = Convert.ToString(n.Couleur);
                    orden[6] = Convert.ToString(n.date_Dec);
                    orden[7] = Convert.ToString(n.date_Fin);
                    orden[8] = Convert.ToString($"Niveau = {n.Niveau}");
                    orden[9] = Convert.ToString($"Degre = {n.Degre}");
                    foreach (var p in n.Pred.Values)
                    {
                        foreach (var pred in p)
                        {
                            s += Convert.ToString(pred + "|");

                        }

                    }
                    orden[10] = Convert.ToString($"Predecesseurs de {n.Station} sont : {s}");
                    foreach (var suc in n.Succ.Values)
                    {
                        foreach (var succ in suc)
                        {

                            s1 += Convert.ToString(succ + "|");

                        }
                    }
                    orden[11] = Convert.ToString($"Sucesseurs de {n.Station} sont : {s1}");

                    Console.WriteLine($"Proprietes de {n.Station}  : {orden[i]}");
                }
                Console.WriteLine();
            }


        }
        public double[,] Floyd_Warshall_Roy()
        {

            int n = graphe.Matrice_ADJ.GetLength(0);
            int nb_sommets = graphe.Sommet.Count;
            double[,] Floyd = new double[n, n];

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    for (int k = 0; k < nb_sommets; k++)
                    {

                        if (graphe.Matrice_ADJ[i, j] != 0 && graphe.Matrice_ADJ[i, k] + graphe.Matrice_ADJ[k, j] == 0)
                        {
                            Floyd[i, j] = graphe.Matrice_ADJ[i, j];
                        }


                        if (graphe.Matrice_ADJ[i, k] + graphe.Matrice_ADJ[k, j] != 0 && graphe.Matrice_ADJ[i, j] == 0)
                        {
                            Floyd[i, j] = graphe.Matrice_ADJ[i, k] + graphe.Matrice_ADJ[k, j];
                        }


                        if (graphe.Matrice_ADJ[i, j] != 0 && graphe.Matrice_ADJ[i, k] + graphe.Matrice_ADJ[k, j] != 0)
                        {
                            Floyd[i, j] = Math.Min(graphe.Matrice_ADJ[i, j], graphe.Matrice_ADJ[i, k] + graphe.Matrice_ADJ[k, j]);

                        }



                    }
                }
            }
            return Floyd;
        }


        public void Afficher_FWR(double[,] m)
        {

            for (int i = 0; i < m.GetLength(0); i++)
            {
                int k = 0;
                while (k < m.GetLength(0))
                {
                    Console.Write("===");
                    k++;
                }

                Console.WriteLine();
                for (int j = 0; j < m.GetLength(1); j++)
                {
                    if (m[i, j] != 0)
                    {
                        string s = Convert.ToString($"|{m[i, j]}|");
                        Console.Write(s);
                    }


                }
                Console.WriteLine();

            }
        }
        public SortedList<int,List<int>> Liste_Succ()
        {
            int n = graphe.Sommet.Count;
            double[,] FWR = Floyd_Warshall_Roy();
            SortedList<int, List<int>> Successeur = new SortedList<int, List<int>>(n);
            for (int a = 0; a < n; a++)
            {
                Successeur[graphe.Sommet[a]] = new List<int>();

            }
            for (int i = 0; i < FWR.GetLength(0); i++)
            {
                for (int j = 0; j < FWR.GetLength(1); j++)
                {
                    if (FWR[i, j] != 0)
                    {
                        if (graphe.Sommet[j].Equals(330) || graphe.Sommet[i].Equals(330))
                        {
                            int s = 332;
                            if (s.Equals(graphe.Sommet[i]))
                            {
                                Successeur[graphe.Sommet[j]].Add(s);
                            }

                        }
                        else
                        {
                            Successeur[graphe.Sommet[j]].Add(graphe.Sommet[i]);
                        }

                    }
                }

            }

            return Successeur;
        }


        public (bool, List<int>, List<Noeud<int>>, double) PCC_FWR(Noeud<int> depart, Noeud<int> arrivee)
        {
            Queue<Noeud<int>> BFS = new Queue<Noeud<int>>();
            List<Noeud<int>> Noeud_v = new List<Noeud<int>>();
            List<int> Ordre = new List<int>();
            List<int> Chemin = new List<int>();
            List<Noeud<int>> C = new List<Noeud<int>>();
            SortedList<int, List<int>> L = Liste_Succ();
            Lien<int> l = new Lien<int>();
            bool chemin = false;
            double dist = 0;
            arrivee = graphe.Noeuds.Find(noeud => noeud.ID.Equals(arrivee.ID));
            try
            {
                depart = graphe.Noeuds.Find(noeud => noeud.ID.Equals(depart.ID));
                depart.Couleur = Color.Yellow;
                depart.date_Dec = depart.Decouverte();
                depart.Degre = depart.Calcul_Degre();
                Console.WriteLine($"Debut d'exploration de  : {depart.ID}");
                Noeud_v.Add(depart);
                Console.WriteLine($"Noeud :{depart.ID} , visité");
                Ordre.Add(depart.ID);
                BFS.Enqueue(depart);
                Console.WriteLine("Noeud rajouté dans la pile");

                while (BFS.Count > 0)
                {
                    Noeud<int> y = BFS.Dequeue();
                    y = graphe.Noeuds.Find(noeud => noeud.ID.Equals(y.ID));

                    y.Degre = y.Calcul_Degre();
                    y.Couleur = Color.Red;
                    y.date_Fin = y.Fin();
                    Console.WriteLine($"Fin d'exploration de : {y.ID}");
                    if (L[y.ID].Count > 0)
                    {
                        foreach (var voisinage in L[y.ID])
                        {

                            if (L.TryGetValue(voisinage, out List<int>? value))
                            {
                                if (L[voisinage].Count > 0)
                                {

                                    Noeud<int> voisin = new Noeud<int>(voisinage);
                                    voisin = graphe.Noeuds.Find(noeud => noeud.ID.Equals(voisinage));


                                    int niveau = y.Niveau + 1;
                                    voisin.Niveau = niveau;
                                    voisin.Degre = voisin.Calcul_Degre();


                                    for (int i = 0; i < Noeud_v.Count; i++)
                                    {
                                        voisin.Pred[voisin.ID] = new List<int>();

                                        if (!voisin.ID.Equals(Noeud_v[i].ID) && Occurence(Noeud_v, voisin) < 1)
                                        {
                                            voisin.Couleur = Color.Yellow;
                                            voisin.date_Dec = voisin.Decouverte();

                                            Console.WriteLine($"Debut d'exploration de  : {voisin.ID}");
                                            Noeud_v.Add(voisin);
                                            Console.WriteLine($"Noeud :{voisin.ID} , visité");
                                            Ordre.Add((voisin.ID));
                                            BFS.Enqueue(voisin);
                                            Console.WriteLine($"Noeud : {voisin.ID}, rajouté dans la pile");
                                            voisin.Pred[voisin.ID].Add(y.ID);


                                        }
                                        if (graphe.Egale(arrivee, voisin))
                                        {
                                            chemin = true;
                                            //dist = distance;
                                        }
                                    }

                                }

                            }

                        }
                    }
                }


            }

            catch (ArgumentNullException arg)
            {
                Console.WriteLine($" Null Exception  : {arg.Source} , \n{arg.Message}");
            }
            catch (StackOverflowException s)
            {
                Console.WriteLine($" Stack Overflow : {s.Source} , \n{s.Message}");
            }
            catch (IndexOutOfRangeException i)
            {
                Console.WriteLine($" Index Out of Range : {i.Source} , \n{i.Message}");
            }
            catch (Exception ex)
            {
                string s = " (Le chemin n'existe pas)";
                Console.WriteLine($" {ex.Source} , \n{ex.Message} ,\n {s} ");
            }
            for (int p = 0; p < Ordre.Count; p++)
            {
                if (arrivee.Egale(Ordre[p], arrivee.ID))
                {
                    int index_arrivee = p;

                    Chemin = Ordre.GetRange(0, index_arrivee + 1);
                }
            }
            for (int i = 0; i < Noeud_v.Count; i++)
            {

                if (graphe.Egale(arrivee, Noeud_v[i]))
                {
                    int index_arrivee = i;

                    C = Noeud_v.GetRange(0, index_arrivee + 1);
                }

            }
            if (C.Count != null)
            {
                for (int c1 = 0; c1 < C.Count; c1++)
                {
                    if (c1 + 1 < C.Count && C[c1 + 1] != null)
                    {
                        int a = graphe.Conversion(C[c1].ID);
                        int b = graphe.Conversion(C[c1 + 1].ID);
                        if (a < b)
                        {
                            dist += l.Calcul_Distance(C[c1], C[c1 + 1]);
                        }
                        else
                        {
                            dist -= l.Calcul_Distance(C[c1], C[c1 + 1]);
                        }


                    }
                }
            }

            Console.WriteLine($"Distance entre {depart.Station} et {arrivee.Station} : {dist}");
            return (chemin, Chemin, C, dist);


        }

        public int Occurence(List<Noeud<int>> n, Noeud<int> n1)
        {
            int occ = 0;
            for (int i = 0; i < n.Count; i++)
            {
                if (n1.Egale(n1.ID, n[i].ID))
                {
                    occ++;
                }
            }
            return occ;
        }


        #endregion

    }
}
