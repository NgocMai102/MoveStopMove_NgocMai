using System;
using System.Collections;
using System.Collections.Generic;
using _Framework.StateMachine;
using _Game.Camera;
using _Game.Scripts.Character;
using _Pattern.StateMachine.PlayerState;
using UnityEngine;

namespace _Game.Scripts.Character.Player
{
    public class Player : Character
    {
        [Header("Player Properties")]
        [SerializeField] private FloatingJoystick joystick;
        [SerializeField] private CharacterController characterController;
        
        private Vector3 moveDirection;
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

        protected override void OnInit()
        {
            base.OnInit();
            InitJoystick();
            InitCamera();
            InitState();

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
    
        private void InitJoystick()
        {
            if (joystick == null)
            {
                joystick = FindObjectOfType<FloatingJoystick>();
            }
        }

        private void InitCamera()
        {
            CameraFollow cameraFollow = FindObjectOfType<CameraFollow>();
            if (cameraFollow != null)
            {
                cameraFollow.SetTarget(TF);
            }
        }
        
        private void GetInput()
        {
            if (joystick == null)
                return; 
            if (Math.Abs(joystick.Horizontal) > 0.1f || Math.Abs(joystick.Vertical) > 0.1f)
            {
                moveDirection.Set(joystick.Horizontal, 0, joystick.Vertical);
                moveDirection.Normalize();
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
        
    }
    
}

