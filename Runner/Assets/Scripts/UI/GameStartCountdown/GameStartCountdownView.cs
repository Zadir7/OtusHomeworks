using TMPro;
using UnityEngine;

namespace UI.GameStartCountdown
{
    public sealed class GameStartCountdownView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _text;

        public void UpdateText(string newNumber)
        {
            if (_text.text != newNumber) _text.text = newNumber;
        }

        public void Enable()
        {
            this.gameObject.SetActive(true);
        }

        public void Disable()
        {
            this.gameObject.SetActive(false);
        }
    }
}