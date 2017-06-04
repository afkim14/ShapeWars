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
            if (other.name.Contains("ContainerTroop") && !other.name.Contains("InsideContainerTroop"))
            {
                if (!(other.gameObject.GetComponent<ContainerTroop>().containerBroken))
                {
                    Troop enemy = other.GetComponent<Troop>();
                    enemy.Damage(0.07f);
                }
            } else
            {
                Troop enemy = other.GetComponent<Troop>();
                enemy.Damage(0.07f);
            }
        }
    }

    public IEnumerator WaitandDestroy()
    {
        yield return new WaitForSeconds(5.0f);
        Destroy(gameObject);
    }

}
