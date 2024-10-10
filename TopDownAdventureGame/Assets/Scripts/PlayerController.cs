using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //Importing SceneManagement Library

public class PlayerController : MonoBehaviour
{
    public float speed;
    private SpriteRenderer sr;
    public bool hasKey = false; 

    //sprite variables
    public Sprite upSprite;
    public Sprite leftSprite;
    public Sprite rightSprite;
    public Sprite frontSprite;

    //public Rigidbody2D rb; 
    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>(); 
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 newPosition = transform.position; 

        //go left
        if(Input.GetKey("a"))
        {
            newPosition.x -= speed;
        }

        //go right
        if (Input.GetKey("d"))
        {
            newPosition.x += speed;
        }

        //go up
        if (Input.GetKey("w"))
        {
            newPosition.y += speed;
        }

        //go down
        if (Input.GetKey("s"))
        {
            newPosition.y -= speed;
        }

        transform.position = newPosition;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if ((collision.gameObject.tag.Equals("Door1") && hasKey == true))
        {
            Debug.Log("change scene");
            SceneManager.LoadScene(1);

        }

        if ((collision.gameObject.tag.Equals("Key")))
        {
            Debug.Log("obtained key");
            hasKey= true;//player has the key now
        }
    }
}
