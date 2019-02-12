using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {


    public Sprite[] lives;
    public Image lives_ImageDispaly;
    public Text scoreText;
    public int score;
    public GameObject titleScreen;

    public void Updatelives(int currentlives)
    {
        Debug.Log("Player Lives : " + currentlives); 
        lives_ImageDispaly.sprite = lives[currentlives];

    }

    public void UpdateScore()
    {
        score += 10;
        scoreText.text= "Score : " + score;
    }

    public void ShowTitleScreen()
    {
        titleScreen.SetActive(true);
        
    }

    public void HideTitleScreen()
    {
        titleScreen.SetActive(false);
        scoreText.text = "Score : ";
    }
}
