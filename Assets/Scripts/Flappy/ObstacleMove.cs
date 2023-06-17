using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMove : MonoBehaviour
{

    public float speed = 3f;


    // Start is called before the first frame update
    

    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        DestroyObject();
    }

    private void DestroyObject()
    {
        if(transform.position.x < -12)
        {
            Destroy(gameObject);
        }
    }

    private void Move()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;
    }
}
