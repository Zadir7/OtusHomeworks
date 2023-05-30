using UnityEngine;
using VContainer.Unity;

namespace ShootEmUp
{
    public sealed class CharacterMoveController : IFixedTickable
    {
        private readonly HorizontalInputManager horizontalInputManager;
        private readonly MoveComponent moveComponent;

        public CharacterMoveController(HorizontalInputManager horizontalInputManager, CharacterView characterView)
        {
            this.horizontalInputManager = horizontalInputManager;
            this.moveComponent = characterView.GetComponent<MoveComponent>();
        }

        void IFixedTickable.FixedTick()
        {
            this.moveComponent.MoveByRigidbodyVelocity(new Vector2(this.horizontalInputManager.HorizontalInput, 0) * Time.fixedDeltaTime);
        }
    }
}