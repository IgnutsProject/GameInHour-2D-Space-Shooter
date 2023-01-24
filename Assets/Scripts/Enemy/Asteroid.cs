using System;
using Player;
using UnityEngine;

namespace Enemy
{
    public class Asteroid : MonoBehaviour
    {
        [SerializeField] private float speedMovement = 5f;
        [SerializeField] private float speedRotation = 45f;

        private Rigidbody2D _rigidbody;
        private Vector2 _currentVelocity;   
        
        public delegate void PlayerCollision(Collision2D collision);
        public event PlayerCollision OnPlayerCollision;
        
        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            transform.Rotate(Vector3.forward * speedRotation * Time.deltaTime);
        }

        private void FixedUpdate()
        {
            _rigidbody.velocity = _currentVelocity * speedMovement;
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.transform.GetComponent<PlayerMovement>() == false) return;
            
            OnPlayerCollision?.Invoke(other);
        }

        public void Launch(Vector2 velocity)
        {
            _currentVelocity = velocity;
        }
    }
}
