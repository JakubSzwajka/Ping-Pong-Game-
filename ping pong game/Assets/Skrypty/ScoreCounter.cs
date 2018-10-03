using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class ScoreCounter : MonoBehaviour
{

    public float LeftPlayerScore = 0; 
    public float RightPlayerScore = 0;

    public float SuperShotPointCost;   

    public Text UIcountTextForLeftPlayer;        // place for left player score text
    public Text UIcountTextForRightPlayer;       // place for right player score text
    public Text WinnerName;                      // place for winner name after winning

    public bool LastHitForRightPlayer = true;    
    public bool LastHitForLeftPlayer = true; 

    public Ball BallScript;

    public Canvas Winner; 

    void Start ()
    {
        Winner.enabled = false;                  //winner Canvas off
       
        SetScoreTextForLeftPlayer();   
        SetScoreTextForRightPlayer(); 
    }

    void Update()
    {
        // super Shot for right player
        if(RightPlayerScore >= SuperShotPointCost  && Input.GetKeyDown(KeyCode.RightControl) && LastHitForRightPlayer == false )
        {
            RightPlayerScore = RightPlayerScore - SuperShotPointCost;
            SetScoreTextForRightPlayer();
            SuperShot(); 
        }
        // super Shot for left player
        if(LeftPlayerScore >= SuperShotPointCost && Input.GetKeyDown(KeyCode.Space) && LastHitForLeftPlayer == false )
        {
            LeftPlayerScore = LeftPlayerScore - SuperShotPointCost;
            SetScoreTextForLeftPlayer();
            SuperShot(); 
        }
        SetScoreTextForLeftPlayer();           // for good menu update
        SetScoreTextForRightPlayer();          // for good menu update
        WinnerChecking();                      // check if you win the game 
    }

    private void OnCollisionEnter(Collision col) // collisions detecting
    {
        if(col.gameObject.name == "left wall")  
        {
            RightPlayerScore++;                           // if left wall, add a point for right player
        }
        else if (col.gameObject.name == "right wall")     
        {
            LeftPlayerScore++;                            // if right wall, add a point for left player
        }
        else if (col.gameObject.name == "LeftPlayer")     // if ball hit a left player 
        {
            LastHitForRightPlayer = false;                // set bool states for Super Shot
            LastHitForLeftPlayer = true;                  // avalible for Right player
        }
        else if(col.gameObject.name == "RightPlayer")     // if ball hit a right player
        {
            LastHitForRightPlayer = true;                 // set bool states for Super Shot
            LastHitForLeftPlayer = false;                 // avalible for Left Player
        }
        SetScoreTextForRightPlayer();                   
        SetScoreTextForLeftPlayer();
        
    }

    private void SetScoreTextForLeftPlayer()
    {
        UIcountTextForLeftPlayer.text = "LEFT PLAYER SCORE: " + LeftPlayerScore.ToString();
    }

    private void SetScoreTextForRightPlayer()
    {
        UIcountTextForRightPlayer.text = "RIGHT PLAYER SCORE: " + RightPlayerScore.ToString(); 
    }

    private void SuperShot()
    {
        GetComponent<Rigidbody>().velocity = GetComponent<Rigidbody>().velocity * 2;   // get a ball velocity and multiply it by 2
        transform.localScale = new Vector3(2, 2, 2);                                   // after super Shot ball is going to be much smaller
    }

    private void WinnerChecking()
    {
        // Players are going to win if they will collect 5 point 
        if (LeftPlayerScore == 5)
        {
            Time.timeScale = 0;
            Cursor.visible = true;
            WinnerName.text = " RIGHT PLAYER WON!" ;
            Winner.enabled = true;                         // winner Canvas on
        }
        else if(RightPlayerScore == 5)
        {
            Time.timeScale = 0;
            Cursor.visible = true;
            WinnerName.text = " LEFT PLAYER WON!";
            Winner.enabled = true;                         // winner Canvas on
        }
    }
}
