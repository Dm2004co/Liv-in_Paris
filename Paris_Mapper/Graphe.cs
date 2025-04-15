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
using System.Data;
using Org.BouncyCastle.Utilities;
using System.Drawing;
using System.ComponentModel.DataAnnotations.Schema;

namespace Paris_Mapper
{
    internal class Graphe<T>
    {
#region Attributs
        bool simple = true;
        bool multigraphe = true;
        bool complet = true;
        bool regulier = false;
        bool biparti = false;
        bool planaire = false;
        int degre_max;
        List<Tuple<double, double>> coordonees = new List<Tuple<double, double>>();
        List<Noeud<T>> noeuds = new List<Noeud<T>>();
        List<T> sommet = new List<T>();
        List<Tuple<T, T>> aretes = new List<Tuple<T, T>>();
        List<int> lignes = [1, 2, 3, 4, 5, 6, 7, 8, 9, 0, 11, 12, 13, 14];
        List<Noeud<T>>[] Station_par_Ligne = new List<Noeud<T>>[25];
        double[,] distance = new double[332, 332];
        double[,] matrice_ADJ ;
        SortedList<T, List<T>> succ = new SortedList<T, List<T>>();
        SortedList<T, List<T>> pred = new SortedList<T, List<T>>();
        List<(int, int)> poids = new List<(int, int)>();
        List<int> niveau = new List<int>();
        List<DateTime> date_decouverte = new List<DateTime>();
        List<DateTime> date_fin = new List<DateTime>();
        List<int> degre = new List<int>();
        bool orientation = false;
        bool ponderation = false;
        #endregion
        #region Proprietes
        public List<Tuple<T, T>> Aretes
        {
            get { return aretes; }
            set { aretes = value; }
        }
        /// <summary>,T
        /// Representation planaire
        /// </summary>
        public bool Planaire
        {
            get { return this.planaire; }
        }
        /// <summary>
        /// Liste des sommets du graphe 
        /// </summary>
        public List<Tuple<double, double>> Coordonees
        {
            get { return this.coordonees; }
            set { this.coordonees = value; }
        }

        public List<Noeud<T>> Noeuds
        {
            get { return this.noeuds; }
            set { this.noeuds = value; }
        }

        /// <summary>
        /// Presence uniquement d'arc simple
        /// </summary>

        public bool Simple
        {
            get { return simple; }
        }
        /// <summary>
        /// Presence d'aretes multiples ou de boucles
        /// </summary>
        public bool Multigraphe
        {
            get { return multigraphe; }
        }
        /// <summary>
        /// Degre du graphe
        /// </summary>
        public int Degre_max
        {
            get { return degre_max; }
            set { this.degre_max = value; }
        }
        /// <summary>
        /// Propriete du graphe 
        /// </summary>
        public bool Complet
        {
            get { return complet; }
        }
        /// <summary>
        /// Propriete d'un sommet 
        /// </summary>
        public bool Regulier
        { get { return regulier; } }


        public List<T> Sommet
        {
            get { return sommet; }
            set { sommet = value; }
        }
        public double[,] Distance
        {
            get { return distance; }
            set { distance = value; }
        }

        public double[,]Matrice_ADJ
        {
            get { return matrice_ADJ; }
            set { matrice_ADJ = value; }
        }

        public bool Orientation
        {
            get { return orientation; }
            set { orientation = value; }
        }
        public bool Ponderation
        {
            get { return ponderation; }
            set { ponderation = value; }
        }
        public SortedList<T, List<T>> Pred
        {
            get { return pred; }
            set { pred = value; }
        }
        public SortedList<T, List<T>> Succ
        {
            get { return succ; }
            set { succ = value; }
        }
        #endregion
        public Graphe()
        {
            Noeuds = Lecture();
            Sommet = Clonage_Sommet();
            Aretes = Arete(Noeuds);
            distance = Calcul_Distance();
            Matrice_ADJ = Matrice();
            orientation = Orientation_Arc();
            ponderation = Ponderation_Arc();
            Pred = Liste_Pred();
            Succ = Liste_Succ();
        }

        public bool Orientation_Arc()
        {
            bool oriente = true;
            int n = Matrice_ADJ.GetLength(0);
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                    if (matrice_ADJ[i, j] == matrice_ADJ[j, i] && i !=j)
                    {
                        oriente = false;
                    }
            }
            return oriente;
        }
        public bool Ponderation_Arc()
        {
            bool pondere = false;
            int n = Matrice_ADJ.GetLength(0);
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                    if (matrice_ADJ[i, j] > 1)
                    {
                        pondere = true;
                    }
            }
            return pondere;
        }
        public bool Doublon(List<Noeud<T>> n)
        {
            for (int i = 0; i < n.Count; i++)
            {
                foreach (Noeud<T> a in n)
                {
                    if (Egale(a.ID, n[i].ID))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public bool Egale(T a, T b)
        {
            if (a.ToString().CompareTo(b.ToString()) == 0)
            {
                return true;
            }
            return false;
        }

        public int Occurence(List<Noeud<T>> n, Noeud<T> a)
        {
            int occ = 0;
            for (int i = 0; i < n.Count; i++)
            {

                if (Egale(a.ID, n[i].ID))
                {
                    occ++;
                }

            }
            return occ;
        }
        public List<Tuple<T, T>> Arete(List<Noeud<T>> N)
        {
            Type t = typeof(T);
            List<Tuple<T, T>> a = new List<Tuple<T, T>>();
            
            Direct();
            //Indirect();
            void Direct()
            {
                for (int k = 0; k < N.Count; k++)
                {
                    if (k + 1 < N.Count && k - 1 < N.Count)
                    {

                        int j = k + 1;
                        
                        object c = Convert.ChangeType(N[j].ID, t);
                        object b = Convert.ChangeType(N[k].ID, t);


                        if (N[k].Numero_2_ligne == N[k + 1].Numero_2_ligne && N[k + 1].ID != null)
                        {
                            a.Add((Tuple.Create((T)b, (T)c)));

                        }
                    }

                    if ( k > 0 )
                    {
                        int m = k - 1;
                        object d = Convert.ChangeType(N[k].ID, t);
                        object e = Convert.ChangeType(N[m].ID, t);
                        if (N[k].Numero_2_ligne == N[k - 1].Numero_2_ligne && N[k - 1].ID != null)
                        {
                            a.Add((Tuple.Create((T)d, (T)e)));

                        }
                    }
                }

                void Indirect()
                {
                    for (int l = N.Count; l <= 0; l--)
                    {
                        if (l > 0)
                        {



                            if (N[l].Numero_2_ligne == N[l - 1].Numero_2_ligne && N[l - 1].ID != null)
                            {

                                //a.Add((Tuple.Create((T)d, (T)e)));
                            }
                        }



                    }

                }

            }

            
            
            return a;
        }
            
            
        
           

        public double Exist_Adjacence(T s1, T s2)
        {
           double result = 0;
            //int a = Convert.ToInt32(s1);
            //int b = Convert.ToInt32(s2);
            int indice_distance_a = Sommet.IndexOf(s1);
            int indice_distance_b = Sommet.IndexOf(s2);
            foreach (var arete in Aretes)
            {
                if(Egale(s1, arete.Item1) && Egale(s2, arete.Item2))
                {
                    
                        result = distance[indice_distance_a, indice_distance_b];
                      
                }
                
            }
           
            return result;

        }

        public double[,] Matrice()
        {
            int n = Sommet.Count;
            double[,] Matrice_Adjacence = new double[n, n];

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Matrice_Adjacence[i, j] = Exist_Adjacence(Sommet[i], Sommet[j]);
                }
            }

            return Matrice_Adjacence;
        }

        public void Afficher_ADJ(double[,] m)
        {

            for (int i = 0; i < m.GetLength(0); i++)
            {

                Console.WriteLine();
                for (int j = 0; j < m.GetLength(1); j++)
                {
                    string s = Convert.ToString($"|{m[i, j]}");

                    Console.Write(s);


                }
                Console.WriteLine();

            }
        }

        List<T> Clonage_Sommet()
        {
            List<T> Sommet = new List<T>();
            for (int i = 0; i < Noeuds.Count; i++)
            {
                Sommet.Add(Noeuds[i].ID);
            }
            return Sommet;
        }

         public void Afficher(double[,] m)
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
                    string s = Convert.ToString($"|{m[i, j]}|");

                    Console.Write(s);


                }
                Console.WriteLine();

            }
        }


        public List<Noeud<T>> Lecture()
        {
            string connexion = "Data Source=(localdb)\\ProjectModels;Initial Catalog=Paris;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";
            SqlConnection connection = new SqlConnection(connexion);
            connection.Open();
            string selecton_metro = "SELECT * FROM Metro ORDER BY ID_Metro ;";
            SqlCommand command = new SqlCommand(selecton_metro, connection);
            SqlDataReader reader = command.ExecuteReader();
            string[] grid = new string[reader.FieldCount];
            int taille = Noeuds.Capacity = 332;
            List<Noeud<T>> temp = new List<Noeud<T>>();
            Coordonees.Capacity = taille;

            while (reader.Read())
            {
                Noeud<T> N = new Noeud<T>();
                Type t = typeof(T);
                
                for (int i = 0; i < grid.Length; i++)
                {
                    grid[i] = reader.GetValue(i).ToString();
                    //object a = Convert.ChangeType(grid[1], t);
                    
                    
                        if (i == 0)
                    {
                        T a = Inversion_Conversion(Convert.ToInt32(grid[0]));
                        N.ID = a;
                    }
                    if(i == 1)
                    {
                        N.Numero_2_ligne = Convert.ToDouble(grid[1]);

                    }
                    if (!N.Correspondance.Contains(grid[2]) && N.Correspondance.Count == 0 && N.Correspondance.Count < 6)
                    {
                        N.Correspondance.Add(grid[2]);
                    }
                    if( i == 3)
                    {
                        N.Station = grid[3];

                    }
                    
                        N.Coordonnees = Tuple.Create(Convert.ToDouble(grid[4]), Convert.ToDouble(grid[5]));
                        if(i == 6)
                        {
                            N.Commune = grid[6];
                        }
                        if(i == 7)
                        {
                            N.Code_Postal = Convert.ToInt32(grid[7]);
                        }
                       
                    
                   
                    
                }
                temp.Add(N);

            }
            reader.Close();
            connection.Close();
            Suppression_Doublon(temp);
            return temp;

        }

        public void Suppression_Doublon(List<Noeud<T>> N)
        {
            Type t = typeof(T);
             T a = (T)Convert.ChangeType(332, t);
            string nb = Convert.ToString(332);
            
            for (int i = 0; i < N.Count; i++)
            {
                if (i + 1 < N.Count && N[i + 1].ID != null)
                {
                    while (Egale(N[i].ID, N[i + 1].ID) && Occurence(N, N[i]) > 0 &&!Egale(N[i].ID,a))
                    {
                        N.RemoveAt(i + 1);
                    }
                    if (Egale(N[i].ID, a))
                    {
                        if (Occurence(N, N[i]) > 0)
                        {
                            N.RemoveAt(i);
                        }
                    }

                }
                
                
                
            }
            N.RemoveAt(N.Count - 1);
            N.RemoveAt(N.Count - 1);
            N.RemoveAt(N.Count - 1);
        }
        public bool Egale(Noeud<T> n, Noeud <T> a)
        {
            if (n.ID.ToString().CompareTo(a.ID.ToString()) == 0)
            {
                return true;
            }
            return false;
        }
        public bool Inferieur(T n,T a)
        {
            if (n.ToString().CompareTo(a.ToString()) < 0)
            {
                return true;
            }
            return false;
        }

         public double[,] Calcul_Distance()
        {
            Lien<T> l = new Lien <T>();
            int n = Noeuds.Count;
            double[,] d = new double[n, n];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    d[i, j] = l.Calcul_Distance(Noeuds[i], Noeuds[j]);
                }
            }
            return d;
        }
        public int Conversion(T a)
        {
            string s = a.ToString();
            int n = Convert.ToInt32(s);
            return n;
        }
        public  T Inversion_Conversion (int a)
        {
            object b = Convert.ChangeType(a, typeof(T));
            return (T)b;
        }
        
        public SortedList<T, List<T>> Liste_Succ()
        {
            int n = Sommet.Count;
            SortedList<T, List<T>> Successeur = new SortedList<T, List<T>>(n);
            for (int a = 0; a < n; a++)
            {
                //T i = Inversion_Conversion(a);
                Successeur[Sommet[a]] = new List<T>();

            }
            for (int i = 0; i < this.matrice_ADJ.GetLength(0); i++)
            {
                for (int j = 0; j < this.matrice_ADJ.GetLength(1); j++)
                {
                    if (this.matrice_ADJ[i, j] != 0)
                    {

                        Successeur[Sommet[j]].Add(Sommet[i]);



                    }
                }

            }

            return Successeur;
        }
        public SortedList<T, List<T>> Liste_Pred()
        {
            int n = Sommet.Count;
            SortedList<T, List<T>> Pred = new SortedList<T, List<T>>(n);
            for (int a = 0; a < n; a++)
            {
                //T i = Inversion_Conversion(a);
                Pred[Sommet[a]] = new List<T>();

            }
            for (int i = 0; i < this.matrice_ADJ.GetLength(0); i++)
            {
                for (int j = 0; j < this.matrice_ADJ.GetLength(1); j++)
                {
                    if (this.matrice_ADJ[i, j] != 0)
                    {

                        Pred[Sommet[j]].Add(Sommet[i]);

                    }
                }

            }

            return Pred;
        }

        public (bool, List<T>, List<Noeud<T>>) Chemin(Noeud<T> depart, Noeud<T> arrivee)
        {
            Queue<Noeud<T>> BFS = new Queue<Noeud<T>>();
            List<Noeud<T>> Noeud_v = new List<Noeud<T>>();
            List<T> Ordre = new List<T>();
            List<T> Chemin = new List<T>();
            List<Noeud<T>> C = new List<Noeud<T>>();
            bool chemin = false;

            try
            {

                depart.Couleur = Color.Yellow;
                depart.date_Dec = depart.Decouverte();
                depart.Degre = depart.Calcul_Degre(); ;
                //Console.WriteLine($"Debut d'exploration de  : {depart.Sommet}");
                Noeud_v.Add(depart);
                //Console.WriteLine($"Noeud<T> :{depart.Sommet} , visité");
                Ordre.Add(depart.ID);
                BFS.Enqueue(depart);
                //Console.WriteLine("Noeud<T> rajouté dans la pile");

                while (BFS.Count > 0)
                {
                    Noeud<T> y = BFS.Dequeue();
                    y.Degre = y.Calcul_Degre();
                    y.Couleur = Color.Red;
                    y.date_Fin = y.Fin();
                    //Console.WriteLine($"Fin d'exploration de : {y.Sommet}");
                    if (Succ[y.ID].Count > 0)
                    {
                        foreach (var voisinage in Succ[y.ID])
                        {
                            if (Succ.TryGetValue(voisinage, out List<T>? value))
                            {
                                if (Succ[voisinage].Count > 0)
                                {

                                    Noeud<T> voisin = new Noeud<T>(voisinage);
                                    voisin.Niveau = y.Niveau + 1;
                                    voisin.Degre = voisin.Calcul_Degre();
                                    for (int i = 0; i < Noeud_v.Count; i++)
                                    {

                                        if (!Egale(voisin, Noeud_v[i]) && Occurence(Noeud_v, voisin) < 1)
                                        {
                                            voisin.Couleur = Color.Yellow;
                                            voisin.date_Dec = voisin.Decouverte();
                                            //Console.WriteLine($"Debut d'exploration de  : {voisin.Sommet}");
                                            Noeud_v.Add(voisin);
                                            //Console.WriteLine($"Noeud<T> :{voisin.Sommet} , visité");
                                            Ordre.Add((voisin.ID));
                                            BFS.Enqueue(voisin);
                                            //Console.WriteLine($"Noeud<T> : {voisin.Sommet}, rajouté dans la pile");
                                            voisin.Pred[voisin.ID] .Add(y.ID);

                                        }
                                        if (Egale(arrivee, voisin))
                                        {
                                            chemin = true;



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
                string s = " (La Liste d'Adjacence)";
                Console.WriteLine($" {ex.Source} , \n{ex.Message + s} ");
            }
            for (int p = 0; p < Ordre.Count; p++)
            {
                if (arrivee.Egale(Ordre[p],arrivee.ID))
                {
                    int index_arrivee = p;

                    Chemin = Ordre.GetRange(0, index_arrivee + 1);
                }
            }
            for (int i = 0; i < Noeud_v.Count; i++)
                if (Egale(arrivee, Noeud_v[i]))
                {
                    int index_arrivee = i;

                    C = Noeud_v.GetRange(0, index_arrivee + 1);
                }
            return (chemin, Chemin, C);


        }

          public void Tri_Croissant(List<Noeud<T>> L)
        {
             int Partionner(List<Noeud<T>> L, int fin, int debut, int pivot)
            {
                

                Noeud<T> resul = new Noeud<T>();
                resul = L[pivot];
                L[pivot] = L[fin];
                L[debut] = resul;

                int j = debut;

                for (int i = debut; i < fin; i++)
                {
                    int degre = L[i].Degre;
                    int degre_1 = L[debut].Degre;
                    if (degre <= degre_1)
                    {
                        resul = L[j];
                        L[j] = L[i];
                        L[i] = resul;
                        j--;
                    }

                }
                resul = L[j];
                L[j] = L[debut];
                L[fin] = resul;

                return j;
            }
            void Quick_Sort(List<Noeud<T>> L, int debut, int fin)
            {
                int pivot;
                if (debut < fin)
                {
                    pivot = (debut + fin) / 2;
                    pivot = Partionner(L, debut, fin, pivot);
                    Quick_Sort(L, debut, pivot - 1);
                    Quick_Sort(L, pivot + 1, fin);

                }
            }
        }


        public void Tri_Decroissant(List<Noeud<T>> L)
        {
             int Partionner(List<Noeud<T>> L, int fin, int debut, int pivot)
            {
                Noeud<T> resul;
                resul = L[pivot];
                L[pivot] = L[debut];
                L[debut] = resul;

                int j = fin;

                for (int i = fin; i <= debut; i--)
                {
                    int degre = L[i].Degre;
                    int degre_1 = L[debut].Degre;
                    if (degre <= degre_1)
                    {
                        resul = L[j];
                        L[j] = L[i];
                        L[i] = resul;
                        j--;
                    }

                }
                resul = L[j];
                L[j] = L[debut];
                L[debut] = resul;

                return j;
            }
             void Quick_Sort(List<Noeud<T>> L, int debut, int fin)
            {
                int pivot;
                if (debut < fin)
                {
                    pivot = (debut + fin) / 2;
                    pivot = Partionner(L, debut, fin, pivot);
                    Quick_Sort(L, debut, pivot - 1);
                    Quick_Sort(L, pivot + 1, fin);

                }
            }
        }


    }
}
