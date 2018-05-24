using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinalLevelScreen : MonoBehaviour {

	public Text nextlevel;

	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.CompareTag ("Player")) {

			nextlevel.text = ("Press [E] to advance!");
			if (Input.GetKeyDown ("e")) {
				SceneManager.LoadScene ("Level1");
			}
		}
	}

	void OnTriggerStay2D(Collider2D col)
	{
		if (col.CompareTag ("Player")) {

			if (Input.GetKeyDown ("e")) {
				SceneManager.LoadScene ("Level1");
			}
		}
	}

	void OnTriggerExit2D(Collider2D col)
	{
		if (col.CompareTag ("Player")) {

			nextlevel.text = (" ");
		}
	}
}
