using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Share
{
    public class ServiceRecettes : IServiceRecettes
    {
        public List<Recette> Recettes { get; set; }

        public ServiceRecettes()
        {
            Recettes = new List<Recette>();
        }

        public ServiceRecettes(List<Recette> recettes)
        {
            Recettes = recettes;
        }

        public List<Recette> RechRecettesParIngredient(string ingredient)
        {
            List<Recette> recettes = new List<Recette>();

            foreach (Recette recette in Recettes)
            {
                foreach (Ingredient ingre in recette.Ingredients)
                {
                    if (ingre.Nom.Equals(ingredient))
                    {
                        recettes.Add(recette);
                    }
                }
            }
            return recettes;
        }

        public void SupprimerRecette(Recette recette)
        {
            Recettes.Remove(recette);
        }

        public void AjouterRecette(Recette recette)
        {
            Recettes.Add(recette);
        }

        public void MemoriserRecherche()
        {
            throw new NotImplementedException();
        }

        public List<Recette> RecupererSelection()
        {
            return Recettes;
        }
    }
}
