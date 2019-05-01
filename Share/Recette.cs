using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Share
{
    [DataContract]
    public class Recette
    {
        [DataMember]
        public string Nom { get; set; }

        [DataMember]
        public List<Ingredient> Ingredients { get; set; }

        public Recette()
        {
        }

        public Recette(string nom)
        {
            Nom = nom;
            Ingredients = new List<Ingredient>();
        }
    }
}
