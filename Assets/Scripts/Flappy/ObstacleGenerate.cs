
using System;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleGenerate : MonoBehaviour
{
    public List<GameObject> obstacles = new List<GameObject>();
    List<int> percentages = new List<int> { 30, 30, 40 };
    public float timeDuration;
    private float countDown;
    public bool enable;
  
    // Start is called before the first frame update
    void Start()
    {
        //countDown = timeDuration;
        enable = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (enable)
        {
            countDown -= Time.deltaTime;
            if (countDown <= 0)
            {
                RandomObject(percentages, obstacles);
                //Instantiate(RandomObject(percentages,obstacles ), new Vector3(25, UnityEngine.Random.Range(-8.4f, -0.6f), 0), Quaternion.identity);
                countDown = timeDuration;
            }
        }
        
    }


    public static void RandomObject(List<int> percentages, List<GameObject> pipes)
    {
        string objectDict = "";

        System.Random random = new System.Random();
        double randomValue = random.Next(1, 101);
        Console.WriteLine(randomValue);

        int minPipe1 = 1;
        int maxPipe1 = (int)percentages[0] + 1;

        int minPipe2 = (int)percentages[0] + 1;
        int maxPipe2 = (int)percentages[0] + (int)percentages[1] + 1;

        int minPipe3 = (int)percentages[0] + (int)percentages[1] + 1;
        int maxPipe3 = 101;

        if (randomValue >= minPipe1 && randomValue <= maxPipe1)
        {
            Instantiate(pipes[0], new Vector3(25, UnityEngine.Random.Range(-8.45f, -0.73f), 0), Quaternion.identity);
            //return pipes[0];
        }
        if (randomValue >= minPipe2 && randomValue <= maxPipe2)
        {
            Instantiate(pipes[2], new Vector3(25, UnityEngine.Random.Range(-6.48f, -0.66f), 0), Quaternion.identity);
            //return pipes[1];
        }
        if (randomValue >= minPipe3 && randomValue <= maxPipe3)
        {
            Instantiate(pipes[2], new Vector3(25, UnityEngine.Random.Range(-5.5f, -0.7f), 0), Quaternion.identity);
            //return pipes[2];
        }

        //return null;
    }
}
