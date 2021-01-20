using System;
using UnityEngine;
using UnityEngine.UI;

namespace Samples
{
    public sealed class ButtonView : MonoBehaviour, IButtonView
    {
        public event Action Click;
        
        [SerializeField] private Button _button;

        private void Awake()
        {
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