// using System.Collections;
// using System.Collections.Generic;
// using _Framework.StateMachine;
// using Game.Character.Animation;
// using _Game.Scripts.Character.Player;
// using UnityEngine;
//
// namespace _Pattern.StateMachine.PlayerState
// {
//     public class RunState : IState<Player>
//     {
//         public void OnEnter(Player player)
//         {
//             player.ChangeAnim(AnimType.RUN);
//         }
//
//         public void OnExecute(Player player)
//         {
//             if (!player.IsMoving)
//             {
//                 player.ChangeState(new IdleState());
//             }
//             player.Move();
//         }
//
//         public void OnExit(Player player)
//         {
//             
//         }
//     }
// }
//
