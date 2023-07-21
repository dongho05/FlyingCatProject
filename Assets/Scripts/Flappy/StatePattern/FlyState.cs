using UnityEngine;

namespace Assets.Scripts.Flappy.StatePattern
{
    public class FlyState : PlayerBaseState
    {
        public FlyState(CatMovement bird) : base(bird)
        {
        }
        public override void EnterState()
        {
            //player.animator.SetFloat("Run", Mathf.Abs(Input.GetAxis("Horizontal")));
        }

        public override void UpdateState()
        {
            float move = Input.GetAxis("Horizontal");
            if (bird.isDead)
            {
                bird.ChangeState(new DeadState(bird));
            }
        }

    }
}
