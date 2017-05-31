using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HomeArea : MonoBehaviour {

    public Text homeLivesLeftText;

	// Use this for initialization
	void Start () {
        homeLivesLeftText.text = PlayerPrefs.GetInt("homeLivesLeft").ToString();
	}
	
	// Update is called once per frame
	void Update () {
        homeLivesLeftText.text = PlayerPrefs.GetInt("homeLivesLeft").ToString();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Troop"))
        {
            PlayerPrefs.SetInt("ap_score", PlayerPrefs.GetInt("ap_score") + 200);
            PlayerPrefs.SetInt("ap_money", PlayerPrefs.GetInt("ap_money") + 100);
            PlayerPrefs.SetInt("homeLivesLeft", PlayerPrefs.GetInt("homeLivesLeft") - 1);
            col.gameObject.GetComponent<Troop>().currHealth = 0;
            Destroy(col.gameObject);
        }
    }
}
