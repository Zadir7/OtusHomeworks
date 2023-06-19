using UnityEngine;

namespace UI.CharacterInfoPopup
{
    public interface ICharacterInfoPopupPM
    {
        public string GetUserName();
        public string GetUserDescription();
        public Sprite GetUserIcon();


        public bool GetIsButtonActive();
        public string GetCurrentExperience();
        public string GetRequiredExperience();
        
        public CharacterStatData[] GetCharacterStats();

        public void OnLevelUpButtonClicked();
        public void OnCloseButtonClicked();
        
        void SetData(CharacterInfoPopupData popupData);
    }
}