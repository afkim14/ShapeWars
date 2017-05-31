using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathParticle : MonoBehaviour {

	// Use this for initialization
	void Start () {
        StartCoroutine(WaitandDestroy());
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public IEnumerator WaitandDestroy()
    {
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
    }
}
