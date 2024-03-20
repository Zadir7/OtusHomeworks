using System;
using Gameplay.Obstacle;
using UnityEngine;

namespace Gameplay.Player
{
    public sealed class PlayerView : MonoBehaviour
    {
        public float PositionX => transform.position.x;
        
        public event Action Collided = () => { };
        
        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.GetComponent<ObstacleView>())
            {
                Collided.Invoke();
            }
        }

        public void MoveLeft()
        {
            transform.position += Vector3.left;
        }

        public void MoveRight()
        {
            transform.position += Vector3.right;
        }
    }
}