using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScriptSceneToLevel3 : MonoBehaviour
{
  [SerializeField] private AudioSource clickaudio;
    public Animator transitionanim;
    public void level3 ()
    {
        clickaudio.Play();
        transitionanim.SetTrigger("Start");
        Invoke ("LoadNextScene", 1.2f);
    }

    public void LoadNextScene ()
    {
        SceneManager.LoadScene(5);
    }
}
