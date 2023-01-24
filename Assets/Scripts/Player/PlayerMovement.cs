using UnityEngine;

namespace Player
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private float speedRotation = 120f;

        public void Rotate(float rotateFactor)
        {
            transform.Rotate(Vector3.forward * rotateFactor * speedRotation * Time.deltaTime);
        }
    }
} 
