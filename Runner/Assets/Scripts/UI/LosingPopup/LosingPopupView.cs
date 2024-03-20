using UnityEngine;

namespace UI.LosingPopup
{
    public sealed class LosingPopupView : MonoBehaviour
    {
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