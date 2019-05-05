using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Share
{
    [DataContract]
    [Serializable]
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

        public Recette(string nom, List<Ingredient> ingredients)
        {
            Nom = nom;
            Ingredients = ingredients;
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("=====" + this.Nom + "=====\n");
            stringBuilder.Append("Ingredients\n");
            foreach(Ingredient ingredient in Ingredients)
            {
                stringBuilder.Append("\t" + ingredient.Nom + "\n");
            }
            Console.WriteLine(stringBuilder.ToString());
            return stringBuilder.ToString();
        }
    }
}
