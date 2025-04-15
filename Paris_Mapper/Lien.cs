using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Paris_Mapper
{
    internal class Lien<T>
    {
        static Graphe<T> graphe = new Graphe<T>();
        Tuple<T,T> arete;
        Tuple<double, double> coor;
        bool orientation;
        bool ponderation;
        double distance;
        int poids;
        //Noeud n = new Noeud();
        /// <summary>
        /// Constructeur naturel de la classe Lien
        /// </summary>
        public Lien()
        {
            //this.arete = (typeof(Lien),typeof(Lien));
            this.orientation = true;
            this.ponderation = true;
            this.distance = 0;
        }

        public Lien(Noeud<T> n)
        {
            this.orientation = false;
            this.ponderation = false;
            this.poids = 0;
            this.distance = this.poids;
        }
        public Lien(Noeud<T> a , Noeud <T> b)
        {
            arete = Tuple.Create(a.ID,b.ID);
            this.orientation = true;
            this.ponderation = true;
            this.distance = Calcul_Distance(a,b);
        }
        /// <summary>
        /// Propirete d'une arete
        /// </summary>
        public Tuple<T, T> Arete
        {
            get { return this.arete; }
            set { this.arete = value; }
        }
        /// <summary>
        /// Propirete de la liste d'aretes
        /// </summary>

        /// <summary>
        /// Propirete de l'orientation d'un graphe
        /// </summary>
        public bool Orientation
        {
            get { return this.orientation; }
        }
        /// <summary>
        /// Propirete de la ponderation d'un graphe
        /// </summary>
        public bool Ponderation
        {
            get { return this.ponderation; }
        }
        public double Distance
        {
            get { return this.distance; }
            set { this.distance = value; }
        }

        public double Calcul_Poids(Noeud<T> a, Noeud<T> b)
        {
            double poids = 0;
            if (graphe.Chemin(a, b).Item1)
            {
                List<Noeud<T>> Chemin = graphe.Chemin(a, b).Item3;
                for(int i = 0; i < Chemin.Count;i++)
                {
                    if(i+1 < Chemin.Count && Chemin[i+1] != null)
                    {
                        Lien<T> l = new Lien<T>(Chemin[i], Chemin[i+1]);
                       
                        poids += l.Calcul_Distance(Chemin[i], Chemin[i + 1]);
                    }
                }
            }

            return poids;
        }
        public double Calcul_Distance(Noeud<T> a , Noeud<T> b)
        {
            double d = 0;
            (double,double) latitude = (0,0);
            double pi = Math.PI;
            double cste = 360;
            latitude.Item1 = (a.Coordonnees.Item2 * pi)/cste;
            latitude.Item2 = (b.Coordonnees.Item2 * pi)/cste;
            (double,double) longitude = (0, 0);
            longitude.Item1 = (a.Coordonnees.Item1 * pi) / cste;
            longitude.Item2 = (b.Coordonnees.Item1 * pi) / cste;
            double delta_latitude = latitude.Item2-latitude.Item1;
            double delta_longitude = longitude.Item2-longitude.Item1;
            double R = 6371;
            double arg1 = (Math.Pow(Math.Sin(delta_latitude), 2));
            double arg2 = Math.Cos(2*latitude.Item1);
            double arg3 = Math.Cos(2*latitude.Item2);
            double arg4 = Math.Pow(Math.Sin(delta_longitude),2);
            double arg_1 = arg2 * arg3 * arg4;
            double arg_2 = arg1 + arg_1;
            double c = Math.Sqrt(arg_2);
            double e = Math.Asin(c);
            d = R * 2 * e;
            return d;
        }
        



    }
}
