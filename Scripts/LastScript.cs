using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LastScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Invoke ("LoadFinalScene", 30f);
    }

    void LoadFinalScene ()
    {
        SceneManager.LoadScene(8);
    }
}
