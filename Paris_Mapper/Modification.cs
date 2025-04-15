using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
using System.Collections;
using Org.BouncyCastle.Tls.Crypto;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;

namespace Paris_Mapper
{
    class Modification
    {
        string connexion;
        SqlConnection connection;
         public Modification(string connexion , SqlConnection connection)
        {
            this.connexion = connexion;
            this.connection = connection;
           
        }
        #region Client
        public void Client(int id , string prenom = null,string email = null, string nom = null , string numero = null)
        {

            SqlCommand b = connection.CreateCommand();
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
            q.Value = numero;
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
            string query = "UPDATE Client SET ";
            if (nom != null)
            {
                query += "Nom = '@Nom'";
                b.Parameters.Add(o);
            }
            if (prenom != null)
            {
                query += "Prenom = '@Prenom'";
                b.Parameters.Add(m);
            }
            if (numero != null)
            {
                query += "Telephone = '@Telephone'";
                b.Parameters.Add(r);
            }
            if (email != null)
            {

                query += "Email = '@Email'";
                b.Parameters.Add(q);
            }
            query += "WHERE ID_Client = @ID_Client";
            b.CommandText = query;
            b.CommandType = CommandType.Text;
            b.Parameters.Add(p);
            
          
           
            
            try
            {
                b.ExecuteNonQuery();
                Console.WriteLine("Modification réussi");
                

                
            }
            catch(SqlException ex)
            {
                Console.WriteLine(" ErreurConnexion : " + ex.ToString());
                return;
            }
            finally
            {
                b.Dispose();
             
                
            }

        }
        public void Client_1()
        {
            
            string q = "UPDATE Client\r\nSET Adresse = CONCAT_WS(',',a.Numero,a.Lieu,a.Code_Postal,a.Ville,a.Region) FROM Adresse_Client a\r\nWHERE Client.ID_Client = a.ID_Client;";
            SqlCommand c = new SqlCommand(q, connection);
            
            try
            {
                c.ExecuteNonQuery();
            }
            catch(SqlException ex)
            {
                Console.WriteLine(" ErreurConnexion : " + ex.ToString());
                return;
            }
            finally
            {
                c.Dispose();
            }
        }
        #endregion
        #region Cuisinier
        public void Cuisto(int id_1 , string prenom_1 = null,string nom_1 = null,string numero_1 = null,string email_1 = null)
        {
            SqlCommand b = connection.CreateCommand();
            SqlParameter p = new SqlParameter();
            p.DbType = DbType.Int32;
            p.Value = id_1;
            p.ParameterName = "@ID_Cuisto";
            p.Direction = ParameterDirection.Input;
            p.SourceColumn = "ID_Cuisto";
            SqlParameter m = new SqlParameter();
            m.Value = prenom_1;
            m.ParameterName = "@Prenom";
            m.Direction = ParameterDirection.Input;
            m.SourceColumn = "Prenom";
            m.DbType = DbType.String;
            SqlParameter o = new SqlParameter();
            o.Value = nom_1;
            o.ParameterName = "@Nom";
            o.Direction = ParameterDirection.Input;
            o.SourceColumn = "Nom";
            o.DbType = DbType.String;
            SqlParameter q = new SqlParameter();
            q.Value = numero_1;
            q.ParameterName = "@Telephone";
            q.Direction = ParameterDirection.Input;
            q.SourceColumn = "Telephone";
            q.DbType = DbType.String;
            q.Size = 10;
            SqlParameter r = new SqlParameter();
            r.Value = email_1;
            r.ParameterName = "@Email";
            r.Direction = ParameterDirection.Input;
            r.SourceColumn = "Email";
            r.DbType = DbType.String;
            string query = "UPDATE Cuisto SET ";
            if (nom_1 != null)
            {
                query += "Nom = '@Nom'";
                b.Parameters.Add(o);
            }
            if (prenom_1 != null)
            {
                query += "Prenom = '@Prenom'";
                b.Parameters.Add(m);
            }
            if (numero_1 != null)
            {
                query += "Telephone = '@Telephone'";
                b.Parameters.Add(r);
            }
            if (email_1 != null)
            {

                query += "Email = '@Email'";
                b.Parameters.Add(q);
            }
            query += "WHERE ID_Cuisto = @ID_Cuisto";
            b.CommandText = query;
            b.CommandType = CommandType.Text;
            b.Parameters.Add(p);




            try
            {
                b.ExecuteNonQuery();
                Console.WriteLine("Modification réussi");



            }
            catch (SqlException ex)
            {
                Console.WriteLine(" ErreurConnexion : " + ex.ToString());
                return;
            }
            finally
            {
                b.Dispose();

                connection.Close();
            }
        }
        #region Adresse
        public void Adresse(int id_a)
        {

        }
        #endregion
        #endregion
        #region Commandes
        #region Entree

        #endregion
        #region Plat 

        #endregion

        #region Dessert

        #endregion
        #endregion
    }
}
