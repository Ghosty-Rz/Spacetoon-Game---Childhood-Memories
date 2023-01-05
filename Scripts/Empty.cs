using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Empty : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        RectTransform rt = GetComponent<RectTransform>();
        rt.localPosition = Vector3.zero;
        Destroy(this); //The object is moved when the game is loaded so you don't need this script anymore after this.
    }
    
}
