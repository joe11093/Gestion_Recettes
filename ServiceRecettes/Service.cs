using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Share;

namespace ServiceRecettes
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerSession)]
    public class Service : IServiceRecettes
    {
        RecettesSingleton Recettes { get; set; }
        public List<Recette> SelectionCourante { get; set; }

        public Service()
        {
            SelectionCourante = new List<Recette>();
            Recettes = RecettesSingleton.getInstance();
        }

        public string testerService(string msg)
        {
            return "Your test string: " + msg;
        }

        public List<Recette> RechRecettesParIngredient(string ingredient)
        {
            List<Recette> resultat;
            resultat = this.Recettes.RechRecettesParIngredient(ingredient);
            if (resultat.Count < 1)
            {
                //pas de resultats
                return null;
            }
            else
            {
                this.SelectionCourante = resultat;
                return resultat;
            }
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
            return this.Recettes.addRecette(recette);
            
        }

        

        public List<Recette> RecupererSelection()
        {
            return this.SelectionCourante;
        }

        public List<Recette> GetAllRecettes()
        {
            return Recettes.RecupererToutesRecettes();
        }
    }
}
