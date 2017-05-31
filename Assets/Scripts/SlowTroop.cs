using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SlowTroop : Troop {

	// Use this for initialization
	void Start () {
		maxHealth = 10;
		currHealth = maxHealth;
		transform.localScale = new Vector3(0.1355172f, 0.1355172f, 0.1355172f);
		rb2d = gameObject.GetComponent<Rigidbody2D>();

		if (SceneManager.GetActiveScene().buildIndex == 1)
		{
			direction = new Vector3(0, -1, 0);
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (SceneManager.GetActiveScene().buildIndex == 1)
		{
			transform.Translate(direction * Time.deltaTime * 0.5f);
		}
	}
}
