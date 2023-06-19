using System.Linq;
using Infrastructure;
using Unchangeable;
using UnityEngine;
using CharacterInfo = Unchangeable.CharacterInfo;

namespace UI.CharacterInfoPopup
{
    public sealed class CharacterInfoPopupPM : ICharacterInfoPopupPM
    {
        private readonly IUserInfoRepository _userInfoRepository;

        private UserInfo _userInfo;
        private PlayerLevel _playerLevel;
        private CharacterInfo _characterInfo;

        public CharacterInfoPopupPM(IUserInfoRepository userInfoRepository)
        {
            _userInfoRepository = userInfoRepository;
        }

        string ICharacterInfoPopupPM.GetUserName() => _userInfo.Name;
        string ICharacterInfoPopupPM.GetUserDescription() => _userInfo.Description;
        Sprite ICharacterInfoPopupPM.GetUserIcon() => _userInfo.Icon;
        
        bool ICharacterInfoPopupPM.GetIsButtonActive() => _playerLevel.CanLevelUp();
        string ICharacterInfoPopupPM.GetCurrentExperience() => _playerLevel.CurrentExperience.ToString();
        string ICharacterInfoPopupPM.GetRequiredExperience() => _playerLevel.RequiredExperience.ToString();

        public CharacterStatData[] GetCharacterStats()
        {
            return _characterInfo
                .GetStats()
                .Select(st => 
                    new CharacterStatData(st.Name, st.Value.ToString()))
                .ToArray();
        }

        public void OnLevelUpButtonClicked()
        {
            _playerLevel.LevelUp();
        }
        
        public void OnCloseButtonClicked()
        {
            _userInfo = null;
            _characterInfo = null;
            _playerLevel = null;
        }

        public void SetData(CharacterInfoPopupData popupData)
        {
            var user = _userInfoRepository.Get(popupData.UserId);
            if (user is null) throw new UserNotFoundException();
            
            _userInfo = user.UserInfo;
            _playerLevel = user.Level;
            _characterInfo = user.CharacterInfo;
        }
    }
}