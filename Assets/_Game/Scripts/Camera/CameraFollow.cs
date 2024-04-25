using _Framework.Singleton;
using _Game.Scripts.Character.Player;
using UnityEngine;

namespace _Game.Camera
{
    public class CameraFollow : Singleton<CameraFollow>
    {
        
        public enum State
        {
            MainMenu = 0,
            Gameplay = 1,
            Shop = 2
        }
        
        [SerializeField] private Transform tf;
        [SerializeField] private float smoothSpeed = 5f;
        
        
        [Header("Offset")]
        [SerializeField] private Vector3 offset;
        [SerializeField] private Vector3 offsetMax;
        [SerializeField] private Vector3 offsetMin;
        
        [SerializeField] private Transform[] offsets;

   
        private Transform target;
        
        private Vector3 targetOffset;
        private Quaternion targetRotate;
        private State currentState;

        public UnityEngine.Camera Camera;

        private void Awake()
        {
            target = FindObjectOfType<Player>().transform;
            Camera = UnityEngine.Camera.main;
        }

        private void LateUpdate()
        {
            offset = Vector3.Lerp(offset, targetOffset, Time.deltaTime * smoothSpeed);
            tf.rotation = Quaternion.Lerp(tf.rotation, targetRotate, Time.deltaTime * smoothSpeed);
            tf.position = Vector3.Lerp(tf.position, target.position + targetOffset, Time.deltaTime * smoothSpeed);
        }

        public void OnReset()
        {
            SetRateOffset(0);
        }

        //Lerp
        public void SetRateOffset(float rate)
        {
            if (currentState == State.Gameplay)
            {
                targetOffset = Vector3.Lerp(offsetMin, offsetMax, rate);
            }
        }
        
        public void ChangeState(State state)
        {
            currentState = state;
            targetOffset = offsets[(int)state].localPosition;
            targetRotate = offsets[(int)state].localRotation;
        }
    }
}