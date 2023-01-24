using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Enemy
{
    public class AsteroidController : MonoBehaviour
    {
        [SerializeField] private AsteroidSpawner[] asteroidSpawners;
        [SerializeField] private float spawnRate = 3f;

        private void Start()
        {
            StartCoroutine(SpawnDelay());
        }

        private IEnumerator SpawnDelay()
        {
            while (true)
            {
                yield return new WaitForSeconds(spawnRate);
                asteroidSpawners[Random.Range(0, asteroidSpawners.Length)].Spawn();
            }
        }
    }
}