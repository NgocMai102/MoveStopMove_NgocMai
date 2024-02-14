using System.Collections;
using System.Collections.Generic;
using _Framework.StateMachine;
// using Game.Character.Animation;
using _Game.Scripts.Character.Player;
using _Pattern.StateMachine.CharacterState;
using UnityEngine;


namespace _Pattern.StateMachine.PlayerState
{
    public class DeadState : DeadState<Player>
    {
        protected override void Despawn(Player player)
        {
            base.Despawn(player);
            //GameManager.ChangeState(GameState.Revive);
        }
    }
}

