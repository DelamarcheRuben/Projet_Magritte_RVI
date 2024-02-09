using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class MainMenu : MonoBehaviour{

	public string saveFileName = "gamestate.json";

	public void Start()
	{
		
	}

	public void PlayGame()
	{
		SceneManager.LoadScene("SampleScene");
	}

	public void QuitGame()
	{
		DeleteGameState();
		Application.Quit();
	}

	public void DeleteGameState()
	{
		string filePath = Path.Combine(Application.persistentDataPath, saveFileName);
		if (File.Exists(filePath))
		{
			File.Delete(filePath);
		}
	}
}