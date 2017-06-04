using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TroopInfoMenu : MonoBehaviour {

    public GameObject troop_info_box;
    public Image troop_info;
    public Sprite troop0_info;
    public Sprite troop1_info;
    public Sprite troop2_info;
    public Sprite troop3_info;
    public Sprite troop4_info;
    public Sprite troop5_info;
    public Sprite[] all_sprites;

    // Use this for initialization
    void Start () {
        all_sprites = new Sprite[6];
        all_sprites[0] = troop0_info;
        all_sprites[1] = troop1_info;
        all_sprites[2] = troop2_info;
        all_sprites[3] = troop3_info;
        all_sprites[4] = troop4_info;
        all_sprites[5] = troop5_info;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void moreInfo()
    {
        troop_info_box.SetActive(true);
        string button_name = EventSystem.current.currentSelectedGameObject.name;
        troop_info.sprite = all_sprites[int.Parse(button_name[11].ToString())];
    }

    public void goBack()
    {
        troop_info_box.SetActive(false);
    }

    public void quitMenu()
    {
        SceneManager.LoadScene(1);
    }
}
