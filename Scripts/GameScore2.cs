using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GameScore2 : MonoBehaviour
{
    public GameObject GameManagerGO2;
    Text scoreTextUI;
    int score;

    const int MaxScore = 14;

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
            GameManagerGO2.GetComponent<GameManager>().SetGameManagerState2(GameManager.GameManagerState.End);
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
