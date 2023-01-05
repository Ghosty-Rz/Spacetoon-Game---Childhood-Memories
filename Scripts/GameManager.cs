using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private AudioSource clickaudio;
    public GameObject playership;
    public GameObject enemySpawner;

    public GameObject pirateShip;
    public GameObject monsterSpawner;

    public GameObject playButton;
    public GameObject GameOverGO;
    public GameObject Congratulations;
    public GameObject scoreUIText;
    public GameObject TimeTextUI;
    public static int GMStateGameplay;
    public enum GameManagerState
    {
        Opening,
        Gameplay,
        GameOver,
        End,

    }

    GameManagerState GMState;

    void start ()
    {
        GMState = GameManagerState.Opening;
    }

    void UpdateGameManagerState ()
    {
        switch (GMState)
        {
            case GameManagerState.Opening:

                GameOverGO.SetActive(false);
                Congratulations.SetActive(false);
                playButton.SetActive(true);
                    break;

            case GameManagerState.Gameplay:
                scoreUIText.GetComponent<GameScore>().Score = 0;
                Congratulations.SetActive(false);
                GameOverGO.SetActive(false);
                playButton.SetActive(false);
                playership.GetComponent<PlayerController>().init();
                enemySpawner.GetComponent<EnemySpawnerScript>().ScheduleEnemySpawner();
                    break;

            case GameManagerState.GameOver:

                //display Game Over
                GameOverGO.SetActive(true);

                Invoke ("ChangeToOpeningState", 5f);
                    break;

            case GameManagerState.End:
                Congratulations.SetActive(true);
                playership.SetActive(false);
                //load next scene 
                Invoke ( "LoadEndLevel1" , 4f );

                    break;
        }
    }

    void UpdateGameManagerState2 ()
    {
        switch (GMState)
        {
            case GameManagerState.Opening:

                GameOverGO.SetActive(false);
                Congratulations.SetActive(false);
                playButton.SetActive(true);
                break;
            case GameManagerState.Gameplay:
                GameOverGO.SetActive(false);
                Congratulations.SetActive(false);
                playButton.SetActive(false);
                pirateShip.GetComponent<PirateShipController>().init();
                monsterSpawner.GetComponent<MonsterSpawnerScript>().ScheduleMonsterSpawner();
                break;
            case GameManagerState.GameOver:

                //display Game Over
                GameOverGO.SetActive(true);
                Invoke ("ChangeToOpeningState2", 5f);
                break;

            case GameManagerState.End:
                Congratulations.SetActive(true);
                pirateShip.SetActive(false);
                //load next scene 

                Invoke ( "LoadEndLevel2" , 4f );
                    break;
        }
    }

    void UpdateGameManagerState3 ()
    {
        switch (GMState)
        {
            case GameManagerState.Opening:

                GameOverGO.SetActive(false);
                Congratulations.SetActive(false);
                playButton.SetActive(true);
                break;
            case GameManagerState.Gameplay:
                TimeTextUI.GetComponent<Timer>().init();
                GMStateGameplay = 1;
                GameOverGO.SetActive(false);
                Congratulations.SetActive(false);
                playButton.SetActive(false);
                
                break;
            case GameManagerState.GameOver:

                //display Game Over
                GameOverGO.SetActive(true);
                Invoke ("ChangeToOpeningState3", 5f);
                break;

            case GameManagerState.End:
                Congratulations.SetActive(true);
                
                //load next scene 

                Invoke ( "LoadEndLevel3" , 4f );
                    break;
        }
    }
    public void SetGameManagerState(GameManagerState state)
    {
        GMState = state;
        UpdateGameManagerState ();
    }

    public void SetGameManagerState2(GameManagerState state2)
    {
        GMState = state2;
        UpdateGameManagerState2 ();
    }

    public void SetGameManagerState3(GameManagerState state3)
    {
        GMState = state3;
        UpdateGameManagerState3 ();
    }

    public void StartGamePlay ()
    {
        //play audio
        clickaudio.Play();

        GMState = GameManagerState.Gameplay;
        UpdateGameManagerState();

    }

    public void StartGamePlay2 ()
    {
        clickaudio.Play();
        GMState = GameManagerState.Gameplay;
        UpdateGameManagerState2();

    }

    public void StartGamePlay3 ()
    {
        clickaudio.Play();
        GMState = GameManagerState.Gameplay;
        UpdateGameManagerState3();

    }
    public void ChangeToOpeningState ()
    {
        SetGameManagerState (GameManagerState.Opening);
    }

    public void ChangeToOpeningState2 ()
    {
        SetGameManagerState2 (GameManagerState.Opening);
    }

    public void ChangeToOpeningState3 ()
    {
        SetGameManagerState3 (GameManagerState.Opening);
    }

    public void LoadEndLevel1 ()
    {
        SceneManager.LoadScene(2);
    }

    public void LoadEndLevel2 ()
    {
        SceneManager.LoadScene(4);
    }

    public void LoadEndLevel3 ()
    {
        SceneManager.LoadScene(6);
    } 
}
