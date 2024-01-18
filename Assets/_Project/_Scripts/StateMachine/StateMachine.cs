using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace _Project._Scripts.Infrastructure.StateMachine
{
    public abstract class StateMachine<T> where T : IState
    {
        protected List<T> _states;
        protected T _currentState;

        public T CurrentState => _currentState;

        public StateMachine(List<T> states)
        {
            _states = states;
        }

        public void EnterState<TState>() where TState : T
        {
            var targetState = _states.FirstOrDefault(x => x.GetType() == typeof(TState));
            if (targetState == null)
            {
                Debug.LogWarning("Trying to enter non-existent state");
                return;
            }

            if (targetState.GetType() == _currentState?.GetType())
            {
                return;
            }
            
            if (_currentState != null)
            {
                _currentState.Exit();
            }

            _currentState = targetState;
            _currentState.Enter();
        }
    }
}