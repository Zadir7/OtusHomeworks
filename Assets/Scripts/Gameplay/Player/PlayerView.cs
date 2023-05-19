using System;
using Gameplay.Obstacle;
using UnityEngine;

namespace Gameplay.Player
{
    public sealed class PlayerView : MonoBehaviour
    {
        public event Action Collided = () => { };

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.GetComponent<ObstacleView>())
            {
                Collided.Invoke();
            }
        }
    }
}