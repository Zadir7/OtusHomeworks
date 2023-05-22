using System;
using VContainer.Unity;

namespace ShootEmUp
{
    public class FinishGameController : IStartable, IDisposable
    {
        private readonly GameManager gameManager;
        private readonly CharacterController characterController;

        public FinishGameController(GameManager gameManager, CharacterController characterController)
        {
            this.gameManager = gameManager;
            this.characterController = characterController;
        }
        
        public void Start()
        {
            this.characterController.OnPlayerDeath += FinishGame;
        }

        public void Dispose()
        {
            this.characterController.OnPlayerDeath -= FinishGame;
        }

        private void FinishGame()
        {
            this.gameManager.FinishGame();
        }
    }
}