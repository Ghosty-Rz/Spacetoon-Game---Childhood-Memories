using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneToFinish : MonoBehaviour
{
   [SerializeField] private AudioSource clickaudio;
    //public Animator transitionanim;
    public void FinishGame ()
    {
        clickaudio.Play();
        //transitionanim.SetTrigger("Start");
        //Invoke ("LoadNextScene", 1.2f);
        SceneManager.LoadScene(7);
    }

    /*public void LoadNextScene ()
    {
        SceneManager.LoadScene(3);
    }*/
}
