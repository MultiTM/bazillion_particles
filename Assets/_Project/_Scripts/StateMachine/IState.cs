namespace _Project._Scripts.Infrastructure.StateMachine
{
    public interface IState
    {
        public void Enter();
        public void Exit();
    }
}