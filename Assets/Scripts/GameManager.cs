using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private GameObject Player;
    public int ballsLeft;
    public int goalsScored;
    public TextMeshProUGUI ballsLeftUI;
    public TextMeshProUGUI goalsScoredUI;
    public bool isGameOver;
    private Animator playerAnim;
    

    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("goalsScored", 0);
        ballsLeft = 10;
        goalsScored = 0;
        Player = GameObject.FindGameObjectWithTag("Player");
        isGameOver = false;
        playerAnim = Player.GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {

        
    }

    public void goalScored()
    {
        goalsScored += 1;
        ballsLeft += 1;
        ballsLeftUI.text = "Balls Left: " + ballsLeft;
        goalsScoredUI.text = "Goals: " + goalsScored;
    }

    public void shotTaken()
    {
        ballsLeft -= 1;
        ballsLeftUI.text = "Balls Left: " + ballsLeft;

        //set animation
        playerAnim.SetBool("animShot", false);

        //if player has ran out of balls
        if (ballsLeft < 0)
        {
            gameOver();
        }
    }

    void gameOver()
    {
        PlayerPrefs.SetInt("goalsScored", goalsScored);
        isGameOver = true;
        SceneManager.LoadScene("Endgame");
    }
}
