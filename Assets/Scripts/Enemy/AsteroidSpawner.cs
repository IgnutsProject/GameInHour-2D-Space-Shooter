using System;
using Common;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

namespace Enemy
{
    [Serializable]
    public struct Range
    {
        public float min;
        public float max;

        public static float GetRandomNumber(Range range)
        {
            return Random.Range(range.min, range.max);
        }
    }
    
    public class AsteroidSpawner : MonoBehaviour
    {
        [Header("Prefabs")]
        [SerializeField] private Asteroid asteroidPrefab;
        
        [Header("Spawn properties")]
        [SerializeField] private Transform beginSpawnPoint;
        [SerializeField] private Transform endSpawnPoint;
        
        [Header("Movement")]
        [SerializeField] private Range rangeVelocityX;
        [SerializeField] private Range rangeVelocityY;

        public void Spawn()
        {
            Vector2 position = GameMath.RandomVector(beginSpawnPoint.position, endSpawnPoint.position);
            Vector2 velocity = new Vector2(
                Range.GetRandomNumber(rangeVelocityX), 
                Range.GetRandomNumber(rangeVelocityY));
            
            Asteroid asteroid = Instantiate(asteroidPrefab, position, Quaternion.identity);
            asteroid.OnPlayerCollision += collision =>
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            };
            asteroid.Launch(velocity);
        }
    }
}