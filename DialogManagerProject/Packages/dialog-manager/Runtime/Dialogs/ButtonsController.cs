using System;
using System.Collections.Generic;

namespace Dialogs
{
    internal sealed class ButtonsController : IButtonsController
    {
        private readonly IDictionary<string, IButton> _buttons = new Dictionary<string, IButton>();
        private readonly IDictionary<string, Action> _buttonCallbacks = new Dictionary<string, Action>();
        
        public ButtonsController(IEnumerable<IButton> buttons)
        {
            InitializeButtons(buttons);
        }
        
        private void InitializeButtons(IEnumerable<IButton> buttons)
        {
            foreach (var dialogButton in buttons)
            {
                _buttons[dialogButton.Id] = dialogButton;
            }
        }
        
        private void SetButtonCallback(string id, Action callback)
        {
            _buttonCallbacks.Add(id, callback);
            AddButtonListener(_buttons[id], callback);
        }

        public void SetButtonsCallbacks(IDictionary<string, Action> callbacks)
        {
            ResetButtonsCallbacks();
            
            foreach (var id in callbacks.Keys)
            {
                SetButtonCallback(id, callbacks[id]);
            }
        }

        private void ResetButtonsCallbacks()
        {
            foreach (var id in _buttonCallbacks.Keys)
            {
                RemoveButtonListener(_buttons[id], _buttonCallbacks[id]);
            }

            _buttonCallbacks.Clear();
        }

        private void AddButtonListener(IButton button, Action callback)
        {
            button.Click += callback.Invoke;
        }
        
        private void RemoveButtonListener(IButton button, Action callback)
        {
            button.Click -= callback.Invoke;
        }
        
        public void SetButtonsTexts(IDictionary<string, string> texts)
        {
            foreach (var id in _buttons.Keys)
            {
                _buttons[id].SetText(texts[id]);
            }
        }
    }
}