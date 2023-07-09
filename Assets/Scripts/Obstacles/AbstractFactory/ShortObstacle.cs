namespace Assets.Scripts.Obstacles.AbstractFactory
{

    public class ShortObstacle : Pipe
    {

        public override PipeType GetEnemyType()
        {
            return PipeType.Short;
        }

        public override void Initialize()
        {
            pHeight = 2;
            pWidth = 2;
        }
    }
}
