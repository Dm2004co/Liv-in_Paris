using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
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

namespace Paris_Mapper
{
    class Suppression
    {

        string connexion;
        SqlConnection connection;
         public Suppression(string connexion , SqlConnection connection)
        {
            this.connexion = connexion;
            this.connection = connection;
        }
        #region Personne
        public void Client(int id)
        {

            SqlParameter p = new SqlParameter();
            p.Value = id;
            p.ParameterName = "@ID_Client";
            p.Direction = ParameterDirection.InputOutput;
            p.SourceColumn = "ID_Client";
            string query = "DELETE FROM Client where ID_Client = @ID_Client";
            SqlCommand c = new SqlCommand(query, connection);
            c.Parameters.Add(p);
            try
            {

                c.ExecuteNonQuery();
                Console.WriteLine("Suppresion réussi");

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
        public void Cuisinier(int id)
        {

            SqlParameter p = new SqlParameter();
            p.Value = id;
            p.ParameterName = "@ID_Cuisto";
            p.Direction = ParameterDirection.InputOutput;
            p.SourceColumn = "ID_Cuisto";
            string query = "DELETE FROM Cuisto where ID_Cuisto = @ID_Cuisto";
            SqlCommand c = new SqlCommand(query, connection);
            c.Parameters.Add(p);
            try
            {

                c.ExecuteNonQuery();
                Console.WriteLine("Suppresion réussi");

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
        public void Commande(int id)
        {

            SqlParameter p = new SqlParameter();
            p.Value = id;
            p.ParameterName = "@ID_Commandes";
            p.Direction = ParameterDirection.InputOutput;
            p.SourceColumn = "ID_Commandes";
            string query = "DELETE FROM Commandes where ID_Commandes = @ID_Commandes";
            SqlCommand c = new SqlCommand(query, connection);
            c.Parameters.Add(p);
            try
            {

                c.ExecuteNonQuery();
                Console.WriteLine("Suppresion réussi");

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
        public void Adresse(int id)
        {

            SqlParameter p = new SqlParameter();
            p.Value = id;
            p.ParameterName = "@Id";
            p.DbType = DbType.Int32;
            string query = "DELETE FROM Adresse where Id = @Id";
            SqlCommand c = new SqlCommand(query, connection);
            c.Parameters.Add(p);
            try
            {

                c.ExecuteNonQuery();
                Console.WriteLine("Suppresion réussi");

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
        #region Repas
        public void Entree(int id)
        {

            SqlParameter p = new SqlParameter();
            p.Value = id;
            p.ParameterName = "@ID_Entree";
            p.DbType = DbType.Int32;
            string query = "DELETE FROM Entree where ID_Entree = @ID_Entree";
            SqlCommand c = new SqlCommand(query, connection);
            c.Parameters.Add(p);
            try
            {

                c.ExecuteNonQuery();
                Console.WriteLine("Suppresion réussi");

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
            }

        }
        public void Plat(int id)
        {

            SqlParameter p = new SqlParameter();
            p.Value = id;
            p.ParameterName = "@ID_Plat";
            p.DbType = DbType.Int32;
            string query = "DELETE FROM Plat where ID_Plat = @ID_Plat";
            SqlCommand c = new SqlCommand(query, connection);
            c.Parameters.Add(p);
            try
            {

                c.ExecuteNonQuery();
                Console.WriteLine("Suppresion réussi");

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
            }

        }
        public void Dessert(int id)
        {

            SqlParameter p = new SqlParameter();
            p.Value = id;
            p.ParameterName = "@ID_Dessert";
            p.DbType = DbType.Int32;
            string query = "DELETE FROM Dessert where ID_Dessert = @ID_Dessert";
            SqlCommand c = new SqlCommand(query, connection);
            c.Parameters.Add(p);
            try
            {

                c.ExecuteNonQuery();
                Console.WriteLine("Suppresion réussi");

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
            }

        }

        #endregion
        public void Ingredient(int id)
        {

            SqlParameter p = new SqlParameter();
            p.Value = id;
            p.ParameterName = "@ID_Ingredient";
            p.DbType = DbType.Int32;
            string query = "DELETE FROM Ingredient where ID_Ingredient = @ID_Ingredient";
            SqlCommand c = new SqlCommand(query, connection);
            c.Parameters.Add(p);
            try
            {

                c.ExecuteNonQuery();
                Console.WriteLine("Suppresion réussi");

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
            }

        }
        public void Volume (int id)
        {

            SqlParameter p = new SqlParameter();
            p.Value = id;
            p.ParameterName = "@ID_Volume";
            p.DbType = DbType.Int32;
            string query = "DELETE FROM Volume where ID_Volume = @ID_Volume";
            SqlCommand c = new SqlCommand(query, connection);
            c.Parameters.Add(p);
            try
            {

                c.ExecuteNonQuery();
                Console.WriteLine("Suppresion réussi");

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
            }

        }
        public void Menu(int id)
        {

            SqlParameter p = new SqlParameter();
            p.Value = id;
            p.ParameterName = "@ID_Menu";
            p.DbType = DbType.Int32;
            string query = "DELETE FROM Contenu_du_Menu as menu where ID_Menu = @ID_Menu";
            SqlCommand c = new SqlCommand(query, connection);
            c.Parameters.Add(p);
            try
            {

                c.ExecuteNonQuery();
                Console.WriteLine("Suppresion réussi");

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
            }

        }
        public void Application(int id)
        {

            SqlParameter p = new SqlParameter();
            p.Value = id;
            p.ParameterName = "@ID_Application";
            p.DbType = DbType.Int32;
            string query = "DELETE FROM Application where ID_Application = @ID_Application";
            SqlCommand c = new SqlCommand(query, connection);
            c.Parameters.Add(p);
            try
            {

                c.ExecuteNonQuery();
                Console.WriteLine("Suppresion réussi");

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
            }
            

        }
        public void Fermeture()
        { connection.Close(); }

    }
}

