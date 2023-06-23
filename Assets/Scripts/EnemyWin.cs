using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyWin : MonoBehaviour
{

    public Text livesText;
    private int livesLeft = 20;
    public Image gameOver;
    public Text gameOverText;

    private void Start()
    {
        gameOver.enabled = false;
        gameOverText.enabled = false;
    }

    private void Update()
    {
        CountLives();
        GameEnd();
    }



    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            Debug.Log("Life Lost");
            Destroy(other.gameObject);
            livesLeft--;
        }


    }

    private void CountLives()
    {
        livesText.text = "Lives left" + " " + livesLeft.ToString();
    }

    private void GameEnd()
    {
        if(livesLeft <= 0)
        {
            gameOver.enabled = true;
            gameOverText.enabled = true;
        }
    }
}
