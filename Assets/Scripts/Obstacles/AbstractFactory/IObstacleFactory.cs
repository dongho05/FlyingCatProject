using UnityEngine;

public abstract class IObstacleFactory : MonoBehaviour
{
    public Transform ObstacleTransform;
    public abstract GameObject CreateShortObstacle();
    public abstract GameObject CreateMediumObstacle();
    public abstract GameObject CreateLongObstacle();
}
