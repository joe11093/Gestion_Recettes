using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Share
{
    [DataContract]
    public class Ingredient
    {
        [DataMember]
        public string Nom { get; set; }

        public Ingredient()
        {
        }

        public Ingredient(string nom)
        {
            Nom = nom;
        }
    }
}
