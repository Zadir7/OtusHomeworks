using UnityEngine;
using VContainer.Unity;

namespace ShootEmUp
{
    public sealed class GameManager : IStartable
    {
        public void FinishGame()
        {
            Debug.Log("Game over!");
            Time.timeScale = 0;
        }

        public void Start() 
        {
        }
    }
}