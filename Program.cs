using System;


namespace TP1b
{

    internal class Voitures //définition de la classe Voitures 
    {
        private string noSerie;
        private string marque;
        private int annee;
        private double prix;



        public Voitures(string noSerie, string marque, int annee, double prix)//déclaration de la classe Voitures
        {
            this.noSerie = noSerie;
            this.marque = marque;
            this.annee = annee;
            this.prix = prix;
        }

        public string Serie//getter et setter
        {
            get { return noSerie; }
            set { noSerie = value; }
        }
        public string Marque//getter et setter
        {
            get { return marque; }
            set { marque = value; }
        }
        public int Annee//getter et setter
        {
            get { return annee; }
            set { annee = value; }
        }
        public double Prix//getter et setter
        {
            get { return prix; }
            set { prix = value; }
        }
    }
    class Program
    {
        static List<Voitures> remplir(string fichier)//méthode pour la lecture des données d'un fichier pour mettre dans un liste
        {
            string ligne;
            int i = 0;

            StreamReader sr = new StreamReader(fichier);
            List<Voitures> listeVoitures = new List<Voitures>();
            while ((ligne = sr.ReadLine()) != null)
            {
                var tableSplit = ligne.Split(';');
                
                
                    string noSerie = tableSplit[0].Trim ();
                    string marque = tableSplit[1].Trim ();
                    int annee = int.Parse(tableSplit[2].Trim ());
                    double prix = double.Parse(tableSplit[3].Trim ());
                    Voitures voiture = new Voitures(noSerie, marque, annee, prix);
                    listeVoitures.Add(voiture);
                 
            }
            sr.Close();
            return listeVoitures;

        }

        static void afficher(List<Voitures> listeVoitures)//affichage de la liste
        {
            string modele;
            Console.WriteLine("{0,-15}{1,-15}{2,-15}{3,15}", "NO SERIE", "SORTE", "ANNEE", "PRIX");
            foreach (var voiture in listeVoitures)
            {

                switch (voiture.Marque)
                {
                    case "1": modele = "americaine"; break;
                    case "2": modele = "japonaise"; break;
                    case "3": modele = "autre"; break;
                    default: modele = "autre";break;
                }
                Console.WriteLine("{0,-15}{1,-15}{2,-15}{3,15:F2}$", voiture.Serie, modele, voiture.Annee, voiture.Prix);
                Console.WriteLine("");
            }
            Console.WriteLine(" " + " ");
        }

        static double somme(List<Voitures> listeVoitures)//méhthode pour calculer le montant total des ventes
        {
            double somme = 0.0;
            foreach (var voiture in listeVoitures)
            {
                somme = somme + voiture.Prix;
            }   
           return somme;
        }

        static int vautPlus(double montant, List<Voitures> listeVoiture)//méthode pour trouver la voiture qui 
        {
            int compteur = 0;
            foreach (var voiture in listeVoiture)
            {
                if (voiture.Prix >= montant)
                    compteur++;
            }
            return compteur;
        }

        static void nbRecent(int annee, List<Voitures> listeVoiture)//méthode pour trouver le nombre de voitures plus récentes que 1990
        {
            int compteur = 0;
            foreach (var voiture in listeVoiture)
            {
                if (voiture.Annee > annee)
                {
                    compteur++;
                }   
            }
            //string monMontant = String.Format("{0,1:F2}", montant);
           // string monCompteur = String.Format("{0,10}", compteur)
            Console.WriteLine("{0,-15}{1,1}{2,-10}{3,6}{4,6}","nb de voitures recentes (",annee," et +)",":",compteur);
            //return compteur;
        }

        static void prixMoyen(string marque, List<Voitures> listeVoiture)//méthode pour calculer le prix de vente moyen des autos japonaises
        {
            double somme = 0;
            double moyenne = 0;
            int compteur = 0;
            string modele;

            switch (marque)
            {
                case "1": modele = "americaine"; break;
                case "2": modele = "japonaise"; break;
                case "3": modele = "autre"; break;
                default: modele = "autre"; break;
            }


            foreach (var voiture in listeVoiture)
            {
                if (voiture.Marque == marque)
                {
                    compteur++;
                    somme = somme + voiture.Prix;
                    if (compteur < 1)
                    {
                        moyenne = 0.0;
                    }
                    else moyenne = somme / compteur;
                }
            }
            string priMoy = String.Format("{0,1:F2}", moyenne);
            //Console.WriteLine($"prix moyen d'une auto {modele} :    {priMoy}$");
            Console.WriteLine("{0,-20}{1,1}{2,14}{3,10}$","prix moyen d'une auto ", modele, ":",    priMoy);

        }

        static void meilleurPrix(string marque, List<Voitures> listeVoiture)//méthode pour trouver le numéro de série de la voiture américaine qui s'est vendue au meilleur prix et ce prix
        {
            double somme = 0;
            double moyenne = 0;
            int compteur = 0;
            string modele;
            double minPrix = 500000;
            int index;
            string serie = "";
            double basPrix = 500000;

            switch (marque)
            {
                case "1": modele = "americaine"; break;
                case "2": modele = "japonaise"; break;
                case "3": modele = "autre"; break;
                default: modele = "autre"; break;
            }


            foreach (var voiture in listeVoiture)
            {
                if (voiture.Marque == marque)
                {
                    if(minPrix > voiture.Prix)
                    {
                        minPrix = voiture.Prix;
                        basPrix = voiture.Prix;
                        serie = voiture.Serie;
                    }
                }
            }
            string monPrix = String.Format("{0,1:F2}", basPrix);
            Console.WriteLine($"{serie} est la voiture {modele} la moins chere ({monPrix}$)");

        }

        static void Main(string[] args)
        {
            double montant = 10000.00;
            List<Voitures> mesVoitures = remplir("../../../voitures.txt"); 
            afficher(mesVoitures);
            Console.WriteLine("\n{0,10}{1,10}{2,-20}{3:F2}{4,1}","TOTAL :",mesVoitures.Count," voitures pour un montant de ",somme(mesVoitures),"$");
            Console.WriteLine($"\nnb de voitures americaines de {montant}$ ou plus:     {vautPlus(montant, mesVoitures)}");
            nbRecent(1990, mesVoitures);
            prixMoyen("2", mesVoitures);
            meilleurPrix("1", mesVoitures);
        }
    }

}//TEST

