using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneToLevel2 : MonoBehaviour
{
    [SerializeField] private AudioSource clickaudio;
    public Animator transitionanim;
    public void level2 ()
    {
        clickaudio.Play();
        transitionanim.SetTrigger("Start");
        Invoke ("LoadNextScene", 1.2f);
    }

    public void LoadNextScene ()
    {
        SceneManager.LoadScene(3);
    }
}
