using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplashParticle : MonoBehaviour {
	
	void Start() {
        StartCoroutine(WaitandDestroy());
	}

    private void OnParticleCollision(GameObject other)
    {
        if (other.CompareTag("Troop"))
        {
            Troop enemy = other.GetComponent<Troop>();
            enemy.Damage(0.1f);
        }
    }

    public IEnumerator WaitandDestroy()
    {
        yield return new WaitForSeconds(5.0f);
        Destroy(gameObject);
    }

}
