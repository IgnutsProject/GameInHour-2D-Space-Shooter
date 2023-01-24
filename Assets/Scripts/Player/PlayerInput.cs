using UnityEngine;

namespace Player
{
    public class PlayerInput : MonoBehaviour
    {
        [SerializeField] private PlayerMovement playerMovement;

        private void Update()
        {
            float rotateFactor = Input.GetAxis("Horizontal");
        
            playerMovement.Rotate(rotateFactor);
        }
    }
}
