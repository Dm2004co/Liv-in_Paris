using Paris_Mapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Data.Common;
using Microsoft.SqlServer.Server;
using Microsoft.Data.SqlClient;
using Org.BouncyCastle.Asn1;
using Org.BouncyCastle.Utilities;
using static Mysqlx.Expect.Open.Types.Condition.Types;
using MySqlX.XDevAPI;
using Mysqlx.Crud;
using K4os.Compression.LZ4.Encoders;
using System.Security;
using Mysqlx.Session;
using Google.Protobuf.WellKnownTypes;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Configuration.Internal;
using System.Security.Authentication;
using System.Text.Json;
using Newtonsoft.Json;
using Org.BouncyCastle.Crypto.Macs;
using static Org.BouncyCastle.Asn1.Cmp.Challenge;
using Org.BouncyCastle.Asn1.X509;
Console.Clear();
Console.Title = "Liv'in Paris";
Console.WriteLine(value: Console.Title.ToUpper() + Environment.NewLine);
Console.WriteLine("Modules :\n\t 0 : Graphes \n\t 1 : BDD");
int Menu = Convert.ToInt32(Console.ReadLine());
#region Connection 
string connexion = "Data Source=(localdb)\\ProjectModels;Initial Catalog=Paris;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";
SqlConnection connection = new SqlConnection(connexion);
connection.Open();
#endregion
switch (Menu)
{
    #region Graphe
    case 0: Console.WriteLine("Module : Graphes");
        Graphe<int> graphe = new Graphe<int>();
        Lien<int> l = new Lien<int>();
        Console.Title = "Projet d'analyse des stations de Metro : Liv'in Paris";
        Console.WriteLine(value: Console.Title.ToUpper() + Environment.NewLine);
        Console.WriteLine("Entrer  :\n 0 : Propriétés \n 1 : Algorithmes de Parcours \n 2 : Modes : (Matrices et Listes)  \n 3 : Coloration du graphe et proprietes du graphe(planaire,biparti) \n 4 : PCC et son implementation \n 5 : Visualisation du graphe ");
        int i = Convert.ToInt32(Console.ReadLine());
        switch (i)
        {
            case 0:
                Console.WriteLine("Entrer  :\n 0 : Connexité du graphe \n 1 : Detection de circuit  \n 2 : Orientation du graphe  \n 3 : Ponderation du graphe \n 4 : Ordre du graphe \n 5 : Taille du graphe");
                int c = Convert.ToInt32(Console.ReadLine());
                switch (c)
                {
                    case 0:
                        Console.WriteLine("Propriete(s) du graphe : ");
                        Console.WriteLine("Connexité du graphe : \n 0 : Connexe \n 1 : Composantes Connexes  ");
                        int d = Convert.ToInt32(Console.ReadLine());
                        switch (d)
                        {
                            case 0:

                                // Console.WriteLine($"\n Le graphe est connexe : {graphe.Connexe()}");

                                break ;
                            case 1:
                                Console.Write("");
                                break;
                            
                        }
                        break;

                    case 1:
                        Console.WriteLine("Circuit : \n 0 : Existence \n 1 : Exemple  ");
                        int p = Convert.ToInt32(Console.ReadLine());
                        switch (p)
                        {
                            case 0:
                                Existence();
                                void Existence()
                                {
                                    Console.WriteLine(" Choissisez un Noeud de départ entre 1 et 319 (compris) : ");
                                    Noeud<int> n = new Noeud<int>();
                                    //Console.WriteLine($"Existence d'au moins un cycle dans le graphe : {(graphe.Existence_Circuit(n).Item1)}");//Obligatoire
                                }


                                break;
                            case 1:
                                Exemple();
                                void Exemple()
                                {
                                    for (int i = 0; i < 33; i++)
                                    {
                                        Noeud<int> n = new Noeud<int>(graphe.Sommet[i]);
                                        /*if ((graphe.Existence_Circuit(n).Item1) == true)
                                        {
                                            graphe.Affichage_Ordre_Circuit((graphe.Existence_Circuit(n)));
                                        }*/

                                    }
                                    Console.WriteLine("Il n'y a pas de circuit dans le graphe");
                                }


                                break;
                        }

                        break;

                    case 2:
                        Console.WriteLine($"Orientation du graphe (O)  : {graphe.Orientation} ");
                       break;
                    case 3:
                        Console.WriteLine($"Pondération du graphe (W) : {graphe.Ponderation}");
                        break;
                    case 4:
                        Console.WriteLine($"Ordre du graphe (V) : {graphe.Sommet.Count}");
                       break;
                    case 5:
                        Console.WriteLine($"Taille du graphe (E) : {graphe.Aretes.Count}");
                      break;
                    default:
                        bool quitter = false ; 
                        if(quitter)
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Entrer  :\n 0 : Connexité du graphe \n 1 : Detection de circuit  \n 2 : Orientation du graphe  \n 3 : Ponderation du graphe \n 4 : Ordre du graphe \n 5 : Taille du graphe");
                            int c1 = Convert.ToInt32(Console.ReadLine());
                            if(c1 == 0)
                            {
                                goto case 0;
                            }
                            if(c1 == 1)
                            {
                                goto case 1;
                            }
                            if(c1 == 2)
                            {
                                goto case 2;
                            }
                            if(c1 == 3)
                            {
                                goto case 3;
                            }
                            if (c1 == 4)
                            {
                                goto case 4;
                            }
                            if(c1 == 5)
                            {
                                goto case 5;
                            }
                            return;
                        }

                }



                //graphe.Simple;
                //graphe.Complet;
                //graphe.Regulier;
                //graphe.Multigraphe;
                break;
            case 1:
                Console.WriteLine("Algorithme de parcours : BFS(0) ou  DFS(1) ");//Obligatoire
                int imput = Convert.ToInt32(Console.ReadLine());
                switch (imput)
                {
                    case 0:
                        Console.WriteLine("Choix de parcours : BFS \n 0 : BFS \n 1 : Chemin ");
                        int bfs = Convert.ToInt32(Console.ReadLine());
                        switch (bfs)
                        {

                            case 0:
                                Console.WriteLine("Selection  :  BFS ");
                                BFS();


                                void BFS()
                                {
                                    Console.WriteLine(" Choissisez un Noeud de départ entre 1 et 319 (compris) : ");
                                    Noeud<int> n = new Noeud<int>();
                                    //graphe.Affichage_Ordre_BFS(graphe.BFS(n).Item1);
                                }


                                break;
                            case 1:
                                Console.WriteLine(" Selection  :  Chemin \n 0 : Existence de Chemin \n 1 : Affichage de Chemin \n 2 : Nombre(s) de Chemins ");
                                int chemin = Convert.ToInt32(Console.ReadLine());
                                switch (chemin)
                                {
                                    case 0:
                                        Console.WriteLine(" Selection  : Existence de Chemins ");
                                        Existence_Chemin();
                                        break;
                                    case 1:
                                        Console.WriteLine(" Selection  : Affichage de Chemin ");
                                        Chemin();
                                        break;
                                    case 2:
                                        Console.WriteLine(" Selection  : Nombre de Chemins ");
                                        Console.WriteLine("Degre de la matrice resultante :");
                                        int degre = Convert.ToInt32(Console.ReadLine());
                                        //graphe.Puissance(graphe.Matrice_ADJ, degre);
                                        //Nb_Chemins();
                                        break;
                                }
                                void Existence_Chemin()
                                {
                                    Console.WriteLine(" Choissisez un Noeud de départ entre 1 et 319 (compris) : ");
                                    Noeud<int> n = new Noeud<int>();
                                    Console.WriteLine(" Choissisez un Noeud de d'arrivée entre 1 et 319 (compris) : ");
                                    Noeud<int> m = new Noeud<int>();
                                    //Console.WriteLine($"Existence d'au moins un chemin dans le graphe : {(graphe.Chemin(n, m).Item1)}");
                                }
                                void Chemin()
                                {
                                    Console.WriteLine(" Choissisez un Noeud< de départ entre 1 et 319 (compris) : ");
                                    Noeud<int> n = new Noeud<int>();
                                    Console.WriteLine(" Choissisez un Noeud d'arrivée entre 1 et 319 (compris) : ");
                                    Noeud<int> m = new Noeud<int>();
                                    //graphe.Affichage_Ordre_BFS(graphe.Chemin(n, m).Item2);
                                    Console.WriteLine();
                                    //graphe.Affichage_Ordre_BFS_Noeud(graphe.Chemin(n, m).Item3);
                                }
                                void Nb_Chemins()
                                {
                                    Console.WriteLine(" Choissisez un Noeud de départ entre 1 et 319 (compris) : ");
                                    Noeud<int> depart = new Noeud<int>();
                                    Console.WriteLine(" Choissisez un Noeud d'arrivée entre 1 et 319 (compris) : ");
                                    Noeud<int> arrivee = new Noeud<int>();
                                    Console.WriteLine("Choisssez la longueur de votre chemin");
                                    int longueur = Convert.ToInt32(Console.ReadLine());
                                    //Console.WriteLine($"Nombre de chemins de {depart.Sommet} à {arrivee.Sommet} est  : {graphe.Nb_2_Chemin(depart, arrivee, longueur)}");
                                }
                                break;
                        }

                        break;
                    case 1:
                        Console.WriteLine("Choix de parcours : DFS ");
                        Console.WriteLine("DFS : \n 0 : Ordre de visite \n 1 : Noeuds visités  ");
                        int dfs = Convert.ToInt32(Console.ReadLine());
                        switch (dfs)
                        {
                            case 0:
                                DFS();
                                void DFS()
                                {
                                    Console.WriteLine(" Choissisez un Noeud  de départ entre 1 et 319 (compris) : ");
                                    Noeud<int> n = new Noeud<int>();
                                    //graphe.Affichage_Ordre_DFS(graphe.DFS(n));

                                }

                                break;

                            case 1:
                                DFS_Noeud();

                                void DFS_Noeud()
                                {
                                    Console.WriteLine(" Choissisez un Noeud de départ entre 1 et 319 (compris) : ");
                                    Noeud<int> n = new Noeud<int>();
                                    //graphe.Affichage_Ordre_DFS_Noeud(graphe.DFS_Noeud(n));
                                }

                                break;

                        }
                        break;
                }

                break;
            case 2:
                Console.WriteLine("Modes : Liste d'adjacence (0)  \n\tMatrice d'adjacence (1)  \n\tMatrice d'incidence (2) \n\tListe des Predecesseurs (3) \n\tListes des Noeuds (4)  \n\tListes des Poids (5)");//Obligatoire
                int choix = Convert.ToInt32(Console.ReadLine());
                switch (choix)
                {

                    case 0:

                        foreach (var key in graphe.Succ.Keys)
                        {
                            foreach (int value in graphe.Succ[key])
                            {

                                Console.WriteLine($"Succeseur(s) de {key} sont : {value} ");
                            }
                            Console.WriteLine();


                        }

                        break;
                    case 1:
                        Console.WriteLine("Matrice d'Adjacence : ");
                        graphe.Afficher_ADJ(graphe.Matrice_ADJ);
                        break;
                    case 2:
                        Console.WriteLine("Matrice d'incidence : ");
                        //graphe.Afficher_Incidence(graphe.Matrice_Incidence);
                        break;
                    case 3:
                        Console.WriteLine("Liste des Predecesseurs ");
                        Affichage();
                        void Affichage()
                        {
                            foreach (var key in graphe.Pred.Keys)
                            {
                                foreach (int value in graphe.Pred[key])
                                {

                                    Console.WriteLine($"Predecesseur(s) de {key} sont : {value} ");
                                }
                                Console.WriteLine();


                            }
                        }


                        break;

                    case 4:
                        Console.WriteLine("Liste des Noeuds(sommet,degre,niveau) : ");
                        break;
                    case 5:
                        Console.WriteLine("Liste des Poids : ");
                        break;



                }
                break;
            case 3:
                Coloration<int> color = new Coloration<int>();
                color.Affichage(color.Welsh_Powell());
                Console.WriteLine("Proprietes : \n\t 0 : Biparti \n\t 1 : Planaire");
                int prop = Convert.ToInt32(Console.ReadLine());
                switch (prop)
                {
                    case 0:
                        Console.WriteLine("Planaire :");
                        if (color.Nombre_Chromatique <= 4)
                        {
                            graphe.Planaire = true;
                            Console.WriteLine(graphe.Planaire);
                        }
                        break;
                    case 1:
                        Console.WriteLine("Biparti :");
                        if (color.Nombre_Chromatique == 2)
                        {
                            graphe.Biparti = true;
                            Console.WriteLine(graphe.Biparti);
                        }
                        break;

                }

                Console.WriteLine($"Nombre chromatique : {color.Nombre_Chromatique}");
                break;
            case 4:
                PCC<int> pcc = new PCC<int>();
                Console.WriteLine("PCC : \tDijkstra (0)  \n\tBellman-Ford (1)  \n\tFloyd-Warshall (2)");
                int selection = Convert.ToInt32(Console.ReadLine());
                string file = "C:\\Users\\Darrell Messi\\source\\repos\\Liv'in_Paris\\Paris_Mapper\\PCC.txt";
                int Insertion_Sommet(string n)
                {
                    int a = Convert.ToInt32(n);

                    try
                    {
                        while (graphe.Sommet.Contains(a) == false || a < 1 || a > graphe.Noeuds.Count)
                        {
                            Console.WriteLine(" Choissisez un noeud de départ entre 1 et 318 (compris) : ");
                            a = Convert.ToInt32(Console.ReadLine());
                        }

                    }
                    catch (FormatException f)
                    {
                        Console.WriteLine($" Format Exception  : {f.Source} , \n{f.Message}");
                    }
                    catch (ArgumentNullException arg)
                    {
                        Console.WriteLine($" Null Exception  : {arg.Source} , \n{arg.Message}");
                    }

                    return a;
                }
                switch (selection)
                {

                    case 0:
                        Console.WriteLine("Choix de PCC : Dijkstra \n\t0 : Noeuds visités à partir d'une source unique (y compris l'ordre de visite) \n\t1 : Recherche du PCC entre deux sommets ");
                        int dijkstra = Convert.ToInt32(Console.ReadLine());

                        switch (dijkstra)
                        {

                            case 0:
                                Console.WriteLine("Selection : Noeuds visités à partir d'une source unique (y compris l'ordre de visite) ");
                                Console.WriteLine("Choissisez une source (Noeud de depart) entre 1 et 318 (compris) : ");
                                int depart = Convert.ToInt32(Console.ReadLine());
                                pcc.Affichage_Ordre_Dijkstra_Noeud(pcc.Djisktra(depart).Item3);
                                break;
                            case 1:
                                Console.WriteLine("Selection : 1 : Recherche du PCC entre deux sommets \n\t 0 : Ordre de visite \n\t 1 : Noeuds visités ");
                                int recherche = Convert.ToInt32(Console.ReadLine());
                                switch (recherche)
                                {
                                    case 0:
                                        Console.WriteLine("Selection : Ordre de visite ");
                                        Recherche();
                                        break;
                                    case 1:
                                        Console.WriteLine("Selection : Noeuds visités ");
                                        Recherche_Noeud();
                                        break;
                                    

                                }
                                void Recherche()
                                {
                                    Console.WriteLine("Choissisez une source (Noeud de depart) entre 1 et 318 (compris) : ");
                                    int depart = Convert.ToInt32(Console.ReadLine());
                                    Console.WriteLine("Arrivee (entre 0 et 317) : ");
                                    int arrivee = Convert.ToInt32(Console.ReadLine());
                                    pcc.Recherche_Chemin(arrivee, depart);
                                }
                                void Recherche_Noeud()
                                {
                                    Console.WriteLine("Choissisez une source (Noeud de depart) entre 1 et 318 (compris) : ");
                                    int depart = Convert.ToInt32(Console.ReadLine());
                                    Console.WriteLine("Arrivee (entre 0 et 317) : ");
                                    int arrivee = Convert.ToInt32(Console.ReadLine());
                                    pcc.Affichage_Ordre_Dijkstra_Noeud(pcc.Recherche_Chemin(arrivee, depart).Item3);
                                }
                                break;
                          

                        }


                        Console.WriteLine();
                        break;

                    case 1:
                        Console.WriteLine("Choix de PCC : Bellman-Ford");
                        //pcc.Bellman_Ford();

                        break;
                    case 2:
                        Console.WriteLine("Choix de PCC : Floyd");
                        Console.WriteLine("Modes : Liste d'adjacence (1)  \n\tMatrice d'adjacence (0) \n\tAlgorithme de Parcours (2)");
                        int floyd = Convert.ToInt32(Console.ReadLine());
                        switch (floyd)
                        {
                            case 0:
                                Console.WriteLine("Selection :  Matrice de Floyd");
                                double[,] FWR = pcc.Floyd_Warshall_Roy();
                                Console.WriteLine("Matrice de FWR : ");
                                pcc.Afficher_FWR(FWR);
                                break;
                            case 1:
                                Console.WriteLine("Selection :  Liste de Succeseurs de Floyd");

                                graphe.Succ = pcc.Liste_Succ();
                                Affichage();
                                void Affichage()
                                {
                                    foreach (var key in graphe.Succ.Keys)
                                    {
                                        foreach (int value in graphe.Succ[key])
                                        {

                                            Console.WriteLine($"Succeseur(s) de {key} sont : {value} ");
                                        }
                                        Console.WriteLine();


                                    }
                                }

                                break;
                            
                            case 2:
                                Console.WriteLine("Selection : PCC (Floyd) \n\t Ordre de visite (0) \n\t Noeuds visités (1)");
                                int fl = Convert.ToInt32(Console.ReadLine());
                                switch (fl)
                                {
                                    case 0:
                                        Console.WriteLine("Selection : Ordre de visite ");
                                        Floyd();
                                        break;
                                    case 1:
                                        Console.WriteLine("Selection : Noeuds visités");
                                        Floyd_Noeud();
                                        break;
                                    
                                }

                                break;
                            
                        }


                        void Floyd()
                        {
                            Console.WriteLine("Depart (entre 0 et 319) : ");
                            int depart = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Arrivee (entre 0 et 319) : ");
                            int arrivee = Convert.ToInt32(Console.ReadLine());
                            Noeud<int> d = new Noeud<int>(depart);
                            Noeud<int> a = new Noeud<int>(arrivee);
                            pcc.Affichage_FWR(pcc.PCC_FWR(d, a).Item2);

                        }
                        void Floyd_Noeud()
                        {
                            Console.WriteLine("Depart (entre 0 et 319) : ");
                            int depart = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Arrivee (entre 0 et 319) : ");
                            int arrivee = Convert.ToInt32(Console.ReadLine());
                            Noeud<int> d = new Noeud<int>(depart);
                            Noeud<int> a = new Noeud<int>(arrivee);
                            pcc.Affichage_Ordre_FWR_Noeud(pcc.PCC_FWR(d, a).Item3);

                        }



                        break;
                  

                }
                break;
            case 5:
                // Dessin dessin = new Dessin();
                break;
           
              
        }
        break;
    #endregion
    #region BDD
    case 1:
        Console.WriteLine("Module : BDD(Base de données) \n\t 0 : Interface Client \n\t 1 : Interface Cuisto \n\t 2 : Interface Administrateur \n\t 3 : Serialisation");
        int user = Convert.ToInt32(Console.ReadLine());
        Functions f = new Functions(connexion, connection);
        switch (user)
        {
            #region Interface Utilisateurs
            case 0:
                connection.Close();
                Console.WriteLine("Interface Client : ");
                Paris_Mapper.Client client = new Paris_Mapper.Client();

                /*Console.WriteLine("Selection : Modification du Client \n\t True \n\t False");
                   bool client_modif = Convert.ToBoolean(Console.ReadLine());
                   if (client_modif)
                   {
                        
                       client.Modification_Client();
                       
                   }
                   Console.WriteLine("Selection : Suppression du Client  \n\t True \n\t False");
                   bool client_suppression = Convert.ToBoolean(Console.ReadLine());
                   if (client_suppression)
                   {
                       client.Suppression_Client();
                   }
                   break;*/

                break;
            case 1:
                connection.Close();
                Console.WriteLine("Interface Cuisto : ");
                Cuisto cui = new Cuisto();/*
                Console.WriteLine("Selection : Modification du Cuisto \n\t True \n\t False");
                bool cuisto_modif = Convert.ToBoolean(Console.ReadLine());
                if (cuisto_modif)
                {
         
                    cui.Modifcation_Cuisto();
                }
                Console.WriteLine("Selection : Suppression du Cuisto \n\t True \n\t False");
                bool cuisto_suppression = Convert.ToBoolean(Console.ReadLine());
                if (cuisto_suppression)
                {
                    cui.Suppression_Cuisto();
                    
                }*/
                break;
              
                #endregion

            #region Interface Administrateur
            case 2:
                Console.WriteLine("Interface Administrateur : ");
                
                Console.WriteLine("Modules : \n\t 0 : Requetes \n\t 1 : Suppression \n\t 2 : Insertion \n\t 3 : Modification ");

                int command = Convert.ToInt32(Console.ReadLine());
                switch (command)
                {
                    #region Requetes
                    case 0:
                        Requetes r = new Requetes(connexion,connection);
                        Console.WriteLine(" Table : 0 : Client \n\t 1 : Cuisinier \n\t 2 : Statistiques \n\t 3 : Autres ");
                        int req = Convert.ToInt32(Console.ReadLine());
                        switch (req)
                        {
                            case 0:
                                Console.WriteLine("Table : Client");
                                r.Client();
                                goto default;
                            case 1:
                                Console.WriteLine("Table : Cuisinier");
                                r.Cuisinier();
                               goto default;
                            case 2:
                                Console.WriteLine("Statistiques");
                                r.Stats();
                                goto default;
                            case 3:
                                Console.WriteLine("Autres");
                                goto default;
                            case 4:
                                goto default;
                            case 5:
                                goto default;
                            case 6:
                                goto default;
                            default: bool quitter14 = false;
                                if(quitter14)
                                {
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine(" Table : 0 : Client \n\t 1 : Cuisinier \n\t 2 : Statistiques \n\t 3 : Autres ");
                                    int c1 = Convert.ToInt32(Console.ReadLine());
                                    if (c1 == 0)
                                    {
                                        goto case 0;
                                    }
                                    if (c1 == 1)
                                    {
                                        goto case 1;
                                    }
                                    if (c1 == 2)
                                    {
                                        goto case 2;
                                    }
                                    if (c1 == 3)
                                    {
                                        goto case 3;
                                    }
                                    if (c1 == 4)
                                    {
                                        goto case 4;
                                    }
                                    if (c1 == 5)
                                    {
                                        goto case 5;
                                    }
                                    break;

                                }


                        }
                        break;
                        #endregion
                       
                    #region Suppression
                    case 1:
                        Suppression s = new Suppression(connexion,connection);
                        Console.WriteLine("Table :  0 : Client \n\t 1 : Cuisinier \n\t 2 : Adresse \n\t 3 : Commandes \n\t 4 : Plat \n\t 5 : Dessert \n\t 6 : Entree \n\t 7 : Contenu du Menu \n\t 8 : Application_Site \n\t 9 : Volume \n\t 10 : Ingredient");
                        int sup = Convert.ToInt32(Console.ReadLine());
                        switch (sup)
                        {
                            #region Personne
                            case 0:
                                Console.WriteLine("Table : Client");
                                Console.WriteLine("Identifiant : ");
                                int id = Convert.ToInt32(Console.ReadLine());
                                s.Client(id);
                                break;
                            case 1:
                                Console.WriteLine("Table : Cuisinier");
                                Console.WriteLine("Identifiant : ");
                                int id_1 = Convert.ToInt32(Console.ReadLine());
                                s.Cuisinier(id_1);
                                break;
                            #endregion
                            case 2:
                                Console.WriteLine("Table : Adresse");
                                Console.WriteLine("Identifiant : ");
                                int adresse = Convert.ToInt32(Console.ReadLine());
                                s.Adresse(adresse);
                                goto default ;
                            case 3:
                                Console.WriteLine("Table : Commandes");
                                int id_commande = Convert.ToInt32(Console.ReadLine());
                                s.Commande(id_commande);
                                goto default;
                            #region Repas
                            case 4:
                                Console.WriteLine("Table : Plat");
                                Console.WriteLine("Identifiant : ");
                                int p = Convert.ToInt32(Console.ReadLine());
                                s.Plat(p);
                                break;
                            case 5:
                                Console.WriteLine("Table : Dessert");
                                Console.WriteLine("Identifiant : ");
                                int de = Convert.ToInt32(Console.ReadLine());
                                s.Dessert(de);
                                break;
                            case 6:
                                Console.WriteLine("Table : Entree");
                                Console.WriteLine("Identifiant : ");
                                int e = Convert.ToInt32(Console.ReadLine());
                                s.Entree(e);
                                break;
                            #endregion
                            case 7:
                                Console.WriteLine("Table : Contenu du Menu");
                                Console.WriteLine("Identifiant : ");
                                int menu = Convert.ToInt32(Console.ReadLine());
                                s.Menu(menu);
                                goto default;
                            case 8:
                                Console.WriteLine("Table : Application_Site");
                                Console.WriteLine("Identifiant : ");
                                int id_app = Convert.ToInt32(Console.ReadLine());
                                s.Application(id_app);
                                goto default;
                            case 9:
                                Console.WriteLine("Table : Volume");
                                Console.WriteLine("Identifiant : ");
                                int id_volume = Convert.ToInt32(Console.ReadLine());
                                s.Volume(id_volume);
                                goto default;
                            case 10:
                                Console.WriteLine("Table : Ingredient");
                                Console.WriteLine("Identifiant : ");
                                int id_ingredient = Convert.ToInt32(Console.ReadLine());
                                s.Ingredient(id_ingredient);
                                goto default;
                            case 11:
                                break;
                            default:
                                bool quitter3 = false;
                                if(quitter3)
                                {
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine("Table :  0 : Client \n\t 1 : Cuisinier \n\t 2 : Adresse \n\t 3 : Commandes \n\t 4 : Plat \n\t 5 : Dessert \n\t 6 : Entree \n\t 7 : Contenu du Menu \n\t 8 : Application_Site \n\t 9 : Volume \n\t 10 : Ingredient");

                                    int c1 = Convert.ToInt32(Console.ReadLine());
                                    if (c1 == 0)
                                    {
                                        goto case 0;
                                    }
                                    if (c1 == 1)
                                    {
                                        goto case 1;
                                    }
                                    if (c1 == 2)
                                    {
                                        goto case 2;
                                    }
                                    if (c1 == 3)
                                    {
                                        goto case 3;
                                    }
                                    if (c1 == 4)
                                    {
                                        goto case 4;
                                    }
                                    if (c1 == 5)
                                    {
                                        goto case 5;
                                    }
                                    if (c1 == 6)
                                    {
                                        goto case 6;
                                    }
                                    if (c1 == 7)
                                    {

                                    }
                                    if (c1 == 8)
                                    {
                                        goto case 8;
                                    }
                                    if (c1 == 9)
                                    {
                                        goto case 9;
                                    }
                                    if (c1 == 10)
                                    {
                                        goto case 10;
                                    }
                                }
                                    
                                break ;
                        }
                        #endregion
                        break;
                    #region Modification
                    case 3:
                        Modification m = new Modification(connexion,connection);
                        Console.WriteLine("Table :  0 : Client \n\t 1 : Cuisinier \n\t 2 : Adresse \n\t 3 : Commandes \n\t 4 : Plat \n\t 5 : Dessert \n\t 6 : Entree \n\t 7 : Contenu du Menu \n\t 8 : Application_Site ");
                        int modif = Convert.ToInt32(Console.ReadLine());
                        switch (modif)
                        {
                            case 0:
                                Console.WriteLine("Table : Client");
                                Console.WriteLine("Modificaton de tuples(id,prenom,nom,telephone,email) au choix");
                                Console.WriteLine("Identifiant : ");
                                int id_1 = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine("Prenom : ");
                                string prenom_1 = Console.ReadLine();
                                Console.WriteLine("Nom : ");
                                string nom_1 = Console.ReadLine();
                                Console.WriteLine("Telephone: ");
                                string n = Console.ReadLine();
                                Console.WriteLine("Email :");
                                string e_mail = Console.ReadLine();
                                if (prenom_1 != string.Empty && nom_1 != string.Empty && n != string.Empty && e_mail != string.Empty)
                                {
                                    // m.Client(id_1, prenom_1, nom_1, e_mail, n);
                                }
                                if (prenom_1 != string.Empty && nom_1 != string.Empty)
                                {
                                    m.Client(id_1, prenom_1, nom_1);
                                }
                                if (prenom_1 != string.Empty && n != string.Empty)
                                {
                                    //m.Client(id_1, prenom_1, n);
                                }
                                if (prenom_1 != string.Empty && e_mail != string.Empty)
                                {
                                    m.Client(id_1, prenom_1, e_mail);
                                }
                                if (nom_1 != string.Empty && n != string.Empty)
                                {
                                    //m.Client(id_1, null,null,nom_1, n);
                                }
                                if (nom_1 != string.Empty && e_mail != string.Empty)
                                {
                                    m.Client(id_1, nom_1, e_mail);
                                }
                                if (n != string.Empty && e_mail != string.Empty)
                                {
                                    //m.Client(id_1, null,e_mail,null, n);
                                }
                                if (prenom_1 != string.Empty)
                                {
                                    m.Client(id_1, prenom_1);
                                }
                                if (nom_1 != string.Empty)
                                {
                                    m.Client(id_1, nom_1);
                                }
                                if (n != string.Empty)
                                {
                                    //m.Client(id_1,null,null,null, n);
                                }
                                if (e_mail != string.Empty)
                                {
                                    m.Client(id_1, e_mail);
                                }
                                bool maj_adresse_client = false;
                                maj_adresse_client = Convert.ToBoolean(Console.ReadLine());
                                if(maj_adresse_client == true)
                                {
                                    m.Client_1();
                                }
                                goto default;

                            case 1:
                                Console.WriteLine("Table : Cuisinier");
                                Console.WriteLine("Modificaton de tuples(id,prenom,nom,telephone,email) au choix");
                                Console.WriteLine("Identifiant : ");
                                int id_2 = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine("Prenom : ");
                                string prenom_2 = Console.ReadLine();
                                Console.WriteLine("Nom : ");
                                string nom_2 = Console.ReadLine();
                                Console.WriteLine("Telephone: ");
                                string n1 = Console.ReadLine();
                                Console.WriteLine("Email :");
                                string e_mail_1 = Console.ReadLine();
                                if (prenom_2 != string.Empty && nom_2 != string.Empty && n1 != string.Empty && e_mail_1 != string.Empty)
                                {
                                    // m.Cuisto(id_2, prenom_2, nom_2, e_mail_1, n1);
                                }
                                if (prenom_2 != string.Empty && nom_2 != string.Empty)
                                {
                                    m.Cuisto(id_2, prenom_2, nom_2);
                                }
                                if (prenom_2 != string.Empty && n1 != string.Empty)
                                {
                                    //m.Cuisto(id_2, prenom_2, n1);
                                }
                                if (prenom_2 != string.Empty && e_mail_1 != string.Empty)
                                {
                                    m.Cuisto(id_2, prenom_2, e_mail_1);
                                }
                                if (nom_2 != string.Empty && n1 != string.Empty)
                                {
                                    //m.Cuisto(id_2, null,null,nom_2, n1);
                                }
                                if (nom_2 != string.Empty && e_mail_1 != string.Empty)
                                {
                                    m.Cuisto(id_2, nom_2, e_mail_1);
                                }
                                if (n1 != string.Empty && e_mail_1 != string.Empty)
                                {
                                    //m.Cuisto(id_2, null,e_mail_1,null, n1);
                                }
                                if (prenom_2 != string.Empty)
                                {
                                    m.Cuisto(id_2, prenom_2);
                                }
                                if (nom_2 != string.Empty)
                                {
                                    m.Cuisto(id_2, nom_2);
                                }
                                if (n1 != string.Empty)
                                {
                                    //m.Cuisto(id_2,null,null,null, n1);
                                }
                                if (e_mail_1 != string.Empty)
                                {
                                    m.Cuisto(id_2, e_mail_1);
                                }
                                bool maj_adresse_cuisto = false;
                                maj_adresse_cuisto = Convert.ToBoolean(Console.ReadLine());
                                if (maj_adresse_cuisto == true)
                                {
                                    m.Cuisto_1();
                                }
                                goto default;
                            case 2:
                                Console.WriteLine("Table : Adresse");
                                Console.WriteLine("Identifiant : ");
                                int id_a = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine("ID_Client : ");
                                int id_c = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine("ID_Cuisto : ");
                                int id_cui = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine("Ville: ");
                                string ville = Console.ReadLine();
                                Console.WriteLine("Region :");
                                string region = Console.ReadLine();
                                string commune = Console.ReadLine();
                                string lieu = Console.ReadLine();
                                int num = Convert.ToInt32(Console.ReadLine());
                                int code = Convert.ToInt32(Console.ReadLine());
                                int id_m = Convert.ToInt32(Console.ReadLine());
                               goto default;
                            case 3:
                                Console.WriteLine("Table : Commandes");
                               goto default;
                            case 4:
                                Console.WriteLine("Table : Plat");
                                goto default;
                            case 5:
                                Console.WriteLine("Table : Dessert");
                                goto default;
                            case 6:
                                Console.WriteLine("Table : Entree");
                                goto default;
                            case 7:
                                Console.WriteLine("Table : Contenu du Menu");
                                goto default;
                            case 8:
                                Console.WriteLine("Table : Application_Site");
                                goto default;
                            case 9:
                                break;
                            case 10:
                                break;
                            case 11:
                                break;
                            default:
                                bool quitter2 = false;
                                Console.WriteLine("Table :  0 : Client \n\t 1 : Cuisinier \n\t 2 : Adresse \n\t 3 : Commandes \n\t 4 : Plat \n\t 5 : Dessert \n\t 6 : Entree \n\t 7 : Contenu du Menu \n\t 8 : Application_Site ");
                                int c1 = Convert.ToInt32(Console.ReadLine());
                                if (c1 == 0)
                                {
                                    goto case 0;
                                }
                                if (c1 == 1)
                                {
                                    goto case 1;
                                }
                                if (c1 == 2)
                                {
                                    goto case 2;
                                }
                                if (c1 == 3)
                                {
                                    goto case 3;
                                }
                                if (c1 == 4)
                                {
                                    goto case 4;
                                }
                                if (c1 == 5)
                                {
                                    goto case 5;
                                }
                                if (c1 == 6)
                                {
                                    goto case 6;
                                }
                                if (c1 == 7)
                                {

                                }
                                if (c1 == 8)
                                {
                                    goto case 8;
                                }
                                if (c1 == 9)
                                {
                                    goto case 9;
                                }
                                if (c1 == 10)
                                {
                                    goto case 10;
                                }
                                return;
                        }
                        #endregion
                        break;
                    #region Insertion
                    case 2:
                        Insertion insert = new Insertion(connexion,connection);
                        
                        Console.WriteLine("Table :  0 : Client \n\t 1 : Cuisinier \n\t 2 : Adresse \n\t 3 : Commandes  ");
                        int table = Convert.ToInt32(Console.ReadLine());
                        switch (table)
                        {
                            case 0:
                                Console.WriteLine("Table : Client \n\t 0 : Tuples(id,prenom,nom) \n\t 1 : Tuples(id,prenom,nom,telephone,email) ");
                                int clients = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine("Nombre de Clients :");
                                int nb_clients = Convert.ToInt32(Console.ReadLine());
                                bool rollback_client = false;
                                switch (clients)
                                {
                                    case 0:
                                        try
                                        {
                                          
                                            if(nb_clients > 0)
                                            {
                                                for (int y = 0; y < nb_clients; y++)
                                                {
                                                    Console.WriteLine();
                                                    SqlTransaction insertion_client = connection.BeginTransaction();
                                                    insertion_client.Save("Debut insertion client");
                                                    Console.WriteLine("Insertion de tuples sans un numero de telephone et d'adresse email");
                                                    Console.WriteLine("Identifiant : ");
                                                    int d = Convert.ToInt32(Console.ReadLine());
                                                    insertion_client.Save("SVG id_client");
                                                    Console.WriteLine("Prenom : ");
                                                    string prenom = Console.ReadLine();
                                                    insertion_client.Save("SVG prenom_client");
                                                    Console.WriteLine("Nom : ");
                                                    string nom = Console.ReadLine();
                                                    insertion_client.Save("SVG nom_client");
                                                    insert.Client_1(d, prenom, nom, insertion_client);

                                                }
                                            }
                                            

                                           
                                        }
                                        catch (SqlException ex)
                                        {
                                            Console.WriteLine(" ErreurConnexion : " + ex.ToString());
                                            return;
                                        }
                                        break;
                                    case 1:
                                         try
                                        {
                                            if(nb_clients > 0)
                                            {
                                                for(int cl2 =  0;  cl2 < nb_clients; cl2++)
                                                {
                                                    SqlTransaction insertion_client_1 = connection.BeginTransaction();
                                                    insertion_client_1.Save("Debut d'insertion du client");
                                                    Console.WriteLine("Insertion de tous les tuples(id,prenom,nom,telephone,email)");
                                                    Console.WriteLine("Identifiant : ");
                                                    int id_1 = Convert.ToInt32(Console.ReadLine());
                                                    insertion_client_1.Save("SVG id_client");
                                                    Console.WriteLine("Prenom : ");
                                                    string prenom_1 = Console.ReadLine();
                                                    insertion_client_1.Save("SVG prenom_client ");
                                                    Console.WriteLine("Nom : ");
                                                    string nom_1 = Console.ReadLine();
                                                    insertion_client_1.Save("SVG nom_client");
                                                    Console.WriteLine("Telephone: ");
                                                    string tel = Console.ReadLine();
                                                    insertion_client_1.Save("SVG tel_client ");
                                                    Console.WriteLine("Email :");
                                                    string email = Console.ReadLine();
                                                    insertion_client_1.Save("SVG email_client");
                                                    insert.Client(id_1, prenom_1, nom_1, tel, email, insertion_client_1);

                                                }
                                            }
                                            
                                            
                                        }
                                         catch(SqlException ex)
            {
                                            Console.WriteLine(" ErreurConnexion : " + ex.ToString());
                                            return;
                                        }
                                        break;
                                }
                                break;
                            case 1:
                                Console.WriteLine("Table : Cuisinier \n\t 0 : Tuples(id,prenom,nom) \n\t 1 : Tuples(id,prenom,nom,telephone,email) ");
                                int cuist = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine("Nombre de Cuistos :");
                                int nb_cuistos = Convert.ToInt32(Console.ReadLine());
                                bool rollback_cuisto = false;
                                switch (cuist)
                                {
                                    case 0:
                                      try
                                        {
                                            if(nb_cuistos > 0)
                                            {
                                                for(int cui1 = 0;  cui1 < nb_cuistos; cui1++)
                                                {
                                                    SqlTransaction insertion_cuisto = connection.BeginTransaction();
                                                    insertion_cuisto.Save("Debut d'insertion du cuisinier");
                                                    Console.WriteLine("Insertion de tuples sans un numero de telephone et d'adresse email");
                                                    Console.WriteLine("Identifiant : ");
                                                    int id = Convert.ToInt32(Console.ReadLine());
                                                    insertion_cuisto.Save("SVG id_cuisinier");
                                                    Console.WriteLine("Prenom : ");
                                                    string prenom = Console.ReadLine();
                                                    insertion_cuisto.Save("SVG prenom_cuisinier");
                                                    Console.WriteLine("Nom : ");
                                                    string nom = Console.ReadLine();
                                                    insert.Cuisinier_1(id, prenom, nom, insertion_cuisto);
                                                }
                                            }
                                            
                                           
                                        }
                                        catch (SqlException ex)
                                        {
                                            Console.WriteLine(" ErreurConnexion : " + ex.ToString());
                                            return;
                                        }
                                        break;
                                    case 1:
                                        try
                                        {
                                            if(nb_cuistos > 0)
                                            {
                                                for(int cui2 = 0;  cui2 < nb_cuistos; cui2++)
                                                {
                                                    SqlTransaction insertion_cuisto_1 = connection.BeginTransaction();
                                                    insertion_cuisto_1.Save("Debut");
                                                    Console.WriteLine("Insertion de tous les tuples(id,prenom,nom,telephone,email)");
                                                    Console.WriteLine("Identifiant : ");
                                                    int id_1 = Convert.ToInt32(Console.ReadLine());
                                                    insertion_cuisto_1.Save("SVG id_cuisineir");
                                                    Console.WriteLine("Prenom : ");
                                                    string prenom_1 = Console.ReadLine();
                                                    insertion_cuisto_1.Save("SVG prenom_cuisinier");
                                                    Console.WriteLine("Nom : ");
                                                    string nom_1 = Console.ReadLine();
                                                    insertion_cuisto_1.Save("SVG nom_cuisinier");
                                                    Console.WriteLine("Telephone: ");
                                                    string tel = Console.ReadLine();
                                                    insertion_cuisto_1.Save("SVG numero_cuisiner");
                                                    Console.WriteLine("Email :");
                                                    string email = Console.ReadLine();
                                                    insertion_cuisto_1.Save("SVG email_cuisinier");
                                                    insert.Cuisinier(id_1, prenom_1, nom_1, tel, email, insertion_cuisto_1);
                                                }
                                            }
                                           
                                        
                                        }
                                        catch (SqlException ex)
                                        {
                                            Console.WriteLine(" ErreurConnexion : " + ex.ToString());
                                            return;
                                        }
                                        break;
                                }
                                goto default;
                            case 2:
                                Console.WriteLine("Table : Adresse \n\t 0 : Tuples(id,ville,numero,lieu dit,id_metro) \n\t 1 : Tuples(id,ville,numero,lieu dit,id_metro,region,code postal,dept,commune)");
                                int adresse = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine("Nombre d'Adresse(s) de Client");
                                int a = Convert.ToInt32(Console.ReadLine());
                                int nb_adresse_client = a;
                                Console.WriteLine("Nombre d'Adresse(s) de Cuisto");
                                int b = Convert.ToInt32(Console.ReadLine());
                                int nb_adresse_cuisto = b;
                                bool rollback_adresse = false;
                                switch (adresse)
                                {
                                    case 0:
                                        bool
                                        client_1 = false;
                                        bool cuisto_1 = false;
                                        
                                            Console.WriteLine("Selection : Client \n\t True \n\t False");
                                            if(nb_adresse_client > 0)
                                            {
                                                client_1 = true;
                                                
                                            }
                                            Console.WriteLine(client_1);
                                            Console.WriteLine("Selection : Cuisto \n\t True \n\t False");
                                            if (nb_adresse_cuisto > 0)
                                            {
                                                cuisto_1 = true;
                                                
                                            }
                                            Console.WriteLine(cuisto_1);

                                        if (client_1 == true)
                                        {
                                           try
                                            {
                                                if(nb_adresse_client > 0)
                                                {
                                                    for (int cl = 0; cl < nb_adresse_client; cl++)
                                                    {
                                                        Console.WriteLine();
                                                        SqlTransaction insertion_adresse = connection.BeginTransaction();
                                                        insertion_adresse.Save("Debut insertion adresse_client");
                                                        Console.WriteLine("Insertion de tuples(id,ville,numero,lieu dit,id_metro)");
                                                        Console.WriteLine("Identifiant : ");
                                                        int id_ad = Convert.ToInt32(Console.ReadLine());
                                                        Console.WriteLine("Identifiant Client  : ");
                                                        int u1 = Convert.ToInt32(Console.ReadLine());
                                                        insertion_adresse.Save("SVG id_client");
                                                        Console.WriteLine("Ville : ");
                                                        string ville_2 = Console.ReadLine();
                                                        insertion_adresse.Save("SVG ville_client");
                                                        Console.WriteLine("Lieu dit : ");
                                                        string lieu_2 = Console.ReadLine();
                                                        insertion_adresse.Save("SVG lieu_client");
                                                        Console.WriteLine("Numero : ");
                                                        int numero_1 = Convert.ToInt32(Console.ReadLine());
                                                        insertion_adresse.Save("SVG numero_client");
                                                        Console.WriteLine("ID_Metro : ");
                                                        int metro_2 = Convert.ToInt32(Console.ReadLine());
                                                        insertion_adresse.Save("SVG id_métro ");
                                                        Console.WriteLine("Code Postal : ");
                                                        int code_p_c = Convert.ToInt32(Console.ReadLine());
                                                        insertion_adresse.Save("SVG code_postal");
                                                        insert.Adresse_Client(id_ad, u1, ville_2, numero_1, lieu_2, code_p_c, metro_2, insertion_adresse);

                                                    }
                                                }
                                                
                                                
                                            }
                                            catch (SqlException ex)
                                            {
                                                Console.WriteLine(" ErreurConnexion : " + ex.ToString());
                                                return;
                                            }
                                        }
                                        if (cuisto_1 == true)
                                        {
                                            try
                                            {
                                                if(nb_adresse_cuisto > 0)
                                                {
                                                    for(int cuistos = 0; cuistos < nb_adresse_cuisto;cuistos++)
                                                    {
                                                        Console.WriteLine();
                                                        SqlTransaction insertion_adresse_1 = connection.BeginTransaction();
                                                        insertion_adresse_1.Save("Debut");
                                                        Console.WriteLine("Insertion de tuples(id,ville,numero,lieu dit,id_metro)");
                                                        Console.WriteLine("Identifiant : ");
                                                        int id_a = Convert.ToInt32(Console.ReadLine());
                                                        Console.WriteLine("Identifiant Cuisto: ");
                                                        int id_cui = Convert.ToInt32(Console.ReadLine());
                                                        insertion_adresse_1.Save("SVG id_cuisinier");
                                                        Console.WriteLine("Ville : ");
                                                        string ville = Console.ReadLine();
                                                        insertion_adresse_1.Save("SVG ville_cuisinier");
                                                        Console.WriteLine("Lieu dit : ");
                                                        string lieu = Console.ReadLine();
                                                        insertion_adresse_1.Save("SVG lieu_cuisinier");
                                                        Console.WriteLine("Numero : ");
                                                        int numero = Convert.ToInt32(Console.ReadLine());
                                                        insertion_adresse_1.Save("SVG numero");
                                                        Console.WriteLine("ID_Metro : ");
                                                        int metro = Convert.ToInt32(Console.ReadLine());
                                                        insertion_adresse_1.Save("SVG id_métro");
                                                        Console.WriteLine("Code Postal : ");
                                                        int code_cuisto = Convert.ToInt32(Console.ReadLine());
                                                        insertion_adresse_1.Save("SVG code ");
                                                        insert.Adresse_Cuisto(id_a, id_cui, ville, numero, lieu, code_cuisto, metro, insertion_adresse_1);

                                                    }
                                                }
                                                
                                            }
                                            catch (SqlException ex)
                                            {
                                                Console.WriteLine(" ErreurConnexion : " + ex.ToString());
                                                return;
                                            }
                                        }

                                        break;
                                    case 1:
                                        bool client_2 = false;
                                        bool cuisto_2 = false;

                                        Console.WriteLine("Selection : Client \n\t True \n\t False");
                                        if (nb_adresse_client > 0)
                                        {
                                            client_2 = true;

                                        }
                                        Console.WriteLine(client_2);
                                        Console.WriteLine("Selection : Cuisto \n\t True \n\t False");
                                        if (nb_adresse_cuisto > 0)
                                        {
                                            cuisto_2 = true;

                                        }
                                        Console.WriteLine(cuisto_2);

                                        if (!client_2)
                                        {
                                           try
                                            {
                                                if(nb_adresse_client > 0)
                                                {
                                                    for (int cl1 = 0; cl1 < nb_adresse_client; cl1++)
                                                    {
                                                        Console.WriteLine();
                                                        SqlTransaction insertion_c = connection.BeginTransaction();
                                                        insertion_c.Save("Debut insertion adresse_client");
                                                        Console.WriteLine("Identifiant :");
                                                        int id_adresse = Convert.ToInt32(Console.ReadLine());
                                                        Console.WriteLine("Identifiant Client :");
                                                        int id_c = Convert.ToInt32(Console.ReadLine());
                                                        insertion_c.Save("SVG id_client");
                                                        Console.WriteLine("Ville :");
                                                        string ville_1 = Console.ReadLine();
                                                        insertion_c.Save("SVG ville_client");
                                                        Console.WriteLine("Lieu dit : ");
                                                        string lieu_1 = Console.ReadLine();
                                                        insertion_c.Save("SVG lieu dit_client");
                                                        Console.WriteLine("Numéro  : ");
                                                        int num = Convert.ToInt32(Console.ReadLine());
                                                        insertion_c.Save("SVG numero");
                                                        Console.WriteLine("ID_Metro  : ");
                                                        int metro_1 = Convert.ToInt32(Console.ReadLine());
                                                        insertion_c.Save("SVG id_métro");
                                                        Console.WriteLine("Code Postal : ");
                                                        int code = Convert.ToInt32(Console.ReadLine());
                                                        insertion_c.Save("SVG code postal");
                                                        Console.WriteLine("Departement : ");
                                                        int dept = Convert.ToInt32(Console.ReadLine());
                                                        insertion_c.Save("SVG departement ");
                                                        Console.WriteLine("Commune : ");
                                                        string commune = Console.ReadLine();
                                                        insertion_c.Save("SVG commune");
                                                        Console.WriteLine("Region : ");
                                                        string region = Console.ReadLine();
                                                        insertion_c.Save("SVG region");
                                                        insert.Adresse_Client_1(id_adresse, id_c, ville_1, num, lieu_1, metro_1, region, code, dept, commune, insertion_c);

                                                    }
                                                }
                                                
                                                
                                            }
                                            catch (SqlException ex)
                                            {
                                                Console.WriteLine(" ErreurConnexion : " + ex.ToString());
                                                return;
                                            }
                                        }
                                        if (!cuisto_2)
                                        {
                                          try
                                            {
                                                if(nb_adresse_cuisto > 0)
                                                {
                                                    for(int cuistos1 = 0; cuistos1 < nb_adresse_cuisto; cuistos1++)
                                                    {
                                                        Console.WriteLine();
                                                        SqlTransaction insertion_cui = connection.BeginTransaction();
                                                        Console.WriteLine("Insertion de tous les tuples(id,ville,numero,lieu dit,id_metro,region,code postal,dept,commune)");
                                                        Console.WriteLine("Identifiant :");
                                                        int id_adresse_cui = Convert.ToInt32(Console.ReadLine());
                                                        Console.WriteLine("Identifiant Cuisto :");
                                                        int id_cui = Convert.ToInt32(Console.ReadLine());
                                                        Console.WriteLine("Ville :");
                                                        string ville_2 = Console.ReadLine();
                                                        Console.WriteLine("Lieu dit : ");
                                                        string lieu_2 = Console.ReadLine();
                                                        Console.WriteLine("Numéro  : ");
                                                        int num_1 = Convert.ToInt32(Console.ReadLine());
                                                        Console.WriteLine("ID_Metro  : ");
                                                        int metro_2 = Convert.ToInt32(Console.ReadLine());
                                                        Console.WriteLine("Code Postal : ");
                                                        int code_1 = Convert.ToInt32(Console.ReadLine());
                                                        Console.WriteLine("Departement : ");
                                                        int dept_1 = Convert.ToInt32(Console.ReadLine());
                                                        Console.WriteLine("Commune : ");
                                                        string commune_1 = Console.ReadLine();
                                                        Console.WriteLine("Region : ");
                                                        string region_1 = Console.ReadLine();
                                                        insert.Adresse_Cuisto_1(id_adresse_cui, id_cui, ville_2, num_1, lieu_2, metro_2, region_1, code_1, dept_1, commune_1, insertion_cui);

                                                    }
                                                }
                                               
                                            }
                                            catch (SqlException ex)
                                            {
                                                Console.WriteLine(" ErreurConnexion : " + ex.ToString());
                                                return;
                                            }
                                        }

                                        goto default;
                                    default:
                                        break;
                                }

                                break;
                            case 3:
                                #region App
                                string nom_menu = "";
                                bool rollback_app = false;
                                bool inscription = false;
                                Console.WriteLine("Inscription : \n\t True \n\t False");
                                inscription = Convert.ToBoolean(Console.ReadLine());
                                if(inscription)
                                {
                                    Console.WriteLine("Nombre d'inscriptions de clients dans l'application");
                                    int nb_inscription_client = Convert.ToInt32(Console.ReadLine());
                                    Console.WriteLine("Nombre d'inscriptions de cuistos dans l'application");
                                    int nb_inscription_cuisto = Convert.ToInt32(Console.ReadLine());
                                    int Nb_Appli()
                                    {

                                        string q = "SELECT COUNT(*) FROM Application_Site";
                                        SqlCommand c = new SqlCommand(q, connection);
                                        int n = 0;
                                        try
                                        {


                                            SqlDataReader read = c.ExecuteReader();
                                            string[] valueString = new string[read.FieldCount];


                                            while (read.Read())
                                            {

                                                for (int i = 0; i < read.FieldCount; i++)
                                                {

                                                    valueString[i] = read.GetValue(i).ToString();
                                                    n = Convert.ToInt32(valueString[0]);


                                                }


                                            }

                                            read.Close();
                                        }

                                        catch (SqlException e)
                                        {
                                            Console.WriteLine(" ErreurConnexion : " + e.ToString());
                                            return 0;
                                        }


                                        return n;
                                    }
                                    int id_app = 1;
                                    int n_appli = Nb_Appli();
                                    if (n_appli > 1)
                                    {
                                        id_app = n_appli;
                                    }


                                    try
                                    {
                                        if (nb_inscription_cuisto > 0)
                                        {
                                            for (int nombre = 0; nombre < nb_inscription_cuisto; nombre++)
                                            {
                                                SqlTransaction inscription_appli_cuisto = connection.BeginTransaction();
                                                string inscription_cuisto_debut = " Debut Inscription_Cuisinier";
                                                inscription_appli_cuisto.Save(inscription_cuisto_debut);
                                                Console.WriteLine("Table : Application_Site");
                                                Console.WriteLine("Mot de passe : ");
                                                string mot_de_passse = Console.ReadLine();
                                                inscription_appli_cuisto.Save($" SVG Mdp_cuisinier");
                                                Console.WriteLine("Identifiant  Cuisinier :");
                                                int id_cuisto = Convert.ToInt32(Console.ReadLine());
                                                inscription_appli_cuisto.Save($" SVG Id_Cuisinier");
                                                Console.WriteLine("Nom  Menu : ");
                                                nom_menu = Console.ReadLine();
                                                inscription_appli_cuisto.Save($" SVG Nom Menu ");
                                                insert.App(id_app, nom_menu, id_cuisto, mot_de_passse, inscription_appli_cuisto);
                                                id_app++;
                                                Console.WriteLine();

                                            }
                                        }

                                        if (nb_inscription_client > 0)
                                        {
                                            for (int nb_c = 0; nb_c < nb_inscription_client; nb_c++)
                                            {
                                                SqlTransaction inscription_appli_client = connection.BeginTransaction();
                                                string inscription_client_debut = "Debut Inscription_Client";
                                                inscription_appli_client.Save(inscription_client_debut);
                                                Console.WriteLine("Table : Application_Site");
                                                Console.WriteLine("Mot de passe : ");
                                                string mot_de_passe = Console.ReadLine();
                                                inscription_appli_client.Save($" SVG Mdp_client");
                                                Console.WriteLine("Identifiant Client :");
                                                int id_cl = Convert.ToInt32(Console.ReadLine());
                                                insert.App_Client(id_app, id_cl, mot_de_passe, inscription_appli_client);
                                                id_app++;
                                                Console.WriteLine();
                                            }
                                        }


                                    }
                                    catch (SqlException ex)
                                    {
                                        Console.WriteLine(" ErreurConnexion : " + ex.ToString());
                                        return;
                                    }

                                }


                                #endregion
                                bool rollback_commandes = false;
                                SqlTransaction Commandes = connection.BeginTransaction();
                                Commandes.Save("Debut de la Commande");
                                int nombre_commandes = 0;
                                Console.WriteLine("Nombre de commandes : ");
                                nombre_commandes = Convert.ToInt32(Console.ReadLine());
                                for (int commande = 0; commande < nombre_commandes; commande++)
                                {
                                    #region Commandes
                                     Commandes.Save("Etape 1");
                                    Console.WriteLine("Etape 1 : Creation de repas(entree,plat,dessert)");
                                    #region Repas
                                    #region Plat
                                    
                                    bool rollback_plat = false;
                                    int total = 0;
                                    int id = 0;
                                    
                                    int nb_plat = Nb_Plat(Commandes);
                                    
                                   
                                    int Nb_Plat(SqlTransaction t)
                                    {

                                        string q = "SELECT COUNT(*) FROM Plat";
                                        SqlCommand c = new SqlCommand(q, connection);
                                        c.Transaction = t;
                                        int n = 0;
                                        try
                                        {


                                            SqlDataReader read = c.ExecuteReader();
                                            string[] valueString = new string[read.FieldCount];


                                            while (read.Read())
                                            {

                                                for (int i = 0; i < read.FieldCount; i++)
                                                {

                                                    valueString[i] = read.GetValue(i).ToString();
                                                    n = Convert.ToInt32(valueString[0]);


                                                }


                                            }

                                            read.Close();
                                        }

                                        catch (SqlException e)
                                        {
                                            Console.WriteLine(" ErreurConnexion : " + e.ToString());
                                            return 0;
                                        }


                                        return n;
                                    }
                                    
                                    bool plat1 = false;
                                    Console.WriteLine("Selection : Plat \n\t True \n\t False");
                                    plat1 = Convert.ToBoolean(Console.ReadLine());
                                    string path_plat = "C:\\Users\\Darrell Messi\\source\\repos\\Liv'in_Paris\\Paris_Mapper\\Plat.txt";
                                    if (plat1 == true)
                                    {
                                        Console.WriteLine("Table : Plat");
                                        StreamWriter w = new StreamWriter(path_plat);
                                        Console.WriteLine("Nom Plat : ");
                                        string nom_plat = "";
                                        while (nom_plat == string.Empty)
                                        {
                                            nom_plat = Console.ReadLine();

                                        }
                                        Console.WriteLine("Nombre d'ingredients et de volumes : ");

                                        int n = Convert.ToInt32(Console.ReadLine());
                                        bool date_plat = false;
                                        Console.WriteLine("Insertion des dates de fabrication et de peremption ? \n\t True \n\t False");
                                        date_plat = Convert.ToBoolean(Console.ReadLine());
                                        for (int z = 0; z < n; z++)
                                        {

                                            w.Write(nom_plat + "|");

                                            id = nb_plat + z + 1;
                                            total = id;
                                            w.Write(Convert.ToString(id) + "|");
                                            I();
                                            Console.WriteLine();
                                            V();
                                            Console.WriteLine();
                                            w.WriteLine();
                                            if (date_plat == false)
                                            {
                                                insert.Lecture_Ingredient(Commandes);

                                                insert.Lecture_Volume(Commandes);
                                            }
                                            else
                                            {
                                                insert.Lecture_Ingredient_1(Commandes);

                                                insert.Lecture_Volume(Commandes);
                                            }
                                            void V()
                                            {
                                                Console.WriteLine("Table : Volume");
                                                Console.WriteLine("Identifiant :");
                                                int id_v = total;
                                                Console.WriteLine(id_v);
                                                w.Write(Convert.ToString(id_v) + "|");
                                                Console.WriteLine("Volume(en decimal avec deux chiffres apres la virgule) :");
                                                decimal volume = Convert.ToDecimal(Console.ReadLine());
                                                Console.WriteLine("Unite de mesure :");
                                                string unite_2 = Console.ReadLine();
                                                insert.Volume(id_v, volume, unite_2,Commandes);
                                            }
                                            void I()
                                            {

                                                if (date_plat == true)
                                                {
                                                    Console.WriteLine("Table : Ingredient");
                                                    Console.WriteLine("Identifiant :");
                                                    int ID_2 = total;
                                                    Console.WriteLine(ID_2);
                                                    w.Write(Convert.ToString(ID_2) + "|");
                                                    Console.WriteLine("Ingredient : ");
                                                    string ingredient_2 = Console.ReadLine();
                                                    Console.WriteLine("Quantite/Portions :");
                                                    int q2 = Convert.ToInt32(Console.ReadLine());
                                                    bool choix = false;
                                                    Console.WriteLine("Choix d'insertion de date :  \n\t True : Insertion manuelle \n\t False : Insertion aléatoire");
                                                    choix = Convert.ToBoolean(Console.ReadLine());
                                                    if (choix == true)
                                                    {
                                                        Console.WriteLine("Date de fabrication : ");
                                                        DateTime fabrication1 = DateTime.Parse(Console.ReadLine());
                                                        Console.WriteLine("Date de peremption : ");
                                                        DateTime peremption1 = DateTime.Parse(Console.ReadLine());
                                                        insert.Ingredient(ID_2, ingredient_2, q2, fabrication1, peremption1,Commandes);
                                                    }
                                                    else
                                                    {
                                                        Random r = new Random();
                                                        int alea = r.Next(-366, 0);
                                                        int alea1 = r.Next(1, 366);
                                                        DateTime d = DateTime.Today;
                                                        DateTime fabrication_10 = d.AddDays(alea);
                                                        DateTime peremption_10 = d.AddDays(alea1);

                                                        
                                                        Console.WriteLine("Date de fabrication : ");
                                                        Console.WriteLine(fabrication_10);
                                                        Console.WriteLine("Date de peremption : ");
                                                        Console.WriteLine(peremption_10);
                                                        insert.Ingredient(ID_2, ingredient_2, q2, fabrication_10, peremption_10,Commandes);
                                                    }


                                                }
                                                else
                                                {
                                                    Console.WriteLine();
                                                    Console.WriteLine("Table : Ingredient");
                                                    Console.WriteLine("Identifiant :");
                                                    int ID = total;
                                                    Console.WriteLine(ID);
                                                    w.Write(Convert.ToString(ID) + "|");
                                                    Console.WriteLine("Ingredient : ");
                                                    string ingredient = Console.ReadLine();
                                                    Console.WriteLine("Quantite :");
                                                    int q = Convert.ToInt32(Console.ReadLine());
                                                    insert.Ingredient(ID, ingredient, q,Commandes);
                                                }

                                            }
                                        }

                                        w.Close();

                                    }
                                    Commandes.Save("SVG plat");
                                    #endregion
                                    #region Dessert
                                    bool dessert1 = false;
                                    bool rollback_dessert = false;
                                    Console.WriteLine("Selection : Dessert \n\t True \n\t False");
                                    dessert1 = Convert.ToBoolean(Console.ReadLine());
                                    string path_dessert = "C:\\Users\\Darrell Messi\\source\\repos\\Liv'in_Paris\\Paris_Mapper\\Dessert.txt";
                                    
                                    int Nb_Dessert(SqlTransaction t)
                                    {

                                        string q = "SELECT COUNT(*) FROM Dessert";
                                        SqlCommand c = new SqlCommand(q, connection);
                                        c.Transaction = t;
                                        int n = 0;
                                        try
                                        {


                                            SqlDataReader read = c.ExecuteReader();
                                            string[] valueString = new string[read.FieldCount];


                                            while (read.Read())
                                            {

                                                for (int i = 0; i < read.FieldCount; i++)
                                                {

                                                    valueString[i] = read.GetValue(i).ToString();
                                                    n = Convert.ToInt32(valueString[0]);


                                                }


                                            }

                                            read.Close();
                                        }

                                        catch (SqlException e)
                                        {
                                            Console.WriteLine(" ErreurConnexion : " + e.ToString());
                                            return 0;
                                        }


                                        return n;
                                    }
                                    if (dessert1 == true)
                                    {
                                        Console.WriteLine("Table : Dessert");
                                        StreamWriter w_dessert = new StreamWriter(path_dessert);
                                        Console.WriteLine("Nom  Dessert : ");
                                        string nom_dessert = "";
                                        int nb_dessert = Nb_Dessert(Commandes);
                                        while (nom_dessert == string.Empty)
                                        {
                                            nom_dessert = Console.ReadLine();

                                        }
                                        Console.WriteLine("Nombre d'ingredients et de volumes : ");
                                        int n1 = Convert.ToInt32(Console.ReadLine());
                                        bool date = false;
                                        Console.WriteLine("Insertion des dates de fabrication et de peremption ? \n\t True \n\t False");
                                        date = Convert.ToBoolean(Console.ReadLine());
                                        for (int z = 0; z < n1; z++)
                                        {
                                            w_dessert.Write(nom_dessert + "|");
                                            id =  nb_dessert  + z + 1;
                                            total += id;
                                            w_dessert.Write(Convert.ToString(id) + "|");
                                            I();
                                            Console.WriteLine();
                                            V();
                                            Console.WriteLine();
                                            w_dessert.WriteLine();
                                            if (date == false)
                                            {
                                                insert.Lecture_Ingredient(Commandes);

                                                insert.Lecture_Volume(Commandes);
                                            }
                                            else
                                            {
                                                insert.Lecture_Ingredient_1(Commandes);

                                                insert.Lecture_Volume(Commandes);
                                            }
                                            void V()
                                            {
                                                Console.WriteLine("Table : Volume");
                                                Console.WriteLine("Identifiant :");
                                                int id_v = total;
                                                Console.WriteLine(id_v);
                                                w_dessert.Write(Convert.ToString(id_v) + "|");
                                                Console.WriteLine("Volume(en decimal avec deux chiffres apres la virgule) :");
                                                decimal volume = Convert.ToDecimal(Console.ReadLine());
                                                Console.WriteLine("Unite de mesure :");
                                                string unite_1 = Console.ReadLine();
                                                insert.Volume(id_v, volume, unite_1,Commandes);
                                            }
                                            void I()
                                            {

                                                if (date == true)
                                                {
                                                    Console.WriteLine("Table : Ingredient");
                                                    Console.WriteLine("Identifiant :");
                                                    int ID_2 = total;
                                                    Console.WriteLine(ID_2);
                                                    w_dessert.Write(Convert.ToString(ID_2) + "|");
                                                    Console.WriteLine("Ingredient : ");
                                                    string ingredient_2 = Console.ReadLine();
                                                    Console.WriteLine("Quantite :");
                                                    int q2 = Convert.ToInt32(Console.ReadLine());
                                                    Console.WriteLine("Choix d'insertion de date :  \n\t True : Insertion manuelle \n\t False : Insertion aléatoire");
                                                    bool choix = Convert.ToBoolean(Console.ReadLine());
                                                    if (choix == true)
                                                    {
                                                        Console.WriteLine("Date de fabrication : ");
                                                        DateTime fabrication = DateTime.Parse(Console.ReadLine());
                                                        Console.WriteLine("Date de peremption : ");
                                                        DateTime peremption = DateTime.Parse(Console.ReadLine());
                                                        insert.Ingredient(ID_2, ingredient_2, q2, fabrication, peremption,Commandes);
                                                    }
                                                    else
                                                    {
                                                        Random r = new Random();
                                                        int alea = r.Next(-366, 0);
                                                        int alea1 = r.Next(1, 366);
                                                        DateTime d = DateTime.Today;
                                                        DateTime fabrication_1 = d.AddDays(alea);
                                                        DateTime peremption_1 = d.AddDays(alea1);



                                                        if (peremption_1 < fabrication_1)
                                                        {
                                                            DateTime temp = peremption_1;
                                                            peremption_1 = fabrication_1;
                                                            fabrication_1 = temp;
                                                        }
                                                        Console.WriteLine("Date de fabrication : ");
                                                        Console.WriteLine(fabrication_1);
                                                        Console.WriteLine("Date de peremption : ");
                                                        Console.WriteLine(peremption_1);
                                                        insert.Ingredient(ID_2, ingredient_2, q2, fabrication_1, peremption_1,Commandes);
                                                    }
                                                }
                                                else
                                                {
                                                    Console.WriteLine("Table : Ingredient");
                                                    Console.WriteLine("Identifiant :");
                                                    int ID = total;
                                                    Console.WriteLine(ID);
                                                    w_dessert.Write(Convert.ToString(ID) + "|");
                                                    Console.WriteLine("Ingredient : ");
                                                    string ingredient = Console.ReadLine();
                                                    Console.WriteLine("Quantite :");
                                                    int q = Convert.ToInt32(Console.ReadLine());
                                                    insert.Ingredient(ID, ingredient, q,Commandes);
                                                }

                                            }
                                        }
                                        w_dessert.Close();

                                    }

                                    Commandes.Save("SVG dessert");
                                    #endregion
                                    #region Entree
                                    bool entree1 = false;
                                    bool rollback_entree = false;
                                    Console.WriteLine("Selection : Entree \n\t True \n\t False");
                                    entree1 = Convert.ToBoolean(Console.ReadLine());
                                    string path_entree = "C:\\Users\\Darrell Messi\\source\\repos\\Liv'in_Paris\\Paris_Mapper\\Entree.txt";
                                    
                                    int nb_entree = Nb_Entree(Commandes);
                                    int Nb_Entree(SqlTransaction entree)
                                    {

                                        string q = "SELECT COUNT(*) FROM Entree";
                                        SqlCommand c = new SqlCommand(q, connection);
                                        c.Transaction = entree;
                                        int n = 0;
                                        try
                                        {


                                            SqlDataReader read = c.ExecuteReader();
                                            string[] valueString = new string[read.FieldCount];


                                            while (read.Read())
                                            {

                                                for (int i = 0; i < read.FieldCount; i++)
                                                {

                                                    valueString[i] = read.GetValue(i).ToString();
                                                    n = Convert.ToInt32(valueString[0]);


                                                }


                                            }

                                            read.Close();
                                        }

                                        catch (SqlException e)
                                        {
                                            Console.WriteLine(" ErreurConnexion : " + e.ToString());
                                            return 0;
                                        }


                                        return n;
                                    }
                                    if (entree1 == true)
                                    {
                                        StreamWriter w_entree = new StreamWriter(path_entree);
                                        Console.WriteLine("Table : Entree");
                                        Console.WriteLine("Nom de l'Entree : ");
                                        string nom_entree = string.Empty;
                                        while (nom_entree == string.Empty)
                                        {
                                            nom_entree = Console.ReadLine();

                                        }
                                        Console.WriteLine("Nombre d'ingredients et de volumes : ");
                                        int n2 = Convert.ToInt32(Console.ReadLine());
                                        bool date_entree = false;
                                        Console.WriteLine("Insertion des dates de fabrication et de peremption ? \n\t True \n\t False");
                                        date_entree = Convert.ToBoolean(Console.ReadLine());
                                        for (int z = 0; z < n2; z++)
                                        {
                                            w_entree.Write(nom_entree + "|");
                                             id = nb_entree + z + 1;
                                            total += id;
                                            w_entree.Write(Convert.ToString(id) + "|");
                                            I();
                                            Console.WriteLine();
                                            V();
                                            Console.WriteLine();
                                            w_entree.WriteLine();
                                            if (date_entree == false)
                                            {
                                                insert.Lecture_Ingredient(Commandes);

                                                insert.Lecture_Volume(Commandes);
                                            }
                                            else
                                            {
                                                insert.Lecture_Ingredient_1(Commandes);

                                                insert.Lecture_Volume(Commandes);
                                            }

                                            void V()
                                            {
                                                Console.WriteLine("Table : Volume");
                                                Console.WriteLine("Identifiant :");
                                                int id_v = total;
                                                Console.WriteLine(id_v);
                                                w_entree.Write(Convert.ToString(id_v) + "|");
                                                Console.WriteLine("Volume(en decimal avec deux chiffres apres la virgule) :");
                                                decimal volume = Convert.ToDecimal(Console.ReadLine());
                                                Console.WriteLine("Unite de mesure :");
                                                string unite = Console.ReadLine();
                                                insert.Volume(id_v, volume, unite,Commandes);
                                            }
                                            void I()
                                            {

                                                if (date_entree == true)
                                                {
                                                    Console.WriteLine("Table : Ingredient");
                                                    Console.WriteLine("Identifiant :");
                                                    int ID_1 = total;
                                                    Console.WriteLine(ID_1);
                                                    w_entree.Write(Convert.ToString(ID_1) + "|");
                                                    Console.WriteLine("Ingredient : ");
                                                    string ingredient_1 = Console.ReadLine();
                                                    Console.WriteLine("Quantite :");
                                                    int q1 = Convert.ToInt32(Console.ReadLine());
                                                    Console.WriteLine("Choix d'insertion de date :  \n\t True : Insertion manuelle \n\t False : Insertion aléatoire");
                                                    bool choix = Convert.ToBoolean(Console.ReadLine());
                                                    if (choix == true)
                                                    {
                                                        Console.WriteLine("Date de fabrication : ");
                                                        DateTime fabrication = DateTime.Parse(Console.ReadLine());
                                                        Console.WriteLine("Date de peremption : ");
                                                        DateTime peremption = DateTime.Parse(Console.ReadLine());
                                                        insert.Ingredient(ID_1, ingredient_1, q1, fabrication, peremption,Commandes);
                                                    }
                                                    else
                                                    {
                                                        Random r = new Random();
                                                        int alea = r.Next(-366, 0);
                                                        int alea1 = r.Next(1, 366);
                                                        DateTime d = DateTime.Today;
                                                        DateTime fabrication_1 = d.AddDays(alea);
                                                        DateTime peremption_1 = d.AddDays(alea1);

                                                        Console.WriteLine("Date de fabrication : ");
                                                        Console.WriteLine(fabrication_1);
                                                        Console.WriteLine("Date de peremption : ");
                                                        Console.WriteLine(peremption_1);
                                                        insert.Ingredient(ID_1, ingredient_1, q1, fabrication_1, peremption_1,Commandes);
                                                    }
                                                }
                                                else
                                                {
                                                    Console.WriteLine("Table : Ingredient");
                                                    Console.WriteLine("Identifiant :");
                                                    int ID = total;
                                                    Console.WriteLine(ID);
                                                    w_entree.Write(Convert.ToString(ID) + "|");
                                                    Console.WriteLine("Ingredient : ");
                                                    string ingredient = Console.ReadLine();
                                                    Console.WriteLine("Quantite :");
                                                    int q = Convert.ToInt32(Console.ReadLine());
                                                    insert.Ingredient(ID, ingredient, q,Commandes);
                                                }


                                            }
                                        }
                                        w_entree.Close();

                                    }
                                    
                                    
                                    Commandes.Save("SVG entree");
                                    Commandes.Commit();
                                    insert.Lecture_2_Fichier(path_entree);
                                    insert.Lecture_2_Fichier_Plat(path_plat);
                                    insert.Lecture_2_Fichier_Dessert(path_dessert);

                                    #endregion
                                    #endregion
                                    SqlTransaction Commandes1 = connection.BeginTransaction();
                                    Commandes1.Save("Etape 2");
                                    
                                    Console.WriteLine("Etape 2 : Creation du menu grace aux repas");
                                    //string nom_menu = "";
                                    #region Menu
                                    if (plat1 == true || dessert1 == true || entree1 == true)
                                    {
                                        
                                        try
                                        {
                                            
                                            Console.WriteLine("Table : Contenu du Menu");
                                            Console.WriteLine("Nom du Menu : ");
                                            //nom_menu = Console.ReadLine();
                                            insert.Contenu_du_Menu(nom_menu, Commandes1);
                                           
                                        }
                                        catch (SqlException ex)
                                        {
                                            Console.WriteLine(" ErreurConnexion : " + ex.ToString());
                                            return;
                                        }
                                        Console.WriteLine();
                                    }

                                    #endregion
                                    #region Commande
                                    Commandes1.Save("Etape 3");
                             
                                    Console.WriteLine("Etape 3 : Finalisation de la commande ");
                                    Console.WriteLine("Table : Commandes \n\t True : Tuples(Client,Cuisto,Nombre de Personnes, Date de depart , Date d'arrivee,Pays d'origine,Prix par personne ,Regime alimentaire) \n\t False : Tuples(Client,Cuisto,Nombre,Prix Unitaire)");


                                    bool com = false;
                                        
                                    com = Convert.ToBoolean(Console.ReadLine());
                                    
                                    int id_com = commande + 1;
                                    int id_C = 0;
                                    int id_cuisinier = 0;
                                    if (com == false)
                                    {
                                       
                                        Console.WriteLine("Identifiant Client : ");
                                         id_C = Convert.ToInt32(Console.ReadLine());
                                        Commandes1.Save("SVG Client");
                                        Console.WriteLine("Identifiant Cuisinier : ");
                                        id_cuisinier = Convert.ToInt32(Console.ReadLine());
                                        Commandes1.Save("SVG Cuisinier");
                                        Console.WriteLine("Nombre de Personnes : ");
                                        int nombre = Convert.ToInt32(Console.ReadLine());
                                        Commandes1.Save("SVG Nombre de Personnes");
                                        Console.WriteLine("Prix Unitaire : ");
                                        decimal prix = Convert.ToDecimal(Console.ReadLine());
                                        Console.WriteLine("Prix de la commande :");
                                        decimal p = prix * nombre;
                                        f.Prix_C(nombre, prix,Commandes1);
                                        insert.Commandes_1(id_com, id_C, id_cuisinier, nombre,prix, nom_menu,Commandes1);
                                        #region Catalogue
                                        SqlTransaction cat = connection.BeginTransaction();
                                        Console.WriteLine("Identifiant Client : ");
                                        //id_C = Convert.ToInt32(Console.ReadLine());
                                        Console.WriteLine("Identifiant Cuisinier : ");
                                       // id_cuisinier = Convert.ToInt32(Console.ReadLine());
                                        Console.WriteLine("Identifiant Commande : ");
                                        id_com = commande + 1;
                                        insert.Catalogue(id_C, id_cuisinier, id_com,cat);

                                        #endregion
                                    }
                                    else
                                    {
                                       
                                      try
                                        {
                                            Console.WriteLine("Identifiant Client : ");
                                             id_C = Convert.ToInt32(Console.ReadLine());
                                            Console.WriteLine("Identifiant Cuisinier : ");
                                             id_cuisinier = Convert.ToInt32(Console.ReadLine());
                                            Console.WriteLine("Nombre de Personnes : ");
                                            int nombre = Convert.ToInt32(Console.ReadLine());
                                            Console.WriteLine("Pays d'orgine :");
                                            string pays = Console.ReadLine();
                                            bool jour = false;
                                            DateTime depart = DateTime.Now;
                                            DateTime arrivee = DateTime.Now;
                                            if (!jour)
                                            {
                                                Console.WriteLine("Date de depart : ");
                                                depart = DateTime.Today;
                                                Console.WriteLine("Date d'arrivee : ");
                                                bool gestion_aleatoire = false;
                                                if(!gestion_aleatoire)
                                                {
                                                    Console.WriteLine("Temps d'arrivee(en minutes) : ");
                                                    Random t = new Random();
                                                    int temps = Convert.ToInt32(t.Next(1, 1441));
                                                    Console.WriteLine("Date d'arrivee : ");
                                                    arrivee = depart.AddMinutes(temps);
                                                }
                                                else
                                                {
                                                    Console.WriteLine("Temps d'arrivee(en minutes) : ");
                                                    int temps = Convert.ToInt32(Console.ReadLine());
                                                    Console.WriteLine("Date d'arrivee : ");
                                                    arrivee = depart.AddMinutes(temps);
                                                }
                                                    
                                            }
                                            else
                                            {
                                                Console.WriteLine("Date de depart : ");
                                                 depart = DateTime.Parse(Console.ReadLine());
                                                Console.WriteLine("Date d'arrivee : ");
                                                 arrivee = DateTime.Parse(Console.ReadLine());
                                            }
                                              
                                            Console.WriteLine("Prix par personne : ");
                                            decimal prix_unitaire = Convert.ToDecimal(Console.ReadLine());
                                            Console.WriteLine("Regime alimentaire : ");
                                            string regime = Console.ReadLine();
                                            Console.WriteLine("Prix de la commande : ");
                                            decimal p = prix_unitaire * nombre;
                                           f.Prix_C(nombre,prix_unitaire,Commandes1);
                                            insert.Commandes(id_com, id_C, id_cuisinier, nombre, nom_menu, pays, depart, arrivee, prix_unitaire, regime, Commandes1);

                                          
                                            
                                        }
                                        catch (SqlException ex)
                                        {
                                            Console.WriteLine(" ErreurConnexion : " + ex.ToString());
                                            return;
                                        }

                                        #region Catalogue
                                        bool rollback_cat = false;
                                        try
                                        {
                                            SqlTransaction heritage = connection.BeginTransaction();
                                            heritage.Save("Debut insertion_Catalogue");
                                            Console.WriteLine("Identifiant  Client : ");
                                           // id_C = Convert.ToInt32(Console.ReadLine());
                                            heritage.Save($"SVG Id_Client");
                                            Console.WriteLine("Identifiant Cuisinier : ");
                                           // id_cuisinier = Convert.ToInt32(Console.ReadLine());
                                            heritage.Save($"Cuisinier : {id_cuisinier}");
                                            Console.WriteLine("Identifiant Commande : ");
                                            id_com = commande + 1;
                                            heritage.Save("Fin insertion_Catalogue");
                                            
                                            insert.Catalogue(id_C, id_cuisinier, id_com, heritage);
                                           
                                        }
                                        catch (SqlException ex)
                                        {
                                            Console.WriteLine(" ErreurConnexion : " + ex.ToString());
                                            return;
                                        }
                                        #endregion

                                    }
                                    
                                  












                                    #endregion
                                    #endregion




                                    //f.Plat_du_Jour();

                                }

                                goto default;



                            default:
                                bool qui = false;
                                if (qui)
                                {
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine("Table :  0 : Client \n\t 1 : Cuisinier \n\t 2 : Adresse \n\t 3 : Commandes  ");
                                    int cq = Convert.ToInt32(Console.ReadLine());
                                    if (cq == 1)
                                    {
                                        goto case 1;
                                    }
                                    if (cq == 2)
                                    {
                                        goto case 2;
                                    }
                                    if (cq == 3)
                                    {
                                        goto case 3;
                                    }

                                }


                                break;
                                

                        }

                        break;

                        #endregion
                    

                    default:
                        bool quitter16 = false;
                        return;
                }

                break;
            #endregion
            #region Serialisation
            case 3:
                #region Serialisation Client
                
                Console.WriteLine(" Selection : Serialisaiton Client");
                string fileToWrite = "client.json";
                Serialisation_Client c = new Serialisation_Client();
                //instanciation des objets <CQlient>
                List<Serialisation_Client> Client = new List<Serialisation_Client>();
                int nb = 0;
                int Nombre_Client()
                {
                    string q = "SELECT COUNT(*) FROM Client";
                    SqlCommand c = new SqlCommand(q, connection);
                    int n = 0;
                        try
                        {


                            SqlDataReader read = c.ExecuteReader();
                            string[] valueString = new string[read.FieldCount];


                            while (read.Read())
                            {
                                
                                for (int i = 0; i < read.FieldCount; i++)
                                {

                                valueString[i] = read.GetValue(i).ToString();
                                n = Convert.ToInt32(valueString[0]);
                                   

                                }


                            }

                            read.Close();
                        }

                    catch (SqlException e)
                    {
                        Console.WriteLine(" ErreurConnexion : " + e.ToString());
                        return 0 ;
                    }
                    

                    return n;
                }
                nb = Nombre_Client();
                Client.Capacity = nb;
                
                    string q = "SELECT ID_Client,Prenom,Nom,Telephone,Email,Adresse FROM Client";
                    SqlCommand commandes = new SqlCommand(q, connection);

                    try
                    {


                        SqlDataReader read = commandes.ExecuteReader();
                        string[] valueString = new string[read.FieldCount];


                        while (Client.Count < nb)
                        {
                        read.Read();
                        for (int o = 0; o < read.FieldCount; o++)
                                {

                                    valueString[o] = read.GetValue(o).ToString();
                                    Console.WriteLine();

                                }
                                Client.Add(new Serialisation_Client(Convert.ToInt32(valueString[0]), valueString[1], valueString[2], valueString[3], valueString[4], valueString[5]));
                                




                    }

                        read.Close();
                    }

                    catch (SqlException e)
                    {
                        Console.WriteLine(" ErreurConnexion : " + e.ToString());
                        return;
                    }
                
                //instanciation des flux d'écriture(writer)
                StreamWriter fileWriter = new StreamWriter(fileToWrite);
                JsonTextWriter jsonWriter = new JsonTextWriter(fileWriter);

                // sérialisation des objets vers le flux d'écriture fichier
                Newtonsoft.Json.JsonSerializer serializer = new Newtonsoft.Json.JsonSerializer();
                serializer.Serialize(jsonWriter, Client);

                //fermture des flux (writer)
                jsonWriter.Close();
                fileWriter.Close();

                //relecture du fichier créé
                //-----------------------------
                Console.WriteLine("\nlecture des informations de Serialisation_Client.json\n");

                StreamReader reader = new StreamReader(fileToWrite);
                JsonTextReader jreader = new JsonTextReader(reader);
                while (jreader.Read())
                {
                    if (jreader.Value != null)
                    {
                        if (jreader.TokenType.ToString() == "PropertyName")
                        {
                            Console.Write(jreader.Value + " : ");
                        }
                        else
                        {
                            Console.WriteLine(jreader.Value);
                        }
                    }
                    else
                    {
                        // Console.WriteLine("Token:{0} ", jreader.TokenType.ToString());
                        if (jreader.TokenType.ToString() == "StartObject") Console.WriteLine("Nouvel objet\n--------------");
                        if (jreader.TokenType.ToString() == "EndObject") Console.WriteLine("-------------\n");
                        if (jreader.TokenType.ToString() == "StartArray") Console.WriteLine("Liste\n");
                    }
                }
                jreader.Close();
                reader.Close();
                Console.WriteLine("Appuyer sur espace pour continuer");
                Console.ReadLine();
                #endregion
                #region Serialisation_Cuisto
                Console.WriteLine(" Selection : Serialisaiton Cuisto");
                string fileToWrite_1 = "cuisto.json";
                Serialisation_Cuisto cuisto = new Serialisation_Cuisto();
                //instanciation des objets <CQlient>
                List<Serialisation_Cuisto> Cuisto = new List<Serialisation_Cuisto>();
                int nb_1 = 0;
                int Nombre_Cuisto()
                {
                    string q = "SELECT COUNT(*) FROM Cuisto";
                    SqlCommand c = new SqlCommand(q, connection);
                    int n = 0;
                    try
                    {


                        SqlDataReader read = c.ExecuteReader();
                        string[] valueString = new string[read.FieldCount];


                        while (read.Read())
                        {

                            for (int i = 0; i < read.FieldCount; i++)
                            {

                                valueString[i] = read.GetValue(i).ToString();
                                n = Convert.ToInt32(valueString[0]);


                            }


                        }

                        read.Close();
                    }

                    catch (SqlException e)
                    {
                        Console.WriteLine(" ErreurConnexion : " + e.ToString());
                        return 0;
                    }


                    return n;
                }
                nb_1 = Nombre_Cuisto();
                Cuisto.Capacity = nb_1;

                string q1 = "SELECT ID_Cuisto,Prenom,Nom,Telephone,Email,Adresse FROM Cuisto";
                SqlCommand commandes_1 = new SqlCommand(q1, connection);

                try
                {


                    SqlDataReader read = commandes_1.ExecuteReader();
                    string[] valueString = new string[read.FieldCount];


                    while (Cuisto.Count < nb_1)
                    {
                        read.Read();
                        for (int o = 0; o < read.FieldCount; o++)
                        {

                            valueString[o] = read.GetValue(o).ToString();
                            Console.WriteLine();

                        }
                        Cuisto.Add(new Serialisation_Cuisto(Convert.ToInt32(valueString[0]), valueString[1], valueString[2], valueString[3], valueString[4], valueString[5]));


                    }

                    read.Close();
                }

                catch (SqlException e)
                {
                    Console.WriteLine(" ErreurConnexion : " + e.ToString());
                    return;
                }

                //instanciation des flux d'écriture(writer)
                StreamWriter fileWriter_1 = new StreamWriter(fileToWrite_1);
                JsonTextWriter jsonWriter_1 = new JsonTextWriter(fileWriter_1);

                // sérialisation des objets vers le flux d'écriture fichier
                Newtonsoft.Json.JsonSerializer serializer_1 = new Newtonsoft.Json.JsonSerializer();
                serializer_1.Serialize(jsonWriter_1, Cuisto);

                //fermture des flux (writer)
                jsonWriter_1.Close();
                fileWriter_1.Close();

                //relecture du fichier créé
                //-----------------------------
                Console.WriteLine("\nlecture des informations de Serialisation_Cuisto.json\n");

                StreamReader reader_1 = new StreamReader(fileToWrite_1);
                JsonTextReader jreader_1 = new JsonTextReader(reader_1);
                while (jreader_1.Read())
                {
                    if (jreader_1.Value != null)
                    {
                        if (jreader_1.TokenType.ToString() == "PropertyName")
                        {
                            Console.Write(jreader_1.Value + " : ");
                        }
                        else
                        {
                            Console.WriteLine(jreader_1.Value);
                        }
                    }
                    else
                    {
                        // Console.WriteLine("Token:{0} ", jreader.TokenType.ToString());
                        if (jreader_1.TokenType.ToString() == "StartObject") Console.WriteLine("Nouvel objet\n--------------");
                        if (jreader_1.TokenType.ToString() == "EndObject") Console.WriteLine("-------------\n");
                        if (jreader_1.TokenType.ToString() == "StartArray") Console.WriteLine("Liste\n");
                    }
                }
                jreader_1.Close();
                reader_1.Close();
                Console.ReadLine();

               #endregion

   
                
                goto default;

                default:
                return;


                #endregion
        }
        break;
        #endregion
}


