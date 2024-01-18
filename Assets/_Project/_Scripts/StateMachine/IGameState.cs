using _Project._Scripts.Infrastructure.StateMachine;

namespace _Project._Scripts.Infrastructure.GameStates
{
    public interface IGameState : IState
    {
        void Init(StateMachine<IGameState> stateMachine);
    }
}