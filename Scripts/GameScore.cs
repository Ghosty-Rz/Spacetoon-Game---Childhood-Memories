using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GameScore : MonoBehaviour
{
    public GameObject GameManagerGOT;
    Text scoreTextUI;
    int score;

    const int MaxScore = 60;

    public int Score
    {
        get
        {
            return this.score;
        }
        set 
        {
            this.score = value;
            UpdateScoreTextUI ();
        }
    }
    void Start()
    {
        scoreTextUI = GetComponent<Text>();
    }

    void UpdateScoreTextUI ()
    {
        int s = score;
        scoreTextUI.text = s.ToString();
        if (s >= MaxScore)
        {
            GameManagerGOT.GetComponent<GameManager>().SetGameManagerState(GameManager.GameManagerState.End);
        }
        //CheckMax (s);
    }

    /*void CheckMax (int s)
    {
        if (s >= MaxScore)
        {
            GameManagerGOT.GetComponent<GameManager>().SetGameManagerState(GameManager.GameManagerState.End);
        }
    }*/
    
}
