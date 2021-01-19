using UnityEngine;
using UnityEngine.UI;

namespace Dialogs
{
    [RequireComponent(typeof(Button))]
    public sealed class UnityDialogButton : MonoBehaviour, IDialogButton
    {
        public event ClickHandler Click;

        [SerializeField] private string _id;
        private Button _button;

        public string Id => _id;

        private void Awake()
        {
            _button = GetComponent<Button>();
            AddButtonListener();
        }

        private void AddButtonListener()
        {
            _button.onClick.AddListener(OnClick);
        }
        
        private void RemoveButtonListener()
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