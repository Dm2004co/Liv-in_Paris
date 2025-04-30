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


namespace Paris_Mapper
{
    class Insertion
    {
        string connexion;
        SqlConnection connection;
        
        public Insertion(string connexion, SqlConnection connection)
        {

            this.connection = connection;
            this.connexion = connexion;
            

        }
        
        #region Client

        public void Client(int id, string prenom, string nom, string telephone, string email,SqlTransaction t)
        {
            SqlParameter p = new SqlParameter();
            p.DbType = DbType.Int32;
            p.Value = id;
            p.ParameterName = "@ID_Client";
            p.Direction = ParameterDirection.Input;
            p.SourceColumn = "ID_Client";
            SqlParameter m = new SqlParameter();
            m.Value = prenom;
            m.ParameterName = "@Prenom";
            m.Direction = ParameterDirection.Input;
            m.SourceColumn = "Prenom";
            m.DbType = DbType.String;
            SqlParameter o = new SqlParameter();
            o.Value = nom;
            o.ParameterName = "@Nom";
            o.Direction = ParameterDirection.Input;
            o.SourceColumn = "Nom";
            o.DbType = DbType.String;
            SqlParameter q = new SqlParameter();
            q.Value = telephone;
            q.ParameterName = "@Telephone";
            q.Direction = ParameterDirection.Input;
            q.SourceColumn = "Telephone";
            q.DbType = DbType.String;
            q.Size = 10;
            SqlParameter r = new SqlParameter();
            r.Value = email;
            r.ParameterName = "@Email";
            r.Direction = ParameterDirection.Input;
            r.SourceColumn = "Email";
            r.DbType = DbType.String;

            string query = "INSERT INTO Client(ID_Client,Prenom,Nom,Telephone,Email) VALUES(@ID_Client,@Prenom,@Nom,@Telephone,@Email);";
            SqlCommand c = connection.CreateCommand();
            c.CommandText = query;
            c.Parameters.Add(p);
            c.Parameters.Add(m);
            c.Parameters.Add(o);
            c.Parameters.Add(r);
            c.Parameters.Add(q);
            c.Transaction = t;
            try
            {

                c.ExecuteNonQuery();
                t.Commit();
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
                t.Dispose();
            }


        }
        public void Client_1(int id, string prenom, string nom , SqlTransaction t)
        {
            SqlParameter p = new SqlParameter();
            p.DbType = DbType.Int32;
            p.Value = id;
            p.ParameterName = "@ID_Client";
            p.Direction = ParameterDirection.Input;
            p.SourceColumn = "ID_Client";
            SqlParameter m = new SqlParameter();
            m.Value = prenom;
            m.ParameterName = "@Prenom";
            m.Direction = ParameterDirection.Input;
            m.SourceColumn = "Prenom";
            m.DbType = DbType.String;
            SqlParameter o = new SqlParameter();
            o.Value = nom;
            o.ParameterName = "@Nom";
            o.Direction = ParameterDirection.Input;
            o.SourceColumn = "Nom";
            o.DbType = DbType.String;

            string query = "INSERT INTO Client(ID_Client,Prenom,Nom) VALUES(@ID_Client,@Prenom,@Nom);";
            SqlCommand c = connection.CreateCommand();
            c.CommandText = query;
            c.Parameters.Add(p);
            c.Parameters.Add(m);
            c.Parameters.Add(o);
            c.Transaction = t;

            try
            {

                c.ExecuteNonQuery();
                t.Commit();
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
                t.Dispose();
            }


        }
        #endregion
        #region Cuisinier
        public void Cuisinier(int id, string prenom, string nom, string telephone, string email, SqlTransaction t)
        {
            SqlParameter p = new SqlParameter();
            p.Value = id;
            p.ParameterName = "@ID_Cuisto";
            p.Direction = ParameterDirection.Input;
            p.SourceColumn = "ID_Cuisto";
            p.DbType = DbType.Int32;
            SqlParameter m = new SqlParameter();
            m.Value = prenom;
            m.ParameterName = "@Prenom";
            m.Direction = ParameterDirection.Input;
            m.SourceColumn = "Prenom";
            m.DbType = DbType.String;
            SqlParameter o = new SqlParameter();
            o.Value = nom;
            o.ParameterName = "@Nom";
            o.Direction = ParameterDirection.Input;
            o.SourceColumn = "Nom";
            o.DbType = DbType.String;
            SqlParameter q = new SqlParameter();
            q.Value = telephone;
            q.ParameterName = "@Telephone";
            q.Direction = ParameterDirection.Input;
            q.SourceColumn = "Telephone";
            q.DbType = DbType.String;
            SqlParameter r = new SqlParameter();
            r.Value = email;
            r.ParameterName = "@Email";
            r.Direction = ParameterDirection.Input;
            r.SourceColumn = "Email";
            r.DbType = DbType.String;
            string query = "INSERT INTO Cuisto(ID_Cuisto,Prenom,Nom,Telephone,Email) VALUES(@ID_Cuisto,@Prenom,@Nom,@Telephone,@Email);";
            SqlCommand c = connection.CreateCommand();
            c.CommandText = query;
            c.Parameters.Add(p);
            c.Parameters.Add(m);
            c.Parameters.Add(o);
            c.Parameters.Add(r);
            c.Parameters.Add(q);
            c.Transaction = t;
            try
            {

                c.ExecuteNonQuery();
                t.Commit();
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
                t.Dispose();

            }

        }
        public void Cuisinier_1(int id, string prenom, string nom, SqlTransaction t)
        {
            SqlParameter p = new SqlParameter();
            p.Value = id;
            p.ParameterName = "@ID_Cuisto";
            p.Direction = ParameterDirection.Input;
            p.SourceColumn = "ID_Cuisto";
            p.DbType = DbType.Int32;
            SqlParameter m = new SqlParameter();
            m.Value = prenom;
            m.ParameterName = "@Prenom";
            m.Direction = ParameterDirection.Input;
            m.SourceColumn = "Prenom";
            m.DbType = DbType.String;
            SqlParameter o = new SqlParameter();
            o.Value = nom;
            o.ParameterName = "@Nom";
            o.Direction = ParameterDirection.Input;
            o.SourceColumn = "Nom";
            o.DbType = DbType.String;

            string query = "INSERT INTO Cuisto(ID_Cuisto,Prenom,Nom) VALUES(@ID_Cuisto,@Prenom,@Nom);";
            SqlCommand c = new SqlCommand(query, connection);
            c.Parameters.Add(p);
            c.Parameters.Add(m);
            c.Parameters.Add(o);
            c.Transaction = t;
            try
            {

                c.ExecuteNonQuery();
                t.Commit();
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
                t.Dispose();
            }

        }
        #endregion
        #region Adresse
        public void Adresse_Client(int id,int id_client, string ville, int numero, string lieu,int code_postal, int metro , SqlTransaction t)
        {
            SqlParameter ad = new SqlParameter("@Id", DbType.Int32);
            ad.Value = id;
            SqlParameter m = new SqlParameter();
            m.Value = id_client;
            m.ParameterName = "@ID_Client";
            m.DbType = DbType.Int32;
            SqlParameter o = new SqlParameter();
            o.Value = ville;
            o.ParameterName = "@Ville";
            o.DbType = DbType.String;
            SqlParameter q = new SqlParameter();
            q.Value = numero;
            q.ParameterName = "@Numero";
            q.DbType = DbType.Int32;
            SqlParameter r = new SqlParameter();
            r.Value = lieu;
            r.ParameterName = "@Lieu";
            r.DbType = DbType.String;
            SqlParameter a = new SqlParameter("@ID_Métro", DbType.Int32);
            a.Value = metro;
            SqlParameter b = new SqlParameter("@Code_Postal", DbType.Int32);
            b.Value = code_postal;
            string query = "INSERT INTO Adresse(Id,ID_Client,Ville,Numero,Lieu,Code_Postal,ID_Métro) VALUES(@Id,@ID_Client,@Ville,@Numero,@Lieu,@Code_Postal,@ID_Métro);";
            SqlCommand c = new SqlCommand(query, connection) ;
            c.CommandText = query;
            c.Parameters.Add(ad);
            c.Parameters.Add(m);
            c.Parameters.Add(o);
            c.Parameters.Add(q); 
            c.Parameters.Add(r);
            c.Parameters.Add(a);
            c.Parameters.Add(b);
           
            
            c.Transaction = t;
            try
            {

                c.ExecuteNonQuery();
                t.Commit();
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
                t.Dispose();
            }

        }
        public void Adresse_Cuisto(int id ,int id_cuisto, string ville, int numero, string lieu, int code , int metro,SqlTransaction t)
        {
            SqlParameter ad = new SqlParameter("@Id", DbType.Int32);
            ad.Value = id;
            SqlParameter m = new SqlParameter();
            m.Value = id_cuisto;
            m.ParameterName = "@ID_Cuisto";
            m.DbType = DbType.Int32;
            SqlParameter o = new SqlParameter();
            o.Value = ville;
            o.ParameterName = "@Ville";
            o.DbType = DbType.String;
            SqlParameter q = new SqlParameter();
            q.Value = numero;
            q.ParameterName = "@Numero";
            q.DbType = DbType.Int32;
            SqlParameter r = new SqlParameter();
            r.Value = lieu;
            r.ParameterName = "@Lieu";
            r.DbType = DbType.String;
            SqlParameter a = new SqlParameter("@ID_Métro", DbType.Int32);
            a.Value = metro;
            SqlParameter b = new SqlParameter("@Code_Postal", DbType.Int32);
            b.Value = code;
            string query = "INSERT INTO Adresse(Id,ID_Cuisto,Ville,Numero,Lieu,Code_Postal,ID_Métro) VALUES(@Id,@ID_Cuisto,@Ville,@Numero,@Lieu,@Code_Postal,@ID_Métro);";
            SqlCommand c = connection.CreateCommand();
            c.CommandText = query;
            c.Parameters.Add(ad);
            c.Parameters.Add(m);
            c.Parameters.Add(o);
            c.Parameters.Add(q);
            c.Parameters.Add(r);
            c.Parameters.Add(a);
            c.Parameters.Add(b);
            
            c.Transaction = t;
            try
            {

                c.ExecuteNonQuery();
                t.Commit();
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
                t.Dispose();

            }

        }
        public void Adresse_Client_1(int id , int id_client, string ville, int numero, string lieu, int metro, string region, int code, int dept, string commune ,SqlTransaction t)
        {
            SqlParameter ad = new SqlParameter("@Id", DbType.Int32);
            ad.Value = id;
            SqlParameter m = new SqlParameter();
            m.Value = id_client;
            m.ParameterName = "@ID_Client";
            m.DbType = DbType.Int32;
            SqlParameter o = new SqlParameter();
            o.Value = ville;
            o.ParameterName = "@Ville";
            o.DbType = DbType.String;
            SqlParameter q = new SqlParameter();
            q.Value = numero;
            q.ParameterName = "@Numero";
            q.DbType = DbType.Int32;
            SqlParameter r = new SqlParameter();
            r.Value = lieu;
            r.ParameterName = "@Lieu";
            SqlParameter a = new SqlParameter("@Region", DbType.String);
            a.Value = region;
            SqlParameter b = new SqlParameter("@Code_Postal", DbType.Int32);
            b.Value = code;
            SqlParameter c = new SqlParameter("@Dept", DbType.Int32);
            c.Value = dept;
            SqlParameter d = new SqlParameter("@Commune", DbType.String);
            d.Value = commune;
            SqlParameter e = new SqlParameter("@ID_Métro", DbType.Int32);
            e.Value = metro;

            string query = "INSERT INTO Adresse(Id,ID_Client,Ville,Numero,Lieu,ID_Métro,Region,Code_Postal,Dept,Commune) VALUES(@Id,@ID_Client,@Ville,@Numero,@Lieu,@ID_Métro,@Region,@Code_Postal,@Dept,@Commune);";
            SqlCommand command = connection.CreateCommand();
            command.CommandText = query;
            command.Parameters.Add(ad);
            command.Parameters.Add(m);
            command.Parameters.Add(o);
            command.Parameters.Add(q);
            command.Parameters.Add(r);
            command.Parameters.Add(a);
            command.Parameters.Add(b);
            command.Parameters.Add(c);
            command.Parameters.Add(d);
            command.Parameters.Add(e);
          
            command.Transaction = t;
            try
            {

                command.ExecuteNonQuery();
                t.Commit();
                Console.Write("Insertion réussite");
            }


            catch (SqlException ex)
            {
                Console.WriteLine(" ErreurConnexion : " + ex.ToString());
                return;
            }
            finally
            {
                command.Dispose();
                t.Dispose();

            }
        }
            public void Adresse_Cuisto_1(int id, int id_cuisto, string ville, int numero, string lieu, int metro, string region, int code, int dept, string commune, SqlTransaction t)
        {
            SqlParameter ad = new SqlParameter("@Id", DbType.Int32);
            ad.Value = id;
            SqlParameter m = new SqlParameter();
            m.Value = id_cuisto;
            m.ParameterName = "@ID_Cuisto";
            m.DbType = DbType.Int32;
            SqlParameter o = new SqlParameter();
            o.Value = ville;
            o.ParameterName = "@Ville";
            o.DbType = DbType.String;
            SqlParameter q = new SqlParameter();
            q.Value = numero;
            q.ParameterName = "@Numero";
            q.DbType = DbType.Int32;
            SqlParameter r = new SqlParameter();
            r.Value = lieu;
            r.ParameterName = "@Lieu";
            SqlParameter a = new SqlParameter("@Region", DbType.String);
            a.Value = region;
            SqlParameter b = new SqlParameter("@Code_Postal", DbType.Int32);
            b.Value = code;
            SqlParameter c = new SqlParameter("@Dept", DbType.Int32);
            c.Value = dept;
            SqlParameter d = new SqlParameter("@Commune", DbType.String);
            d.Value = commune;
            SqlParameter e = new SqlParameter("@ID_Métro", DbType.Int32);
            e.Value = metro;

            string query = "INSERT INTO Adresse(Id,ID_Cuisto,Ville,Numero,Lieu,ID_Métro,Region,Code_Postal,Dept,Commune) VALUES(@Id,@ID_Cuisto,@Ville,@Numero,@Lieu,@ID_Métro,@Region,@Code_Postal,@Dept,@Commune);";
            SqlCommand command = connection.CreateCommand();
            command.CommandText = query;
            command.Parameters.Add(ad);
            command.Parameters.Add(m);
            command.Parameters.Add(o);
            command.Parameters.Add(q);
            command.Parameters.Add(r);
            command.Parameters.Add(a);
            command.Parameters.Add(b);
            command.Parameters.Add(c);
            command.Parameters.Add(d);
            command.Parameters.Add(e);
            command.Transaction = t;
            try
            {

                command.ExecuteNonQuery();
                t.Commit();
                Console.Write("Insertion réussite");
            }


            catch (SqlException ex)
            {
                Console.WriteLine(" ErreurConnexion : " + ex.ToString());
                return;
            }
            finally
            {
                command.Dispose();
                t.Dispose();

            }

        }
        #endregion
        #region Commandes
        public void File()
        {
            //Ecriture(table_1,table_1_csv);
            //Lecture_2_Fichier(table_1);
            void Ecriture(string file, string file_1)
            {

                StreamReader sr = new StreamReader(file_1);
                StreamWriter w = new StreamWriter(file);

                string m;
                string separateur = ",";
                string val = "";
                string v = "";

                while ((m = sr.ReadLine()) != null)
                {
                    string[] lignes = m.Split(separateur);

                    for (int j = lignes.Length; j < lignes.Length - 4; j--)
                    {
                        if (lignes[j] != null)
                        {
                            w.Write(lignes[j] + "|");
                        }

                    }

                    w.WriteLine();


                }
                w.Close();
                sr.Close();

            }
            void Lecture_2_Fichier(string file)
            {
                SqlBulkCopy insert = new SqlBulkCopy(connection);
                string table = "Commandes";
                insert.DestinationTableName = table;
                insert.SqlRowsCopied += Insert_SqlRowsCopied;
                DataTable M = new DataTable();
                Creation_Colonne();
                void Creation_Colonne()
                {
                    M.Columns.Add("ID_Commandes", typeof(int));
                    M.Columns.Add("ID_Client", typeof(int));
                    M.Columns.Add("ID_Cuisto", typeof(int));
                    M.Columns.Add("ID_Menu", typeof(int));
                    M.Columns.Add("Nb_2_Personnes", typeof(int));
                    M.Columns.Add("Pays d'origine", typeof(string));
                    M.Columns.Add("Regime", typeof(string));
                    M.Columns.Add("Date_depart", typeof(DateOnly));
                    M.Columns.Add("Date_arrivee", typeof(DateOnly));
                    M.Columns.Add("Prix", typeof(decimal));
                }

                using (StreamReader sr = new StreamReader(file))
                {
                    string m;

                    string separateur = "|";

                    while ((m = sr.ReadLine()) != null)
                    {
                        string[] lignes = m.Split(separateur);
                        DataRow row = M.NewRow();
                        for (int j = 0; j < lignes.Length; j++)
                        {
                            if (lignes[j] != null)
                            {
                                row[j] = lignes[j];
                                Console.Write(lignes[j]);
                            }



                        }
                        Console.WriteLine();
                        M.Rows.Add(row);

                    }


                    insert.WriteToServer(M);
                    insert.Close();
                    ;

                }


            }
        }
        public void Commandes(int id,int id_client,int id_cuisto,int nb , string menu, string pays,DateTime date_depart,DateTime date_arrivee,decimal prix_par_personne, string regime ,SqlTransaction t)
        {
            SqlParameter co = new SqlParameter();
            co.DbType = DbType.Int32;
            co.Value = id_cuisto;
            co.ParameterName = "@ID_Commandes";
            SqlParameter me = new SqlParameter();
            me.Value = menu;
            me.ParameterName = "@Nom_Menu";
            me.DbType = DbType.String;
            SqlParameter j = new SqlParameter();
            j.DbType = DbType.Int32;
            j.Value = id_client;
            j.ParameterName = "@ID_Client";
            SqlParameter a = new SqlParameter();
            a.DbType = DbType.Int32;
            a.Value = id_cuisto;
            a.ParameterName = "@ID_Cuisto";
            SqlParameter p = new SqlParameter();
            p.DbType = DbType.Int32;
            p.Value = nb;
            p.ParameterName = "@Nombre_de_Personnes";
            SqlParameter m = new SqlParameter();
            m.Value = pays;
            m.ParameterName = "@Pays_d_origine";
            m.DbType = DbType.String;
            SqlParameter o = new SqlParameter();
            o.Value = date_depart;
            o.DbType = DbType.DateTime;
            o.ParameterName = "@Date_Depart";
            SqlParameter q = new SqlParameter();
            q.Value = date_arrivee;
            q.ParameterName = "@Date_Arrivee";
            q.DbType = DbType.DateTime;
            SqlParameter r = new SqlParameter();
            r.Value = prix_par_personne;
            r.ParameterName = "@Prix_Unitaire";
            r.DbType = DbType.Decimal;
            SqlParameter s = new SqlParameter();
            s.Value = regime;
            s.ParameterName = "@Regime";
            s.DbType = DbType.String;
            string query = "INSERT INTO Commande(ID_Commandes,Nom_Menu,ID_Client,ID_Cuisto,Nb_de_Personnes,Pays_d_origine,Date_Depart,Date_Arrivee,Prix_Unitaire,Regime))" +
                "VALUES(@ID_Commandes,@Nom_Menu,@ID_Client,@ID_Cuisto,@Nombre_de_Personnes,@Pays_d_origine,@Date_Depart,@Date_Arrivee,@Prix_Unitaire,@Regime)\r\n;";
                ;
            SqlCommand c = connection.CreateCommand();
            c.CommandText = query;
            c.Parameters.Add(p);
            c.Parameters.Add(m);
            c.Parameters.Add(o);
            c.Parameters.Add(r);
            c.Parameters.Add(q);
            c.Parameters.Add(j);
            c.Parameters.Add(a);
            c.Parameters.Add(s);
            c.Parameters.Add(me);
            c.Parameters.Add(co);
            c.Transaction = t;
            try
            {

                c.ExecuteNonQuery();
                t.Commit();
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
                t.Dispose();
            }



        }

        public void Commandes_1(int id ,int nb,int id_client , int id_cuisto,decimal prix,string menu, SqlTransaction t)
        {
            SqlParameter com = new SqlParameter();
            com.DbType = DbType.Int32;
            com.Value = id;
            com.ParameterName = "@ID_Commandes";
            SqlParameter j = new SqlParameter();
            j.DbType = DbType.Int32;
            j.Value = id_client;
            j.ParameterName = "@ID_Client";
            SqlParameter a = new SqlParameter();
            a.DbType = DbType.Int32;
            a.Value = id_cuisto;
            a.ParameterName = "@ID_Cuisto";
            SqlParameter p = new SqlParameter();
            p.DbType = DbType.Int32;
            p.Value = nb;
            p.ParameterName = "@Nombre_de_Personnes";
            SqlParameter pri = new SqlParameter("@Prix_Unitaire", DbType.Decimal);
            pri.Value = prix;
            SqlParameter m = new SqlParameter();
            m.Value = menu;
            m.ParameterName = "@Nom_Menu";
            m.DbType = DbType.String;
            string query = "INSERT INTO Commande(ID_Commandes,Nom_Menu,ID_Client,ID_Cuisto,Nb_de_Personnes,Prix_Unitaire)\r\nVALUES (@ID_Commandes,@Nom_Menu,@ID_Client,@ID_Cuisto,@Nombre_de_Personnes,@Prix_Unitaire);";
            SqlCommand c = connection.CreateCommand();
            c.CommandText = query;
            c.Parameters.Add(p);
            c.Parameters.Add(j);
            c.Parameters.Add(a);
            c.Parameters.Add(m);
            c.Parameters.Add(com);
            c.Parameters.Add(pri);
            c.Transaction = t;
            try
            {

                c.ExecuteNonQuery();
                t.Commit();
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
                t.Dispose();
            }



        }
        private static void Insert_SqlRowsCopied(object sender, SqlRowsCopiedEventArgs e)
        {
            throw new NotImplementedException();
        }

        #endregion
        #region Application_Site

        public void App(int id_cuisto,string menu,int id , string mdp, SqlTransaction t)
        {
            SqlParameter p = new SqlParameter();
            p.Value = mdp;
            p.ParameterName = "@Mdp";
            p.DbType = DbType.String;
            SqlParameter a = new SqlParameter();
            a.DbType = DbType.Int32;
            a.Value = id_cuisto;
            a.ParameterName = "@ID_Cuisto";
            SqlParameter men = new SqlParameter();
            men.Value = menu;
            men.ParameterName = "@Nom_Menu";
            men.DbType = DbType.String;
            SqlParameter app = new SqlParameter();
            app.DbType = DbType.Int32;
            app.Value = id;
            app.ParameterName = "@ID_Application";
            string query = "INSERT INTO Application_Site(ID_Application,Nom_Menu,ID_Cuisto,Mdp)\r\nVALUES(@ID_Application,@Nom_Menu,@ID_Cuisto,@Mdp);";
            SqlCommand c = connection.CreateCommand();
            c.CommandText = query;
            c.Parameters.Add(p);
            c.Parameters.Add(a);
            c.Parameters.Add(men);
            c.Parameters.Add(app);
            c.Transaction = t;
            try
            {

                c.ExecuteNonQuery();
                t.Commit();
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
                t.Dispose();
            }
        }

        public void App_Client(int id_client,int id, string mdp , SqlTransaction t)
        {
            SqlParameter p = new SqlParameter();
            p.Value = mdp;
            p.ParameterName = "@Mdp";
            p.DbType = DbType.String;
            SqlParameter a = new SqlParameter();
            a.DbType = DbType.Int32;
            a.Value = id_client;
            a.ParameterName = "@ID_Client";
            SqlParameter app = new SqlParameter();
            app.DbType = DbType.Int32;
            app.Value = id;
            app.ParameterName = "@ID_Application";
            string query = "INSERT INTO Application_Site(ID_Application,ID_Client,Mdp)\r\nVALUES(@ID_Application,@ID_Client,@Mdp);";
            SqlCommand c = connection.CreateCommand();
            c.CommandText = query;
            c.Parameters.Add(p);
            c.Parameters.Add(a);
            c.Parameters.Add(app);
            c.Transaction = t;
            try
            {

                c.ExecuteNonQuery();
                t.Commit();
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
                t.Dispose();
            }
        }

        #endregion

        #region Catalogue
        public void Catalogue(int id_c,int id_cui,int id_com,SqlTransaction t)
        {
            SqlParameter com = new SqlParameter();
            com.DbType = DbType.Int32;
            com.Value = id_com;
            com.ParameterName = "@ID_Commandes";
            SqlParameter j = new SqlParameter();
            j.DbType = DbType.Int32;
            j.Value = id_c;
            j.ParameterName = "@ID_Client";
            SqlParameter a = new SqlParameter();
            a.DbType = DbType.Int32;
            a.Value = id_cui;
            a.ParameterName = "@ID_Cuisto";
            string q = "INSERT INTO Catalogue(ID_Client,ID_Cuisto,ID_Commandes)\r\nVALUES(@ID_Client,@ID_Cuisto,@ID_Commandes)";
            SqlCommand c = new SqlCommand(q, connection);
            c.Parameters.Add(j);
            c.Parameters.Add(a);
            c.Parameters.Add(com);
            c.Transaction = t;
            try
            {

                c.ExecuteNonQuery();
                t.Commit();
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
                t.Dispose();
            }
        }

        #endregion

        #region Contenu du Menu

        public void Contenu_du_Menu(string nom, SqlTransaction t)
        {
            SqlParameter p = new SqlParameter();
            p.DbType = DbType.Int32;
            p.Value = nom;
            p.ParameterName = "@Nom_Menu";
            p.DbType = DbType.String;
            string query = "INSERT INTO Contenu_du_Menu(ID_Menu,ID_Entree,ID_Plat,ID_Dessert,Nom_Menu)\r\nSELECT  ROW_NUMBER()OVER(ORDER BY e.ID_Entree,p.ID_Plat,d.ID_Dessert),e.ID_Entree,p.ID_Plat,d.ID_Dessert,@Nom_Menu\r\nFROM Entree as e ,Plat as p ,Dessert as d\r\ngroup by  e.ID_Entree,p.ID_Plat,d.ID_Dessert;";
            SqlCommand c = connection.CreateCommand();
            c.CommandText = query;
            c.Parameters.Add(p);
            c.Transaction = t;
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
               
            }
        }





        #endregion

        #region Entree

        public void Lecture_2_Fichier(string file)
        {
            
            SqlBulkCopy insert = new SqlBulkCopy(connection);
            string table = "Entree";
            insert.DestinationTableName = table;
            insert.SqlRowsCopied += Insert_SqlRowsCopied;
            DataTable M = new DataTable();
            Creation_Colonne();
            void Creation_Colonne()
            {
                M.Columns.Add("Nom_Entree", typeof(string));
                M.Columns.Add("ID_Entree", typeof(int));
                M.Columns.Add("ID_Ingredient", typeof(int));
                M.Columns.Add("ID_Volume", typeof(int));
                
            }

            using (StreamReader sr = new StreamReader(file))
            {
                string m;

                string separateur = "|";
                
                while ((m = sr.ReadLine()) != null)
                {
                    string[] lignes = m.Split(separateur);
                    DataRow row = M.NewRow();
                    for (int j = 0; j < lignes.Length - 1; j++)
                    {
                        if (lignes[j] != null  )
                        {
                            row[j] = lignes[j];
                            Console.Write(lignes[j] + "|");
                        }



                    }
                    Console.WriteLine();
                    M.Rows.Add(row);

                }


                insert.WriteToServer(M);
                insert.Close();
                ;

            }


        }




        #endregion

        #region Plat


        public void Lecture_2_Fichier_Plat(string file)
        {

            SqlBulkCopy insert = new SqlBulkCopy(connection);
            string table = "Plat";
            insert.DestinationTableName = table;
            insert.SqlRowsCopied += Insert_SqlRowsCopied;
            DataTable M = new DataTable();
            Creation_Colonne();
            void Creation_Colonne()
            {
                M.Columns.Add("Nom_Plat", typeof(string));
                M.Columns.Add("ID_Plat", typeof(int));
                M.Columns.Add("ID_Ingredient", typeof(int));
                M.Columns.Add("ID_Volume", typeof(int));

            }

            using (StreamReader sr = new StreamReader(file))
            {
                string m;

                string separateur = "|";

                while ((m = sr.ReadLine()) != null)
                {
                    string[] lignes = m.Split(separateur);
                    DataRow row = M.NewRow();
                    for (int j = 0; j < lignes.Length - 1; j++)
                    {
                        if (lignes[j] != null)
                        {
                            row[j] = lignes[j];
                            Console.Write(lignes[j] + "|");
                        }



                    }
                    Console.WriteLine();
                    M.Rows.Add(row);

                }


                insert.WriteToServer(M);
                insert.Close();
                ;

            }


        }



        #endregion

        #region Dessert



        public void Lecture_2_Fichier_Dessert(string file)
        {

            SqlBulkCopy insert = new SqlBulkCopy(connection);
            string table = "Dessert";
            insert.DestinationTableName = table;
            insert.SqlRowsCopied += Insert_SqlRowsCopied;
            DataTable M = new DataTable();
            Creation_Colonne();
            void Creation_Colonne()
            {
                M.Columns.Add("Nom_Dessert", typeof(string));
                M.Columns.Add("ID_Dessert", typeof(int));
                M.Columns.Add("ID_Ingredient", typeof(int));
                M.Columns.Add("ID_Volume", typeof(int));

            }

            using (StreamReader sr = new StreamReader(file))
            {
                string m;

                string separateur = "|";

                while ((m = sr.ReadLine()) != null)
                {
                    string[] lignes = m.Split(separateur);
                    DataRow row = M.NewRow();
                    for (int j = 0; j < lignes.Length - 1; j++)
                    {
                        if (lignes[j] != null)
                        {
                            row[j] = lignes[j];
                            Console.Write(lignes[j] + "|");
                        }



                    }
                    Console.WriteLine();
                    M.Rows.Add(row);

                }


                insert.WriteToServer(M);
                insert.Close();
                ;

            }


        }

        #endregion

        #region Ingredient

        public void Ingredient(int id, string ingredient,int quantite,SqlTransaction t)
        {
            SqlParameter p = new SqlParameter();
            p.DbType = DbType.Int32;
            p.Value = id;
            p.ParameterName = "@ID_Ingredient";
            p.DbType = DbType.String;
            SqlParameter m = new SqlParameter();
            m.Value = ingredient;
            m.ParameterName = "@Ingredient";
            m.DbType = DbType.String;
            SqlParameter o = new SqlParameter();
            o.DbType = DbType.Int32;
            o.Value = quantite;
            o.ParameterName = "@Quantite";
            

            string query = "INSERT INTO Ingredient(ID_Ingredient,Ingredient,Quantite) VALUES(@ID_Ingredient,@Ingredient,@Quantite);";
            SqlCommand c = connection.CreateCommand();
            c.CommandText = query;
            c.Parameters.Add(p);
            c.Parameters.Add(m);
            c.Parameters.Add(o);
            c.Transaction = t;

            try
            {

                c.ExecuteNonQuery();
                Console.Write("Insertion réussite");

            }

            catch (SqlException e)
            {
                Console.WriteLine(" ErreurConnexion : " + e.ToString());
                
            }
            finally
            {
                c.Dispose();
                
            }
        }
        public void Ingredient(int id, string ingredient, int quantite,DateTime fabrication , DateTime peremption , SqlTransaction t)
        {
            SqlParameter p = new SqlParameter();
            p.DbType = DbType.Int32;
            p.Value = id;
            p.ParameterName = "@ID_Ingredient";
            p.DbType = DbType.String;
            SqlParameter m = new SqlParameter();
            m.Value = ingredient;
            m.ParameterName = "@Ingredient";
            m.DbType = DbType.String;
            SqlParameter o = new SqlParameter();
            o.DbType = DbType.Int32;
            o.Value = quantite;
            o.ParameterName = "@Quantite";
            SqlParameter fab = new SqlParameter();
            fab.DbType = DbType.DateTime;
            fab.Value = fabrication;
            fab.ParameterName = "@Date_2_Fabrication";
            SqlParameter per = new SqlParameter();
            per.DbType = DbType.DateTime;
            per.Value = peremption;
            per.ParameterName = "@Date_2_Peremption";

            string query = "INSERT INTO Ingredient(ID_Ingredient,Ingredient,Quantite,Date_2_Fabrication,Date_2_Peremption) VALUES(@ID_Ingredient,@Ingredient,@Quantite,@Date_2_Fabrication,@Date_2_Peremption);";
            SqlCommand c = connection.CreateCommand();
            c.CommandText = query;
            c.Parameters.Add(p);
            c.Parameters.Add(m);
            c.Parameters.Add(o);
            c.Parameters.Add(fab);
            c.Parameters.Add(per);
            c.Transaction = t;

            try
            {

                c.ExecuteNonQuery();
                Console.Write("Insertion réussite");

            }

            catch (SqlException e)
            {
                Console.WriteLine(" ErreurConnexion : " + e.ToString());
         
                
            }
            finally
            {
                c.Dispose();

            }
        }
        public void Lecture_Ingredient_1(SqlTransaction t)
        {
            try
            {


                string selecton_ing = "SELECT * FROM Ingredient;";  
                SqlCommand command2 = new SqlCommand(selecton_ing, connection);
                command2.Transaction = t;
                SqlDataReader read = command2.ExecuteReader();
                string[] valueString = new string[read.FieldCount];
              

                while (read.Read())


                {
                    int ID = (int)read["ID_Ingredient"];
                    string ingredient = (string)read["Ingredient"];
                    DateTime f = (DateTime)read["Date_2_Fabrication"];
                    DateTime p = (DateTime)read["Date_2_Peremption"];
                    int Q = (int)read["Quantite"];
                    Console.WriteLine($"{ID},{ingredient},{Q},{f},{p}");
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
        public void Lecture_Ingredient(SqlTransaction t)
        {
            try
            {


                string selecton_ing = "SELECT * FROM Ingredient ;";
                SqlCommand command2 = new SqlCommand(selecton_ing, connection);
                command2.Transaction = t;
                SqlDataReader read = command2.ExecuteReader();
                string[] valueString = new string[read.FieldCount];
               

                while (read.Read())


                {
                    int ID = (int)read["ID_Ingredient"];
                    string ingredient = (string)read["Ingredient"];
                    int Q = (int)read["Quantite"];
                    Console.WriteLine($"{ID},{ingredient},{Q}");
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



        #endregion

        #region Volume

        public void Volume(int id,  decimal volume , string unite, SqlTransaction t)
        {
            SqlParameter p = new SqlParameter();
            p.DbType = DbType.Int32;
            p.Value = id;
            p.ParameterName = "@ID_Volume";
            p.DbType = DbType.Int32;
            SqlParameter m = new SqlParameter();
            m.Value = volume;
            m.ParameterName = "@Volume";
            m.DbType = DbType.Decimal;
            SqlParameter o = new SqlParameter();
            o.Value = unite;
            o.ParameterName = "@Unite_de_mesure";
            o.DbType = DbType.String;

            string query = "INSERT INTO Volume(ID_Volume,Volume,Unite_de_mesure) VALUES(@ID_Volume,@Volume,@Unite_de_mesure);";
            SqlCommand c = connection.CreateCommand();
            c.CommandText = query;
            c.Parameters.Add(p);
            c.Parameters.Add(m);
            c.Parameters.Add(o);
            c.Transaction = t;
            try
            {

                c.ExecuteNonQuery();
                Console.Write("Insertion réussite");

            }

            catch (SqlException e)
            {
                Console.WriteLine(" ErreurConnexion : " + e.ToString());
                
            }
            finally
            {
                c.Dispose();
                
            }

        }
        public void Lecture_Volume(SqlTransaction t)
        {
            try
            {


                string selecton_ing = "SELECT * FROM Volume;";
                SqlCommand command2 = new SqlCommand(selecton_ing, connection);
                command2.Transaction = t;
                SqlDataReader read = command2.ExecuteReader();
                string[] valueString = new string[read.FieldCount];
                

                while (read.Read())


                {
                    int ID = (int)read["ID_Volume"];
                    decimal volume = (decimal)read["Volume"];
                    string unite = (string)read["Unite_de_mesure"];
                    //DateTime mylastupdate = (DateTime)read["mydate"];
                    Console.WriteLine($"{ID},{volume},{unite}");
                    string val = "";
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
        public void Lecture_Ingredient_Volume()
        {

        }

       public void Fermeture()
        { connection.Close(); }

        #endregion
    }
    

}


