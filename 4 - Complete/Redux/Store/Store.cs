using System;
using System.Threading.Tasks;

namespace Redux.Store
{
    public class Store
    {
        private State _lastState;
        public event Action<State> StateChanged;

        public void Dispatch(IAction action)
        {
            _lastState = action.Reduce(_lastState);
            StateChanged?.Invoke(_lastState);
        }
        
        public async Task Dispatch(ISaga saga)
        {
            await saga.Handle(this);
        }
    }

    public interface IAction
    {
        State Reduce(State state);
    }
    
    public interface ISaga
    {
        Task Handle (Store store);
    }
}