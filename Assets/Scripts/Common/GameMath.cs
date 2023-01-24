using UnityEngine;

namespace Common
{
    public static class GameMath
    {
        public static Vector2 RandomVector(Vector2 first, Vector2 second)
        {
            return new Vector2(
                Random.Range(first.x, second.x),
                Random.Range(first.y, second.y));
        }
    }
}