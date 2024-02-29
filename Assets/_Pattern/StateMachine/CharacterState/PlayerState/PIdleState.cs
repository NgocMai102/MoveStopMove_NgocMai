using System.Collections;
using System.Collections.Generic;
using _Framework.StateMachine;
// using Game.Character.Animation;
using _Game.Scripts.Character.Player;
using _Game.Utils;
using UnityEngine;

namespace _Pattern.StateMachine.PlayerState
{
    public class PIdleState : IState<Player>
    {
        public void OnEnter(Player player)
        {
            player.model.rotation = Quaternion.Euler(0, player.model.rotation.eulerAngles.y, 0);
            player.ChangeAnim(AnimType.IDLE);
            
        }

        public void OnExecute(Player player)
        {
            if (player.IsMoving)
            {
                player.ChangeState(new PRunState());
            }
            if (player.FoundCharacter && player.IsAttackable)
            {
                player.ChangeState(new PAttackState());
            }
        }

        public void OnExit(Player t)
        {
        
        }
    }
}

