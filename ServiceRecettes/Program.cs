using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Share;

namespace ServiceRecettes
{
    class Program
    {
        static void Main(string[] args)
        {
            //Création du catalogues de recettes
            List<Recette> recettes = new List<Recette>();


            //Recette 1
            Ingredient ing1 = new Ingredient("beurre");
            Ingredient ing2 = new Ingredient("sucre");
            Ingredient ing3 = new Ingredient("farine");

            Recette recette1 = new Recette();
            recette1.Ingredients.Add(ing1);
            recette1.Ingredients.Add(ing2);
            recette1.Ingredients.Add(ing3);

            //Recette 2
            Ingredient ing4 = new Ingredient("semoule");
            Ingredient ing5 = new Ingredient("sel");
            Ingredient ing6 = new Ingredient("huile");

            Recette recette2 = new Recette();
            recette1.Ingredients.Add(ing3);
            recette1.Ingredients.Add(ing4);
            recette1.Ingredients.Add(ing5);
            recette1.Ingredients.Add(ing6);

            //Ajout des recettes au catalogue
            recettes.Add(recette1);
            recettes.Add(recette2);

        }
    }
}
