using UnityEngine;
using VContainer;

namespace UI.CharacterInfoPopup
{
    public sealed class CharacterInfoPopup : MonoBehaviour
    {
        
        
        private ICharacterInfoPopupPM _pm;
        
        [Inject]
        public void Construct(ICharacterInfoPopupPM pm)
        {
            _pm = pm;
        }
        
        public void Show()
        {
            
            
            this.gameObject.SetActive(true);
        }

        public void Hide()
        {
            
            
            this.gameObject.SetActive(false);
        }
    }
}