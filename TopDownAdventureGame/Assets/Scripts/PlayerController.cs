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

    //audio variables
    public AudioSource soundEffects;
    public AudioClip[] sounds;

    //public Rigidbody2D rb; 

    public static PlayerController instance;
    // Start is called before the first frame update
    void Start()
    {
        soundEffects = GetComponent<AudioSource>();
        sr = GetComponent<SpriteRenderer>();
        if (instance != null) //if another instance of the player is in the scene
        {
            Destroy(gameObject); //then destroy it
        }

        instance = this; //reassign the instance to the current player
        GameObject.DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 newPosition = transform.position; 

        //go left
        if(Input.GetKey("a"))
        {
            newPosition.x -= speed;
            sr.sprite = leftSprite;
        }

        //go right
        if (Input.GetKey("d"))
        {
            newPosition.x += speed;
            sr.sprite = rightSprite;
        }

        //go up
        if (Input.GetKey("w"))
        {
            newPosition.y += speed;
            sr.sprite = upSprite;
        }

        //go down
        if (Input.GetKey("s"))
        {
            newPosition.y -= speed;
            sr.sprite = frontSprite;
        }

        transform.position = newPosition;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if ((collision.gameObject.tag.Equals("Door1")))
        {
            Debug.Log("change scene");
            soundEffects.PlayOneShot(sounds[0], .7f); //play door sound effect
            SceneManager.LoadScene(1);

        }

        if ((collision.gameObject.tag.Equals("Door2")))
        {
            Debug.Log("change scene");
            SceneManager.LoadScene(0);

        }

        if ((collision.gameObject.tag.Equals("Key")))
        {
            Debug.Log("obtained knife");
            hasKey= true;//player has the key now
        }
    }
}
