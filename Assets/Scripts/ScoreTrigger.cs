using UnityEngine.Events;
using UnityEngine;
using TMPro;
public class ScoreTrigger : MonoBehaviour
{
    public TMP_Text score1;
    public TMP_Text score2;
    public TMP_Text winner;

    public static int playerScore1 = 0;
    public static int playerScore2 = 0;
    Ball ballReset;

    void Start(){
        ballReset = GetComponent<Ball>();
    }

    void FixedUpdate()
    {
        Debug.Log("Player 1: " + playerScore1);
        Debug.Log("Player 2: " + playerScore2);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name == "RightWall"){
            playerScore1++;
            ballReset.RestartGame();
        }
        if (col.gameObject.name == "LeftWall"){
            playerScore2++;
            ballReset.RestartGame();
        }
        UpdateScore();

    }
    
    public void UpdateScore(){
        score1.text = playerScore1.ToString();
        score2.text = playerScore2.ToString();
        FinishGame();

    }

    public void FinishGame(){
        ballReset.ResetBall();
        if (playerScore1 == 5){
            winner.text = "Player 1 Wins!";
            Time.timeScale = 0;
        }
        if (playerScore2 == 5){
            winner.text = "Player 2 Wins!";
            Time.timeScale = 0;
        }
    }

}