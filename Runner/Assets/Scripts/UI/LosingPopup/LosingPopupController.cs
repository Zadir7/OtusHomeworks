using Infrastructure.GameEventListeners;
using VContainer.Unity;

namespace UI.LosingPopup
{
    public sealed class LosingPopupController : 
        IGameFinishListener, 
        IStartable
    {
        private readonly LosingPopupView _losingPopupView;

        public LosingPopupController(LosingPopupView losingPopupView)
        {
            _losingPopupView = losingPopupView;
        }
        
        public void Start()
        {
            _losingPopupView.Disable();
        }

        public void OnGameFinish()
        {
            _losingPopupView.Enable();
        }
    }
}