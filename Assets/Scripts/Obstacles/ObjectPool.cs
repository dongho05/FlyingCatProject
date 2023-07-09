using Assets.Scripts.Obstacles.AbstractFactory;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public static ObjectPool instance;

    public GameObject spawnPoints;
    private readonly Transform[] _factoryBuildings = new Transform[4];

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
        AssignFactoryToBuilding();
        for (int i = 0; i < poolSize; i++)
        {
            GameObject obj1 = _factoryBuildings[1].GetComponent<IObstacleFactory>().CreateShortObstacle();
            //GameObject obj1 = Instantiate(shortPrefab);
            obj1.SetActive(false);
            shortObstaclePool.Add(obj1);
        }
        for (int i = 0; i < poolSize; i++)
        {
            GameObject obj2 = _factoryBuildings[1].GetComponent<IObstacleFactory>().CreateMediumObstacle();
            //GameObject obj2 = Instantiate(mediumPrefab);
            obj2.SetActive(false);
            mediumObstaclePool.Add(obj2);
        }
        for (int i = 0; i < poolSize; i++)
        {
            GameObject obj3 = _factoryBuildings[1].GetComponent<IObstacleFactory>().CreateLongObstacle();
            //GameObject obj3 = Instantiate(tallPrefab);
            obj3.SetActive(false);
            longObstaclePool.Add(obj3);
        }
    }

    public void AssignFactoryToBuilding()
    {
        for (int i = 0; i < 4; i++)
        {
            Transform obstacleTransform = null;
            CreateFactory(i, spawnPoints, out obstacleTransform);

            // nếu như có loại obstacle khác thì làm tương tư bước như dưới để add vào factory
            ObstacleFactory TowerFactory = obstacleTransform.gameObject.AddComponent<ObstacleFactory>();
            TowerFactory.ObstacleTransform = obstacleTransform;

        }
    }

    private Transform CreateFactoryBuilding(GameObject Fac)
    {
        Transform newFactory = Instantiate(Fac.transform, new Vector2(Fac.transform.position.x, Fac.transform.position.y), Quaternion.identity);
        return newFactory;
    }

    private void CreateFactory(int arrayPosition, GameObject Factory, out Transform factoryBuildingTransform)
    {
        if (_factoryBuildings[arrayPosition] == null)
        {
            _factoryBuildings[arrayPosition] = CreateFactoryBuilding(Factory);
            factoryBuildingTransform = _factoryBuildings[arrayPosition];
        }
        else
        {
            factoryBuildingTransform = _factoryBuildings[arrayPosition];
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
                gameObject.transform.position = spawnPoints.transform.position;
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
                gameObject.transform.position = spawnPoints.transform.position;
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
                gameObject.transform.position = spawnPoints.transform.position;
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
