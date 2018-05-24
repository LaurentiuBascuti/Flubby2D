using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeadScreen : MonoBehaviour {

	public GameObject dead;
	public GameObject HUD;
	public GameObject SM;
	public GameObject Player;

	private Player player;
	private bool paused = false;

	void Start()
	{
		dead.SetActive(false);
		player = GameObject.FindGameObjectWithTag ("Player").GetComponent<Player> ();
	}

	void Update()
	{
		if (player.curHealth <= 0) {

			paused = !paused; 
		}

		if (paused) {
			dead.SetActive (true);
			HUD.SetActive (false);
			SM.SetActive (false);
			Player.SetActive (false);
			Time.timeScale = 0;
		}

		if (Input.GetKeyDown("r")) {
			SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);
		}

		if (Input.GetKeyDown("escape")) {
			SceneManager.LoadScene ("MainMenu");
		}
			
	}

}
