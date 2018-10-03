using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public ScoreCounter ScoreCounterScript; 

    public float speed = 10f ;                  // speed of a ball

    private Vector3 StartPosition;              // start position of a ball
    private Quaternion StartRotation;           // Start rotation of a ball

    public Color Color1;                        // first color that ball will change after detecting a collision
    public Color Color2;                        // second color  - | | - 

    public Material ObjectMaterial;             // material of a ball

    void Start ()
    {
        StartPosition = gameObject.transform.position;                                           // setting a  start position for a ball
        StartRotation = gameObject.transform.rotation;                                           // setting a start rotation for a ball

        Invoke("PowerGiver", 3);                                                                 // launches a PowerGiver in 3 seconds after pressing PLAY

        // CZY TO NIE POWINNO BYC GDZIEŚ INDZIEJ ? 
    }

    private void OnCollisionEnter(Collision col)                                                 // everything after collision
    {
        if(col.gameObject.tag == "Score Wall")  
        {
            GetComponent<Rigidbody>().velocity = new Vector3(0,0);                               // stop ball after hitting score wall
            transform.localScale = new Vector3(3, 3, 3);                                         // scaling it to start scale
            gameObject.transform.SetPositionAndRotation(StartPosition, StartRotation );          // seting start position and start rotation
            Invoke("PowerGiver", 2);                                                             // launches a PowerGiver in 2  seconds 
        }
        ColorChange();                                                                           // changing color after every collision 
    }

    public void PowerGiver() 
    {
        /* losowo wybierana wartosc pomiędzy 0 i 2 . 
        Jeżeli wybierzemy wartosc mniejsza od 1
        to wartość równa sie - 1 
        jeżeli nie, wartosc równa sie 1. */ 

        float sx = Random.Range(0, 2) < 1 ? -1 : 1;
        float sz = Random.Range(0, 2) < 1 ? -1 : 1; 

        GetComponent<Rigidbody>().velocity = new Vector3(speed * sx, 0f, speed * sz);            // add a force to the ball with random direction

        ScoreCounterScript.LastHitForLeftPlayer = true;                                          // nobodys turn for SuperShot
        ScoreCounterScript.LastHitForRightPlayer = true;                                         // nobodys turn for SuperShot
    }

    private void ColorChange()
    {
        // methode that change color of a ball between color1 and color2 

        if (ObjectMaterial.color == Color1)             
        {
            ObjectMaterial.color = Color2;
        }
        else ObjectMaterial.color = Color1;  
    }
}
