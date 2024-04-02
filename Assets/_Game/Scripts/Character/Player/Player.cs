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
using _UI.Scripts;
using _UI.Scripts.Gameplay;
using _UI.Scripts.Shop.SkinShop;
using _UI.Scripts.UI;
using Unity.VisualScripting;
using UnityEngine;

namespace _Game.Scripts.Character.Player
{
    public class Player : Character
    {
        [Header("Player Properties")] 
        [SerializeField] private Rigidbody rb;

        [SerializeField] private PlayerSkin playerSkin;

        private Vector3 moveDirection;
        private bool startMove;
        public bool IsMoving => moveDirection != Vector3.zero;
        public bool CanUpdate => GameManager.Instance.IsState(GameState.Gameplay);
        public bool IsStartMove => startMove;

        private StateMachine<Player> currentState;
        
        private void Start()
        {
            OnInit();
        }
        
        private void Update()
        {
            if (!CanUpdate)
            {
                return;
            }
            GetInput();
            currentState.UpdateState();
        }

        public override void OnInit()
        {
            base.OnInit();
            InitState();
            playerSkin.OnInit();
            
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

        private void OnStartMove()
        {
            if (startMove == false)
            {
                startMove = true;
                UIManager.Instance.GetUI<UIGameplay>().HideTutorial();
            }
        }
        
        private void GetInput()
        {
            if (EventInput.InputManager.HasInput()) {
                OnStartMove();
                moveDirection.Set(EventInput.InputManager.HorizontalAxis, 0, EventInput.InputManager.VerticalAxis);
                moveDirection.Normalize();
            }
            else
            {
                moveDirection = Vector3.zero;
            }
        }
        
        public void Move()
        {
            rb.MovePosition(rb.position + moveDirection * moveSpeed * Time.deltaTime);
            TF.position = rb.position;
            if (IsMoving)
            {
                TF.forward = moveDirection;
            }
        }

        public override void StopMove()
        {
            base.StopMove();
            rb.velocity = Vector3.zero;
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
            startMove = false;

            ClearEnemyInRange();
        }

        public void Dance()
        {
            ChangeAnim(AnimType.DANCE);
        }
    }
    
}

