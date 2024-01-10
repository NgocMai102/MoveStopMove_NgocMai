using System.Collections;
using System.Collections.Generic;
using _Framework.StateMachine;
using _Game.Scripts.Character;
using UnityEngine;

public class StateMachine<T> where T: Character
{
    private IState<T> state;
    private T t;
    
    public void ChangeState(IState<T> state)
    {
        if(state == this.state)
            return;
        this.state?.OnExit(t);
        this.state = state;
        this.state?.OnEnter(t);
    }
    
    public void SetCharacter(T t)
    {
        this.t = t;
    }

    public void UpdateState()
    {
        state?.OnExecute(t);
    }
}
