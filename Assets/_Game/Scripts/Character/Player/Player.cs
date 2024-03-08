using System;
using System.Collections;
using System.Collections.Generic;
using _Framework.StateMachine;
using _Game.Camera;
using _Game.Scripts.Character;
using _Game.Scripts.Manager;
using _Game.Scripts.Manager.Level;
using _Game.Utils;
using _Pattern.StateMachine.PlayerState;
using _UI.Scripts.Gameplay;
using UnityEngine;

namespace _Game.Scripts.Character.Player
{
    public class Player : Character
    {
        [Header("Player Properties")]
        [SerializeField] private CharacterController characterController;
        
        private Vector3 moveDirection;
        private bool startMove;
        public bool IsMoving => moveDirection != Vector3.zero;
        
        private StateMachine<Player> currentState;
        
        private void Start()
        {
            OnInit();
        }
        
        private void Update()
        {
            GetInput();
            currentState.UpdateState();
        }

        public override void OnInit()
        {
            base.OnInit();
          
           
            InitState();

            startMove = false;
            
            TF.position = Vector3.zero;
            moveDirection = Vector3.zero;
        }
    
        private void InitState()
        {
            if (currentState == null)
            {
                currentState = new StateMachine<Player>();
                currentState.SetOwner(this);
            }
            currentState.ChangeState(new PIdleState());
        }
    
        
        
        private void GetInput()
        {
            if (EventInput.InputManager.HasInput()) {
                moveDirection.Set(EventInput.InputManager.HorizontalAxis, 0, EventInput.InputManager.VerticalAxis);
                moveDirection.Normalize();
                if (startMove == false)
                {
                    startMove = true;
                    UIManager.Instance.GetUI<UIGameplay>().HideTutorial();
                }
            }
            else
            {
                moveDirection = Vector3.zero;
            }
        }
        
        public void Move()
        {
            characterController.Move(moveDirection * moveSpeed * Time.deltaTime);
            RotateTo(TF.position + moveDirection);
        }
    
        public void ChangeState(IState<Player> state)
        {
            currentState.ChangeState(state);
        }

        public override void OnHit()
        {
            base.OnHit();
            ChangeState(new PDeadState());
        }
        
        public override void SetSize(float size)
        {
            base.SetSize(size);
            CameraFollow.Instance.SetRateOffset((this.size - CharacterUtils.MIN_SIZE)/(CharacterUtils.MAX_SIZE - CharacterUtils.MIN_SIZE));
        }

        public void OnRevive()
        {
            ChangeState(new PIdleState());
            isDead = false;
            
            ClearEnemyInRange();
        }
    }
    
}

