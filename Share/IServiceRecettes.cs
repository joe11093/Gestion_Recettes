using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Share
{
    [ServiceContract(SessionMode = SessionMode.Required)]
    public interface IServiceRecettes
    {

        [OperationContract]
        List<Recette> RechRecettesParIngredient(string ingredient);

        [OperationContract]
        bool SupprimerRecetteDeSelectionCourante(string nom_recette);

        [OperationContract]
        bool AjouterRecette(Recette recette);

        [OperationContract]
        List<Recette> RecupererSelection();

        [OperationContract]
        String testerService(string msg);

        [OperationContract]
        List<Recette> GetAllRecettes();
    }
}
