using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChoppingMechanic : MonoBehaviour
{
    private Vector3 target;
    public float speed = 0.5f;

    public AudioSource soundEffects;
    public AudioClip[] sounds;

    public static int totalObjects = 6; 
    public static int clickedObjects = 0;

    // Start is called before the first frame update
    void Start()
    {
        soundEffects = GetComponent<AudioSource>();
        target = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        /*if (Input.GetMouseButtonDown(0))
        {
            //target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            /target.z = transform.position.z;
        }

        transform.position = Vector3.MoveTowards(transform.position, target,speed * Time.deltaTime);*/
    }

    void OnMouseDown()
    {
        transform.position = new Vector3(Random.Range(-1.5f, 1.5f), Random.Range(-1.5f, 1.5f), Random.Range(-1.5f, 1.5f));
        soundEffects.PlayOneShot(sounds[0], .7f);
        Debug.Log("clicked the cucumber!");

        if (clickedObjects == totalObjects)
            return;

        clickedObjects++; 
        Debug.Log(gameObject.name + " has been clicked!");

        if (clickedObjects == totalObjects)
        {
            SceneManager.LoadScene(5);
        }
    }
}
