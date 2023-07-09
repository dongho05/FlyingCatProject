namespace Assets.Scripts.Obstacles.AbstractFactory
{
    public class LongObstacle : Pipe
    {
        public override PipeType GetEnemyType()
        {
            return PipeType.Long;
        }

        public override void Initialize()
        {
            pWidth = 2;
            pHeight = 5;
        }
    }
}
