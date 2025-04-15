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
using Newtonsoft.Json;

namespace Paris_Mapper
{
    class Serialisation_Client
    {

        private string nom;
        private string prenom;
        string email;
        string telephone;
        string adresse;

        public Serialisation_Client(string nom, string prenom, string email, string telephone, string adresse)
        {
            this.nom = nom;
            this.prenom = prenom;
            this.email = email;
            this.telephone = telephone;
            this.adresse = adresse;
        }
        public Serialisation_Client()
        {
           
        }

        public string Nom

        {
            get { return nom; }
            set { nom = value; }
        }
        public string Prenom
        {
            get { return prenom; }
            set { prenom = value; }
        }

        public string Email
        {
            get { return this.email; }
            set { this.email = value; }
        }

        public string Telephone
        {
            get { return this.telephone; }
            set { this.telephone = value; }
        }
        public string Adresse
        {
            get { return this.adresse; }
            set { this.adresse = value; }
        }
        override public string ToString()
        {
            return nom + " " + prenom;
        }

    }
}
