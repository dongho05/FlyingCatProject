using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public static ObjectPool instance;

    private List<GameObject> shortObstaclePool = new List<GameObject>();
    private List<GameObject> mediumObstaclePool = new List<GameObject>();
    private List<GameObject> longObstaclePool = new List<GameObject>();
    public int poolSize = 10;

    [SerializeField] private GameObject shortPrefab;
    [SerializeField] private GameObject mediumPrefab;
    [SerializeField] private GameObject tallPrefab;


    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < poolSize; i++)
        {
            GameObject obj1 = Instantiate(shortPrefab);
            obj1.SetActive(false);
            shortObstaclePool.Add(obj1);
        }
        for (int i = 0; i < poolSize; i++)
        {
            GameObject obj2 = Instantiate(mediumPrefab);
            obj2.SetActive(false);
            mediumObstaclePool.Add(obj2);
        }
        for (int i = 0; i < poolSize; i++)
        {
            GameObject obj3 = Instantiate(tallPrefab);
            obj3.SetActive(false);
            longObstaclePool.Add(obj3);
        }
    }
    // Short Obstacle
    public GameObject GetShortObstacleFromPool()
    {
        foreach (GameObject gameObject in shortObstaclePool)
        {
            if (!gameObject.activeInHierarchy)
            {
                shortObstaclePool.Remove(gameObject);
                gameObject.SetActive(true);    
                return gameObject;
            }
           
        }

        // Nếu không có đối tượng nào khả dụng trong Object Pool, hãy tạo thêm đối tượng mới
        GameObject newObj = Instantiate(shortPrefab);
        shortObstaclePool.Add(newObj);
        return newObj;
    }

    // Phương thức để trả lại đối tượng vào Object Pool
    public void ReturnShortObstacleToPool(GameObject obj)
    {
        shortObstaclePool.Add(obj);
        obj.SetActive(false);
    }


    // Medium Obstacle
    public GameObject GetMediumObstacleFromPool()
    {
        foreach (GameObject gameObject in mediumObstaclePool)
        {
            if (!gameObject.activeInHierarchy)
            {
                mediumObstaclePool.Remove(gameObject);
                gameObject.SetActive(true);
                return gameObject;
            }

        }

        // Nếu không có đối tượng nào khả dụng trong Object Pool, hãy tạo thêm đối tượng mới
        GameObject newObj = Instantiate(mediumPrefab);
        mediumObstaclePool.Add(newObj);
        return newObj;
    }

    // Phương thức để trả lại đối tượng vào Object Pool
    public void ReturnMediumObstacleToPool(GameObject obj)
    {
        mediumObstaclePool.Add(obj);
        obj.SetActive(false);
    }


    // Tall Obstacle
    public GameObject GetLongObstacleFromPool()
    {
        foreach (GameObject gameObject in longObstaclePool)
        {
            if (!gameObject.activeInHierarchy)
            {
                longObstaclePool.Remove(gameObject);
                gameObject.SetActive(true);
                return gameObject;
            }

        }

        // Nếu không có đối tượng nào khả dụng trong Object Pool, hãy tạo thêm đối tượng mới
        GameObject newObj = Instantiate(tallPrefab);
        longObstaclePool.Add(newObj);
        return newObj;
    }

    // Phương thức để trả lại đối tượng vào Object Pool
    public void ReturnLongObstacleToPool(GameObject obj)
    {
        longObstaclePool.Add(obj);
        obj.SetActive(false);
    }
}
