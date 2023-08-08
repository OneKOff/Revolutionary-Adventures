using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

namespace Camera
{
    [RequireComponent(typeof(Rigidbody))]
    public class CameraController : MonoBehaviour
    {
        [SerializeField] private Transform target;
        
        [Header("Speed")]
        [SerializeField] private float minSpeed;
        [SerializeField] private float maxSpeed;
        [SerializeField] private float rangeForMaxSpeed;
        
        private Rigidbody _rb;
        
        private void Awake()
        {
            Init();
        }
    
        private void Init()
        {
            TryGetComponent(out _rb);
        }
    
        private void Update()
        {
            var targetPos = target.position;
            var cameraPos = transform.position;
            var sqrRange = (targetPos - cameraPos).sqrMagnitude;
            
            _rb.velocity = (targetPos - cameraPos).normalized * 
                           Mathf.Lerp(minSpeed, maxSpeed, sqrRange / rangeForMaxSpeed * rangeForMaxSpeed);
        }
    }

}
