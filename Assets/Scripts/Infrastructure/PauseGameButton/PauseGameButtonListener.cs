using System;
using VContainer.Unity;

namespace Infrastructure.PauseGameButton
{
    public class PauseGameButtonListener : IStartable, IDisposable
    {
        private readonly PauseGameButtonView _view;

        public event Action ButtonPressed = () => { };

        public PauseGameButtonListener(PauseGameButtonView view)
        {
            _view = view;
            _view.ButtonPressed += OnButtonPressed;
        }

        public void Start()
        {
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