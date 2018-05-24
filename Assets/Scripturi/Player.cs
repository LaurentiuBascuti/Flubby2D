using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {

	//Floats
	public float maxSpeed = 3;
	public float speed = 250f;
	public float jumpPower = 400f;

	//Booleans
	public bool grounded;

	//Stats
	public int curHealth;
	public int maxHealth = 5;

	//References
	private Rigidbody2D rb2d;
	private Animator anim;
	private ScoreManager sm;

	void Start () 
	{	
		rb2d = gameObject.GetComponent<Rigidbody2D>();
		anim = gameObject.GetComponent<Animator>();

		curHealth = maxHealth;
		sm = GameObject.FindGameObjectWithTag ("ScoreManager").GetComponent<ScoreManager> ();
	}


	void Update ()
	{
		anim.SetBool ("Grounded", grounded);
		anim.SetFloat ("Speed", Mathf.Abs (rb2d.velocity.x));

		if (Input.GetAxis("Horizontal") < -0.1f) 
		{
			transform.localScale = new Vector3 (-1, 1, 1);
		}

		if (Input.GetAxis("Horizontal") > 0.1f) 
		{
			transform.localScale = new Vector3 (1, 1, 1);
		}

		if (Input.GetButtonDown ("Jump") && grounded) 
		{
			rb2d.AddForce (Vector2.up * jumpPower);
		}

		if (curHealth > maxHealth) {
			curHealth = maxHealth;
		}
			
	}

	void FixedUpdate ()
	{
		Vector3 easeVelocity = rb2d.velocity;
		easeVelocity.y = rb2d.velocity.y;
		easeVelocity.z = 0.0f;
		easeVelocity.x *= 0.75f;

		float h = Input.GetAxis("Horizontal");

		if (grounded) 
		{
			rb2d.velocity = easeVelocity;
		}
		//Miscarea jucatorului
		rb2d.AddForce((Vector2.right * speed) * h);

		//Limitarea vitezei
		if (rb2d.velocity.x > maxSpeed) 
		{
			rb2d.velocity = new Vector2(maxSpeed, rb2d.velocity.y);
		}

		if (rb2d.velocity.x < -maxSpeed) 
		{
			rb2d.velocity = new Vector2(-maxSpeed, rb2d.velocity.y);
		}
	}

	/*void Die()
	{
		//Restart level
		SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex);
	}*/

	public void Damage(int dmg){
	
		curHealth -= dmg;
		gameObject.GetComponent<Animation> ().Play ("Damaged");
	}

	public IEnumerator Knockback(float knockDur, float knockbackPwr, Vector3 knockbackDir)
	{
		float timer = 0;
		rb2d.velocity = new Vector2 (rb2d.velocity.x, 0);
		while (knockDur > timer) {

			timer += Time.deltaTime;

			rb2d.AddForce (new Vector3 (knockbackDir.x * -50, knockbackDir.y * knockbackPwr, transform.position.z));
		}

		yield return 0;
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.CompareTag ("IceCream")) {

			Destroy (col.gameObject);
			sm.points += 15;
		}

		if (col.CompareTag ("Heart")) {
			if (curHealth == 5)
				curHealth = maxHealth;
			else
				curHealth += 1;
			Destroy (col.gameObject);
		}
	}
}
