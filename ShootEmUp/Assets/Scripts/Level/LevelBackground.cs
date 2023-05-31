using UnityEngine;

namespace ShootEmUp
{
    public sealed class LevelBackground : MonoBehaviour
    {
        [SerializeField] private LevelBackgroundConfig backgroundConfig;
        [SerializeField] private Transform backgroundTransform;

        private float startPositionY;
        private float endPositionY;
        private float movingSpeedY;

        private float positionX;
        private float positionZ;

        private bool HasReachedEndPosition => this.backgroundTransform.position.y <= this.endPositionY;

        public void Awake()
        {
            this.startPositionY = this.backgroundConfig.startPositionY;
            this.endPositionY = this.backgroundConfig.endPositionY;
            this.movingSpeedY = this.backgroundConfig.speedY;
            
            var position = this.backgroundTransform.position;
            this.positionX = position.x;
            this.positionZ = position.z;
        }

        private void FixedUpdate()
        {
            if (HasReachedEndPosition)
            {
                ResetPosition();
            }

            MoveBackground(Time.fixedDeltaTime);
        }

        private void ResetPosition()
        {
            this.backgroundTransform.position = new Vector3(
                this.positionX,
                this.startPositionY,
                this.positionZ
            );
        }

        private void MoveBackground(float deltaTime)
        {
            this.backgroundTransform.position -= new Vector3(
                this.positionX,
                this.movingSpeedY * deltaTime,
                this.positionZ
            );
        }
    }
}