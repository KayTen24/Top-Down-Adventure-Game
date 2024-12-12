using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoppingMechanic : MonoBehaviour
{
    private Vector3 target;
    public float speed = 0.5f; 
    
    // Start is called before the first frame update
    void Start()
    {
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
        target.x += 1f;
        Debug.Log("clicked the cucumber!");
        transform.position = target;
    }
}
