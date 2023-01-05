using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public GameObject GM1;
    public static float currentTime;
    public float startingTime = 200f;

    [SerializeField] Text countdownText;

    public void init() 
    {
        countdownText.GetComponent<Text>();
        currentTime = startingTime;
    }
    void Start()
    {
        
    }
    void Update()
    {
        currentTime -= Time.deltaTime;
        string MyString = string.Format ("{0:00:00}", currentTime);
        countdownText.text = MyString;

        if (currentTime <= 0)
        {
            currentTime = 0;
            if (GameManager.GMStateGameplay == 1)
            {
                GM1.GetComponent<GameManager>().SetGameManagerState3(GameManager.GameManagerState.GameOver);
            }
        }
    }
}

