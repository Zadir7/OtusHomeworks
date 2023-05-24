using UnityEngine;
using VContainer.Unity;

namespace ShootEmUp
{
    public sealed class LevelBackground : IFixedTickable
    {
        private readonly Transform backgroundTransform;

        private readonly float startPositionY;
        private readonly float endPositionY;
        private readonly float movingSpeedY;

        private readonly float positionX;
        private readonly float positionZ;

        private bool HasReachedEndPosition => this.backgroundTransform.position.y <= this.endPositionY;

        public LevelBackground(LevelBackgroundConfig levelBackgroundConfig, LevelBackgroundView view)
        {
            this.startPositionY = levelBackgroundConfig.startPositionY;
            this.endPositionY = levelBackgroundConfig.endPositionY;
            this.movingSpeedY = levelBackgroundConfig.speedY;
            this.backgroundTransform = view.transform;
            
            var position = this.backgroundTransform.position;
            this.positionX = position.x;
            this.positionZ = position.z;
        }

        void IFixedTickable.FixedTick()
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