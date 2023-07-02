
using System;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleGenerate : MonoBehaviour
{
    public List<GameObject> obstacles = new List<GameObject>();

    public static int phaseNow = 1;

    List<int> percentages = new List<int> { 30, 30, 40 };
    public float timeDuration;
    private float countDown;
    public bool enable;

    private float timePhase = 10f;
    private float countTimePhase;
    public int phase;


    void Awake()
    {

    }
    // Start is called before the first frame update
    void Start()
    {
        phase = 0;
        percentages[0] = SpawnRateController.listSpawnRates[phase].ShortPipe;
        percentages[1] = SpawnRateController.listSpawnRates[phase].MediumPipe;
        percentages[2] = SpawnRateController.listSpawnRates[phase].LongPipe;
        //countDown = timeDuration;
        countTimePhase = timePhase;

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
                countDown = timeDuration;
            }

            countTimePhase -= Time.deltaTime;
            if (countTimePhase <= 0)
            {
                phase++;
                
                phaseNow = phase;
                Debug.Log(phaseNow);
                
                if (phase <= 11)
                {
                    if (phase == 4 || phase == 8 || phase == 12)
                    {
                        ObstacleMove.speed++;

                    }

                    percentages[0] = SpawnRateController.listSpawnRates[phase].ShortPipe;
                    percentages[1] = SpawnRateController.listSpawnRates[phase].MediumPipe;
                    percentages[2] = SpawnRateController.listSpawnRates[phase].LongPipe;
                }
                else
                {
                    ObstacleMove.speed += 0.5f;
                }
                countTimePhase = timePhase;
            }
        }

    }


    public static void RandomObject(List<int> percentages, List<GameObject> pipes)
    {
        System.Random random = new System.Random();
        double randomValue = random.Next(1, 101);
        Console.WriteLine(randomValue);

        int minPipe1 = 1;
        int maxPipe1 = (int)percentages[0];

        int minPipe2 = (int)percentages[0] + 1;
        int maxPipe2 = (int)percentages[0] + (int)percentages[1];

        int minPipe3 = (int)percentages[0] + (int)percentages[1] + 1;
        int maxPipe3 = 100;

        if (randomValue >= minPipe1 && randomValue <= maxPipe1)
        {
            //Instantiate(pipes[0], new Vector3(25, UnityEngine.Random.Range(-8.45f, -0.73f), 0), Quaternion.identity);
            GameObject shortOb = ObjectPool.instance.GetShortObstacleFromPool();
            shortOb.gameObject.transform.position = new Vector3(25, UnityEngine.Random.Range(-8.45f, -0.73f), 0);
        }
        if (randomValue >= minPipe2 && randomValue <= maxPipe2)
        {
            //Instantiate(pipes[2], new Vector3(25, UnityEngine.Random.Range(-6.48f, -0.66f), 0), Quaternion.identity);
            GameObject mediumOb = ObjectPool.instance.GetMediumObstacleFromPool();
            mediumOb.gameObject.transform.position = new Vector3(25, UnityEngine.Random.Range(-6.48f, -0.66f), 0);
        }
        if (randomValue >= minPipe3 && randomValue <= maxPipe3)
        {
            //Instantiate(pipes[2], new Vector3(25, UnityEngine.Random.Range(-5.5f, -0.7f), 0), Quaternion.identity);
            GameObject longOb = ObjectPool.instance.GetLongObstacleFromPool();
            longOb.gameObject.transform.position = new Vector3(25, UnityEngine.Random.Range(-5.5f, -0.7f), 0);

        }

        //return null;
    }
}
