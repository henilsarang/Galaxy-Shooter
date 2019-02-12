 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {


    public bool GameOver = true;
    public GameObject player;
    private UIManager uimanager;

    public void Start()
    {
        uimanager = GameObject.Find("Canvas").GetComponent<UIManager>();
    }


    // Update is called once per frame
    void Update () {
         if (GameOver == true)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Instantiate(player, Vector3.zero, Quaternion.identity);
                GameOver = false;
                uimanager.HideTitleScreen();

            }
        }
		
	}
}
