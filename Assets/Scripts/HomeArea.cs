using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HomeArea : MonoBehaviour {

    public Text homeLivesLeftText;
    public GameAdmin ga;
    public AudioSource dmgSound;
    CameraShake camShake;

	// Use this for initialization
	void Start () {
        ga = GameObject.FindGameObjectWithTag("GameAdmin").GetComponent<GameAdmin>();
        homeLivesLeftText.text = PlayerPrefs.GetInt("homeLivesLeft").ToString();
        camShake = ga.GetComponent<CameraShake>();

    }
	
	// Update is called once per frame
	void Update () {
        homeLivesLeftText.text = PlayerPrefs.GetInt("homeLivesLeft").ToString();
        int life = int.Parse(homeLivesLeftText.text);
        if (life <= 0)
        {
            Time.timeScale = 0;
            ga.End(PlayerPrefs.GetString("attplayername"));
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Troop"))
        {
            dmgSound.Play();
            //camShake.Shake(0.05f, 0.1f);
            if (col.gameObject.name.Contains("UserTroop"))
            {
                PlayerPrefs.SetInt("homeLivesLeft", PlayerPrefs.GetInt("homeLivesLeft") - 3);
                PlayerPrefs.SetInt("ap_money", PlayerPrefs.GetInt("ap_money") + 500);
            }
            else
            {
                PlayerPrefs.SetInt("ap_money", PlayerPrefs.GetInt("ap_money") + 100);
                PlayerPrefs.SetInt("homeLivesLeft", PlayerPrefs.GetInt("homeLivesLeft") - 1);
            }

            col.gameObject.GetComponent<Troop>().currHealth = 0;
            Destroy(col.gameObject);
        }
    }
}
