using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public GameObject Player;
    public GameObject PlayerCube; 

    private float Speed = 50f;   // speed of a player

    public bool LeftPlayer;      
    public bool RightPlayer;

    public Vector3 Translation; 

    private void LateUpdate()
    {
        if(RightPlayer)       // right player movement
        {
            float UpAndDownMove = Input.GetAxis("Player2Movement") * Speed * Time.deltaTime;
            Translation = new Vector3(0, 0, UpAndDownMove); 
            Player.transform.Translate(Translation); 
            MaxPosition();   
        }
        if(LeftPlayer)        // left player movement
        {
            float UpAndDownMove = Input.GetAxis("Player1Movement") * Speed * Time.deltaTime;
            Player.transform.Translate(Vector3.forward * UpAndDownMove);
            MaxPosition(); 
        }
    }

    private void MaxPosition ()                // players max movement
    {
        if (Player.transform.position.z >= 23) 
        {
            Player.transform.position = new Vector3(Player.transform.position.x , Player.transform.position.y, 23);
        }
        if (Player.transform.position.z <= -23)
        {
            Player.transform.position = new Vector3(Player.transform.position.x, Player.transform.position.y, -23);
        }
    }
}

