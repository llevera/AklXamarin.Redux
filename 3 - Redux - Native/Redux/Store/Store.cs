using System;
using Redux.Services;

namespace Redux.Store
{
    public class Store
    {
        private State _currentState;
        private readonly IReducer _reducer = new Reducer(new MockDataStore());
        public event Action<State> StateChanged;

        public void Dispatch(IAction action)
        {
            _currentState = _reducer.Reduce(_currentState, action);
            StateChanged?.Invoke(_currentState);
        }
    }

    public interface IReducer
    {
        State Reduce(State state, IAction action);
    }

    public interface IAction
    {
    }
}