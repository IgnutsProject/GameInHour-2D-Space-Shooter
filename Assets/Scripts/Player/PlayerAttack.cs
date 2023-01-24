using System;
using System.Collections;
using Systems.GameScore;
using Unity.Mathematics;
using UnityEngine;

namespace Player
{
    public class PlayerAttack : MonoBehaviour
    {
        [SerializeField] private Projectile projectilePrefab;
        [SerializeField] private Transform spawnPoint;
        [SerializeField] private Transform directionPoint;
        [SerializeField] private float attackDelay = 1f;

        private void Start()
        {
            StartCoroutine(AttackDelay());
        }

        private void Attack()
        {
            Projectile projectile = Instantiate(
                projectilePrefab,
                spawnPoint.position,
                transform.rotation);

            projectile.OnCollision += collision =>
            {
                ScoreManager.Instance.Score++;
                Destroy(collision.gameObject);
                Destroy(projectile.gameObject);
            };
            
            projectile.Launch(directionPoint.position);
        }

        private IEnumerator AttackDelay()
        {
            while (true)
            {
                yield return new WaitForSeconds(attackDelay);
                Attack();
            }
        }
    }
}