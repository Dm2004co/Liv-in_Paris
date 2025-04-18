using Org.BouncyCastle.Asn1.X509;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Threading.Tasks;

using System.Linq;
using System.Threading.Tasks;
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
using System.Runtime.CompilerServices;

namespace Paris_Mapper
{
    class PCC<T>
    {
        static Graphe<T> graphe = new Graphe<T>();
        #region Floyd
        public void Affichage_FWR(List<T> FWR)
        {
            string orden = "";
            foreach (T s in FWR)
            {
                orden += Convert.ToString(s) + "|";
            }

            Console.WriteLine();
            Console.WriteLine($"L'ordre de visite : {orden}");
        }

        public void Affichage_Ordre_FWR_Noeud(List<Noeud<T>> BFS)
        {
            Console.WriteLine();
            string[] orden = new string[13];
            foreach (Noeud<T> n in BFS)
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
        public SortedList<T, List<T>> Liste_Succ()
        {
            int n = graphe.Sommet.Count;
            double[,] FWR = Floyd_Warshall_Roy();
            SortedList<T, List<T>> Successeur = new SortedList<T, List<T>>(n);
            for (int a = 0; a < n; a++)
            {
                Successeur[graphe.Sommet[a]] = new List<T>();

            }
            for (int i = 0; i < FWR.GetLength(0); i++)
            {
                for (int j = 0; j < FWR.GetLength(1); j++)
                {
                    if (FWR[i, j] != 0)
                    {
                        if (graphe.Sommet[j].Equals(330) || graphe.Sommet[i].Equals(330))
                        {
                            T s = graphe.Inversion_Conversion(332);
                            if(s.Equals(graphe.Sommet[i]))
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


        public (bool, List<T>, List<Noeud<T>>, double) PCC_FWR(Noeud<T> depart, Noeud<T> arrivee)
        {
            Queue<Noeud<T>> BFS = new Queue<Noeud<T>>();
            List<Noeud<T>> Noeud_v = new List<Noeud<T>>();
            List<T> Ordre = new List<T>();
            List<T> Chemin = new List<T>();
            List<Noeud<T>> C = new List<Noeud<T>>();
            SortedList<T, List<T>> L = Liste_Succ();
            Lien<T> l = new Lien<T>();
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
                    Noeud<T> y = BFS.Dequeue();
                    y = graphe.Noeuds.Find(noeud => noeud.ID.Equals(y.ID));

                    y.Degre = y.Calcul_Degre();
                    y.Couleur = Color.Red;
                    y.date_Fin = y.Fin();
                    Console.WriteLine($"Fin d'exploration de : {y.ID}");
                    if (L[y.ID].Count > 0)
                    {
                        foreach (T voisinage in L[y.ID])
                        {

                            if (L.TryGetValue(voisinage, out List<T>? value))
                            {
                                if (L[voisinage].Count > 0)
                                {

                                    Noeud<T> voisin = new Noeud<T>(voisinage);
                                    voisin = graphe.Noeuds.Find(noeud => noeud.ID.Equals(voisinage));


                                    int niveau = y.Niveau + 1;
                                    voisin.Niveau = niveau;
                                    voisin.Degre = voisin.Calcul_Degre();


                                    for (int i = 0; i < Noeud_v.Count; i++)
                                    {
                                        voisin.Pred[voisin.ID] = new List<T>();

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

        public int Occurence(List<Noeud<T>> n, Noeud<T> n1)
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
        #region Dijkstra


        public (List<T>, List<List<Noeud<T>>>, List<Noeud<T>>, List<List<T>>, List<T>) Djisktra( int depart)
        {
            
            T d1 = graphe.Inversion_Conversion(depart);
            Noeud<T> n = new Noeud<T>(d1);
            int v = graphe.Conversion(n.ID);
            n = graphe.Noeuds.Find(noeud => noeud.ID.Equals(d1));

            Lien<T> l = new Lien<T>(n);
            List<T> P1 = new List<T>();
            List<T> Q = graphe.Sommet;
            List<Noeud<T>> Q1 = graphe.Noeuds;
            List<Noeud<T>> P3 = new List<Noeud<T>>();
            List<T> Pred = new List<T>();
            List<List<Noeud<T>>> N2 = new List<List<Noeud<T>>>();
            List<List<T>> N1 = new List<List<T>>();
            double d = 0;
            double distance = 0;
            double distance_1 = 0;
            double distance_2 = 0;
            P1.Add(n.ID);
            P3.Add(n);
            Pred.Add(n.ID);
            //Q1.Remove(n);
            //Q.Remove(n.ID);
            while (Q1.Count > 0)
            {
                int nb1 = Q1.Count;
                List<T> P2 = new List<T>();
                List<Noeud<T>> P4 = new List<Noeud<T>>();
                T s1 = Min().Item1;
                d = Min().Item2;
                Console.WriteLine($"Sommet de distance minimale : {s1}");
                Noeud<T> y = new Noeud<T>(s1);
                int v1 = graphe.Conversion(y.ID);
                y = graphe.Noeuds.Find(noeud => noeud.ID.Equals(s1));
                if(!n.ID.Equals(y.ID))
                {
                    if (graphe.Inferieur(n.ID, y.ID))
                    {
                        distance += d;
                    }
                    else
                    {
                        distance -= d;
                    }
                }
               
                Q.Remove(y.ID);
                Q1.Remove(y);
                P1.Add(y.ID);
                P2.Add(y.ID);
                Pred.Add(y.ID);
                P3.Add(y);
                P4.Add(y);

                // Console.WriteLine("Q privé de s1");
                foreach (var voisinage in graphe.Succ[y.ID])
                {
                    if (Q.Contains(voisinage))
                    {
                        
                        Noeud<T> voisin = new Noeud<T>(voisinage);
                        int voi = graphe.Conversion(voisinage);
                        if(voi != depart)
                        {
                            voisin = graphe.Noeuds.Find(noeud => noeud.ID.Equals(voi));

                            if (graphe.Succ.TryGetValue(voisinage, out List<T>? value))
                            {
                                if (graphe.Succ[voisinage].Count > 0)
                                {

                                    if (voisin.Coordonnees.Item1 != null && voisin.Coordonnees.Item2 != null && y.Coordonnees.Item2 != null && y.Coordonnees.Item1 != null)
                                    {
                                        double maj =
                                        Maj_Distance(voisin, y);
                                        if (!y.ID.Equals(voisin.ID))
                                        {
                                            if (graphe.Inferieur(y.ID, voisin.ID))
                                            {
                                                distance_1 += maj;
                                            }
                                            else
                                            {
                                                distance_1 -= maj;
                                            }
                                        }

                                        Console.WriteLine(distance_1);

                                    }



                                }
                            }

                        }

                    }


                    N1.Add(P2);
                    N2.Add(P4);
                    Affichage_Dijkstra(P1);
                    Console.WriteLine();
                    Affichage_Ordre_Dijkstra_Noeud(P3);
                    Console.WriteLine();
                    P1.Clear();
                    P3.Clear();
                }



                double Maj_Distance(Noeud<T> s1, Noeud<T> s2)
                {
                    double maj = 0;
                    s2.Pred[s2.ID] = new List<T>();
                    if (l.Calcul_Distance(n, s2) > l.Calcul_Distance(n, s1) + l.Calcul_Poids(s1, s2))
                    {
                        maj = l.Calcul_Distance(n, s1) + l.Calcul_Poids(s1, s2);
                        s2.Pred[s2.ID].Add(s1.ID);
                        P1.Add(s2.ID);
                        P2.Add(s2.ID);
                        P3.Add(s2);
                        P4.Add(s2);
                        s2.Couleur = Color.Red;
                        s2.date_Fin = s2.Fin();
                        //Console.WriteLine($"{s2} rajouté à la liste P1");
                    }

                    else
                    {
                        P1.Add(s1.ID);
                        P2.Add(s1.ID);
                        P3.Add(s1);
                        P4.Add(s1);
                        s1.Couleur = Color.Red;
                        s1.date_Fin = s1.Fin();

                        //Console.WriteLine($"{s1} rajouté à la liste P1");
                    }
                    return maj;
                }
                (T, double) Min()
                {
                    double min = double.MaxValue;
                    foreach (var s in Q1)
                    {

                        Noeud<T> sdeb = s;
                        double distance = l.Calcul_Distance(n, sdeb);


                        if (distance < min)
                        {
                            min = distance;
                            n.ID = s.ID;
                        }


                    }
                    return (n.ID, min);
                }
                
                distance_2 = distance + distance_1;
                Console.WriteLine(distance_2);
            }

            
           
            return (P1, N2, P3, N1, Pred);
        }


        public void Affichage_Dijkstra(List<T> Dijkstra)
        {
            string orden = "";
            foreach (var s in Dijkstra)
            {
                orden += Convert.ToString(s) + "|";
            }

            Console.WriteLine();
            Console.WriteLine($"L'ordre de visite : {orden}");
        }


        public void Affichage_Ordre_Dijkstra_Noeud(List<Noeud<T>> Dijkstra)
        {
            Console.WriteLine();
            string[] orden = new string[13];
            foreach (Noeud<T> n in Dijkstra)
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
        public (List<List<Noeud<T>>>, List<List<T>>, List<Noeud<T>>) Recherche_Chemin(int arrivee, int depart)
        {
            (List<T>, List<List<Noeud<T>>>, List<Noeud<T>>, List<List<T>>, List<T>) n = Djisktra(depart);
            T ar = graphe.Inversion_Conversion(arrivee);
            Noeud<T> arrive = new Noeud<T>(ar);
            List<List<Noeud<T>>> N1 = new List<List<Noeud<T>>>();
            List<Noeud<T>> N4 = new List<Noeud<T>>();
            List<T> N2 = new List<T>();
            List<List<T>> N3 = new List<List<T>>();
            List<int> a = new List<int>();
            int longueur_chemin = 0;
            int index = 0;
            int nb = n.Item4.Count;
            int nb_chemins = 0;
            int indice_arrivee = 0;
            double dist = 0;
            foreach (var l in n.Item2)
            {
                foreach (var n1 in l)
                {
                    if (n1.ID.Equals(ar))
                    {
                        arrive = n1;
                    }
                }
            }

            for (int i = 0; i < nb; i++)
            {
                if (n.Item4[i].Contains(arrive.ID))
                {
                    N3.Add(n.Item4[i]);
                    N1.Add(n.Item2[i]);
                }

            }
            longueur_chemin = Min();
            nb_chemins = a.Count;

            for (int j = 0; j < N3.Count; j++)
            {
                int nc = N3[j].Count;
                if (longueur_chemin == nc)
                {
                    for (int k = 0; k < nc; k++)
                    {


                        if (nb_chemins > 1)
                        {

                            if (!N3[j][0].Equals(arrive.ID))
                            {
                                N3.RemoveAt(j);
                                N1.RemoveAt(j);
                            }

                        }



                    }
                    N2 = N3[0];
                    N4 = N1[0];
                    index = n.Item5.IndexOf(N2[0]);
                }
            }
            N2 = N2.GetRange(0, indice_arrivee + 1);
            N4 = N4.GetRange(0, indice_arrivee + 1);
            
            n.Item5 = n.Item5.GetRange(0, index);
            
            if (n.Item5.Count != null)
            {
                for (int c1 = 0; c1 < n.Item5.Count; c1++)
                {
                    List<Noeud<T>> n4 = new List<Noeud<T>>(n.Item5.Count);
                    if (c1 + 1 < n.Item5.Count && n.Item5[c1 + 1] != null)
                    {
                        Noeud<T> n2 = new Noeud<T>(n.Item5[c1]);
                    void Acces_Noeud(int id)
                    {
                        string connexion = "Data Source=(localdb)\\ProjectModels;Initial Catalog=Paris;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";
                        SqlConnection connection = new SqlConnection(connexion);
                        connection.Open();
                        SqlParameter p = new SqlParameter();
                        p.Value = id;
                        p.ParameterName = "@ID_Metro";
                        p.DbType = DbType.Int32;
                        string q = "SELECT * FROM Metro WHERE ID_Metro = @ID_Metro";
                        SqlCommand c = new SqlCommand(q, connection);
                        c.Parameters.Add(p);
                        try
                        {
                            
                            
                            SqlDataReader read = c.ExecuteReader();
                            string[] valueString = new string[read.FieldCount];

                            {
                                while (read.Read())


                                {
                                    double val = 0;
                                    double val1 = 0;
                                    for (int i = 0; i < read.FieldCount; i++)
                                    {

                                        valueString[i] = read.GetValue(i).ToString();

                                        if (i == 1)
                                        {
                                            decimal ligne_1 = Convert.ToDecimal(valueString[1]);
                                            n2.Numero_2_ligne = Convert.ToDouble(ligne_1);
                                        }
                                        if (i == 2)
                                        {
                                            for (int cor = 0; cor < n2.Correspondance.Count; cor++)
                                            {
                                                n2.Correspondance[cor] = valueString[2][cor].ToString();
                                            }

                                        }
                                        if (i == 3)
                                        {
                                            n2.Station = valueString[3];
                                        }
                                        if (i == 4)
                                        {
                                            val = Convert.ToDouble(valueString[4]);

                                        }
                                        if (i == 5)
                                        {
                                            val1 = Convert.ToDouble(valueString[5]);
                                        }

                                        if (i == 6)
                                        {
                                            n2.Commune = valueString[6];
                                        }
                                        if (i == 7)
                                        {
                                            n2.Code_Postal = Convert.ToInt32(valueString[7]);
                                        }

                                    }
                                    n2.Coordonnees = Tuple.Create(val, val1);

                                    Console.WriteLine();

                                }


                            }

                            read.Close();
                        }
                        catch(SqlException e)
                        {
                            Console.WriteLine(" ErreurConnexion : " + e.ToString());
                            return;
                        }
                        finally
                        {
                            connection.Close();
                        }


                    }
                    Noeud<T> n3 = new Noeud<T>(n.Item5[c1 + 1]);
                    void Acces_Noeud_1(int id)
                    {
                        string connexion = "Data Source=(localdb)\\ProjectModels;Initial Catalog=Paris;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";
                        SqlConnection connection = new SqlConnection(connexion);
                        connection.Open();
                        SqlParameter p = new SqlParameter();
                        p.Value = id;
                        p.ParameterName = "@ID_Metro";
                        p.DbType = DbType.Int32;
                        string q = "SELECT * FROM Metro WHERE ID_Metro = @ID_Metro";
                        SqlCommand c = new SqlCommand(q, connection);
                        c.Parameters.Add(p);
                        try
                        {


                            SqlDataReader read = c.ExecuteReader();
                            string[] valueString = new string[read.FieldCount];

                            {
                                while (read.Read())


                                {
                                    double val = 0;
                                    double val1 = 0;
                                    for (int i = 0; i < read.FieldCount; i++)
                                    {

                                        valueString[i] = read.GetValue(i).ToString();

                                        if (i == 1)
                                        {
                                            decimal ligne_1 = Convert.ToDecimal(valueString[1]);
                                            n3.Numero_2_ligne = Convert.ToDouble(ligne_1);
                                        }
                                        if (i == 2)
                                        {
                                            for (int cor = 0; cor < n3.Correspondance.Count; cor++)
                                            {
                                                n3.Correspondance[cor] = valueString[2][cor].ToString();
                                            }

                                        }
                                        if (i == 3)
                                        {
                                            n3.Station = valueString[3];
                                        }
                                        if (i == 4)
                                        {
                                            val = Convert.ToDouble(valueString[4]);

                                        }
                                        if (i == 5)
                                        {
                                            val1 = Convert.ToDouble(valueString[5]);
                                        }

                                        if (i == 6)
                                        {
                                            n3.Commune = valueString[6];
                                        }
                                        if (i == 7)
                                        {
                                            n3.Code_Postal = Convert.ToInt32(valueString[7]);
                                        }

                                    }
                                    n3.Coordonnees = Tuple.Create(val, val1);

                                    Console.WriteLine();

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
                            connection.Close();
                        }


                    }
                    Lien<T> l = new Lien<T>();

                        
                        int e = graphe.Conversion(n.Item5[c1]);
                        int f = graphe.Conversion(n.Item5[c1 + 1]);
                        int g = graphe.Conversion(n.Item5[n.Item5.Count - 1]);
                        Acces_Noeud(e);
                        Acces_Noeud_1(f);
                        
                        n4.Add(n2);
                        n4.Add(n3);
                        int c = graphe.Conversion(n2.ID);
                        int d = graphe.Conversion(n3.ID);
                            if (c < d)
                            {
                                dist += (l.Calcul_Distance(n2, n3)/8);
                            }
                            if(c == g && c1 == n.Item5.Count - 1 &&  c < arrivee)
                            {
                                Acces_Noeud(g);
                                Acces_Noeud_1(arrivee);
                                dist += (l.Calcul_Distance(n2, n3)/8);
                            }
                            if(c == g && c1 == n.Item5.Count - 1 && c > arrivee)
                            {
                                Acces_Noeud(g);
                                Acces_Noeud_1(arrivee);
                                dist -= (l.Calcul_Distance(n2, n3)/8);
                            }
                            else
                            {
                                dist -= (l.Calcul_Distance(n2, n3) / 8);
                            }

                        
                    }
                }
            }
            if(depart < arrivee && dist <  0)
            {
                dist = -dist;
            }
                Console.WriteLine();

                Affichage_Dijkstra(N2);

                int Min()
                {
                    int min = int.MaxValue;

                    foreach (var chemin in N3)
                    {

                        int longueur = chemin.Count;
                        int b = longueur;
                        if (longueur < min)
                        {
                            min = longueur;

                        }
                        if (min == b)
                        {
                            a.Add(longueur);
                        }


                    }
                    return min;
                }
                Console.WriteLine($"La liste des predecesseurs est :  ");
                Affichage_Dijkstra(n.Item5);
                Console.WriteLine($"La longueur du chemin est de : {n.Item5.Count + N2.Count} stations ");
                Console.WriteLine($"Distance = {dist}");
                
                return (N1, N3, N4);

            }




        #endregion
        #region Bellman_Ford


        #endregion

    }
}


