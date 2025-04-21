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
using System.Drawing;


namespace Paris_Mapper
{
    internal class Coloration<T>
    {
        int nombre_chromatique;
        List<Color> Couleur = [Color.Yellow, Color.Blue, Color.Green, Color.Red, Color.Orange, Color.RebeccaPurple];
        static Graphe<T> graphe = new Graphe<T>();
        public Coloration()
        {
            nombre_chromatique = 0;
        }
        public int Nombre_Chromatique
        {
            get { return nombre_chromatique; }
        }
     
        public List<Noeud<T>> Welsh_Powell()
        {
            List<Noeud<T>> S = graphe.Noeuds;
            graphe.Tri_Decroissant(S);

            int index_couleur = 0;
            List<Noeud<T>> noeud_c = new List<Noeud<T>>();

            foreach (Noeud<T> noeud in S)
            {
                if (noeud_c.Contains(noeud)) continue;

                noeud.Couleur = Couleur[index_couleur];
                noeud_c.Add(noeud);

                for (int j = 0; j < S.Count; j++)
                {
                    Noeud<T> autre = S[j];
                    if (noeud_c.Contains(autre)) continue;

                    bool noeud_c_adjacent = false;
                    foreach (var n in noeud_c)
                    {
                        if (Est_Adjacent(noeud.ID, autre.ID))
                        {
                            noeud_c_adjacent = true;
                            break;
                        }
                    }
                    if (!noeud_c_adjacent)
                    {
                        autre.Couleur = Couleur[index_couleur];
                        noeud_c.Add(autre);
                    }
                }
                index_couleur++;
                if (index_couleur >= Couleur.Count) break;

            }
            nombre_chromatique = index_couleur;
            return noeud_c;
        }

        private bool Est_Adjacent(T n1, T n2)
        {

            if (graphe.Succ.ContainsKey(n1) && graphe.Succ[n2].Contains(n1))
            {
                return true;
            }
            if (graphe.Succ.ContainsKey(n2) && graphe.Succ[n2].Contains(n1))
            {
                return true;
            }
            return false;
        }

        public void Affichage(List<Noeud<T>> Welsh)
        {
            Console.WriteLine();
            string[] orden = new string[13];
            foreach (Noeud<T> n in Welsh)
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

    }
}


