using UnityEngine;
using UnityEngine.UI;

namespace Dialogs
{
    [RequireComponent(typeof(Button))]
    public sealed class UnityDialogButton : MonoBehaviour, IDialogButton
    {
        public event ClickHandler Click;

        [SerializeField] private string _id;
        [SerializeField] private Text _text;
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

        public void SetLabel(string text)
        {
            _text.text = text;
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