using UnityEngine;

namespace Assets.Scripts.Obstacles.AbstractFactory
{
    public class ObstacleFactory : IObstacleFactory
    {
        public override GameObject CreateShortObstacle()
        {
            var factoryTransformPosition = ObstacleTransform.transform.position;
            var shortObstacle = Resources.Load("ShortPipe") as GameObject;
            if (shortObstacle != null)
            {
                GameObject obj = Instantiate(shortObstacle, new Vector2(factoryTransformPosition.x, factoryTransformPosition.y), Quaternion.identity);
                return obj;
            }
            else
            {
                throw new System.ArgumentException(shortObstacle + " could not be found inside or loaded from Resources folder");
            }
        }

        public override GameObject CreateMediumObstacle()
        {
            var mediumObstacle = Resources.Load("MediumPipe") as GameObject;
            if (mediumObstacle != null)
            {
                GameObject obj = Instantiate(mediumObstacle);
                return obj;
            }
            else
            {
                throw new System.ArgumentException(mediumObstacle + " could not be found inside or loaded from Resources folder");
            }
        }

        public override GameObject CreateLongObstacle()
        {
            var longObstacle = Resources.Load("LongPipe") as GameObject;
            if (longObstacle != null)
            {
                GameObject obj = Instantiate(longObstacle);
                return obj;
            }
            else
            {
                throw new System.ArgumentException(longObstacle + " could not be found inside or loaded from Resources folder");
            }
        }
    }
}
