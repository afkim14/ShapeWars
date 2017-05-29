using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FastTroop : Troop {

	private Vector3 direction;

	// Use this for initialization
	void Start () {
		maxHealth = 3;
		maxSpeed = 10;
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
			transform.Translate(direction * Time.deltaTime * 3);
		}
	}
		
	private void OnTriggerEnter2D(Collider2D col)
	{
		if ((col.CompareTag("WallDownLeft")) || (col.CompareTag("WallUpLeft")))
		{
			direction = new Vector3(-1, 0, 0);
		} else if ((col.CompareTag("WallLeftDown")) || (col.CompareTag("WallRightDown")))
		{
			direction = new Vector3(0, -1, 0);
		} else if ((col.CompareTag("WallDownRight")) || (col.CompareTag("WallUpRight")))
		{
			direction = new Vector3(1, 0, 0);
		} else if ((col.CompareTag("WallRightUp")) || (col.CompareTag("WallLeftUp")))
		{
			direction = new Vector3(0, 1, 0);
		}
	}
}
