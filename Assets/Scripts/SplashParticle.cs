using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplashParticle : MonoBehaviour {

    public float living_time = 0.0f;
	
	// Update is called once per frame
	void Update () {
        living_time += Time.deltaTime;
		if (living_time > 3.0f)
        {
            Destroy(gameObject);
        }
	}

    private void OnParticleCollision(GameObject other)
    {
        if (other.CompareTag("Troop"))
        {
            Troop enemy = other.GetComponent<Troop>();
            enemy.Damage(1);
        }
    }

}
