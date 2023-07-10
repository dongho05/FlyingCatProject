namespace Assets.Scripts.Obstacles.AbstractFactory
{
    public class LongObstacle : Pipe
    {
        public override PipeType GetEnemyType()
        {
            return PipeType.Long;
        }
    }
}
