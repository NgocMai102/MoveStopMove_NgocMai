using _Framework.StateMachine;
using _Pattern.StateMachine.EnemyState;
using UnityEngine;

namespace _Game.Scripts.Character.Enemy
{
    public class Enemy : Character
    {
        [SerializeField] private UnityEngine.AI.NavMeshAgent navmeshAgent;
        [SerializeField] private GameObject circleIndicator;

        private StateMachine<Enemy> currentState;
        private Vector3 destination;
        
        public bool IsDestination => Vector3.Distance(TF.position, destination + (TF.position.y - destination.y) * Vector3.up) < 0.1f;

        private void Start()
        {
            OnInit();
        }

        private void Update()
        {
            currentState.UpdateState();
        }

        #region Init
        public override void OnInit()
        {
            base.OnInit();
            navmeshAgent.speed = moveSpeed;
            InitState();
            HideCircleIndicator();
        }
        
        private void InitState()
        {
            if (currentState == null)
            {
                currentState = new StateMachine<Enemy>();
            }
            currentState.SetOwner(this);
        }
        #endregion

        #region Movement
        public void MoveTo(Vector3 destination)
        {
            this.destination = destination;
            navmeshAgent.enabled = true;
            navmeshAgent.SetDestination(destination);
        }

        public override void StopMove()
        {
            base.StopMove();
            navmeshAgent.enabled = false;
        }
        

        #endregion
        
       

        #region Controller
        
        public void ChangeState(IState<Enemy> state)
        {
            currentState.ChangeState(state);
        }

        public override void OnHit()
        {
            base.OnHit();
            ChangeState(new EDeadState());
        }

        public override void OnDespawn()
        {
            base.OnDespawn();
            SimplePool.Despawn(this);
        }

        #endregion
        
        

        public void ShowCircleIndicator()
        {
            this.circleIndicator.SetActive(true);
        }
        public void HideCircleIndicator()
        {
            this.circleIndicator.SetActive(false);
        }
    }
}
