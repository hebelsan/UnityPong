using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int speed = 10;
    float screenHalfWidth;
    

    void Start()
    {
        float halfPlayerWidth = GetComponent<Renderer>().bounds.size.x / 2f;
        print(halfPlayerWidth);
        screenHalfWidth = Camera.main.aspect * Camera.main.orthographicSize - halfPlayerWidth;
    }

    public void Move()
    {
        Vector3 Movement;
        #if UNITY_ANDROID
            Movement = new Vector3(Input.acceleration.x, 0, 0);
        #elif UNITY_STANDALONE_WIN
            Movement = new Vector3(Input.GetAxis("Horizontal"), 0, 0);
        #endif

        transform.position += Movement * speed * Time.deltaTime;

        if (transform.position.x < -screenHalfWidth) {
            transform.position = new Vector3(-screenHalfWidth, transform.position.y, transform.position.z);
        }

        if (transform.position.x > screenHalfWidth) {
            transform.position = new Vector3(screenHalfWidth, transform.position.y, transform.position.z);
        }
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }
}
