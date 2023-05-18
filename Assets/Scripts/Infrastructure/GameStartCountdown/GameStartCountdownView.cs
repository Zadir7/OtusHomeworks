using TMPro;
using UnityEngine;

namespace Infrastructure.GameStartCountdown
{
    public class GameStartCountdownView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _text;

        public void UpdateText(string newNumber)
        {
            if (_text.text != newNumber) _text.text = newNumber;
        }

        public void Enable()
        {
            this.enabled = true;
        }

        public void Disable()
        {
            this.enabled = false;
        }
    }
}