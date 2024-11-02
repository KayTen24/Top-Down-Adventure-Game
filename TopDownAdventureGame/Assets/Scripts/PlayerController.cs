using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //Importing SceneManagement Library

public class PlayerController : MonoBehaviour
{
    public float speed;
    private SpriteRenderer sr;
    public bool hasKey = false; 
    public bool hasEggs = false;
    public bool hasPeppers = false;
    public bool hasOnions = false;
    public bool hasCheese = false; 

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
            SceneManager.LoadScene(2);

        }

        if ((collision.gameObject.tag.Equals("Door2")))
        {
            Debug.Log("change scene");
            soundEffects.PlayOneShot(sounds[0], .7f); //play door sound effect
            SceneManager.LoadScene(1);

        }

        if ((collision.gameObject.tag.Equals("Key")))
        {
            Debug.Log("obtained knife");
            soundEffects.PlayOneShot(sounds[1], .7f); //play knife sound effect
            hasKey = true;//player has the key now
        }

        if ((collision.gameObject.tag.Equals("Egg")))
        {
            Debug.Log("obtained egg");
            soundEffects.PlayOneShot(sounds[2], .7f); //play item collection sound effect
            hasEggs = true;//player has the egg now
        }

        if ((collision.gameObject.tag.Equals("Pepper")))
        {
            Debug.Log("obtained pepper");
            soundEffects.PlayOneShot(sounds[2], .7f); //play item collection sound effect
            hasPeppers = true;//player has the pepper now
        }

        if ((collision.gameObject.tag.Equals("Onion")))
        {
            Debug.Log("obtained onion");
            soundEffects.PlayOneShot(sounds[2], .7f); //play item collection sound effect
            hasOnions = true;//player has the onion now
        }

        if ((collision.gameObject.tag.Equals("Cheese")))
        {
            Debug.Log("obtained cheese");
            soundEffects.PlayOneShot(sounds[2], .7f); //play item collection sound effect
            hasCheese = true;//player has the cheese now
        }

        if (collision.gameObject.tag.Equals("Oven") && hasKey && hasEggs && hasOnions && hasPeppers && hasCheese == true)
        {
            Debug.Log("Game Ended");
            Destroy(this.gameObject);
            SceneManager.LoadScene(3);
            //End the Game
        }
    }
}
