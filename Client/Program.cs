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
        public static List<Recette> selectionCourante = new List<Recette>();

        static void Main(string[] args)
        {
            serviceProxy = new ChannelFactory<IServiceRecettes>("RecetteServiceConfiguration").CreateChannel();
            Console.WriteLine("Done!");

            Console.WriteLine(serviceProxy.testerService("CLIENT"));
            
            while (true)
            {
                Console.WriteLine("Menu\n1: Recherche de recette\n2: Afficher la selection courante\n3: Supprimer une recette de la selection courante\n4: Ajouter une recette\nChoisissez votre actions:");
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
                        default:
                            Console.WriteLine("\nChoisissez l'une des options du menu");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("\nVotre choix doit être un entier");
                }
            }
            

        }

        //recherche par ingredient
        public static void option1()
        {
            String ingRecherche;
            List<Recette> resultatsRecherche;
            Console.WriteLine("\nEntrez le nom d'un ingredient: ");
            ingRecherche = Console.ReadLine();
            Console.WriteLine("Recherche de recettes contenant l'ingredient: \"" + ingRecherche + "\"");
            resultatsRecherche = serviceProxy.RechRecettesParIngredient(ingRecherche);
            if(resultatsRecherche.Count == 0)
            {
                Console.WriteLine("Aucune recette contient l'ingredient \"" + ingRecherche + "\"");
            }
            else
            {
                Console.WriteLine("On a trouvé " + resultatsRecherche.Count + " resultats\n");
                selectionCourante = resultatsRecherche;
                imprimerListe(resultatsRecherche);
            }
        }

        //afficher la selection courante
        public static void option2()
        {
            if(selectionCourante.Count == 0)
            {
                Console.WriteLine("La selection courante est vide");
            }
            else
            {
                imprimerListe(selectionCourante);
            }
        }

        //supprimer une recette de la selection courante
        public static void option3()
        {
            Console.WriteLine("Ecrivez le nom de la recette à supprimer: ");
            String aSupprimer = Console.ReadLine();

            if (aSupprimer.Length == 0)
            {
                Console.WriteLine("Vous n'avez rien écrit");
                return;
            }

            foreach(Recette recette in selectionCourante){
                if (recette.Nom.Equals(aSupprimer))
                {
                    selectionCourante.Remove(recette);
                    Console.WriteLine("La recette \"" + aSupprimer + "\" a été suppriméee\n");
                    return;
                }
                Console.WriteLine("La recette \"" + aSupprimer + "\" n'est as dans votre selection courante\n");
            }
            Console.WriteLine("\nSupprimer");
        }

        //ajouter une recette a la liste principale
        public static void option4()
        {
            String nom;
            List<Ingredient> ingredients = new List<Ingredient>();

            Console.WriteLine("Quel est le nom de la recette à ajouter?");
            nom = Console.ReadLine();
            if(nom.Length == 0 || nom == null)
            {
                Console.WriteLine("Le nom de la recette est obligatoire.");
                return;
            }
            Console.WriteLine("Quel est le nombre d'ingredients de votre recette?");
            String userInput = Console.ReadLine();
            int nbing;
            bool isNumeric = int.TryParse(userInput, out nbing);

            if (!isNumeric)
            {
                Console.WriteLine("Le nombre d'ingredients doit etre un chiffre....");
                return;
            }
            if(nbing < 1)
            {
                Console.WriteLine("Le nombre d'ingredients doit être 1 au minimum");
                return;
            }

            for(int i = 0; i < nbing; i++)
            {
                Console.WriteLine("Entrez l'ingredient #" + i + ": ");
                string ing = Console.ReadLine();
                ingredients.Add(new Ingredient(ing));
            }
            Console.WriteLine("On essaye d'ajouter votre recette....");
            Recette recette = new Recette(nom, ingredients);
            bool success = serviceProxy.AjouterRecette(recette);
            if (success){
                Console.WriteLine("Votre recette a été ajoutée");
                return;
            }
            Console.WriteLine("On n'a pas pu ajouter votre recette");
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
                stringBuilder.Append("=====" + list[i].Nom + "=====\n");
                stringBuilder.Append("Ingredients\n");
                foreach (Ingredient ingredient in list[i].Ingredients)
                {
                    stringBuilder.Append("\t" + ingredient.Nom + "\n");
                }
               
            }
            Console.WriteLine(stringBuilder.ToString());
            //Console.WriteLine(list[0].Nom + "...." + list[1].Nom);
        }
    }
}
