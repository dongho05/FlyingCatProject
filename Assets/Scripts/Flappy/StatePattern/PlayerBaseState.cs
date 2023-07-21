namespace Assets.Scripts.Flappy.StatePattern
{
    public class PlayerBaseState
    {
        protected CatMovement bird;

        public PlayerBaseState(CatMovement bird)
        {
            this.bird = bird;
        }

        public virtual void EnterState() { }
        public virtual void UpdateState() { }
        public virtual void ExitState() { }

    }
}
