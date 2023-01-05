using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ClickControl : MonoBehaviour
{
    //public AudioSource foundaudio;
    public static int objectsfound;
    public static string relatedToObject;
    public GameObject objectNameText;

    public GameObject GM2;
    void Start()
    {
        objectsfound = 0;
    }

    void Update()
    {
        
    }

    void OnMouseDown() 
    {
        //foundaudio.Play();
        objectsfound += 1;
        TrackingClicks.totalnClicks = 0;

        relatedToObject = gameObject.name;
        Debug.Log (relatedToObject);
        Destroy (gameObject);
        Destroy (objectNameText);
        
        CheckEnd ();
    }

    void CheckEnd ()
    {
        if (objectsfound >= 19)
        {
            GM2.GetComponent<GameManager>().SetGameManagerState3(GameManager.GameManagerState.End);
        }

        //WHYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYY 3LA KALAAAKH !
    }

    /*void NextScene ()
    {
        SceneManager.LoadScene(0);
    }*/
}
