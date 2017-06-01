using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretAttackRange : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        GameObject[] allObjects = UnityEngine.Object.FindObjectsOfType<GameObject>();
        for (int i = 0; i < allObjects.Length; i++)
        {
            GameObject obj = allObjects[i];
            if (obj.activeInHierarchy && obj.CompareTag("Turret"))
            {
                Physics2D.IgnoreCollision(gameObject.GetComponent<Collider2D>(), obj.GetComponent<Collider2D>());
            }
        }
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
