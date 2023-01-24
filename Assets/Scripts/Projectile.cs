using System;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float speedMovement = 5;
    [SerializeField] private Transform directionPoint;

    private Rigidbody2D _rigidbody;

    public delegate void Collision(Collision2D collision);
    public event Collision OnCollision;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        OnCollision?.Invoke(other);
    }

    public void Launch(Vector3 directionPosition)
    {
        directionPoint.position = directionPosition;
    }

    private void Move()
    {
        Vector3 newPosition = Vector3.MoveTowards(
            _rigidbody.position,
            directionPoint.position,
            speedMovement * Time.deltaTime);
            
        _rigidbody.MovePosition(newPosition);
    }
}