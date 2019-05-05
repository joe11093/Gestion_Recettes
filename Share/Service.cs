using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Share
{
    public class Service : IServiceRecettes
    {
        public List<Recette> Recettes { get; set; }
        public List<Recette> SelectionCourante { get; set; }

        public Service()
        {
            SelectionCourante = new List<Recette>();
            Recettes = new List<Recette>();

            //add some default data
            List<Ingredient> ing1 = new List<Ingredient>();
            ing1.Add(new Ingredient("bread"));
            ing1.Add(new Ingredient("meat"));
            ing1.Add(new Ingredient("tomato"));
            ing1.Add(new Ingredient("lettuce"));
            Recette rec1 = new Recette("hamburger", ing1);

            List<Ingredient> ing2 = new List<Ingredient>();
            ing2.Add(new Ingredient("cuccumber"));
            ing2.Add(new Ingredient("lemon"));
            ing2.Add(new Ingredient("tomato"));
            ing2.Add(new Ingredient("lettuce"));
            Recette rec2 = new Recette("salad", ing2);

            List<Ingredient> ing3 = new List<Ingredient>();
            ing3.Add(new Ingredient("bread"));
            ing3.Add(new Ingredient("cheese"));
            Recette rec3 = new Recette("sandwich", ing3);

            Recettes.Add(rec1);
            Recettes.Add(rec2);
            Recettes.Add(rec3);

        }

        public Service(List<Recette> recettes)
        {
            Recettes = recettes;
            SelectionCourante = new List<Recette>();

        }

        public string testerService(string msg)
        {
            return "Your test string: " + msg;
        }
        public List<Recette> RechRecettesParIngredient(string ingredient)
        {
            List<Recette> resultat = new List<Recette>();

            foreach (Recette recette in Recettes)
            {
                foreach (Ingredient ingre in recette.Ingredients)
                {
                    if (ingre.Nom.Equals(ingredient))
                    {
                        resultat.Add(recette);
                    }
                }
            }
            this.SelectionCourante = resultat;
            return resultat;
        }

        //search for recette by string in the selectioncourante
        //if it exists, delete it and return true
        //else return false
        //client must handle the results

        public bool SupprimerRecetteDeSelectionCourante(String nom_recette)
        {
            foreach(Recette recette in SelectionCourante)
            {
                if (recette.Nom.Equals(nom_recette))
                {
                    SelectionCourante.Remove(recette);
                    return true;
                }
            }
            return false;
        }

        //check if nom de la recette existe deja
        //si oui, return false
        //si non, ajouter la recette et return true
        public bool AjouterRecette(Recette recette)
        {
            foreach(Recette rec in Recettes)
            {
                if (rec.Nom.Equals(recette.Nom))
                {
                    return false;
                }
            }
            Recettes.Add(recette);
            return true;
        }

        

        public List<Recette> RecupererSelection()
        {
            return Recettes;
        }

        public List<Recette> GetAllRecettes()
        {
            return this.Recettes;
        }
    }
}
