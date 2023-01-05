using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletScript : MonoBehaviour
{
    float speed;
    Vector2 _direction;
    bool isReady;

    void Awake ()
    {
        speed = 5f;
        isReady = false;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

public void SetDirection (Vector2 direction)
{
    _direction = direction.normalized;
    isReady = true;
}
    // Update is called once per frame
    void Update()
    {
        if (isReady)
        {
            Vector2 position = transform.position; //look fo rinitial position

            position += _direction * speed * Time.deltaTime; //look for new position

            transform.position = position; //update position

            Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2 (0,0)); // find the bottom-left of the screen 

            Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2 (1,1)); // find the top-rigth of the screen 

            if ((transform.position.x < min.x ) || (transform.position.x > max.x) || (transform.position.y < min.y ) || (transform.position.y > max.y))
            {
                Destroy (gameObject); //we have to destroy object when out of screen 
            }
        }
    }

    void OnTriggerEnter2D (Collider2D col)
    {
        if (col.tag == "PlayerShipTag")
            Destroy (gameObject);
    }
}
