using UnityEngine;
using VContainer.Unity;

namespace ShootEmUp
{
    public sealed class CharacterMoveController : IFixedTickable
    {
        private readonly InputManager inputManager;
        private readonly MoveComponent moveComponent;

        public CharacterMoveController(InputManager inputManager, CharacterView characterView)
        {
            this.inputManager = inputManager;
            this.moveComponent = characterView.GetComponent<MoveComponent>();
        }

        void IFixedTickable.FixedTick()
        {
            this.moveComponent.MoveByRigidbodyVelocity(new Vector2(this.inputManager.HorizontalInput, 0) * Time.fixedDeltaTime);
        }
    }
}