using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Share;

namespace ServiceRecettes
{
    class RecettesSingleton
    {
        private static RecettesSingleton instance;
        public List<Recette> Recettes { get; }

        private RecettesSingleton()
        {
            this.Recettes = new List<Recette>();
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

        public static RecettesSingleton getInstance()
        {
            if (RecettesSingleton.instance == null)
            {
                RecettesSingleton.instance = new RecettesSingleton();
            }
            return RecettesSingleton.instance;
        }

        //add recette
        public bool addRecette(Recette recette)
        {
            foreach(Recette rec in this.Recettes)
            {
                if (rec.Nom.Equals(recette.Nom))
                {
                    return false;
                }
            }
            this.Recettes.Add(recette);
            return true;
        }
    }
}
