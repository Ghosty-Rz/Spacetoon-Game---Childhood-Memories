using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterController : MonoBehaviour
{
    public GameObject Collision;
    float speed;
    // Start is called before the first frame update
    void Start()
    {
        speed = 2f;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 position = transform.position; //get the enemy's initial position

        position = new Vector2 (position.x, position.y - speed * Time.deltaTime);

        transform.position = position;

        Vector2 min = Camera.main.ViewportToWorldPoint (new Vector2(0,0));

        if (transform.position.y < min.y)
        {
            Destroy (gameObject);
        }
    }

    void OnTriggerEnter2D (Collider2D col)
    {
        if ((col.tag == "PirateShipTag"))
        {
            PlayCollision();
            Destroy (gameObject);
        }
    }

    void PlayCollision()
    {
        GameObject collision = (GameObject)Instantiate(Collision);
        collision.transform.position = transform.position;
    }
}
