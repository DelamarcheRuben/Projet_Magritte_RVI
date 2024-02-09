using UnityEngine;
using System.IO;

[System.Serializable]
public class GameState
{
    public Vector3 xrigPosition;
    public Vector3[] childPositions;
    public bool doorObjectActive;
}


public class GameDataSerializer : MonoBehaviour
{
    public string saveFileName = "gamestate.json";
    public Transform xrig;
    public Console console;
    public GameObject doorObject;

    void Start()
    {
        LoadGameState();
    }

    void OnDisable()
    {
        SaveGameState();
    }

    void OnApplicationQuit()
    {
        SaveGameState();
    }

    public void SaveGameState()
    {
        GameState gameState = new GameState();
        gameState.xrigPosition = xrig.position;

        int childCount = xrig.childCount;
        gameState.childPositions = new Vector3[childCount];
        for (int i = 0; i < childCount; i++)
        {
            Transform child = xrig.GetChild(i);
            gameState.childPositions[i] = child.position;
        }

        // Sauvegarde l'état d'activation de doorObject
        gameState.doorObjectActive = doorObject.activeSelf;

        string json = JsonUtility.ToJson(gameState);
        string filePath = Path.Combine(Application.persistentDataPath, saveFileName);
        File.WriteAllText(filePath, json);
        console.AddLine("Sauvegarde de la position du joueur et de l'état de la porte.");
    }


    public void LoadGameState()
    {
        string filePath = Path.Combine(Application.persistentDataPath, saveFileName);
        console.AddLine("\nSerialized data.");

        if (File.Exists(filePath))
        {
            console.AddLine("\nFile json exists.");
            string json = File.ReadAllText(filePath);
            GameState gameState = JsonUtility.FromJson<GameState>(json);

            xrig.position = gameState.xrigPosition;

            for (int i = 0; i < gameState.childPositions.Length; i++)
            {
                if (i < xrig.childCount)
                {
                    Transform child = xrig.GetChild(i);
                    child.position = gameState.childPositions[i];
                }
            }

            // Restaure l'état d'activation de doorObject
            doorObject.SetActive(gameState.doorObjectActive);
        }
        else
        {
            console.AddLine("No saved game data found.");
        }
    }
}
