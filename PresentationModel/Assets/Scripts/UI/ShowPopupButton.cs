using UnityEngine;
using UnityEngine.UI;
using VContainer;

namespace UI
{
    public sealed class ShowPopupButton : MonoBehaviour
    {
        [field: SerializeField] public Button Button;
        
        private PopupManager _popupManager;
        
        [Inject]
        public void Construct(PopupManager popupManager)
        {
            _popupManager = popupManager;
        }
        
        private void Awake()
        {
            Button.onClick.AddListener(_popupManager.ShowCharacterInfoPopup);
        }
    }
}