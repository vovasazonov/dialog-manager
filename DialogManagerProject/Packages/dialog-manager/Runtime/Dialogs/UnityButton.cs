using UnityEngine.UI;

namespace Dialogs
{
    internal sealed class UnityButton : IButton
    {
        public event ClickHandler Click;
        
        private readonly Button _button;

        public UnityButton(Button button)
        {
            _button = button;
            AddListener();
        }
        
        private void AddListener()
        {
            _button.onClick.AddListener(OnClick);
        }

        private void RemoveListener()
        {
            _button.onClick.RemoveListener(OnClick);
        }

        private void OnClick()
        {
            CallClick();
        }
        
        private void CallClick()
        {
            Click?.Invoke();
        }
    }
}