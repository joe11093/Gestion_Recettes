using Share;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    class Program
    {
        public static IServiceRecettes serviceProxy;

        static void Main(string[] args)
        {
            serviceProxy = new ChannelFactory<IServiceRecettes>("RecetteServiceConfiguration").CreateChannel();
            Console.WriteLine("Done!");

            //Console.WriteLine(serviceProxy.testerService("CLIENT"));

            while (true)
            {
                Console.Clear();
                Console.WriteLine("\n\n   ****** Menu ******\n" +
                                    "  1: Rechercher de recette par ingredient\n" +
                                    "  2: Afficher la selection courante des recettes\n" +
                                    "  3: Supprimer une recette de la selection courante\n" +
                                    "  4: Ajouter une recette\n" +
                                    "  5: Afficher toutes les recettes\n" +
                                    "  0: Quitter\n" +
                                    "- Veuillez choisir une option \n");
                String userInput = Console.ReadLine();
                int choice;
                bool isNumeric = int.TryParse(userInput, out choice);
                if (isNumeric)
                {
                    switch (choice)
                    {
                        case 1:
                            option1();
                            break;
                        case 2:
                            option2();
                            break;
                        case 3:
                            option3();
                            break;
                        case 4:
                            option4();
                            break;
                        case 5:
                            option5();
                            break;
                        case 0:
                            System.Environment.Exit(0);
                            break;
                        default:
                            Console.WriteLine("- Veuillez choisir une des options du menu ");
                            break;
                    }
                    Console.WriteLine("\nAppuyez sur Entrer pour continuer ...");
                    Console.ReadKey();
                }
                else
                {
                    Console.WriteLine("- Vous devez choisir un entier!");
                }
            }
        }

        //recherche par ingredient
        public static void option1()
        {
            String ingRecherche;
            List<Recette> resultatsRecherche;
            Console.Write("- Entrez le nom de l'ingredient: ");
            ingRecherche = Console.ReadLine();
            Console.WriteLine("\nRecherche en cours ...");
            resultatsRecherche = serviceProxy.RechRecettesParIngredient(ingRecherche);
            if (resultatsRecherche == null)
            {
                Console.WriteLine("\n*** Aucune recette ne contient l'ingredient \"" + ingRecherche + "\"!");
            }
            else
            {
                Console.WriteLine("\n" + resultatsRecherche.Count + " recette(s) trouvée(s):");
                imprimerListe(resultatsRecherche);
            }
        }

        //afficher la selection courante
        public static void option2()
        {
            List<Recette> selectionCourante = serviceProxy.RecupererSelection();

            if (selectionCourante.Count < 1)
            {
                Console.WriteLine("\n*** La sélection courante est vide! ");
            }
            else
            {
                imprimerListe(selectionCourante);
            }
        }

        //supprimer une recette de la selection courante
        public static void option3()
        {
            Console.Write("\n- Donnez le nom de la recette à supprimer: ");
            String aSupprimer = Console.ReadLine();

            if (aSupprimer.Length == 0)
            {
                Console.WriteLine("*** Vous n'avez rien écrit");
                return;
            }

            bool res = serviceProxy.SupprimerRecetteDeSelectionCourante(aSupprimer);
            if (res)
            {
                Console.WriteLine("*** La recette \"" + aSupprimer + "\" a été supprimée avec succés");
                return;
            }
            Console.WriteLine("*** La recette \"" + aSupprimer + "\" n'a pas été supprimée ou n'existe pas dans la sélection courante!");
        }

        //ajouter une recette a la liste principale
        public static void option4()
        {
            String nom;
            List<Ingredient> ingredients = new List<Ingredient>();

            Console.Write("\n- Donnez le nom de la recette à ajouter: ");
            nom = Console.ReadLine();
            if (nom.Length == 0 || nom == null)
            {
                Console.WriteLine("*** Le nom de la recette est obligatoire.");
                return;
            }
            Console.Write("- Donnez le nombre d'ingredients de la recette: ");
            String userInput = Console.ReadLine();
            int nbing;
            bool isNumeric = int.TryParse(userInput, out nbing);

            if (!isNumeric)
            {
                Console.WriteLine("*** Le nombre d'ingredients doit être un chiffre....");
                return;
            }
            if (nbing < 1)
            {
                Console.WriteLine("*** Le nombre d'ingredients doit être supérieur à 0");
                return;
            }

            for (int i = 0; i < nbing; i++)
            {
                Console.Write("\tEntrez l'ingredient N°" + (i + 1) + ": ");
                string ing = Console.ReadLine();
                ingredients.Add(new Ingredient(ing));
            }
            Console.WriteLine("\nAjout de la recette en cours ...");
            Recette recette = new Recette(nom, ingredients);
            bool success = serviceProxy.AjouterRecette(recette);
            if (success)
            {
                Console.WriteLine("*** Votre recette a été ajoutée avec succés!");
                return;
            }
            Console.WriteLine("*** Votre recette n'a pas pu être ajouté!");
        }

        public static void option5()
        {
            List<Recette> res = serviceProxy.GetAllRecettes();
            imprimerListe(res);
        }

        public static void imprimerListe(List<Recette> list)
        {
            StringBuilder stringBuilder = new StringBuilder();

            for (int i = 0; i < list.Count; i++)
            {
                stringBuilder.Append("======= " + list[i].Nom + " =======\n");
                stringBuilder.Append("-Ingredients : [");
                foreach (Ingredient ingredient in list[i].Ingredients)
                {
                    stringBuilder.Append(" " + ingredient.Nom + " ");
                }
                stringBuilder.Append("].\n\n");

            }
            Console.WriteLine(stringBuilder.ToString());
        }
    }
}

