using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackingClicks : MonoBehaviour
{
    public AudioSource failaudio;
    public AudioSource foundaudio;
    public static int totalnClicks;
    public KeyCode mouseClick; //tracks oif the player ever clicks during the game

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(mouseClick))
        {
            totalnClicks += 1;
        }

        if (totalnClicks >= 3)
        {
            failaudio.Play();
            Timer.currentTime = Timer.currentTime - 20f;
            totalnClicks = 0;
        }
        
    }

    
}
