using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMove : MonoBehaviour
{

    public static float speed = 3f;


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
            if (this.gameObject.tag.Equals("shortPipe"))
            {
                ObjectPool.instance.ReturnShortObstacleToPool(this.gameObject);
            }
            if (this.gameObject.tag.Equals("mediumPipe"))
            {
                ObjectPool.instance.ReturnMediumObstacleToPool(this.gameObject);
            }
            if (this.gameObject.tag.Equals("longPipe"))
            {
                ObjectPool.instance.ReturnLongObstacleToPool(this.gameObject);
            }
            //Destroy(gameObject);
        }
    }

    private void Move()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;
    }
}
