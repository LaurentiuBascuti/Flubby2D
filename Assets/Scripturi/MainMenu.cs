using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

	public void PlayGame()
	{
		SceneManager.LoadScene ("Level1");
	}

	public void HighScore()
	{
		print ("Loading..");
	}

	public void Options()
	{
		print ("Loading..");
	}

	public void ExitGame(){
		Application.Quit ();
	}
}
