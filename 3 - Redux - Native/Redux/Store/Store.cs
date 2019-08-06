using System;
using System.Threading.Tasks;
using Redux.Services;

namespace Redux.Store
{
    public class Store
    {
        private readonly IReducer _reducer = new Reducer();
        private State _currentState;
        public event Action<State> StateChanged;

        public void Dispatch(IAction action)
        {
            _currentState = _reducer.Reduce(_currentState, action);
            StateChanged?.Invoke(_currentState);
        }
    }

    public interface IAction
    {
    }

    public interface IReducer
    {
        State Reduce(State state,IAction action);
    }
}