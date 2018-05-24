using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class heartCollect : MonoBehaviour {

	private Player player;

	void Start()
	{
		player = GameObject.FindGameObjectWithTag ("Player").GetComponent<Player> ();
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.tag == "Player") {
			Destroy (gameObject);
			player.curHealth += 1;
		}

	}
}
