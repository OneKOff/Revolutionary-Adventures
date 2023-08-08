using System;
using UnityEngine;
using Utility;

namespace Player
{
    public class PlayerMovementController : MonoBehaviour
    {
        [SerializeField] private Rigidbody rb;
        [SerializeField] private float speed = 5f;
        [SerializeField] private float jumpForce = 50f;
        [Header("GroundedCheck")]
        [SerializeField] private Transform feetPos;
        [SerializeField] private float feetDetectionRadius = 0.3f;
        [SerializeField] private LayerMask groundLayerMask;

        private bool _isGrounded;
        private Vector3 _feetOffset;
        private RaycastHit[] _detectedRaycasts;

        private void Awake()
        {
            Init();
        }

        private void Init()
        {
            _isGrounded = false;
            _feetOffset = feetPos.position - transform.position;
            _detectedRaycasts = new RaycastHit[10];
        }

        private void Update()
        {
            rb.velocity = new Vector3(Input.GetAxis("Horizontal") * speed, rb.velocity.y, 0);

            _isGrounded = Physics.SphereCastNonAlloc(transform.position + _feetOffset,
                feetDetectionRadius, Vector3.down, _detectedRaycasts, 0, groundLayerMask) > 0;

            if (_isGrounded && Input.GetKeyDown(KeyCode.Space))
            {
                rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
                _isGrounded = false;
            }
        }

        private void OnDrawGizmos()
        {
            if (_isGrounded) Gizmos.color = Color.green;
            else Gizmos.color = Color.red;
            
            Gizmos.DrawSphere(transform.position + _feetOffset, feetDetectionRadius);
        }
    }
}

