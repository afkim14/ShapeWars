using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SendBackBullet : Bullet {

    public Transform troopEntryPoint;

    // Use this for initialization
    void Start () {
        maxBulletTime = 2.0f;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Troop"))
        {
            if (col.gameObject.name.Contains("ContainerTroop") && !col.gameObject.name.Contains("InsideContainerTroop"))
            {
                if (!(col.gameObject.GetComponent<ContainerTroop>().containerBroken))
                {
                    if (SceneManager.GetActiveScene().buildIndex == 3)
                    {
                        col.gameObject.GetComponent<Troop>().transform.position = new Vector3(troopEntryPoint.position.x, troopEntryPoint.position.y, 0.0f);
                        col.gameObject.GetComponent<Troop>().direction = new Vector3(0, -1 * col.gameObject.GetComponent<Troop>().currSpeed, 0);
                    }
                }
            }
            else
            {

                if (SceneManager.GetActiveScene().buildIndex == 3)
                {
                    col.gameObject.GetComponent<Troop>().transform.position = new Vector3(troopEntryPoint.position.x, troopEntryPoint.position.y, 0.0f);
                    col.gameObject.GetComponent<Troop>().direction = new Vector3(0, -1 * col.gameObject.GetComponent<Troop>().currSpeed, 0);
                }
            }

            Destroy(gameObject);
        }
    }
}