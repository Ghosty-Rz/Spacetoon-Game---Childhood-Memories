using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PirateShipController : MonoBehaviour
{
    [SerializeField] private AudioSource coinaudio;
    public GameObject GameManagerGO2;
    public Text LivesUIText;
    const int MaxLives = 3; 
    int lives;
    public float speed ;   
    public void init ()
    {
        lives = MaxLives;
        LivesUIText.text = lives.ToString();

        gameObject.SetActive(true);

    }
    
    void Start()
    {
        speed = 6f;
    }

    
    void Update()
    {
        float x = Input.GetAxisRaw ("Horizontal");
        float y = Input.GetAxisRaw ("Vertical");

        Vector2 direction = new Vector2 (x,y).normalized;

        Move (direction);
    }

    void Move (Vector2 direction)
    {
        Vector2 min = Camera.main.ViewportToWorldPoint (new Vector2 (0,0));
        Vector2 max = Camera.main.ViewportToWorldPoint (new Vector2 (1,1));

        max.x = max.x - 0.225f;
        min.x = min.x + 0.225f;

        max.y = -1.7f;
        min.y = -1.7f;

        Vector2 pos = transform.position;

        pos += direction * speed * Time.deltaTime;

        pos.x = Mathf.Clamp (pos.x, min.x, max.x);
        pos.y = Mathf.Clamp (pos.y, min.y, max.y);

        transform.position = pos;
    
    }

    void OnTriggerEnter2D (Collider2D col) {
        {
            if ((col.tag == "Monster1") || (col.tag == "MonsterYellow") || (col.tag == "MonsterWhite") || (col.tag == "MonsterWeight"))
            {
                //THhat was dumb -_-

                lives --;
                LivesUIText.text = lives.ToString();

                if (lives == 0)
                {
                    //change the manager state to game over
                    GameManagerGO2.GetComponent<GameManager>().SetGameManagerState2(GameManager.GameManagerState.GameOver);

                    gameObject.SetActive(false);
                    //Destroy (gameObject);
                }
            }
            else if (col.tag == "GoldCoinTag")
            {
                //play coin audio
                coinaudio.Play();
            }
        }
    }

    
}
