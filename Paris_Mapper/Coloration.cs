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
        public void Welsh_Powell()
        {
            List<Noeud<T>> S = new List<Noeud<T>>();
            foreach (var s in graphe.Noeuds)
            {
                    
                    int ID = graphe.Conversion(s.ID);
                    Noeud<T> n = new Noeud<T>();
                    Acces_Noeud(ID);
                    S.Add(n);
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
                                    n.Degre = n.Calcul_Degre();
                                    for (int i = 0; i < read.FieldCount; i++)
                                    {

                                        valueString[i] = read.GetValue(i).ToString();

                                        if (i == 1)
                                        {
                                            decimal ligne_1 = Convert.ToDecimal(valueString[1]);
                                            n.Numero_2_ligne = Convert.ToDouble(ligne_1);
                                        }
                                        if (i == 2)
                                        {
                                            for (int cor = 0; cor < n.Correspondance.Count; cor++)
                                            {
                                                n.Correspondance[cor] = valueString[2][cor].ToString();
                                            }

                                        }
                                        if (i == 3)
                                        {
                                            n.Station = valueString[3];
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
                                            n.Commune = valueString[6];
                                        }
                                        if (i == 7)
                                        {
                                            n.Code_Postal = Convert.ToInt32(valueString[7]);
                                        }

                                    }
                                    n.Coordonnees = Tuple.Create(val, val1);

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

                

            }
            graphe.Tri_Decroissant(graphe.Noeuds);
            int couleur = -1;
            while (S.Count > 0)
            {
                couleur++;
                S[couleur].Couleur = Couleur[couleur];
                S.RemoveAt(0);
                //Noeud x = new Noeud();
                foreach (var noeud in S)
                {
                    foreach (var key in graphe.Succ.Keys)
                    {
                        foreach (var sommet in graphe.Succ[key])
                        {
                            if (!sommet.Equals(noeud.ID))
                            {
                                noeud.Couleur = Couleur[couleur];


                            }
                        }
                    }
                }
            }
        }


    }
}


