using System;
using _Framework.Event.Scripts;
using _Framework.StateMachine;
using _Game.Camera;
using _Game.Scripts.Manager;
using _Game.Scripts.Manager.Data;
using _Game.Scripts.Skin.Data;
using _Game.Utils;
using _Pattern.StateMachine.PlayerState;
using _UI.Scripts.Gameplay;
using _UI.Scripts.UI;
using UnityEngine;

namespace _Game.Scripts.Character.Player
{
    public class Player : Character
    {
        [Header("Player Properties")] 
        [SerializeField] private Rigidbody rb;
        [SerializeField] private SetSkinDataSO skinData;

        private Vector3 moveDirection;
        private bool startMove;
        private int coin;
        
        private StateMachine<Player> currentState;
        private Action<object> onCloseSkinShop;

        public PlayerData PlayerData => DataManager.Instance.PlayerData;
        public bool IsMoving => moveDirection != Vector3.zero;
        public bool CanUpdate => GameManager.Instance.IsState(GameState.Gameplay);
        public String MurderName => murder;
        public int Score => score;

        private void Awake()
        {
            currentState = new StateMachine<Player>();
            currentState.SetOwner(this);
        }
        
        private void Start()
        {
            OnInit();
        }

        private void RegisterEventSetSkin()
        {
            onCloseSkinShop = _ => SetCurrentSkin();
            this.RegisterListener(EventID.OnCloseSetSkin, onCloseSkinShop);
        }

        private void RemoveEventSetSkin()
        {
            this.RemoveListener(EventID.OnCloseSetSkin, onCloseSkinShop);
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
            SetName();
            SetCurrentSkin();
            RegisterEventSetSkin();
            CalculateCoin();
            
            startMove = false;
            TF.position = Vector3.zero;
            moveDirection = Vector3.zero;
            currentState.ChangeState(new PIdleState());
        }

        private void SetName()
        {
            name = PlayerProperties.NAME;
        }

        #region MovementManager
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
        #endregion

        public void ChangeState(IState<Player> state)
        {
            currentState.ChangeState(state);
        }

        public override void OnHit(String murder)
        {
            base.OnHit(murder);
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

        public void OnVictory()
        {
            characterSkin.ChangeAnim(AnimType.DANCE);
            score = 0;
        }

        public void OnLose()
        {
            score = 0;
            RemoveEventSetSkin();
        }
        

        #region Skin
        
        private void SetCurrentSkin()
        {
            int currentSetSkinId = PlayerData.GetIntData(KeyData.PlayerSetSkin);
            SetSkin((SetType) currentSetSkinId);
            Debug.Log(currentWeapon);
        }

        public void SetSkin(SetType setType)
        {
            if (characterSkin != null)
            {
                if (currentSkinType != setType)
                {
                    Destroy(characterSkin.gameObject);
                    characterSkin = Instantiate(skinData.GetSkin((int)setType), TF);
                }
            }
            else
            {
                characterSkin = Instantiate(skinData.GetSkin((int)setType), TF);
            }
            currentSkinType = setType;
            characterSkin.OnInit(this);
        }
        

        #endregion

        private void CalculateCoin()
        {
            int coin = PlayerData.GetIntData(KeyData.Coin);
            coin += score;
            PlayerData.SetIntData(KeyData.Coin, coin);
        }
        
        public void TripleCoin()
        {
            score *= 3;
            CalculateCoin();
        }
       
    }
    
}

