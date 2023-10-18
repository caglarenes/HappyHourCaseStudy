using Fusion;
using System;
using System.Collections.Generic;

public class NetworkedStateMachine<T> : NetworkBehaviour where T : Enum
{
    public class StateHooks
    {
        public Action<NetworkedStateMachine<T>, T> OnEnter;
        public Action<NetworkedStateMachine<T>, T> OnExit;
        public Action<NetworkedStateMachine<T>> OnUpdate;
        public Action<NetworkedStateMachine<T>> OnRender;
    }

    [Networked] private byte InternalState { get; set; }

    public T State
    {
        get => (T)(object)InternalState;
        set => InternalState = (byte) (object)value;
    }

    private T _lastState;
    private Dictionary<T, StateHooks> _states = new();

    public StateHooks this[T state]
    {
        get
        {
            if (!_states.TryGetValue(state, out StateHooks hooks))
            {
                hooks = new StateHooks();
                _states[state] = hooks;
            }
            return hooks;
        }
    }

    public override void FixedUpdateNetwork()
    {
        if (!Runner.IsForward)
            return;

        if (!Equals(_lastState, State))
        {
            if (_states.TryGetValue(_lastState, out StateHooks oldHooks))
                oldHooks.OnExit?.Invoke(this, State);
            if (_states.TryGetValue(State, out StateHooks newHooks))
                newHooks.OnEnter?.Invoke(this, _lastState);
            _lastState = State;
        }

        if (_states.TryGetValue(State, out StateHooks hooks))
            hooks.OnUpdate?.Invoke(this);
    }

    public override void Render()
    {
        if (_states.TryGetValue(State, out StateHooks hooks))
            hooks.OnRender?.Invoke(this);
    }
}
