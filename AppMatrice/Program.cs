using System;

namespace AppMatrice
{
    class Program
    {
        static void Main(string[] args)
        {

        }

        static void Generation_Tableau(int nbLigne, int nbColonne, out int[,] tabAlea)
        {
            Random alea = new Random();
            tabAlea = new int[nbLigne, nbColonne];
            for (int ligne = 0; ligne < nbLigne; ligne++)
            {
                for (int colonne = 0; colonne < nbColonne; colonne++)
                {
                    tabAlea[ligne, colonne] = alea.Next(0, 20);
                }
            }
        }

        static void String_Tableau(int[,] tab, out string stringTab)
        {
            stringTab = "";
            for (int ligne = 0; ligne < tab.GetLength(0); ligne++)
            {
                for (int colonne = 0; colonne < tab.GetLength(1); colonne++)
                {
                    stringTab += tab[ligne, colonne] + "|";
                }
                stringTab += "\n";
            }
        }

        static void Addition_Matrice(int[,] Tab1, int[,] Tab2, int[,] Tab3, out bool addition)
        {
            addition = true;
            if ((Tab1.GetLength(0) == Tab2.GetLength(0) && Tab1.GetLength(1) == Tab2.GetLength(1)))
            {
                for (int ligne = 0; ligne < Tab1.GetLength(0); ligne++)
                {
                    for (int colonne = 0; colonne < Tab1.GetLength(1); colonne++)
                    {
                        Tab3[ligne, colonne] = Tab1[ligne, colonne] + Tab2[ligne, colonne];
                    }
                }
            }
            else
            {
                addition = false;
            }
        }
    }
}