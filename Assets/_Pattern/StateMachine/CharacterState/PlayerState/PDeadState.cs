using System.Collections;
using System.Collections.Generic;
using _Framework.StateMachine;
// using Game.Character.Animation;
using _Game.Scripts.Character.Player;
using _Pattern.StateMachine.CharacterState;
using _UI.Scripts.UI;
using UnityEngine;


namespace _Pattern.StateMachine.PlayerState
{
    public class PDeadState : DeadState<Player>
    {
        protected override void Despawn(Player player)
        {
            base.Despawn(player);
            GameManager.ChangeState(GameState.Revive);
        }
    }
}

