using UnityEngine;
using TMPro; // Assurez-vous que le package TextMeshPro est inclus dans votre projet Unity

public class IndiceManager : MonoBehaviour
{
    [SerializeField] private TMP_Text indicesText; // Référence au composant TextMeshPro qui affiche les indices
    [SerializeField] private string[] indices; // Tableau des indices à afficher
    private int currentIndiceIndex = 0; // L'indice actuel dans le tableau
    public Console console;

    public void ShowNextIndice()
    {
        if (currentIndiceIndex < indices.Length)
        {
	    console.AddLine("\nL'indice numéro" + currentIndiceIndex + " a été demandé");
            // Afficher l'indice actuel
            indicesText.text += "\n" + indices[currentIndiceIndex];
            // Passer au prochain indice pour la prochaine fois que le bouton est pressé
            currentIndiceIndex++;
        }
        else
        {
            ResetIndices();
	    indicesText.text = "Indices :";
        }
    }

    // Optionnel : Méthode pour réinitialiser les indices
    public void ResetIndices()
    {
	console.AddLine("\nReset des indices");
        currentIndiceIndex = 0;
        indicesText.text = string.Empty;
    }
}
