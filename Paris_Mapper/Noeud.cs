using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Security.Principal;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Paris_Mapper
{
    public  class Noeud<T>
    {

        static Graphe<T> graphe = new Graphe<T>();
        Tuple<double,double> coordonnees;
        SortedList<T, List<T>> pred = new SortedList<T, List<T>>();
        SortedList<T, List<T>> succ = new SortedList<T, List<T>>();
        List<string> correspondance = new List<string>();
        string commune;
        string station;
        double numero_2_ligne;
        int code_postal;
        int degre;
        Color couleur = new Color();
        int niveau;
        DateTime date_dec;
        DateTime date_fin;
        T id;
        public Noeud()
        {

            Tuple<double, double> coordonnees;
            SortedList<T, List<T>> pred = new SortedList<T, List<T>>();
            SortedList<T, List<T>> succ = new SortedList<T, List<T>>();
            List<string> correspondance = new List<string>();
            string commune;
            string station;
            int numero_2_ligne;
            int code_postal;
            int degre ;
            Color couleur = new Color();
            int niveau;
            DateTime date_dec;
            DateTime date_fin;
            T id;

        }
        public Noeud(T sommet)
        {

            id = sommet;
            this.couleur = Color.White;
           //this.pred = new SortedList<T, T>(34);
           //this.degre = Calcul_Degre(sommet);
            this.niveau  = 0;
            this.date_fin = Fin();
            this.date_dec = Decouverte();
        }
        

        public int Degre
        {
            get { return degre; }
            set
            {
                degre = value; 
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public int Niveau

        {
            get { return niveau; }
            set { this.niveau = value; }
        }

        public List<string> Correspondance
        {
            get {return this.correspondance; }
            set { this.correspondance = value; }
        }
        public Tuple<double, double> Coordonnees
        {
            get { return this.coordonnees; }
            set { this.coordonnees = value; }
        }
        public string Commune
        {
            get { return this.commune; }
            set { this.commune = value; }
        }
        public string Station
        {
            get { return this.station; }
            set { this.station = value; }
        }
        public double Numero_2_ligne
        {
            get { return this.numero_2_ligne; }
            set { this.numero_2_ligne = value; }
        }
        public int Code_Postal
        {
            get { return this.code_postal; }
            set { this.code_postal = value; }
        }
        public T ID
        {
            get { return id; }
            set { id = value; }
        }

        public Color Couleur
        {
            get { return couleur; }
            set { couleur = value; }
        }

        public DateTime date_Dec
        {
            get { return date_dec; }
            set { date_dec = value; }
        }
        public DateTime date_Fin
        {
            get { return date_fin; }
            set { date_fin = value; }
        }

        public SortedList<T, List<T>> Pred
        {
            get { return pred; }
            set { pred = value; }
        }
        public SortedList<T, List<T>> Succ
        {
            get { return pred; }
            set { pred = value; }
        }

        public bool Egale(T a, T b)
        {
            if (a.ToString().Equals(b.ToString()))
            {
                return true;
            }
            return false;
        }
        public bool Egale(int a, int b)
        {
            if (a == b)
            {
                return true;
            }
            return false;
        }
        public bool Inferieur(int a, int b)
        {
            if ( a < b)
            {
                return true;
            }
            return false;
        }

        public DateTime Fin()
        {
            if (this.couleur == Color.Red)
            {
                double s = Convert.ToDouble(id);
                DateTime d = date_Dec;
                DateInterval i = DateInterval.Second;
                this.date_fin = (DateAndTime.DateAdd(i, s, d));
            }
            return this.date_fin;
        }

        public DateTime Decouverte()
        {

            if (this.couleur == Color.Yellow)
            {
                double s = Convert.ToDouble(id);
                DateTime d = DateTime.Now;
                DateInterval i = DateInterval.Second;
                this.date_dec = (DateAndTime.DateAdd(i, s, d));
            }
            return this.date_dec;
        }
        
        public int Calcul_Degre(T id)
        {
           
            int nb_succ = graphe.Succ[id].Count;
            int nb_pred = graphe.Pred[id].Count;
            int deg = 0;

            foreach (var suc in graphe.Succ[id])
            {

                foreach (var pred in graphe.Pred[id])
                {

                    while (nb_pred > 0 && nb_succ > 0)
                    {
                        deg++;
                        nb_succ--;
                        nb_pred--;
                    }
                }
            }
            return deg;
        }
        public int Calcul_Degre()
        {

            int nb_succ = graphe.Succ[id].Count;
            int nb_pred = graphe.Pred[id].Count;
            int deg = 0;

            foreach (var suc in graphe.Succ[id])
            {

                foreach (var pred in graphe.Pred[id])
                {

                    while (nb_pred > 0 && nb_succ > 0)
                    {
                        deg++;
                        nb_succ--;
                        nb_pred--;
                    }
                }
            }
            return deg;
        }

    }

}
