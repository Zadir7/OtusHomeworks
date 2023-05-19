using System;
using UnityEngine;
using UnityEngine.UI;

namespace Infrastructure.PauseGameButton
{
    public class PauseGameButtonView : MonoBehaviour
    {
        [SerializeField] private Button _pauseButton;

        public event Action ButtonPressed = () => { };

        private void Awake()
        {
            _pauseButton.onClick.AddListener(OnButtonClick);
        }

        private void OnButtonClick()
        {
            ButtonPressed.Invoke();
        }
    }
}