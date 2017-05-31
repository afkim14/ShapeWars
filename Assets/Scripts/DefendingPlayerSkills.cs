using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DefendingPlayerSkills : MonoBehaviour {

    private GameAdmin ga;
    public Button delete5Troops_button;

	// Use this for initialization
	void Start () {
        ga = GameObject.FindGameObjectWithTag("GameAdmin").GetComponent<GameAdmin>();
    }
	
	// Update is called once per frame
	void Update () {
        if (ga.destroySelectsLeft == 0) {
            ga.destroySelectsLeft = 5;
            delete5Troops_button.interactable = true;
        }
        delete5Troops_button.GetComponentInChildren<Text>().text = "Delete " + ga.destroySelectsLeft.ToString() + " Troops";
    }

    public void Delete5Troops()
    {
        delete5Troops_button.interactable = false;
        ga.destroySelectsLeft = 5;
    }
}
