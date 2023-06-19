using UI.CharacterInfoPopup;
using UnityEngine;

namespace UI
{
    public sealed class PopupManager
    {
        private readonly CharacterInfoPopup.CharacterInfoPopup _characterInfoPopup;
        private readonly ICharacterInfoPopupPM _characterInfoPopupPm;
        
        public void ShowCharacterInfoPopup(CharacterInfoPopupData popupData)
        {
            _characterInfoPopupPm.SetData(popupData);
            _characterInfoPopup.Show();
        }
    }
}