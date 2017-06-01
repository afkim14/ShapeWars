using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DefendingPlayerSkills : MonoBehaviour {

    private GameAdmin ga;
    public Button delete5Troops_button;
    private float delete5CurrTime;
    private float delete5Cooldown = 2.0f;

    public Button freezeTroops_button;
    private float freezeCurrTime;
    private float freezeCooldown = 2.0f;

    // Use this for initialization
    void Start () {
        ga = GameObject.FindGameObjectWithTag("GameAdmin").GetComponent<GameAdmin>();
        ga.destroy_button = delete5Troops_button;
        ga.freeze_button = freezeTroops_button;
    }
	
	// Update is called once per frame
	void Update () {
        if (ga.destroySelectsLeft == 0) {
            delete5CurrTime += Time.deltaTime;
            if (delete5CurrTime > delete5Cooldown)
            {
                ga.destroySelectsLeft = ga.totalDestroySelects;
                ga.destroySelectButtonPressed = false;
                ga.destroy_button.interactable = true;
                delete5CurrTime = 0.0f;
            }
        }
        delete5Troops_button.GetComponentInChildren<Text>().text = "Delete " + ga.destroySelectsLeft.ToString() + " Troops";

        if (ga.freezeButtonPressed)
        {
            freezeCurrTime += Time.deltaTime;
            if (freezeCurrTime > freezeCooldown)
            {
                ga.freezeButtonPressed = false;
                ga.freeze_button.interactable = true;
                freezeCooldown = 0.0f;
            }
        }
    }

    public void Delete5Troops()
    {
        PlayerPrefs.SetInt("dp_money", PlayerPrefs.GetInt("dp_money") - ga.destroyCost);
        ga.destroySelectButtonPressed = true;
        ga.destroy_button.interactable = false;
        ga.destroySelectsLeft = ga.totalDestroySelects;
    }

    public void FreezeTroops()
    {
        PlayerPrefs.SetInt("dp_money", PlayerPrefs.GetInt("dp_money") - ga.freezeCost);
        GameObject[] allObjects = UnityEngine.Object.FindObjectsOfType<GameObject>();
        for (int i = 0; i < allObjects.Length; i++)
        {
            GameObject obj = allObjects[i];
            if (obj.activeInHierarchy && obj.CompareTag("Troop"))
            {
                obj.GetComponent<Troop>().temp_speedMult = obj.GetComponent<Troop>().speedMult;
                obj.GetComponent<Troop>().frozen = true;
                obj.GetComponent<Troop>().speedMult = 0.0f;
            }
        }

        ga.freezeButtonPressed = true;
        ga.freeze_button.interactable = false;
    }
}
