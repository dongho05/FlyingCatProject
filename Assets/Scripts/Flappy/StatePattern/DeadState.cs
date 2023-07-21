namespace Assets.Scripts.Flappy.StatePattern
{
    public class DeadState : PlayerBaseState
    {
        public DeadState(CatMovement bird) : base(bird) { }

        public override void EnterState()
        {
            bird.animator.SetTrigger("isDied");
        }

        public override void UpdateState()
        {

        }

    }
}
