using System;

namespace AppMatrice
{
    class Program
    {
        static void Main(string[] args)
        {
            bool continuer = true;
            while (continuer)
            {
                int choix = 0;
                while (choix < 1 || choix > 3)
                {
                    Console.WriteLine("Que voulez-vous faire ?");
                    Console.WriteLine("1. Générer un tableau aléatoire");
                    Console.WriteLine("2. Additionner deux matrices");
                    Console.WriteLine("3. Multiplier deux matrices");

                    choix = int.Parse(Console.ReadLine());

                    if (choix < 1 || choix > 3)
                    {
                        Console.WriteLine("Choix invalide");
                    }
                }

                if (choix == 1)
                {
                    int nbLigne, nbColonne;
                    Console.WriteLine("Saisissez le nombre de lignes du tableau :");
                    bool nombre = int.TryParse(Console.ReadLine(), out nbLigne);
                    Console.WriteLine("Saisissez le nombre de colonnes du tableau :");
                    bool nombre2 = int.TryParse(Console.ReadLine(), out nbColonne);

                    if (!nombre || !nombre2 || nbLigne <= 0 || nbColonne <= 0)
                    {
                        Console.WriteLine("Veuillez saisir des nombres positifs");
                        continue;
                    }

                    int[,] tableauAlea;
                    Generation_Tableau(nbLigne, nbColonne, out tableauAlea);
                    Console.WriteLine("Tableau généré aléatoirement :");
                    string stringTab;
                    String_Tableau(tableauAlea, out stringTab);
                    Console.WriteLine(stringTab);
                }
                else if (choix == 2)
                {
                    int nbLigne, nbColonne;
                    Console.WriteLine("Saisissez le nombre de lignes des matrices :");
                    bool nombre = int.TryParse(Console.ReadLine(), out nbLigne);
                    Console.WriteLine("Saisissez le nombre de colonnes des matrices :");
                    bool nombre2 = int.TryParse(Console.ReadLine(), out nbColonne);

                    if (!nombre || !nombre2 || nbLigne <= 0 || nbColonne <= 0)
                    {
                        Console.WriteLine("Veuillez saisir des nombres positifs");
                        continue;
                    }

                    int[,] matrice1, matrice2, matriceSum;
                    Generation_Tableau(nbLigne, nbColonne, out matrice1);
                    Console.WriteLine("Matrice 1 générée aléatoirement :");
                    string stringMat1;
                    String_Tableau(matrice1, out stringMat1);
                    Console.WriteLine(stringMat1);

                    Generation_Tableau(nbLigne, nbColonne, out matrice2);
                    Console.WriteLine("Matrice 2 générée aléatoirement :");
                    string stringMat2;
                    String_Tableau(matrice2, out stringMat2);
                    Console.WriteLine(stringMat2);

                    bool addition;
                    Addition_Matrice(matrice1, matrice2, out matriceSum, out addition);
                    if (addition)
                    {
                        Console.WriteLine("Matrice somme :");
                        string stringMatSum;
                        String_Tableau(matriceSum, out stringMatSum);
                        Console.WriteLine(stringMatSum);
                    }
                    else
                    {
                        Console.WriteLine("Impossible d'additionner les matrices car elles n'ont pas la même taille.");
                    }
                }
                else if (choix == 3)
                {
                    int nbLigneMat1, nbColonneMat1, nbLigneMat2, nbColonneMat2;

                    Console.WriteLine("Saisissez le nombre de lignes de la première matrice :");
                    bool nombre = int.TryParse(Console.ReadLine(), out nbLigneMat1);
                    Console.WriteLine("Saisissez le nombre de colonnes de la première matrice :");
                    bool nombre2 = int.TryParse(Console.ReadLine(), out nbColonneMat1);
                    Console.WriteLine("Saisissez le nombre de lignes de la deuxième matrice :");
                    bool nombre3 = int.TryParse(Console.ReadLine(), out nbLigneMat2);
                    Console.WriteLine("Saisissez le nombre de colonnes de la deuxième matrice :");
                    bool nombre4 = int.TryParse(Console.ReadLine(), out nbColonneMat2);

                    if (!nombre || !nombre2 || !nombre3 || !nombre4 ||
                        nbLigneMat1 <= 0 || nbColonneMat1 <= 0 ||
                        nbLigneMat2 <= 0 || nbColonneMat2 <= 0 ||
                        nbColonneMat1 != nbLigneMat2)
                    {
                        Console.WriteLine("Veuillez saisir des nombres positifs et des tailles de matrice compatibles pour la multiplication");
                        continue;
                    }

                    int[,] matrice1, matrice2, matriceMult;
                    Generation_Tableau(nbLigneMat1, nbColonneMat1, out matrice1);
                    Console.WriteLine("Matrice 1 générée aléatoirement :");
                    string stringMat1;
                    String_Tableau(matrice1, out stringMat1);
                    Console.WriteLine(stringMat1);

                    Generation_Tableau(nbLigneMat2, nbColonneMat2, out matrice2);
                    Console.WriteLine("Matrice 2 générée aléatoirement :");
                    string stringMat2;
                    String_Tableau(matrice2, out stringMat2);
                    Console.WriteLine(stringMat2);

                    Multiplication_Matrice(matrice1, matrice2, out matriceMult);
                    Console.WriteLine("Matrice produit :");
                    string stringMatMult;
                    String_Tableau(matriceMult, out stringMatMult);
                    Console.WriteLine(stringMatMult);
                }

                Console.WriteLine("Voulez-vous continuer ? (O/N)");
                string continuerStr = Console.ReadLine();
                continuer = (continuerStr.ToUpper() == "O");
            }
        }

        static void Generation_Tableau(int nbLigne, int nbColonne, out int[,] tableau)
        {
            tableau = new int[nbLigne, nbColonne];
            Random random = new Random();
            for (int i = 0; i < nbLigne; i++)
            {
                for (int j = 0; j < nbColonne; j++)
                {
                    tableau[i, j] = random.Next(1, 10);
                }
            }
        }

        static void Remplir_Matrice(int nbLigne, int nbColonne, out int[,] matrice)
        {
            matrice = new int[nbLigne, nbColonne];
            for (int i = 0; i < nbLigne; i++)
            {
                for (int j = 0; j < nbColonne; j++)
                {
                    Console.WriteLine("Saisissez l'élément à la position [{0}, {1}] :", i, j);
                    matrice[i, j] = int.Parse(Console.ReadLine());
                }
            }
        }

        static void Addition_Matrice(int[,] matrice1, int[,] matrice2, out int[,] matriceSum, out bool addition)
        {
            int nbLignes = matrice1.GetLength(0);
            int nbColonnes = matrice1.GetLength(1);
            matriceSum = new int[nbLignes, nbColonnes];
            addition = true;

            for (int i = 0; i < nbLignes; i++)
            {
                for (int j = 0; j < nbColonnes; j++)
                {
                    matriceSum[i, j] = matrice1[i, j] + matrice2[i, j];
                }
            }
        }

        static void Multiplication_Matrice(int[,] matrice1, int[,] matrice2, out int[,] matriceProduct, out bool multiplication)
        {
            int nbLignes1 = matrice1.GetLength(0);
            int nbColonnes1 = matrice1.GetLength(1);
            int nbLignes2 = matrice2.GetLength(0);
            int nbColonnes2 = matrice2.GetLength(1);
            matriceProduct = new int[nbLignes1, nbColonnes2];
            multiplication = true;

            for (int i = 0; i < nbLignes1; i++)
            {
                for (int j = 0; j < nbColonnes2; j++)
                {
                    matriceProduct[i, j] = 0;
                    for (int k = 0; k < nbColonnes1; k++)
                    {
                        matriceProduct[i, j] += matrice1[i, k] * matrice2[k, j];
                    }
                }
            }
        }

        static void String_Tableau(int[,] tableau, out string stringTableau)
        {
            int nbLignes = tableau.GetLength(0);
            int nbColonnes = tableau.GetLength(1);
            stringTableau = "";

            for (int i = 0; i < nbLignes; i++)
            {
                for (int j = 0; j < nbColonnes; j++)
                {
                    stringTableau += tableau[i, j].ToString() + "\t";
                }
                stringTableau += "\n";
            }
        }
    }
}

