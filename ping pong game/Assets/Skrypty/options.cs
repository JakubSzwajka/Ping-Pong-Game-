using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class options : MonoBehaviour
{
    public ScoreCounter ScoreCounterScript;

    public AudioSource AudioSource;

    public float Volume;
    public float Pitch; 

	void Start ()
    {
        AudioSource.volume = 1;
        AudioSource.pitch = 1; 
	}
	
	void Update ()
    {
        AudioSource.volume = Volume;
        AudioSource.pitch = Pitch;
        // after all points getting closer to 5 the music is going faster
        Pitch = 1f + ScoreCounterScript.LeftPlayerScore * 0.05f + ScoreCounterScript.RightPlayerScore * 0.05f;  
    }

    public void AdjustVolume(float NewVolume)  // ADJUST VOLUME IN OPTIONS
    {
        Volume = NewVolume; 
    }


}
