using UnityEngine;
using UnityEngine.UI;
using System.Text;
using System.Collections;
using System.Collections.Generic;

public class TextLineManager : MonoBehaviour
{
    [SerializeField] private Text uiText; // Référence au composant Text UI
    [SerializeField] private int maxLines = 5; // Nombre maximum de lignes à afficher

    private FixedSizeQueue<string> linesQueue;

    void Start()
    {
        // Initialise la queue avec le nombre maximum de lignes
        linesQueue = new FixedSizeQueue<string>(maxLines);
    }

    public void AddLine(string newLine)
    {
        // Ajoute une nouvelle ligne à la queue
        linesQueue.Enqueue(newLine);

        // Construit le texte à partir de la queue
        UpdateText();
    }

    void UpdateText()
    {
        StringBuilder stringBuilder = new StringBuilder();

        // Parcourt toutes les lignes dans la queue et les ajoute au StringBuilder
        foreach (string line in linesQueue)
        {
            stringBuilder.AppendLine(line);
        }

        // Met à jour le texte du composant UI Text
        uiText.text = stringBuilder.ToString();
    }

    // Optionnel : Appeler cette fonction pour effacer le texte
    public void ClearText()
    {
        linesQueue = new FixedSizeQueue<string>(maxLines);
        uiText.text = "";
    }
}
