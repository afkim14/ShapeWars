using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    public GameObject square;
    private float creationTime;
    private float creationInterval = 0.2f;

    // Use this for initialization
    void Start () {

    }
	
	// Update is called once per frame
	void Update () {
        creationTime += Time.deltaTime;
        if (creationTime >= creationInterval)
        {
            float[] x_border = new float[4] { -8.89f, -3.6f, 2.95f, 8.83f };
            float[] y_vals = new float[2] { -5.5f, 5.54f };
            int randint = Random.Range(0, 2);

            float randfloat_x;
            if (randint == 0) { randfloat_x = Random.Range(x_border[0], x_border[1]); }
            else { randfloat_x = Random.Range(x_border[2], x_border[3]); }
            randint = Random.Range(0, 2);
            Instantiate(square, new Vector2(randfloat_x, y_vals[randint]), new Quaternion(0, 0, 0, 0));
            creationTime = 0.0f;
        }
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
        PlayerPrefs.SetInt("ap_money", 0);
        PlayerPrefs.SetInt("dp_money", 0);
        PlayerPrefs.SetInt("turrets_built", 0);
        PlayerPrefs.SetInt("troops_sent", 0);
        PlayerPrefs.SetInt("troops_killed", 0);
        PlayerPrefs.SetInt("homeLivesLeft", 30);
        PlayerPrefs.SetString("tempattplayername", "");
        PlayerPrefs.SetString("tempdefplayername", "");
    } 

    public void QuitGame()
    {
        Application.Quit();
    }
}
