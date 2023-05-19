using System;
using VContainer.Unity;

namespace UI.PauseGameButton
{
    public sealed class PauseGameButtonListener : IStartable, IDisposable
    {
        private readonly PauseGameButtonView _view;

        public event Action ButtonPressed = () => { };

        public PauseGameButtonListener(PauseGameButtonView view)
        {
            _view = view;
        }

        public void Start()
        {
            _view.ButtonPressed += OnButtonPressed;
        }

        public void Dispose()
        {
            _view.ButtonPressed -= OnButtonPressed;
        }

        private void OnButtonPressed()
        {
            ButtonPressed.Invoke();
        }
    }
}