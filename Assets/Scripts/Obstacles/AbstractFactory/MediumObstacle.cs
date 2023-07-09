﻿namespace Assets.Scripts.Obstacles.AbstractFactory
{
    public class MediumObstacle : Pipe
    {
        public override PipeType GetEnemyType()
        {
            return PipeType.Medium;
        }

        public override void Initialize()
        {
            pWidth = 2;
            pHeight = 4;
        }
    }
}
