using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Share
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom d'interface "IService1" à la fois dans le code et le fichier de configuration.
    [ServiceContract]
    public interface IServiceRecettes
    {

        [OperationContract]
        List<Recette> RechRecettesParIngredient(string ingredient);

        [OperationContract]
        void SupprimerRecette(Recette recette);

        [OperationContract]
        void AjouterRecette(Recette recette);

        [OperationContract]
        void MemoriserRecherche();

        [OperationContract]
        List<Recette> RecupererSelection();

    }
}
