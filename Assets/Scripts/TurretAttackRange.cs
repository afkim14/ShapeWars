using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretAttackRange : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Troop"))
        {
            gameObject.GetComponentInParent<Turret>().currentCollisions.Add(col.gameObject.GetComponent<Troop>());
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("Troop"))
        {
            gameObject.GetComponentInParent<Turret>().currentCollisions.Remove(col.gameObject.GetComponent<Troop>());
        }
    }
}
