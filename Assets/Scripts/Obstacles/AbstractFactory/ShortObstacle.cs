namespace Assets.Scripts.Obstacles.AbstractFactory
{

    public class ShortObstacle : Pipe
    {

        public override PipeType GetEnemyType()
        {
            return PipeType.Short;
        }

    }
}
