using UI.CharacterInfoPopup;
using UnityEngine;
using UnityEngine.UI;
using VContainer;

namespace UI
{
    public sealed class ShowPopupButton : MonoBehaviour
    {
        [field: SerializeField] public Button Button;
        
        private PopupManager _popupManager;
        private CharacterInfoPopupData _data;
        
        [Inject]
        public void Construct(PopupManager popupManager, CharacterInfoPopupData data)
        {
            _popupManager = popupManager;
            _data = data;
        }
        
        private void Awake()
        {
            Button.onClick.AddListener(ShowPopup);
        }

        private void ShowPopup()
        {
            _popupManager.ShowCharacterInfoPopup(_data);
        }
    }
}