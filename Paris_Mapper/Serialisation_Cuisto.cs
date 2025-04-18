using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paris_Mapper
{
    class Serialisation_Cuisto
    {
        int id;
        private string nom;
        private string prenom;
        string email;
        string telephone;
        string adresse;

        public Serialisation_Cuisto(int id,string nom, string prenom, string email, string telephone, string adresse)
        {
            this.id = id;
            this.nom = nom;
            this.prenom = prenom;
            this.email = email;
            this.telephone = telephone;
            this.adresse = adresse;
        }
        public Serialisation_Cuisto()
        {

        }
        public int ID
        {
            get { return id; }
            set { id = value; }
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
